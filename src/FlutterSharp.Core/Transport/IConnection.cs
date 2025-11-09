using FlutterSharp.Core.Protocol;

namespace FlutterSharp.Core.Transport;

/// <summary>
/// Represents a connection to a Flutter client.
/// Abstracts the underlying transport mechanism (WebSocket, TCP, etc.).
/// </summary>
public interface IConnection : IAsyncDisposable
{
    /// <summary>
    /// Gets the unique identifier for this connection.
    /// </summary>
    string ConnectionId { get; }

    /// <summary>
    /// Gets a value indicating whether the connection is currently open.
    /// </summary>
    bool IsConnected { get; }

    /// <summary>
    /// Event raised when a message is received from the client.
    /// </summary>
    event EventHandler<MessageReceivedEventArgs>? MessageReceived;

    /// <summary>
    /// Event raised when the connection is closed.
    /// </summary>
    event EventHandler<ConnectionClosedEventArgs>? ConnectionClosed;

    /// <summary>
    /// Event raised when an error occurs on the connection.
    /// </summary>
    event EventHandler<ConnectionErrorEventArgs>? ConnectionError;

    /// <summary>
    /// Sends a message to the client asynchronously.
    /// </summary>
    /// <param name="message">The message to send.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SendAsync(Message message, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends raw binary data to the client asynchronously.
    /// </summary>
    /// <param name="data">The data to send.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SendBinaryAsync(byte[] data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Closes the connection asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CloseAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// Event arguments for when a message is received.
/// </summary>
public sealed class MessageReceivedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the received message.
    /// </summary>
    public required Message Message { get; init; }

    /// <summary>
    /// Gets the raw binary data of the message.
    /// </summary>
    public byte[]? RawData { get; init; }
}

/// <summary>
/// Event arguments for when a connection is closed.
/// </summary>
public sealed class ConnectionClosedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the reason for the connection closure.
    /// </summary>
    public string? Reason { get; init; }

    /// <summary>
    /// Gets a value indicating whether the closure was initiated by the client.
    /// </summary>
    public bool InitiatedByClient { get; init; }

    /// <summary>
    /// Gets the close status code if available.
    /// </summary>
    public int? StatusCode { get; init; }
}

/// <summary>
/// Event arguments for when a connection error occurs.
/// </summary>
public sealed class ConnectionErrorEventArgs : EventArgs
{
    /// <summary>
    /// Gets the exception that occurred.
    /// </summary>
    public required Exception Exception { get; init; }

    /// <summary>
    /// Gets a value indicating whether the error is fatal and the connection should be closed.
    /// </summary>
    public bool IsFatal { get; init; }
}
