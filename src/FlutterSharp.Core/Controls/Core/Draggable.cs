using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A control that can be dragged to a DragTarget.
/// When a draggable control recognizes the start of a drag gesture, it displays the
/// ContentFeedback control that tracks the user's finger across the screen.
/// If the user lifts their finger while on top of a DragTarget, that target is
/// given the opportunity to complete drag-and-drop flow.
/// Corresponds to Flutter's Draggable widget.
/// </summary>
[Control("Draggable", Category = "core")]
public sealed class Draggable : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Draggable"/> class.
    /// </summary>
    public Draggable()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Draggable"/> class with content.
    /// </summary>
    /// <param name="content">The control to display when not being dragged.</param>
    public Draggable(BaseControl? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the control to display when the draggable is not being dragged.
    /// If the draggable is being dragged, ContentWhenDragging is displayed instead.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets the group this draggable belongs to.
    /// For a DragTarget to accept an incoming drop from a Draggable,
    /// they must both be in the same group.
    /// Defaults to "default".
    /// </summary>
    [JsonPropertyName("group")]
    public string? Group
    {
        get => GetProperty<string>(nameof(Group));
        set => SetProperty(nameof(Group), value);
    }

    /// <summary>
    /// Gets or sets the control to display instead of Content when this draggable is being dragged.
    /// If set, this control visually replaces Content during an active drag operation.
    /// If null, the original Content remains visible while dragging.
    /// </summary>
    [JsonPropertyName("contentWhenDragging")]
    public BaseControl? ContentWhenDragging
    {
        get => GetProperty<BaseControl>(nameof(ContentWhenDragging));
        set => SetProperty(nameof(ContentWhenDragging), value);
    }

    /// <summary>
    /// Gets or sets the control to show under the pointer when a drag is under way.
    /// </summary>
    [JsonPropertyName("contentFeedback")]
    public BaseControl? ContentFeedback
    {
        get => GetProperty<BaseControl>(nameof(ContentFeedback));
        set => SetProperty(nameof(ContentFeedback), value);
    }

    /// <summary>
    /// Gets or sets the axis that restricts the draggable's movement.
    /// Values: "horizontal", "vertical", or null for any direction.
    /// </summary>
    [JsonPropertyName("axis")]
    public string? Axis
    {
        get => GetProperty<string>(nameof(Axis));
        set => SetProperty(nameof(Axis), value);
    }

    /// <summary>
    /// Gets or sets the axis along which this control competes with other gestures to initiate a drag.
    /// Values: "horizontal", "vertical", or null.
    /// If null, the drag starts as soon as a tap down gesture is recognized.
    /// </summary>
    [JsonPropertyName("affinity")]
    public string? Affinity
    {
        get => GetProperty<string>(nameof(Affinity));
        set => SetProperty(nameof(Affinity), value);
    }

    /// <summary>
    /// Gets or sets how many simultaneous drag operations are allowed.
    /// 0 = disables dragging, 1 = one drag at a time, null = no limit.
    /// Defaults to null.
    /// </summary>
    [JsonPropertyName("maxSimultaneousDrags")]
    public int? MaxSimultaneousDrags
    {
        get => GetProperty<int?>(nameof(MaxSimultaneousDrags));
        set => SetProperty(nameof(MaxSimultaneousDrags), value);
    }

    /// <summary>
    /// Occurs when this draggable starts being dragged.
    /// </summary>
    public event EventHandler? DragStart;

    /// <summary>
    /// Occurs when this draggable is dropped and accepted by a DragTarget.
    /// </summary>
    public event EventHandler? DragComplete;
}
