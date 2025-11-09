using MessagePack;

namespace FlutterSharp.Core.Protocol;

/// <summary>
/// Base class for all protocol messages.
/// Uses MessagePack for efficient binary serialization.
/// </summary>
/// <remarks>
/// MessagePack Union attributes are not used here as we use dynamic deserialization
/// based on the Action field to determine the specific message type.
/// </remarks>
[MessagePackObject]
public record Message
{
    /// <summary>
    /// The action type for this message.
    /// </summary>
    [Key(0)]
    public required ClientAction Action { get; init; }

    /// <summary>
    /// Optional message identifier for request/response correlation.
    /// </summary>
    [Key(1)]
    public string? MessageId { get; init; }
}

/// <summary>
/// Message sent by the client to register with the server.
/// This is the first message sent when establishing a connection.
/// </summary>
[MessagePackObject]
public sealed record RegisterClientMessage : Message
{
    /// <summary>
    /// The session ID for reconnecting to an existing session.
    /// Null for new sessions.
    /// </summary>
    [Key(2)]
    public string? SessionId { get; init; }

    /// <summary>
    /// The page name/route to navigate to.
    /// </summary>
    [Key(3)]
    public string? PageName { get; init; }

    /// <summary>
    /// The page hash for cache validation.
    /// </summary>
    [Key(4)]
    public string? PageHash { get; init; }

    /// <summary>
    /// Client platform information (web, windows, macos, linux, ios, android).
    /// </summary>
    [Key(5)]
    public string? Platform { get; init; }

    /// <summary>
    /// Client platform brightness (light, dark).
    /// </summary>
    [Key(6)]
    public string? PlatformBrightness { get; init; }

    /// <summary>
    /// Client screen dimensions.
    /// </summary>
    [Key(7)]
    public Dictionary<string, object>? Media { get; init; }
}

/// <summary>
/// Response to RegisterClientMessage containing initial page state.
/// </summary>
[MessagePackObject]
public sealed record RegisterClientResponse : Message
{
    /// <summary>
    /// The assigned or existing session ID.
    /// </summary>
    [Key(2)]
    public required string SessionId { get; init; }

    /// <summary>
    /// The initial patch to construct the page.
    /// </summary>
    [Key(3)]
    public required List<PatchOperation> Patch { get; init; }

    /// <summary>
    /// Error message if registration failed.
    /// </summary>
    [Key(4)]
    public string? Error { get; init; }
}

/// <summary>
/// Message to apply a JSON Patch to control tree.
/// Uses RFC 6902 JSON Patch format for efficient differential updates.
/// </summary>
[MessagePackObject]
public sealed record PatchControlMessage : Message
{
    /// <summary>
    /// The patch operations to apply.
    /// </summary>
    [Key(2)]
    public required List<PatchOperation> Patch { get; init; }
}

/// <summary>
/// Message sent when a control event occurs (e.g., button click).
/// </summary>
[MessagePackObject]
public sealed record ControlEventMessage : Message
{
    /// <summary>
    /// The ID of the control that fired the event.
    /// </summary>
    [Key(2)]
    public required string ControlId { get; init; }

    /// <summary>
    /// The name of the event (e.g., "click", "change", "submit").
    /// </summary>
    [Key(3)]
    public required string EventName { get; init; }

    /// <summary>
    /// Event data payload.
    /// </summary>
    [Key(4)]
    public Dictionary<string, object>? Data { get; init; }
}

/// <summary>
/// Message to update control properties directly.
/// Simpler alternative to PatchControl for small updates.
/// </summary>
[MessagePackObject]
public sealed record UpdateControlPropsMessage : Message
{
    /// <summary>
    /// The ID of the control to update.
    /// </summary>
    [Key(2)]
    public required string ControlId { get; init; }

    /// <summary>
    /// The properties to update.
    /// </summary>
    [Key(3)]
    public required Dictionary<string, object?> Properties { get; init; }
}

/// <summary>
/// Message to invoke a method on a control.
/// </summary>
[MessagePackObject]
public sealed record InvokeMethodMessage : Message
{
    /// <summary>
    /// The ID of the control on which to invoke the method.
    /// </summary>
    [Key(2)]
    public required string ControlId { get; init; }

    /// <summary>
    /// The name of the method to invoke.
    /// </summary>
    [Key(3)]
    public required string MethodName { get; init; }

    /// <summary>
    /// Arguments to pass to the method.
    /// </summary>
    [Key(4)]
    public List<object?>? Arguments { get; init; }
}

/// <summary>
/// Response to InvokeMethodMessage containing the method result.
/// </summary>
[MessagePackObject]
public sealed record InvokeMethodResponse : Message
{
    /// <summary>
    /// The result of the method invocation.
    /// </summary>
    [Key(2)]
    public object? Result { get; init; }

    /// <summary>
    /// Error message if the method invocation failed.
    /// </summary>
    [Key(3)]
    public string? Error { get; init; }
}

/// <summary>
/// Message indicating a session crash.
/// </summary>
[MessagePackObject]
public sealed record SessionCrashedMessage : Message
{
    /// <summary>
    /// The error message describing the crash.
    /// </summary>
    [Key(2)]
    public required string Error { get; init; }

    /// <summary>
    /// Stack trace if available.
    /// </summary>
    [Key(3)]
    public string? StackTrace { get; init; }
}

/// <summary>
/// Represents a single patch operation (RFC 6902 JSON Patch).
/// </summary>
[MessagePackObject]
public sealed record PatchOperation
{
    /// <summary>
    /// The operation type (add, remove, replace, move, copy, test).
    /// </summary>
    [Key(0)]
    public required string Op { get; init; }

    /// <summary>
    /// The JSON Pointer path to the target location.
    /// </summary>
    [Key(1)]
    public required string Path { get; init; }

    /// <summary>
    /// The value for add, replace, test operations.
    /// </summary>
    [Key(2)]
    public object? Value { get; init; }

    /// <summary>
    /// The source path for move and copy operations.
    /// </summary>
    [Key(3)]
    public string? From { get; init; }
}
