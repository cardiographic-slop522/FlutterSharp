using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A control that can be dismissed by dragging in the indicated dismiss direction.
/// When dragged or flung in the specified dismiss direction, its content smoothly slides out of view.
/// After completing the sliding animation, if a resize duration is provided,
/// this control further animates its height (or width, depending on what is perpendicular to the dismiss direction),
/// gradually reducing it to zero over the specified resize duration.
/// Corresponds to Flutter's Dismissible widget.
/// </summary>
[Control("Dismissible", Category = "core")]
public sealed class Dismissible : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Dismissible"/> class.
    /// </summary>
    public Dismissible()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Dismissible"/> class with content.
    /// </summary>
    /// <param name="content">The control that is being dismissed.</param>
    public Dismissible(BaseControl? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the control that is being dismissed.
    /// Must be visible.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets a control that is stacked behind the content.
    /// If SecondaryBackground is also specified, then this control only appears
    /// when the content has been dragged down or to the right.
    /// </summary>
    [JsonPropertyName("background")]
    public BaseControl? Background
    {
        get => GetProperty<BaseControl>(nameof(Background));
        set => SetProperty(nameof(Background), value);
    }

    /// <summary>
    /// Gets or sets a control that is stacked behind the content and is exposed
    /// when it has been dragged up or to the left.
    /// </summary>
    [JsonPropertyName("secondaryBackground")]
    public BaseControl? SecondaryBackground
    {
        get => GetProperty<BaseControl>(nameof(SecondaryBackground));
        set => SetProperty(nameof(SecondaryBackground), value);
    }

    /// <summary>
    /// Gets or sets the direction in which the control can be dismissed.
    /// Values: "horizontal", "vertical", "endToStart", "startToEnd", "up", "down", "none"
    /// Defaults to "horizontal".
    /// </summary>
    [JsonPropertyName("dismissDirection")]
    public string? DismissDirection
    {
        get => GetProperty<string>(nameof(DismissDirection));
        set => SetProperty(nameof(DismissDirection), value);
    }

    /// <summary>
    /// Gets or sets the duration for content to dismiss or to come back to original position if not dismissed.
    /// Value in milliseconds. Defaults to 200.
    /// </summary>
    [JsonPropertyName("movementDuration")]
    public int? MovementDuration
    {
        get => GetProperty<int?>(nameof(MovementDuration));
        set => SetProperty(nameof(MovementDuration), value);
    }

    /// <summary>
    /// Gets or sets the amount of time the control will spend contracting before on_dismiss is called.
    /// Value in milliseconds. Defaults to 300.
    /// </summary>
    [JsonPropertyName("resizeDuration")]
    public int? ResizeDuration
    {
        get => GetProperty<int?>(nameof(ResizeDuration));
        set => SetProperty(nameof(ResizeDuration), value);
    }

    /// <summary>
    /// Gets or sets the end offset along the main axis once the content has been dismissed.
    /// If set to a non-zero value, then this dismissible moves in cross direction depending on whether it is positive or negative.
    /// Defaults to 0.0.
    /// </summary>
    [JsonPropertyName("crossAxisEndOffset")]
    public double? CrossAxisEndOffset
    {
        get => GetProperty<double?>(nameof(CrossAxisEndOffset));
        set => SetProperty(nameof(CrossAxisEndOffset), value);
    }

    /// <summary>
    /// Occurs when this control has been dragged.
    /// </summary>
    public event EventHandler? Update;

    /// <summary>
    /// Occurs when this control has been dismissed, after finishing resizing.
    /// </summary>
    public event EventHandler? Dismiss;

    /// <summary>
    /// Occurs to give the app an opportunity to confirm or veto a pending dismissal.
    /// This dismissible cannot be dragged again until this pending dismissal is resolved.
    /// To resolve, call ConfirmDismiss method passing a boolean representing the decision.
    /// </summary>
    public event EventHandler? ConfirmDismiss;

    /// <summary>
    /// Occurs when this dismissible changes size, for example, when contracting before being dismissed.
    /// </summary>
    public event EventHandler? Resize;
}
