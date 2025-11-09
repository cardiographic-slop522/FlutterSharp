using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace FlutterSharp.Core.Session;

/// <summary>
/// Manages multiple sessions in a FlutterSharp application.
/// Provides session storage, lookup, and lifecycle management.
/// </summary>
public sealed class SessionManager : IAsyncDisposable
{
    private readonly ConcurrentDictionary<string, Session> _sessions = new();
    private readonly ILogger? _logger;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="SessionManager"/> class.
    /// </summary>
    /// <param name="logger">Optional logger for diagnostics.</param>
    public SessionManager(ILogger? logger = null)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets the number of active sessions.
    /// </summary>
    public int ActiveSessionCount => _sessions.Count;

    /// <summary>
    /// Gets all active session IDs.
    /// </summary>
    public IEnumerable<string> SessionIds => _sessions.Keys;

    /// <summary>
    /// Adds a session to the manager.
    /// </summary>
    /// <param name="session">The session to add.</param>
    /// <returns>True if added; false if a session with the same ID already exists.</returns>
    public bool AddSession(Session session)
    {
        if (session == null)
        {
            throw new ArgumentNullException(nameof(session));
        }

        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(SessionManager));
        }

        var added = _sessions.TryAdd(session.SessionId, session);
        if (added)
        {
            _logger?.LogInformation("Session added: {SessionId} (Total: {Count})",
                session.SessionId, _sessions.Count);
        }
        else
        {
            _logger?.LogWarning("Failed to add session (duplicate ID): {SessionId}", session.SessionId);
        }

        return added;
    }

    /// <summary>
    /// Retrieves a session by ID.
    /// </summary>
    /// <param name="sessionId">The session ID.</param>
    /// <returns>The session, or null if not found.</returns>
    public Session? GetSession(string sessionId)
    {
        if (string.IsNullOrEmpty(sessionId))
        {
            return null;
        }

        _sessions.TryGetValue(sessionId, out var session);
        return session;
    }

    /// <summary>
    /// Removes a session from the manager.
    /// </summary>
    /// <param name="sessionId">The session ID to remove.</param>
    /// <returns>True if removed; false if not found.</returns>
    public bool RemoveSession(string sessionId)
    {
        if (string.IsNullOrEmpty(sessionId))
        {
            return false;
        }

        var removed = _sessions.TryRemove(sessionId, out var session);
        if (removed && session != null)
        {
            _logger?.LogInformation("Session removed: {SessionId} (Remaining: {Count})",
                sessionId, _sessions.Count);
        }

        return removed;
    }

    /// <summary>
    /// Removes and disposes a session.
    /// </summary>
    /// <param name="sessionId">The session ID to remove.</param>
    public async Task<bool> RemoveAndDisposeSessionAsync(string sessionId)
    {
        if (_sessions.TryRemove(sessionId, out var session))
        {
            await session.DisposeAsync();
            _logger?.LogInformation("Session removed and disposed: {SessionId}", sessionId);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets all sessions matching a predicate.
    /// </summary>
    /// <param name="predicate">The filter predicate.</param>
    /// <returns>Matching sessions.</returns>
    public IEnumerable<Session> GetSessions(Func<Session, bool> predicate)
    {
        return _sessions.Values.Where(predicate);
    }

    /// <summary>
    /// Gets all active sessions.
    /// </summary>
    /// <returns>All sessions.</returns>
    public IEnumerable<Session> GetAllSessions()
    {
        return _sessions.Values;
    }

    /// <summary>
    /// Removes all disconnected sessions.
    /// </summary>
    /// <returns>The number of sessions removed.</returns>
    public async Task<int> CleanupDisconnectedSessionsAsync()
    {
        var disconnectedSessions = _sessions.Values
            .Where(s => !s.IsConnected)
            .ToList();

        var count = 0;
        foreach (var session in disconnectedSessions)
        {
            if (await RemoveAndDisposeSessionAsync(session.SessionId))
            {
                count++;
            }
        }

        if (count > 0)
        {
            _logger?.LogInformation("Cleaned up {Count} disconnected sessions", count);
        }

        return count;
    }

    /// <summary>
    /// Broadcasts a message to all sessions.
    /// </summary>
    /// <param name="messageFactory">Function to create the message.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task BroadcastAsync(
        Func<Protocol.Message> messageFactory,
        CancellationToken cancellationToken = default)
    {
        var tasks = _sessions.Values
            .Where(s => s.IsConnected)
            .Select(async session =>
            {
                try
                {
                    var message = messageFactory();
                    await session.SendMessageAsync(message, cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, "Failed to broadcast to session: {SessionId}", session.SessionId);
                }
            });

        await Task.WhenAll(tasks);
        _logger?.LogDebug("Broadcast message sent to {Count} sessions", _sessions.Count);
    }

    /// <summary>
    /// Disposes all sessions and clears the manager.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;

        _logger?.LogInformation("Disposing SessionManager with {Count} sessions", _sessions.Count);

        var disposeTasks = _sessions.Values.Select(s => s.DisposeAsync().AsTask());
        await Task.WhenAll(disposeTasks);

        _sessions.Clear();

        _logger?.LogInformation("SessionManager disposed");
    }
}
