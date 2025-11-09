using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Provide text labels which help explain the function of a button or other user interface action.
/// Corresponds to Flutter's Tooltip widget.
/// </summary>
[Control("Tooltip", Category = "material", IsContainer = true)]
public sealed class Tooltip : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Tooltip"/> class.
    /// </summary>
    public Tooltip()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Tooltip"/> class with a message.
    /// </summary>
    /// <param name="message">The text to display in the tooltip.</param>
    /// <param name="content">The control to attach the tooltip to.</param>
    public Tooltip(string message, BaseControl? content = null)
    {
        Message = message;
        Content = content;
    }

    /// <summary>
    /// Gets or sets the text to display in the tooltip.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message
    {
        get => GetProperty<string>(nameof(Message));
        set => SetProperty(nameof(Message), value);
    }

    /// <summary>
    /// Gets or sets the control to attach the tooltip to.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets whether the tooltip should provide acoustic and/or haptic feedback.
    /// </summary>
    [JsonPropertyName("enableFeedback")]
    public bool? EnableFeedback
    {
        get => GetProperty<bool?>(nameof(EnableFeedback));
        set => SetProperty(nameof(EnableFeedback), value);
    }

    /// <summary>
    /// Gets or sets the vertical gap between the control and the displayed tooltip.
    /// </summary>
    [JsonPropertyName("verticalOffset")]
    public double? VerticalOffset
    {
        get => GetProperty<double?>(nameof(VerticalOffset));
        set => SetProperty(nameof(VerticalOffset), value);
    }

    /// <summary>
    /// Gets or sets the empty space that surrounds the tooltip.
    /// </summary>
    [JsonPropertyName("margin")]
    public string? Margin
    {
        get => GetProperty<string>(nameof(Margin));
        set => SetProperty(nameof(Margin), value);
    }

    /// <summary>
    /// Gets or sets the amount of space by which to inset the tooltip's content.
    /// </summary>
    [JsonPropertyName("padding")]
    public string? Padding
    {
        get => GetProperty<string>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets the background color of the tooltip.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets how the message of the tooltip is aligned horizontally.
    /// Values: "left", "right", "center", "justify", "start", "end"
    /// </summary>
    [JsonPropertyName("textAlign")]
    public string? TextAlign
    {
        get => GetProperty<string>(nameof(TextAlign));
        set => SetProperty(nameof(TextAlign), value);
    }

    /// <summary>
    /// Gets or sets whether the tooltip defaults to being displayed below the control.
    /// </summary>
    [JsonPropertyName("preferBelow")]
    public bool? PreferBelow
    {
        get => GetProperty<bool?>(nameof(PreferBelow));
        set => SetProperty(nameof(PreferBelow), value);
    }

    /// <summary>
    /// Gets or sets the length of time (in milliseconds) that the tooltip will be shown after interaction.
    /// </summary>
    [JsonPropertyName("showDuration")]
    public int? ShowDuration
    {
        get => GetProperty<int?>(nameof(ShowDuration));
        set => SetProperty(nameof(ShowDuration), value);
    }

    /// <summary>
    /// Gets or sets the length of time (in milliseconds) that a pointer must hover before showing the tooltip.
    /// </summary>
    [JsonPropertyName("waitDuration")]
    public int? WaitDuration
    {
        get => GetProperty<int?>(nameof(WaitDuration));
        set => SetProperty(nameof(WaitDuration), value);
    }

    /// <summary>
    /// Gets or sets the length of time (in milliseconds) that the tooltip will be shown after releasing or exiting.
    /// </summary>
    [JsonPropertyName("exitDuration")]
    public int? ExitDuration
    {
        get => GetProperty<int?>(nameof(ExitDuration));
        set => SetProperty(nameof(ExitDuration), value);
    }

    /// <summary>
    /// Gets or sets whether the tooltip can be dismissed by tapping on it.
    /// </summary>
    [JsonPropertyName("tapToDismiss")]
    public bool? TapToDismiss
    {
        get => GetProperty<bool?>(nameof(TapToDismiss));
        set => SetProperty(nameof(TapToDismiss), value);
    }

    /// <summary>
    /// Gets or sets whether the tooltip's message should be excluded from the semantics tree.
    /// </summary>
    [JsonPropertyName("excludeFromSemantics")]
    public bool? ExcludeFromSemantics
    {
        get => GetProperty<bool?>(nameof(ExcludeFromSemantics));
        set => SetProperty(nameof(ExcludeFromSemantics), value);
    }

    /// <summary>
    /// Gets or sets the mode of the tooltip's trigger.
    /// Values: "manual", "tap", "longPress"
    /// </summary>
    [JsonPropertyName("triggerMode")]
    public string? TriggerMode
    {
        get => GetProperty<string>(nameof(TriggerMode));
        set => SetProperty(nameof(TriggerMode), value);
    }

    /// <summary>
    /// Gets or sets the mouse cursor when hovering over the content.
    /// </summary>
    [JsonPropertyName("mouseCursor")]
    public string? MouseCursor
    {
        get => GetProperty<string>(nameof(MouseCursor));
        set => SetProperty(nameof(MouseCursor), value);
    }

    /// <summary>
    /// Gets or sets the border radius of the tooltip.
    /// </summary>
    [JsonPropertyName("borderRadius")]
    public string? BorderRadius
    {
        get => GetProperty<string>(nameof(BorderRadius));
        set => SetProperty(nameof(BorderRadius), value);
    }
}
