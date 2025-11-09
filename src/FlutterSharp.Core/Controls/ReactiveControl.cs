using FlutterSharp.Core.Patching;
using FlutterSharp.Core.Protocol;

namespace FlutterSharp.Core.Controls;

/// <summary>
/// A control that automatically generates patches when properties change.
/// Extends Control to provide reactive updates to the Flutter client.
/// </summary>
public abstract class ReactiveControl : Control
{
    private Session.Session? _session;
    private readonly ControlChangeTracker _changeTracker = new();
    private bool _autoUpdate = true;

    /// <summary>
    /// Gets or sets a value indicating whether property changes should automatically trigger updates.
    /// </summary>
    public bool AutoUpdate
    {
        get => _autoUpdate;
        set => _autoUpdate = value;
    }

    /// <summary>
    /// Attaches this control to a session for reactive updates.
    /// </summary>
    /// <param name="session">The session to attach to.</param>
    internal void AttachToSession(Session.Session session)
    {
        _session = session;
    }

    /// <summary>
    /// Detaches this control from its session.
    /// </summary>
    internal void DetachFromSession()
    {
        _session = null;
    }

    /// <summary>
    /// Called when a property value changes.
    /// Generates and sends patches to the client if auto-update is enabled.
    /// </summary>
    protected override void OnPropertyChanged(string propertyName)
    {
        base.OnPropertyChanged(propertyName);

        if (_autoUpdate && _session != null && IsMounted)
        {
            // Record the change
            var value = GetProperty<object>(propertyName);
            _changeTracker.RecordChange(Id, propertyName, value);

            // Generate and send patches
            _ = SendPatchesAsync();
        }
    }

    /// <summary>
    /// Manually triggers an update, sending all pending changes to the client.
    /// </summary>
    public async Task UpdateAsync()
    {
        await SendPatchesAsync();
    }

    /// <summary>
    /// Begins a batch update. Property changes will be tracked but not sent until EndUpdate() is called.
    /// </summary>
    public void BeginUpdate()
    {
        _autoUpdate = false;
    }

    /// <summary>
    /// Ends a batch update and sends all accumulated changes to the client.
    /// </summary>
    public async Task EndUpdateAsync()
    {
        _autoUpdate = true;
        await SendPatchesAsync();
    }

    private async Task SendPatchesAsync()
    {
        if (_session == null || !_changeTracker.HasChanges)
        {
            return;
        }

        try
        {
            var patches = _changeTracker.GeneratePatches();
            if (patches.Count > 0)
            {
                await _session.SendPatchAsync(patches);
            }
        }
        catch (Exception)
        {
            // Log error but don't throw - property changes should be resilient
            // TODO: Add logging when ILogger is available
        }
    }
}

/// <summary>
/// Extension methods for working with reactive controls.
/// </summary>
public static class ReactiveControlExtensions
{
    /// <summary>
    /// Executes an action with auto-update disabled, then sends a batch update.
    /// </summary>
    /// <param name="control">The reactive control.</param>
    /// <param name="action">The action to execute.</param>
    public static async Task BatchUpdateAsync(this ReactiveControl control, Action action)
    {
        control.BeginUpdate();
        try
        {
            action();
        }
        finally
        {
            await control.EndUpdateAsync();
        }
    }

    /// <summary>
    /// Executes an async action with auto-update disabled, then sends a batch update.
    /// </summary>
    /// <param name="control">The reactive control.</param>
    /// <param name="action">The async action to execute.</param>
    public static async Task BatchUpdateAsync(this ReactiveControl control, Func<Task> action)
    {
        control.BeginUpdate();
        try
        {
            await action();
        }
        finally
        {
            await control.EndUpdateAsync();
        }
    }
}
