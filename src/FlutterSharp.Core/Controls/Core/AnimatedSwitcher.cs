using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// Used to switch between controls with an animation.
/// When content changes, this switcher will animate the transition from the old content to the new one.
/// Corresponds to Flutter's AnimatedSwitcher widget.
/// </summary>
[Control("AnimatedSwitcher", Category = "core")]
public sealed class AnimatedSwitcher : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AnimatedSwitcher"/> class.
    /// </summary>
    public AnimatedSwitcher()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimatedSwitcher"/> class with content.
    /// </summary>
    /// <param name="content">The content to display.</param>
    public AnimatedSwitcher(BaseControl? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the content to display.
    /// When it changes, this switcher will animate the transition from the old content to the new one.
    /// Must be visible.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets the duration of the transition from the old content to the new one.
    /// Value in milliseconds. Defaults to 1000 (1 second).
    /// </summary>
    [JsonPropertyName("duration")]
    public int? Duration
    {
        get => GetProperty<int?>(nameof(Duration));
        set => SetProperty(nameof(Duration), value);
    }

    /// <summary>
    /// Gets or sets the duration of the transition from the new content to the old one.
    /// Value in milliseconds. Defaults to 1000 (1 second).
    /// </summary>
    [JsonPropertyName("reverseDuration")]
    public int? ReverseDuration
    {
        get => GetProperty<int?>(nameof(ReverseDuration));
        set => SetProperty(nameof(ReverseDuration), value);
    }

    /// <summary>
    /// Gets or sets the animation curve to use when transitioning in a new content.
    /// Values: "linear", "easeIn", "easeOut", "easeInOut", "bounceIn", "bounceOut", etc.
    /// Defaults to "linear".
    /// </summary>
    [JsonPropertyName("switchInCurve")]
    public string? SwitchInCurve
    {
        get => GetProperty<string>(nameof(SwitchInCurve));
        set => SetProperty(nameof(SwitchInCurve), value);
    }

    /// <summary>
    /// Gets or sets the animation curve to use when transitioning an old content out.
    /// Values: "linear", "easeIn", "easeOut", "easeInOut", "bounceIn", "bounceOut", etc.
    /// Defaults to "linear".
    /// </summary>
    [JsonPropertyName("switchOutCurve")]
    public string? SwitchOutCurve
    {
        get => GetProperty<string>(nameof(SwitchOutCurve));
        set => SetProperty(nameof(SwitchOutCurve), value);
    }

    /// <summary>
    /// Gets or sets the animation type to transition between new and old content.
    /// Values: "fade", "rotation", "scale"
    /// Defaults to "fade".
    /// </summary>
    [JsonPropertyName("transition")]
    public string? Transition
    {
        get => GetProperty<string>(nameof(Transition));
        set => SetProperty(nameof(Transition), value);
    }
}
