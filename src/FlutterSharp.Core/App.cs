using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Patching;
using FlutterSharp.Core.Protocol;
using FlutterSharp.Core.Session;
using FlutterSharp.Core.Transport;
using Microsoft.Extensions.Logging;

namespace FlutterSharp.Core;

/// <summary>
/// Represents a FlutterSharp application.
/// Main entry point for creating and running Flutter-powered applications with C# backend.
/// </summary>
public sealed class App : IAsyncDisposable
{
    private readonly Func<Page> _pageBuilder;
    private readonly ILogger<App>? _logger;
    private readonly SessionManager _sessionManager;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="pageBuilder">Function that creates the root page.</param>
    /// <param name="logger">Optional logger for diagnostics.</param>
    public App(Func<Page> pageBuilder, ILogger<App>? logger = null)
    {
        _pageBuilder = pageBuilder ?? throw new ArgumentNullException(nameof(pageBuilder));
        _logger = logger;
        _sessionManager = new SessionManager(logger);
    }

    /// <summary>
    /// Gets or sets the application title.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the application's asset directory.
    /// </summary>
    public string? AssetsDirectory { get; set; }

    /// <summary>
    /// Gets the session manager.
    /// </summary>
    public SessionManager SessionManager => _sessionManager;

    /// <summary>
    /// Event raised when a new session is created.
    /// </summary>
    public event EventHandler<SessionCreatedEventArgs>? SessionCreated;

    /// <summary>
    /// Event raised when a session is closed.
    /// </summary>
    public event EventHandler<SessionClosedEventArgs>? SessionClosed;

    /// <summary>
    /// Creates a new session for a connection.
    /// </summary>
    /// <param name="connection">The connection to the Flutter client.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created session.</returns>
    public async Task<Session.Session> CreateSessionAsync(IConnection connection, CancellationToken cancellationToken = default)
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(App));
        }

        var sessionId = Guid.NewGuid().ToString();
        var session = new Session.Session(sessionId, connection, _logger as ILogger<Session.Session>);

        // Build the page for this session
        var page = _pageBuilder();
        if (!string.IsNullOrEmpty(Title))
        {
            page.Title = Title;
        }

        session.RootControl = page;

        // Register session
        _sessionManager.AddSession(session);

        // Subscribe to session events
        session.Disconnected += (s, e) => OnSessionDisconnected(session);
        session.ControlEventReceived += (s, e) => OnControlEventReceived(session, e);

        _logger?.LogInformation("Session created: {SessionId}", sessionId);

        // Send initial page state to client
        await SendInitialPageStateAsync(session, page, cancellationToken);

        // Raise event
        SessionCreated?.Invoke(this, new SessionCreatedEventArgs { Session = session });

        return session;
    }

    /// <summary>
    /// Handles a client registration request and creates or resumes a session.
    /// </summary>
    /// <param name="connection">The connection.</param>
    /// <param name="request">The registration request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task HandleClientRegistrationAsync(
        IConnection connection,
        RegisterClientMessage request,
        CancellationToken cancellationToken = default)
    {
        Session.Session? session;

        // Check if resuming existing session
        if (!string.IsNullOrEmpty(request.SessionId))
        {
            session = _sessionManager.GetSession(request.SessionId);
            if (session != null)
            {
                _logger?.LogInformation("Resuming session: {SessionId}", request.SessionId);
                // TODO: Update connection and re-send page state
                return;
            }
        }

        // Create new session
        session = await CreateSessionAsync(connection, cancellationToken);

        // Send registration response
        var response = new RegisterClientResponse
        {
            Action = ClientAction.RegisterClient,
            SessionId = session.SessionId,
            Patch = new List<PatchOperation>()
        };

        await connection.SendAsync(response, cancellationToken);
    }

    /// <summary>
    /// Disposes the application and all sessions.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;

        _logger?.LogInformation("Disposing application");
        await _sessionManager.DisposeAsync();
    }

    private async Task SendInitialPageStateAsync(Session.Session session, Page page, CancellationToken cancellationToken)
    {
        try
        {
            // Generate patch for the entire page tree
            var patch = ControlPatcher.CreateFullTreePatch(page);

            // Send the patch
            await session.SendPatchAsync(patch, cancellationToken);

            _logger?.LogDebug("Sent initial page state to session: {SessionId}", session.SessionId);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Failed to send initial page state for session: {SessionId}", session.SessionId);
        }
    }

    private void OnSessionDisconnected(Session.Session session)
    {
        _logger?.LogInformation("Session disconnected: {SessionId}", session.SessionId);
        _sessionManager.RemoveSession(session.SessionId);

        SessionClosed?.Invoke(this, new SessionClosedEventArgs
        {
            SessionId = session.SessionId,
            Reason = "Connection closed"
        });
    }

    private void OnControlEventReceived(Session.Session session, ControlEventReceivedEventArgs e)
    {
        _logger?.LogDebug("Control event: {ControlId}.{EventName} in session {SessionId}",
            e.ControlId, e.EventName, session.SessionId);

        // Control events are already handled by the session
        // This is just for application-level logging/monitoring
    }

    /// <summary>
    /// Static helper to run a FlutterSharp application.
    /// </summary>
    /// <param name="pageBuilder">Function that creates the root page.</param>
    /// <param name="port">Port to listen on (for future web server implementation).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public static async Task RunAsync(Func<Page> pageBuilder, int port = 8550, CancellationToken cancellationToken = default)
    {
        var app = new App(pageBuilder);

        // TODO: This will eventually start a web server (ASP.NET Core)
        // For now, it's a placeholder showing the intended API

        Console.WriteLine($"FlutterSharp app would run on port {port}");
        Console.WriteLine("Note: Full web server integration pending - Phase 6 of implementation plan");

        await Task.CompletedTask;
    }

    /// <summary>
    /// Static helper to run a FlutterSharp application synchronously.
    /// </summary>
    /// <param name="pageBuilder">Function that creates the root page.</param>
    /// <param name="port">Port to listen on.</param>
    public static void Run(Func<Page> pageBuilder, int port = 8550)
    {
        RunAsync(pageBuilder, port).GetAwaiter().GetResult();
    }
}

/// <summary>
/// Event arguments for when a session is created.
/// </summary>
public sealed class SessionCreatedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the created session.
    /// </summary>
    public required Session.Session Session { get; init; }
}

/// <summary>
/// Event arguments for when a session is closed.
/// </summary>
public sealed class SessionClosedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the session ID.
    /// </summary>
    public required string SessionId { get; init; }

    /// <summary>
    /// Gets the reason for closure.
    /// </summary>
    public string? Reason { get; init; }
}
