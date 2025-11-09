using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A control that insets its content by sufficient padding to avoid intrusions by the operating system.
/// For example, this will indent the content by enough to avoid the status bar at the top of the screen.
/// It will also indent the content by the amount necessary to avoid the Notch on the iPhone X,
/// or other similar creative physical features of the display.
/// Corresponds to Flutter's SafeArea widget.
/// </summary>
[Control("SafeArea", Category = "core")]
public sealed class SafeArea : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SafeArea"/> class.
    /// </summary>
    public SafeArea()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SafeArea"/> class with content.
    /// </summary>
    /// <param name="content">The control to display.</param>
    public SafeArea(BaseControl? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the control to display.
    /// Must be visible.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets whether to avoid system intrusions on the left.
    /// Note: This hides the Left property from the base Control class.
    /// SafeArea uses Left to control intrusion avoidance, not positioning.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("left")]
    public new bool? Left
    {
        get => GetProperty<bool?>(nameof(Left));
        set => SetProperty(nameof(Left), value);
    }

    /// <summary>
    /// Gets or sets whether to avoid system intrusions at the top of the screen, typically the system status bar.
    /// Note: This hides the Top property from the base Control class.
    /// SafeArea uses Top to control intrusion avoidance, not positioning.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("top")]
    public new bool? Top
    {
        get => GetProperty<bool?>(nameof(Top));
        set => SetProperty(nameof(Top), value);
    }

    /// <summary>
    /// Gets or sets whether to avoid system intrusions on the right.
    /// Note: This hides the Right property from the base Control class.
    /// SafeArea uses Right to control intrusion avoidance, not positioning.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("right")]
    public new bool? Right
    {
        get => GetProperty<bool?>(nameof(Right));
        set => SetProperty(nameof(Right), value);
    }

    /// <summary>
    /// Gets or sets whether to avoid system intrusions on the bottom side of the screen.
    /// Note: This hides the Bottom property from the base Control class.
    /// SafeArea uses Bottom to control intrusion avoidance, not positioning.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("bottom")]
    public new bool? Bottom
    {
        get => GetProperty<bool?>(nameof(Bottom));
        set => SetProperty(nameof(Bottom), value);
    }

    /// <summary>
    /// Gets or sets whether the SafeArea should maintain the bottom view padding.
    /// This avoids layout shifts caused by keyboard overlays, useful when flexible controls are used.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("maintainBottomViewPadding")]
    public bool? MaintainBottomViewPadding
    {
        get => GetProperty<bool?>(nameof(MaintainBottomViewPadding));
        set => SetProperty(nameof(MaintainBottomViewPadding), value);
    }

    /// <summary>
    /// Gets or sets the minimum padding to apply.
    /// The greater of the minimum insets and the media padding will be applied.
    /// </summary>
    [JsonPropertyName("minimumPadding")]
    public string? MinimumPadding
    {
        get => GetProperty<string>(nameof(MinimumPadding));
        set => SetProperty(nameof(MinimumPadding), value);
    }
}
