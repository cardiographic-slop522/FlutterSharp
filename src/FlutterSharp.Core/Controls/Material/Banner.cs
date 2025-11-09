using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A banner displays an important, succinct message, and provides actions for users to
/// address (or dismiss the banner). A user action is required for it to be dismissed.
/// Banners are displayed at the top of the screen, below a top app bar. They are
/// persistent and non-modal, allowing the user to either ignore them or interact with them at any time.
/// Corresponds to Flutter's Banner widget.
/// </summary>
[Control("Banner", Category = "material")]
public sealed class Banner : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Banner"/> class.
    /// </summary>
    public Banner()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Banner"/> class with content.
    /// </summary>
    /// <param name="content">The content of the banner.</param>
    /// <param name="open">Whether the banner is open.</param>
    public Banner(object content, bool open = false)
    {
        Content = content;
        Open = open;
    }

    /// <summary>
    /// Gets or sets the content of this banner.
    /// Can be a string or a BaseControl (typically Text).
    /// </summary>
    [JsonPropertyName("content")]
    public object? Content
    {
        get => GetProperty<object>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets the leading control of this banner.
    /// Can be an icon name string or a BaseControl (typically Icon).
    /// </summary>
    [JsonPropertyName("leading")]
    public object? Leading
    {
        get => GetProperty<object>(nameof(Leading));
        set => SetProperty(nameof(Leading), value);
    }

    /// <summary>
    /// Gets or sets whether the banner is currently open.
    /// </summary>
    [JsonPropertyName("open")]
    public bool? Open
    {
        get => GetProperty<bool?>(nameof(Open));
        set => SetProperty(nameof(Open), value);
    }

    /// <summary>
    /// Gets or sets the amount of space by which to inset the leading control.
    /// </summary>
    [JsonPropertyName("leadingPadding")]
    public string? LeadingPadding
    {
        get => GetProperty<string>(nameof(LeadingPadding));
        set => SetProperty(nameof(LeadingPadding), value);
    }

    /// <summary>
    /// Gets or sets the amount of space by which to inset the content.
    /// </summary>
    [JsonPropertyName("contentPadding")]
    public string? ContentPadding
    {
        get => GetProperty<string>(nameof(ContentPadding));
        set => SetProperty(nameof(ContentPadding), value);
    }

    /// <summary>
    /// Gets or sets whether to force the actions to be below the content regardless of how many there are.
    /// If true, actions will be placed below the content.
    /// If false (default), actions will be placed on the trailing side if there's 1 action, or below if more than 1.
    /// </summary>
    [JsonPropertyName("forceActionsBelow")]
    public bool? ForceActionsBelow
    {
        get => GetProperty<bool?>(nameof(ForceActionsBelow));
        set => SetProperty(nameof(ForceActionsBelow), value);
    }

    /// <summary>
    /// Gets or sets the background color of the surface of this banner.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the color of the shadow below this banner.
    /// </summary>
    [JsonPropertyName("shadowColor")]
    public string? ShadowColor
    {
        get => GetProperty<string>(nameof(ShadowColor));
        set => SetProperty(nameof(ShadowColor), value);
    }

    /// <summary>
    /// Gets or sets the color of the divider.
    /// </summary>
    [JsonPropertyName("dividerColor")]
    public string? DividerColor
    {
        get => GetProperty<string>(nameof(DividerColor));
        set => SetProperty(nameof(DividerColor), value);
    }

    /// <summary>
    /// Gets or sets the elevation of this banner.
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets the amount of space surrounding this banner.
    /// </summary>
    [JsonPropertyName("margin")]
    public string? Margin
    {
        get => GetProperty<string>(nameof(Margin));
        set => SetProperty(nameof(Margin), value);
    }

    /// <summary>
    /// Gets or sets the text style to be used for Text controls in the content.
    /// </summary>
    [JsonPropertyName("contentTextStyle")]
    public string? ContentTextStyle
    {
        get => GetProperty<string>(nameof(ContentTextStyle));
        set => SetProperty(nameof(ContentTextStyle), value);
    }

    /// <summary>
    /// Gets or sets the minimum action bar height.
    /// Defaults to 52.0.
    /// </summary>
    [JsonPropertyName("minActionBarHeight")]
    public double? MinActionBarHeight
    {
        get => GetProperty<double?>(nameof(MinActionBarHeight));
        set => SetProperty(nameof(MinActionBarHeight), value);
    }

    /// <summary>
    /// Occurs when this banner is shown or made visible for the first time.
    /// </summary>
    public event EventHandler? BecameVisible;
}
