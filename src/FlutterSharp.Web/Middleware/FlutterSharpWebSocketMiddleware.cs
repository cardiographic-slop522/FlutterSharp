using System.Net.WebSockets;
using FlutterSharp.Core.Session;
using FlutterSharp.Core.Transport;
using MessagePack;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FlutterSharp.Web.Middleware;

/// <summary>
/// ASP.NET Core middleware for handling FlutterSharp WebSocket connections.
/// Manages WebSocket upgrades and delegates connection handling to the SessionManager.
/// </summary>
public class FlutterSharpWebSocketMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<FlutterSharpWebSocketMiddleware> _logger;
    private readonly SessionManager _sessionManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="FlutterSharpWebSocketMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="logger">The logger instance.</param>
    /// <param name="sessionManager">The session manager for handling connections.</param>
    public FlutterSharpWebSocketMiddleware(
        RequestDelegate next,
        ILogger<FlutterSharpWebSocketMiddleware> logger,
        SessionManager sessionManager)
    {
        _next = next;
        _logger = logger;
        _sessionManager = sessionManager;
    }

    /// <summary>
    /// Invokes the middleware to handle WebSocket requests.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/ws" && context.WebSockets.IsWebSocketRequest)
        {
            _logger.LogInformation("WebSocket connection request received from {RemoteIp}",
                context.Connection.RemoteIpAddress);

            using var webSocket = await context.WebSockets.AcceptWebSocketAsync();

            _logger.LogInformation("WebSocket connection established");

            // Create a WebSocketConnection wrapper
            var connection = new AspNetCoreWebSocketConnection(webSocket, _logger);

            try
            {
                // Create a new session for this connection
                var sessionId = Guid.NewGuid().ToString();
                var session = new FlutterSharp.Core.Session.Session(sessionId, connection);

                // Add session to SessionManager
                _sessionManager.AddSession(session);

                _logger.LogInformation("Session created: {SessionId}", session.SessionId);

                // Keep connection alive until it closes
                while (connection.IsConnected && !context.RequestAborted.IsCancellationRequested)
                {
                    await Task.Delay(100, context.RequestAborted);
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("WebSocket connection cancelled");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error handling WebSocket connection");
            }
            finally
            {
                _logger.LogInformation("WebSocket connection closed");
            }
        }
        else
        {
            await _next(context);
        }
    }
}

/// <summary>
/// Wrapper for ASP.NET Core WebSocket to implement IConnection interface.
/// </summary>
internal class AspNetCoreWebSocketConnection : IConnection
{
    private readonly WebSocket _webSocket;
    private readonly ILogger _logger;
    private readonly string _connectionId;

    public AspNetCoreWebSocketConnection(WebSocket webSocket, ILogger logger)
    {
        _webSocket = webSocket;
        _logger = logger;
        _connectionId = Guid.NewGuid().ToString();
    }

    public string ConnectionId => _connectionId;

    public bool IsConnected => _webSocket.State == WebSocketState.Open;

    public event EventHandler<MessageReceivedEventArgs>? MessageReceived;
    public event EventHandler<ConnectionClosedEventArgs>? ConnectionClosed;
    public event EventHandler<ConnectionErrorEventArgs>? ConnectionError;

    public async Task SendAsync(FlutterSharp.Core.Protocol.Message message, CancellationToken cancellationToken = default)
    {
        // Serialize message to MessagePack
        var data = MessagePackSerializer.Serialize(message);
        await SendBinaryAsync(data, cancellationToken);
    }

    public async Task SendBinaryAsync(byte[] data, CancellationToken cancellationToken = default)
    {
        if (_webSocket.State == WebSocketState.Open)
        {
            await _webSocket.SendAsync(
                new ArraySegment<byte>(data),
                WebSocketMessageType.Binary,
                endOfMessage: true,
                cancellationToken);
        }
    }

    public async Task CloseAsync(CancellationToken cancellationToken = default)
    {
        if (_webSocket.State == WebSocketState.Open)
        {
            await _webSocket.CloseAsync(
                WebSocketCloseStatus.NormalClosure,
                "Connection closed by server",
                cancellationToken);
        }
    }

    public async ValueTask DisposeAsync()
    {
        await CloseAsync();
        _webSocket.Dispose();
    }
}
