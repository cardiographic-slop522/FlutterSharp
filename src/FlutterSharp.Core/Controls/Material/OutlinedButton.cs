using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design outlined button.
/// Corresponds to Flutter's OutlinedButton widget.
/// </summary>
[Control("OutlinedButton", Category = "material")]
public sealed class OutlinedButton : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OutlinedButton"/> class.
    /// </summary>
    public OutlinedButton()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OutlinedButton"/> class with text.
    /// </summary>
    /// <param name="text">The button text.</param>
    /// <param name="onClick">Optional click handler.</param>
    public OutlinedButton(string text, EventHandler? onClick = null)
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
    /// Gets or sets the color.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color
    {
        get => GetProperty<string>(nameof(Color));
        set => SetProperty(nameof(Color), value);
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
    /// Gets or sets the content control (alternative to Text).
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }
}
