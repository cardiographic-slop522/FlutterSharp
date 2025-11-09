using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A filled tonal button is an alternative middle ground between FilledButton and
/// OutlinedButton buttons. They're useful in contexts where a lower-priority button
/// requires slightly more emphasis than an outline would give, such as "Next" in an
/// onboarding flow. Tonal buttons use the secondary color mapping.
/// Corresponds to Flutter's FilledTonalButton widget.
/// </summary>
[Control("FilledTonalButton", Category = "material")]
public sealed class FilledTonalButton : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FilledTonalButton"/> class.
    /// </summary>
    public FilledTonalButton()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FilledTonalButton"/> class with text.
    /// </summary>
    /// <param name="text">The button text.</param>
    /// <param name="onClick">Optional click handler.</param>
    public FilledTonalButton(string text, EventHandler? onClick = null)
    {
        Text = text;
        if (onClick != null)
        {
            Click = onClick;
        }
    }

    /// <summary>
    /// Gets or sets the button text.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text
    {
        get => GetProperty<string>(nameof(Text));
        set => SetProperty(nameof(Text), value);
    }

    /// <summary>
    /// Gets or sets the icon.
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon
    {
        get => GetProperty<string>(nameof(Icon));
        set => SetProperty(nameof(Icon), value);
    }

    /// <summary>
    /// Gets or sets the content control.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets whether the button will be selected as the initial focus.
    /// </summary>
    [JsonPropertyName("autofocus")]
    public bool? Autofocus
    {
        get => GetProperty<bool?>(nameof(Autofocus));
        set => SetProperty(nameof(Autofocus), value);
    }

    /// <summary>
    /// Gets or sets the URL to open when the button is clicked.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url
    {
        get => GetProperty<string>(nameof(Url));
        set => SetProperty(nameof(Url), value);
    }

    /// <summary>
    /// Gets or sets where to open the URL.
    /// Values: "_blank", "_self"
    /// </summary>
    [JsonPropertyName("urlTarget")]
    public string? UrlTarget
    {
        get => GetProperty<string>(nameof(UrlTarget));
        set => SetProperty(nameof(UrlTarget), value);
    }

    /// <summary>
    /// Gets or sets the button style.
    /// </summary>
    [JsonPropertyName("style")]
    public string? Style
    {
        get => GetProperty<string>(nameof(Style));
        set => SetProperty(nameof(Style), value);
    }
}
