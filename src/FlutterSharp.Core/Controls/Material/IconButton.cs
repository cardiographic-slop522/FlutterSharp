using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design icon button.
/// Corresponds to Flutter's IconButton widget.
/// </summary>
[Control("IconButton", Category = "material")]
public sealed class IconButton : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IconButton"/> class.
    /// </summary>
    public IconButton()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IconButton"/> class with an icon.
    /// </summary>
    /// <param name="icon">The icon name.</param>
    /// <param name="onClick">Optional click handler.</param>
    public IconButton(string icon, EventHandler? onClick = null)
    {
        Icon = icon;
        if (onClick != null)
        {
            Click = onClick;
        }
    }

    /// <summary>
    /// Gets or sets the icon name.
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon
    {
        get => GetProperty<string>(nameof(Icon));
        set => SetProperty(nameof(Icon), value);
    }

    /// <summary>
    /// Gets or sets the icon color.
    /// </summary>
    [JsonPropertyName("iconColor")]
    public string? IconColor
    {
        get => GetProperty<string>(nameof(IconColor));
        set => SetProperty(nameof(IconColor), value);
    }

    /// <summary>
    /// Gets or sets the icon size.
    /// </summary>
    [JsonPropertyName("iconSize")]
    public double? IconSize
    {
        get => GetProperty<double?>(nameof(IconSize));
        set => SetProperty(nameof(IconSize), value);
    }

    /// <summary>
    /// Gets or sets the tooltip.
    /// </summary>
    [JsonPropertyName("tooltip")]
    public string? TooltipText
    {
        get => GetProperty<string>(nameof(TooltipText));
        set => SetProperty(nameof(TooltipText), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether autofocus is enabled.
    /// </summary>
    [JsonPropertyName("autofocus")]
    public bool? Autofocus
    {
        get => GetProperty<bool?>(nameof(Autofocus));
        set => SetProperty(nameof(Autofocus), value);
    }

    /// <summary>
    /// Gets or sets the content control (alternative to Icon).
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }
}
