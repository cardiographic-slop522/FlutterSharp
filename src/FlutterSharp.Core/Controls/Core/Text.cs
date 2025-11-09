using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A control that displays text.
/// Corresponds to Flutter's Text widget.
/// </summary>
[Control("Text", Category = "display")]
public sealed class Text : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Text"/> class.
    /// </summary>
    public Text()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Text"/> class with the specified value.
    /// </summary>
    /// <param name="value">The text to display.</param>
    public Text(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets or sets the text value to display.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value
    {
        get => GetProperty<string>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets the text size in pixels.
    /// </summary>
    [JsonPropertyName("size")]
    public double? Size
    {
        get => GetProperty<double?>(nameof(Size));
        set => SetProperty(nameof(Size), value);
    }

    /// <summary>
    /// Gets or sets the text color.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color
    {
        get => GetProperty<string>(nameof(Color));
        set => SetProperty(nameof(Color), value);
    }

    /// <summary>
    /// Gets or sets the font weight.
    /// Values: "normal", "bold", "w100"-"w900"
    /// </summary>
    [JsonPropertyName("weight")]
    public string? Weight
    {
        get => GetProperty<string>(nameof(Weight));
        set => SetProperty(nameof(Weight), value);
    }

    /// <summary>
    /// Gets or sets the font style.
    /// Values: "normal", "italic"
    /// </summary>
    [JsonPropertyName("italic")]
    public bool? Italic
    {
        get => GetProperty<bool?>(nameof(Italic));
        set => SetProperty(nameof(Italic), value);
    }

    /// <summary>
    /// Gets or sets the text alignment.
    /// Values: "left", "right", "center", "justify"
    /// </summary>
    [JsonPropertyName("textAlign")]
    public string? TextAlign
    {
        get => GetProperty<string>(nameof(TextAlign));
        set => SetProperty(nameof(TextAlign), value);
    }

    /// <summary>
    /// Gets or sets the maximum number of lines.
    /// </summary>
    [JsonPropertyName("maxLines")]
    public int? MaxLines
    {
        get => GetProperty<int?>(nameof(MaxLines));
        set => SetProperty(nameof(MaxLines), value);
    }

    /// <summary>
    /// Gets or sets the text overflow behavior.
    /// Values: "clip", "ellipsis", "fade", "visible"
    /// </summary>
    [JsonPropertyName("overflow")]
    public string? Overflow
    {
        get => GetProperty<string>(nameof(Overflow));
        set => SetProperty(nameof(Overflow), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the text should be selectable.
    /// </summary>
    [JsonPropertyName("selectable")]
    public bool? Selectable
    {
        get => GetProperty<bool?>(nameof(Selectable));
        set => SetProperty(nameof(Selectable), value);
    }
}
