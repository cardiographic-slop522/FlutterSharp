using System.Buffers;
using System.Net.WebSockets;
using FlutterSharp.Core.Protocol;
using MessagePack;
using Microsoft.Extensions.Logging;

namespace FlutterSharp.Core.Transport;

/// <summary>
/// WebSocket-based implementation of <see cref="IConnection"/>.
/// Provides reliable bi-directional communication with Flutter client using MessagePack over WebSocket.
/// </summary>
public sealed class WebSocketConnection : IConnection
{
    private readonly WebSocket _webSocket;
    private readonly ILogger<WebSocketConnection>? _logger;
    private readonly CancellationTokenSource _disposalTokenSource = new();
    private readonly SemaphoreSlim _sendLock = new(1, 1);
    private Task? _receiveTask;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="WebSocketConnection"/> class.
    /// </summary>
    /// <param name="webSocket">The underlying WebSocket.</param>
    /// <param name="connectionId">The unique connection identifier.</param>
    /// <param name="logger">Optional logger for diagnostics.</param>
    public WebSocketConnection(
        WebSocket webSocket,
        string? connectionId = null,
        ILogger<WebSocketConnection>? logger = null)
    {
        _webSocket = webSocket ?? throw new ArgumentNullException(nameof(webSocket));
        _logger = logger;
        ConnectionId = connectionId ?? Guid.NewGuid().ToString();

        // Start receiving messages
        _receiveTask = ReceiveLoopAsync(_disposalTokenSource.Token);
    }

    /// <inheritdoc/>
    public string ConnectionId { get; }

    /// <inheritdoc/>
    public bool IsConnected => _webSocket.State == WebSocketState.Open;

    /// <inheritdoc/>
    public event EventHandler<MessageReceivedEventArgs>? MessageReceived;

    /// <inheritdoc/>
    public event EventHandler<ConnectionClosedEventArgs>? ConnectionClosed;

    /// <inheritdoc/>
    public event EventHandler<ConnectionErrorEventArgs>? ConnectionError;

    /// <inheritdoc/>
    public async Task SendAsync(Message message, CancellationToken cancellationToken = default)
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(WebSocketConnection));
        }

        if (!IsConnected)
        {
            throw new InvalidOperationException("Connection is not open.");
        }

        try
        {
            // Serialize message to MessagePack
            var data = MessagePackSerializer.Serialize(message, FlutterSharpMessagePackOptions.Standard);

            await SendBinaryAsync(data, cancellationToken);

            _logger?.LogTrace("Sent message: {MessageType} ({Size} bytes)", message.GetType().Name, data.Length);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Failed to send message: {MessageType}", message.GetType().Name);
            RaiseConnectionError(ex, isFatal: false);
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task SendBinaryAsync(byte[] data, CancellationToken cancellationToken = default)
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(WebSocketConnection));
        }

        if (!IsConnected)
        {
            throw new InvalidOperationException("Connection is not open.");
        }

        // Use lock to ensure thread-safe sending
        await _sendLock.WaitAsync(cancellationToken);
        try
        {
            await _webSocket.SendAsync(
                new ArraySegment<byte>(data),
                WebSocketMessageType.Binary,
                endOfMessage: true,
                cancellationToken);
        }
        finally
        {
            _sendLock.Release();
        }
    }

    /// <inheritdoc/>
    public async Task CloseAsync(CancellationToken cancellationToken = default)
    {
        if (_disposed || _webSocket.State == WebSocketState.Closed)
        {
            return;
        }

        try
        {
            _logger?.LogInformation("Closing WebSocket connection: {ConnectionId}", ConnectionId);

            await _webSocket.CloseAsync(
                WebSocketCloseStatus.NormalClosure,
                "Connection closed by server",
                cancellationToken);
        }
        catch (Exception ex)
        {
            _logger?.LogWarning(ex, "Error while closing WebSocket connection: {ConnectionId}", ConnectionId);
        }
    }

    /// <inheritdoc/>
    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;

        try
        {
            // Signal cancellation
            _disposalTokenSource.Cancel();

            // Close WebSocket
            await CloseAsync();

            // Wait for receive task to complete
            if (_receiveTask != null)
            {
                await _receiveTask.ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            _logger?.LogWarning(ex, "Error during WebSocketConnection disposal");
        }
        finally
        {
            _webSocket.Dispose();
            _disposalTokenSource.Dispose();
            _sendLock.Dispose();
        }
    }

    private async Task ReceiveLoopAsync(CancellationToken cancellationToken)
    {
        var buffer = ArrayPool<byte>.Shared.Rent(1024 * 16); // 16KB buffer
        var messageBuffer = new MemoryStream();

        try
        {
            _logger?.LogInformation("Started receive loop for connection: {ConnectionId}", ConnectionId);

            while (!cancellationToken.IsCancellationRequested && IsConnected)
            {
                try
                {
                    messageBuffer.SetLength(0); // Reset buffer

                    WebSocketReceiveResult result;
                    do
                    {
                        result = await _webSocket.ReceiveAsync(
                            new ArraySegment<byte>(buffer),
                            cancellationToken);

                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            _logger?.LogInformation(
                                "Received close message: {Status} - {Description}",
                                result.CloseStatus,
                                result.CloseStatusDescription);

                            RaiseConnectionClosed(
                                result.CloseStatusDescription,
                                initiatedByClient: true,
                                statusCode: (int?)result.CloseStatus);

                            return;
                        }

                        messageBuffer.Write(buffer, 0, result.Count);
                    }
                    while (!result.EndOfMessage);

                    // Process complete message
                    if (messageBuffer.Length > 0)
                    {
                        await ProcessReceivedMessageAsync(messageBuffer.ToArray(), cancellationToken);
                    }
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    // Expected during shutdown
                    break;
                }
                catch (WebSocketException ex) when (ex.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
                {
                    _logger?.LogWarning("WebSocket connection closed prematurely: {ConnectionId}", ConnectionId);
                    RaiseConnectionClosed("Connection closed prematurely", initiatedByClient: true, statusCode: null);
                    break;
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, "Error in receive loop for connection: {ConnectionId}", ConnectionId);
                    RaiseConnectionError(ex, isFatal: true);
                    break;
                }
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
            messageBuffer.Dispose();
            _logger?.LogInformation("Receive loop ended for connection: {ConnectionId}", ConnectionId);
        }
    }

    private async Task ProcessReceivedMessageAsync(byte[] data, CancellationToken cancellationToken)
    {
        try
        {
            // Deserialize MessagePack message
            var message = MessagePackSerializer.Deserialize<Message>(
                data,
                FlutterSharpMessagePackOptions.Standard,
                cancellationToken);

            _logger?.LogTrace(
                "Received message: {MessageType} ({Size} bytes)",
                message.GetType().Name,
                data.Length);

            // Raise event
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs
            {
                Message = message,
                RawData = data
            });
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Failed to deserialize received message ({Size} bytes)", data.Length);
            RaiseConnectionError(ex, isFatal: false);
        }
    }

    private void RaiseConnectionClosed(string? reason, bool initiatedByClient, int? statusCode)
    {
        try
        {
            ConnectionClosed?.Invoke(this, new ConnectionClosedEventArgs
            {
                Reason = reason,
                InitiatedByClient = initiatedByClient,
                StatusCode = statusCode
            });
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error in ConnectionClosed event handler");
        }
    }

    private void RaiseConnectionError(Exception exception, bool isFatal)
    {
        try
        {
            ConnectionError?.Invoke(this, new ConnectionErrorEventArgs
            {
                Exception = exception,
                IsFatal = isFatal
            });
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error in ConnectionError event handler");
        }
    }
}
