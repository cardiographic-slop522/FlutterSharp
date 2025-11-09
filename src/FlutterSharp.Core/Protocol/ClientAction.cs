namespace FlutterSharp.Core.Protocol;

/// <summary>
/// Represents the actions that can be sent from the client to the server or vice versa.
/// These actions define the protocol for communication between the C# backend and Flutter client.
/// </summary>
public enum ClientAction
{
    /// <summary>
    /// Register a new client session with the server.
    /// Sent by the client when establishing a connection.
    /// </summary>
    RegisterClient = 1,

    /// <summary>
    /// Apply a patch to update control properties.
    /// Used for differential updates to minimize data transfer.
    /// </summary>
    PatchControl = 2,

    /// <summary>
    /// Send an event from a control (e.g., button click, text change).
    /// Sent by the Flutter client when user interacts with UI.
    /// </summary>
    ControlEvent = 3,

    /// <summary>
    /// Update control properties directly.
    /// Alternative to PatchControl for simpler updates.
    /// </summary>
    UpdateControlProps = 4,

    /// <summary>
    /// Invoke a method on a control.
    /// Used for operations like focus(), scroll(), etc.
    /// </summary>
    InvokeMethod = 5,

    /// <summary>
    /// Notify that the session has crashed.
    /// Sent by either client or server on fatal error.
    /// </summary>
    SessionCrashed = 6
}
