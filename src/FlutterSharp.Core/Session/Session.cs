using System.Collections.Concurrent;
using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Protocol;
using FlutterSharp.Core.Transport;
using Microsoft.Extensions.Logging;

namespace FlutterSharp.Core.Session;

/// <summary>
/// Represents a session between the C# backend and a Flutter client.
/// Manages the control tree, event routing, and communication for a single client connection.
/// </summary>
public sealed class Session : IAsyncDisposable
{
    private readonly IConnection _connection;
    private readonly ILogger<Session>? _logger;
    private readonly ConcurrentDictionary<string, WeakReference<BaseControl>> _controlIndex = new();
    private readonly ConcurrentDictionary<string, object?> _sessionData = new();
    private BaseControl? _rootControl;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="Session"/> class.
    /// </summary>
    /// <param name="sessionId">The unique session identifier.</param>
    /// <param name="connection">The connection to the Flutter client.</param>
    /// <param name="logger">Optional logger for diagnostics.</param>
    public Session(string sessionId, IConnection connection, ILogger<Session>? logger = null)
    {
        SessionId = sessionId ?? throw new ArgumentNullException(nameof(sessionId));
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _logger = logger;

        // Subscribe to connection events
        _connection.MessageReceived += OnMessageReceived;
        _connection.ConnectionClosed += OnConnectionClosed;
        _connection.ConnectionError += OnConnectionError;

        _logger?.LogInformation("Session created: {SessionId}", SessionId);
    }

    /// <summary>
    /// Gets the unique session identifier.
    /// </summary>
    public string SessionId { get; }

    /// <summary>
    /// Gets a value indicating whether the session is currently connected.
    /// </summary>
    public bool IsConnected => _connection.IsConnected;

    /// <summary>
    /// Gets or sets the root control of this session's control tree.
    /// </summary>
    public BaseControl? RootControl
    {
        get => _rootControl;
        set
        {
            if (_rootControl != null)
            {
                UnindexControl(_rootControl);
                _rootControl.Unmount();
            }

            _rootControl = value;

            if (_rootControl != null)
            {
                IndexControl(_rootControl);
                _rootControl.Mount();
            }
        }
    }

    /// <summary>
    /// Gets the session-specific data storage.
    /// Use this to store arbitrary data associated with the session.
    /// </summary>
    public ConcurrentDictionary<string, object?> Data => _sessionData;

    /// <summary>
    /// Event raised when a control event is received from the client.
    /// </summary>
    public event EventHandler<ControlEventReceivedEventArgs>? ControlEventReceived;

    /// <summary>
    /// Event raised when the session is disconnected.
    /// </summary>
    public event EventHandler? Disconnected;

    /// <summary>
    /// Retrieves a control by its ID.
    /// </summary>
    /// <param name="controlId">The control ID.</param>
    /// <returns>The control, or null if not found or garbage collected.</returns>
    public BaseControl? GetControl(string controlId)
    {
        if (_controlIndex.TryGetValue(controlId, out var weakRef) && weakRef.TryGetTarget(out var control))
        {
            return control;
        }

        return null;
    }

    /// <summary>
    /// Sends a message to the Flutter client.
    /// </summary>
    /// <param name="message">The message to send.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task SendMessageAsync(Message message, CancellationToken cancellationToken = default)
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(Session));
        }

        await _connection.SendAsync(message, cancellationToken);
    }

    /// <summary>
    /// Sends a patch to update the control tree.
    /// </summary>
    /// <param name="patch">The patch operations to apply.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task SendPatchAsync(List<PatchOperation> patch, CancellationToken cancellationToken = default)
    {
        var message = new PatchControlMessage
        {
            Action = ClientAction.PatchControl,
            Patch = patch
        };

        await SendMessageAsync(message, cancellationToken);
    }

    /// <summary>
    /// Closes the session and disposes resources.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;

        _logger?.LogInformation("Disposing session: {SessionId}", SessionId);

        // Unsubscribe from events
        _connection.MessageReceived -= OnMessageReceived;
        _connection.ConnectionClosed -= OnConnectionClosed;
        _connection.ConnectionError -= OnConnectionError;

        // Clean up control tree
        if (_rootControl != null)
        {
            _rootControl.Unmount();
            UnindexControl(_rootControl);
        }

        // Close connection
        await _connection.DisposeAsync();

        _controlIndex.Clear();
        _sessionData.Clear();
    }

    /// <summary>
    /// Indexes a control and all its children for quick lookup.
    /// Uses weak references to allow garbage collection.
    /// </summary>
    private void IndexControl(BaseControl control)
    {
        _controlIndex[control.Id] = new WeakReference<BaseControl>(control);

        foreach (var child in control.Children)
        {
            IndexControl(child);
        }
    }

    /// <summary>
    /// Removes a control and all its children from the index.
    /// </summary>
    private void UnindexControl(BaseControl control)
    {
        _controlIndex.TryRemove(control.Id, out _);

        foreach (var child in control.Children)
        {
            UnindexControl(child);
        }
    }

    private void OnMessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        try
        {
            switch (e.Message.Action)
            {
                case ClientAction.ControlEvent:
                    HandleControlEvent(e.Message as ControlEventMessage);
                    break;

                case ClientAction.InvokeMethod:
                    HandleInvokeMethod(e.Message as InvokeMethodMessage);
                    break;

                case ClientAction.UpdateControlProps:
                    HandleUpdateControlProps(e.Message as UpdateControlPropsMessage);
                    break;

                case ClientAction.SessionCrashed:
                    HandleSessionCrashed(e.Message as SessionCrashedMessage);
                    break;

                default:
                    _logger?.LogWarning("Unhandled message action: {Action}", e.Message.Action);
                    break;
            }
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error handling message: {Action}", e.Message.Action);
        }
    }

    private void HandleControlEvent(ControlEventMessage? message)
    {
        if (message == null)
        {
            return;
        }

        _logger?.LogDebug("Control event: {ControlId}.{EventName}", message.ControlId, message.EventName);

        var control = GetControl(message.ControlId);
        if (control is Control visualControl)
        {
            visualControl.HandleEvent(message.EventName, message.Data);
        }

        // Raise event for custom handling
        ControlEventReceived?.Invoke(this, new ControlEventReceivedEventArgs
        {
            ControlId = message.ControlId,
            EventName = message.EventName,
            Data = message.Data
        });
    }

    private void HandleInvokeMethod(InvokeMethodMessage? message)
    {
        if (message == null)
        {
            return;
        }

        _logger?.LogDebug("Method invocation: {ControlId}.{MethodName}", message.ControlId, message.MethodName);

        // TODO: Implement method invocation via reflection or source generators
        // For now, log that this needs implementation
        _logger?.LogWarning("Method invocation not yet implemented: {ControlId}.{MethodName}",
            message.ControlId, message.MethodName);
    }

    private void HandleUpdateControlProps(UpdateControlPropsMessage? message)
    {
        if (message == null)
        {
            return;
        }

        _logger?.LogDebug("Update control props: {ControlId}", message.ControlId);

        // This is typically sent by the client to update server-side state
        // Implementation depends on specific use cases
    }

    private void HandleSessionCrashed(SessionCrashedMessage? message)
    {
        if (message == null)
        {
            return;
        }

        _logger?.LogError("Session crashed: {Error}\n{StackTrace}", message.Error, message.StackTrace);
    }

    private void OnConnectionClosed(object? sender, ConnectionClosedEventArgs e)
    {
        _logger?.LogInformation("Connection closed: {Reason}", e.Reason);
        Disconnected?.Invoke(this, EventArgs.Empty);
    }

    private void OnConnectionError(object? sender, ConnectionErrorEventArgs e)
    {
        _logger?.LogError(e.Exception, "Connection error (Fatal: {IsFatal})", e.IsFatal);

        if (e.IsFatal)
        {
            Disconnected?.Invoke(this, EventArgs.Empty);
        }
    }
}

/// <summary>
/// Event arguments for when a control event is received.
/// </summary>
public sealed class ControlEventReceivedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the ID of the control that fired the event.
    /// </summary>
    public required string ControlId { get; init; }

    /// <summary>
    /// Gets the name of the event.
    /// </summary>
    public required string EventName { get; init; }

    /// <summary>
    /// Gets the event data, if any.
    /// </summary>
    public Dictionary<string, object>? Data { get; init; }
}
