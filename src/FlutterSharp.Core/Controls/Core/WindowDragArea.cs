using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// It mimics the behavior (drag, move, maximize, restore) of a native OS window title bar on the content control.
/// This allows you to create custom window title bars with draggable areas.
/// Corresponds to Flutter's WindowDragArea (Flet-specific).
/// </summary>
[Control("WindowDragArea", Category = "core")]
public sealed class WindowDragArea : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowDragArea"/> class.
    /// </summary>
    public WindowDragArea()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowDragArea"/> class with content.
    /// </summary>
    /// <param name="content">The content of this drag area.</param>
    public WindowDragArea(BaseControl? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the content of this drag area.
    /// Must be visible.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets whether double-clicking on the WindowDragArea should maximize/unmaximize the app's window.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("maximizable")]
    public bool? Maximizable
    {
        get => GetProperty<bool?>(nameof(Maximizable));
        set => SetProperty(nameof(Maximizable), value);
    }

    /// <summary>
    /// Occurs when the WindowDragArea is double-tapped and Maximizable is true.
    /// The event type can be "maximize" or "unmaximize".
    /// </summary>
    public event EventHandler? DoubleTap;

    /// <summary>
    /// Occurs when a pointer has contacted the screen and has begun to move/drag.
    /// </summary>
    public event EventHandler? DragStart;

    /// <summary>
    /// Occurs when a pointer that was previously in contact with the screen and moving/dragging is no longer in contact.
    /// </summary>
    public event EventHandler? DragEnd;
}
