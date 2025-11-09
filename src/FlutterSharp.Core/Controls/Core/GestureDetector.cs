using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A control that detects gestures.
/// Attempts to recognize gestures that correspond to its non-null event handlers.
/// If this control has content, it defers to that child control for its sizing behavior,
/// otherwise it grows to fit the parent.
/// Corresponds to Flutter's GestureDetector widget.
/// </summary>
[Control("GestureDetector", Category = "core")]
public sealed class GestureDetector : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GestureDetector"/> class.
    /// </summary>
    public GestureDetector()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GestureDetector"/> class with content.
    /// </summary>
    /// <param name="content">The child control contained by the gesture detector.</param>
    public GestureDetector(BaseControl? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the child control contained by the gesture detector.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets the mouse cursor for mouse pointers hovering over this control.
    /// </summary>
    [JsonPropertyName("mouseCursor")]
    public string? MouseCursor
    {
        get => GetProperty<string>(nameof(MouseCursor));
        set => SetProperty(nameof(MouseCursor), value);
    }

    /// <summary>
    /// Gets or sets throttling in milliseconds for horizontal drag, vertical drag and pan update events.
    /// When a user moves a pointer, many events are generated. This allows sending events every X milliseconds.
    /// Default is 0 (no throttling, all events sent).
    /// </summary>
    [JsonPropertyName("dragInterval")]
    public int? DragInterval
    {
        get => GetProperty<int?>(nameof(DragInterval));
        set => SetProperty(nameof(DragInterval), value);
    }

    /// <summary>
    /// Gets or sets throttling in milliseconds for hover events.
    /// Default is 0 (no throttling).
    /// </summary>
    [JsonPropertyName("hoverInterval")]
    public int? HoverInterval
    {
        get => GetProperty<int?>(nameof(HoverInterval));
        set => SetProperty(nameof(HoverInterval), value);
    }

    /// <summary>
    /// Gets or sets the minimum number of pointers to trigger multi-tap event.
    /// Default is 0.
    /// </summary>
    [JsonPropertyName("multiTapTouches")]
    public int? MultiTapTouches
    {
        get => GetProperty<int?>(nameof(MultiTapTouches));
        set => SetProperty(nameof(MultiTapTouches), value);
    }

    /// <summary>
    /// Gets or sets whether to exclude this control from semantics tree.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("excludeFromSemantics")]
    public bool? ExcludeFromSemantics
    {
        get => GetProperty<bool?>(nameof(ExcludeFromSemantics));
        set => SetProperty(nameof(ExcludeFromSemantics), value);
    }

    /// <summary>
    /// Gets or sets whether trackpad scroll causes scale.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("trackpadScrollCausesScale")]
    public bool? TrackpadScrollCausesScale
    {
        get => GetProperty<bool?>(nameof(TrackpadScrollCausesScale));
        set => SetProperty(nameof(TrackpadScrollCausesScale), value);
    }

    // Tap Events

    /// <summary>
    /// Occurs when a tap with a primary button has occurred.
    /// </summary>
    public event EventHandler? Tap;

    /// <summary>
    /// Occurs when a pointer that might cause a tap with a primary button has contacted the screen.
    /// </summary>
    public event EventHandler? TapDown;

    /// <summary>
    /// Occurs when a pointer that will trigger a tap with a primary button has stopped contacting the screen.
    /// </summary>
    public event EventHandler? TapUp;

    /// <summary>
    /// Occurs when multiple pointers contacted the screen.
    /// </summary>
    public event EventHandler? MultiTap;

    /// <summary>
    /// Occurs when a long press gesture with multiple pointers has been recognized.
    /// </summary>
    public event EventHandler? MultiLongPress;

    // Secondary Tap Events

    /// <summary>
    /// Occurs when a tap with a secondary button has occurred.
    /// </summary>
    public event EventHandler? SecondaryTap;

    /// <summary>
    /// Occurs when a pointer that might cause a tap with a secondary button has contacted the screen.
    /// </summary>
    public event EventHandler? SecondaryTapDown;

    /// <summary>
    /// Occurs when a pointer that will trigger a tap with a secondary button has stopped contacting the screen.
    /// </summary>
    public event EventHandler? SecondaryTapUp;

    // Tertiary Tap Events

    /// <summary>
    /// Occurs when a pointer that might cause a tap with a tertiary button has contacted the screen.
    /// </summary>
    public event EventHandler? TertiaryTapDown;

    /// <summary>
    /// Occurs when a pointer that will trigger a tap with a tertiary button has stopped contacting the screen.
    /// </summary>
    public event EventHandler? TertiaryTapUp;

    // Long Press Events

    /// <summary>
    /// Occurs when a long press gesture with a primary button has been recognized.
    /// </summary>
    public event EventHandler? LongPressStart;

    /// <summary>
    /// Occurs when a pointer that has triggered a long-press with a primary button has stopped contacting the screen.
    /// </summary>
    public event EventHandler? LongPressEnd;

    /// <summary>
    /// Occurs when a long press gesture with a secondary button has been recognized.
    /// </summary>
    public event EventHandler? SecondaryLongPressStart;

    /// <summary>
    /// Occurs when a pointer that has triggered a long-press with a secondary button has stopped contacting the screen.
    /// </summary>
    public event EventHandler? SecondaryLongPressEnd;

    /// <summary>
    /// Occurs when a long press gesture with a tertiary button has been recognized.
    /// </summary>
    public event EventHandler? TertiaryLongPressStart;

    /// <summary>
    /// Occurs when a pointer that has triggered a long-press with a tertiary button has stopped contacting the screen.
    /// </summary>
    public event EventHandler? TertiaryLongPressEnd;

    // Double Tap Events

    /// <summary>
    /// Occurs when the user has tapped the screen with a primary button at the same location twice in quick succession.
    /// </summary>
    public event EventHandler? DoubleTap;

    /// <summary>
    /// Occurs when a pointer that might cause a double tap has contacted the screen.
    /// </summary>
    public event EventHandler? DoubleTapDown;

    // Horizontal Drag Events

    /// <summary>
    /// Occurs when a pointer has contacted the screen with a primary button and has begun to move horizontally.
    /// </summary>
    public event EventHandler? HorizontalDragStart;

    /// <summary>
    /// Occurs when a pointer in contact with the screen and moving horizontally has moved in the horizontal direction.
    /// </summary>
    public event EventHandler? HorizontalDragUpdate;

    /// <summary>
    /// Occurs when a pointer moving horizontally is no longer in contact and was moving at a specific velocity.
    /// </summary>
    public event EventHandler? HorizontalDragEnd;

    // Vertical Drag Events

    /// <summary>
    /// Occurs when a pointer has contacted the screen and has begun to move vertically.
    /// </summary>
    public event EventHandler? VerticalDragStart;

    /// <summary>
    /// Occurs when a pointer moving vertically has moved in the vertical direction.
    /// </summary>
    public event EventHandler? VerticalDragUpdate;

    /// <summary>
    /// Occurs when a pointer moving vertically is no longer in contact and was moving at a specific velocity.
    /// </summary>
    public event EventHandler? VerticalDragEnd;

    // Pan Events

    /// <summary>
    /// Occurs when a pointer has contacted the screen and has begun to move.
    /// </summary>
    public event EventHandler? PanStart;

    /// <summary>
    /// Occurs when a pointer in contact with the screen and moving has moved again.
    /// </summary>
    public event EventHandler? PanUpdate;

    /// <summary>
    /// Occurs when a pointer is no longer in contact and was moving at a specific velocity.
    /// </summary>
    public event EventHandler? PanEnd;

    // Right Pan Events (secondary button)

    /// <summary>
    /// Occurs when pointer has contacted the screen while secondary button pressed and has begun to move.
    /// </summary>
    public event EventHandler? RightPanStart;

    /// <summary>
    /// Occurs when a pointer in contact with the screen, secondary button pressed and moving has moved again.
    /// </summary>
    public event EventHandler? RightPanUpdate;

    /// <summary>
    /// Occurs when a pointer with secondary button pressed is no longer in contact and was moving at a specific velocity.
    /// </summary>
    public event EventHandler? RightPanEnd;

    // Scale Events

    /// <summary>
    /// Occurs when the pointers in contact with the screen have established a focal point and initial scale of 1.0.
    /// </summary>
    public event EventHandler? ScaleStart;

    /// <summary>
    /// Occurs when the pointers in contact with the screen have indicated a new focal point and/or scale.
    /// </summary>
    public event EventHandler? ScaleUpdate;

    /// <summary>
    /// Occurs when the pointers are no longer in contact with the screen.
    /// </summary>
    public event EventHandler? ScaleEnd;

    // Hover Events

    /// <summary>
    /// Occurs when a mouse pointer has moved over this control.
    /// </summary>
    public event EventHandler? Hover;

    /// <summary>
    /// Occurs when a mouse pointer has entered this control.
    /// </summary>
    public event EventHandler? Enter;

    /// <summary>
    /// Occurs when a mouse pointer has exited this control.
    /// </summary>
    public event EventHandler? Exit;

    // Scroll Event

    /// <summary>
    /// Occurs when the user scrolls within this control.
    /// </summary>
    public event EventHandler? Scroll;
}
