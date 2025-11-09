using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design elevated button.
/// Corresponds to Flutter's ElevatedButton widget.
/// </summary>
[Control("ElevatedButton", Category = "material")]
public sealed class ElevatedButton : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ElevatedButton"/> class.
    /// </summary>
    public ElevatedButton()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ElevatedButton"/> class with the specified text.
    /// </summary>
    /// <param name="text">The button text.</param>
    /// <param name="onClick">Optional click event handler.</param>
    public ElevatedButton(string text, EventHandler? onClick = null)
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
    /// Gets or sets the icon to display before the text.
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon
    {
        get => GetProperty<string>(nameof(Icon));
        set => SetProperty(nameof(Icon), value);
    }

    /// <summary>
    /// Gets or sets the button's background color.
    /// </summary>
    [JsonPropertyName("bgColor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the button's foreground (text/icon) color.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color
    {
        get => GetProperty<string>(nameof(Color));
        set => SetProperty(nameof(Color), value);
    }

    /// <summary>
    /// Gets or sets the button's elevation (shadow depth).
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the button should auto-focus.
    /// </summary>
    [JsonPropertyName("autofocus")]
    public bool? Autofocus
    {
        get => GetProperty<bool?>(nameof(Autofocus));
        set => SetProperty(nameof(Autofocus), value);
    }

    /// <summary>
    /// Gets or sets the content of the button (alternative to Text).
    /// Use this for custom button content.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }
}
