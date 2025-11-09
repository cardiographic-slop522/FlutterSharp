using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A control that completes drag operation when a Draggable control is dropped.
/// When a Draggable is dragged on top of a DragTarget, the DragTarget is asked
/// whether it will accept the data the Draggable is carrying. The DragTarget will
/// accept incoming drag if it belongs to the same group as Draggable. If the user
/// does drop the Draggable on top of the DragTarget (and the DragTarget has
/// indicated that it will accept the Draggable's data), then the DragTarget is
/// asked to accept the Draggable's data.
/// Corresponds to Flutter's DragTarget widget.
/// </summary>
[Control("DragTarget", Category = "core")]
public sealed class DragTarget : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DragTarget"/> class.
    /// </summary>
    public DragTarget()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DragTarget"/> class with content.
    /// </summary>
    /// <param name="content">The content of this control.</param>
    public DragTarget(BaseControl? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the content of this control.
    /// Must be visible.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets the group this target belongs to.
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
    /// Occurs when a draggable is dragged on this target.
    /// </summary>
    public event EventHandler? WillAccept;

    /// <summary>
    /// Occurs when the user drops an acceptable (same group) draggable on this target.
    /// Use page.GetControl(e.SrcId) to retrieve Control reference by its ID.
    /// </summary>
    public event EventHandler? Accept;

    /// <summary>
    /// Occurs when a draggable leaves this target.
    /// </summary>
    public event EventHandler? Leave;

    /// <summary>
    /// Occurs when a draggable moves within this target.
    /// </summary>
    public event EventHandler? Move;
}
