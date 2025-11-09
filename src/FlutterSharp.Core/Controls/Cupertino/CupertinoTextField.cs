using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Cupertino;

/// <summary>
/// An iOS-style text field.
/// Provides a text input with iOS design language including rounded corners and subtle shadows.
/// Corresponds to Flutter's CupertinoTextField widget.
/// </summary>
[Control("CupertinoTextField", Category = "cupertino")]
public sealed class CupertinoTextField : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoTextField"/> class.
    /// </summary>
    public CupertinoTextField()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoTextField"/> class with a value.
    /// </summary>
    /// <param name="value">The initial value of this text field.</param>
    public CupertinoTextField(string? value = null)
    {
        if (value != null) Value = value;
    }

    /// <summary>
    /// Gets or sets the current value of this text field.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value
    {
        get => GetProperty<string>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets a lighter colored placeholder hint that appears on the first line when the text entry is empty.
    /// Defaults to an empty string.
    /// </summary>
    [JsonPropertyName("placeholderText")]
    public string? PlaceholderText
    {
        get => GetProperty<string>(nameof(PlaceholderText));
        set => SetProperty(nameof(PlaceholderText), value);
    }

    /// <summary>
    /// Gets or sets the text style to use for the placeholder text.
    /// </summary>
    [JsonPropertyName("placeholderStyle")]
    public string? PlaceholderStyle
    {
        get => GetProperty<string>(nameof(PlaceholderStyle));
        set => SetProperty(nameof(PlaceholderStyle), value);
    }

    /// <summary>
    /// Gets or sets the gradient background configuration.
    /// </summary>
    [JsonPropertyName("gradient")]
    public string? Gradient
    {
        get => GetProperty<string>(nameof(Gradient));
        set => SetProperty(nameof(Gradient), value);
    }

    /// <summary>
    /// Gets or sets the blend mode applied to the bgcolor or gradient background.
    /// Values: "clear", "src", "dst", "srcOver", "dstOver", "srcIn", "dstIn", "srcOut", "dstOut", "srcATop", "dstATop", "xor", "plus", "modulate", "screen", "overlay", "darken", "lighten", "colorDodge", "colorBurn", "hardLight", "softLight", "difference", "exclusion", "multiply", "hue", "saturation", "color", "luminosity"
    /// </summary>
    [JsonPropertyName("blendMode")]
    public string? BlendMode
    {
        get => GetProperty<string>(nameof(BlendMode));
        set => SetProperty(nameof(BlendMode), value);
    }

    /// <summary>
    /// Gets or sets a list of shadows behind this text field.
    /// </summary>
    [JsonPropertyName("shadows")]
    public string? Shadows
    {
        get => GetProperty<string>(nameof(Shadows));
        set => SetProperty(nameof(Shadows), value);
    }

    /// <summary>
    /// Gets or sets the visibility of the prefix control based on the state of text entry.
    /// Values: "never", "editing", "notEditing", "always"
    /// Defaults to "always".
    /// </summary>
    [JsonPropertyName("prefixVisibilityMode")]
    public string? PrefixVisibilityMode
    {
        get => GetProperty<string>(nameof(PrefixVisibilityMode));
        set => SetProperty(nameof(PrefixVisibilityMode), value);
    }

    /// <summary>
    /// Gets or sets the visibility of the suffix control based on the state of text entry.
    /// Values: "never", "editing", "notEditing", "always"
    /// Defaults to "always".
    /// </summary>
    [JsonPropertyName("suffixVisibilityMode")]
    public string? SuffixVisibilityMode
    {
        get => GetProperty<string>(nameof(SuffixVisibilityMode));
        set => SetProperty(nameof(SuffixVisibilityMode), value);
    }

    /// <summary>
    /// Gets or sets the visibility of the clear button based on the state of text entry.
    /// Will appear only if no suffix is provided.
    /// Values: "never", "editing", "notEditing", "always"
    /// Defaults to "never".
    /// </summary>
    [JsonPropertyName("clearButtonVisibilityMode")]
    public string? ClearButtonVisibilityMode
    {
        get => GetProperty<string>(nameof(ClearButtonVisibilityMode));
        set => SetProperty(nameof(ClearButtonVisibilityMode), value);
    }

    /// <summary>
    /// Gets or sets the semantic label for the clear button used by screen readers.
    /// This will be used by screen reading software to identify the clear button widget.
    /// Defaults to "Clear".
    /// </summary>
    [JsonPropertyName("clearButtonSemanticsLabel")]
    public string? ClearButtonSemanticsLabel
    {
        get => GetProperty<string>(nameof(ClearButtonSemanticsLabel));
        set => SetProperty(nameof(ClearButtonSemanticsLabel), value);
    }

    /// <summary>
    /// Gets or sets an image to paint above the bgcolor or gradient background.
    /// </summary>
    [JsonPropertyName("image")]
    public string? Image
    {
        get => GetProperty<string>(nameof(Image));
        set => SetProperty(nameof(Image), value);
    }

    /// <summary>
    /// Gets or sets the padding around the text entry area.
    /// The padding is between the prefix and suffix or the clear button.
    /// Defaults to padding of 7 on all sides.
    /// </summary>
    [JsonPropertyName("padding")]
    public string? Padding
    {
        get => GetProperty<string>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets the keyboard type for this text field.
    /// Values: "text", "multiline", "number", "phone", "datetime", "email", "url", "visiblePassword", "name", "streetAddress", "none"
    /// </summary>
    [JsonPropertyName("keyboardType")]
    public string? KeyboardType
    {
        get => GetProperty<string>(nameof(KeyboardType));
        set => SetProperty(nameof(KeyboardType), value);
    }

    /// <summary>
    /// Gets or sets whether this text field is read-only.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("readOnly")]
    public bool? ReadOnly
    {
        get => GetProperty<bool?>(nameof(ReadOnly));
        set => SetProperty(nameof(ReadOnly), value);
    }

    /// <summary>
    /// Gets or sets whether this text field should be obscured (for passwords).
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("password")]
    public bool? Password
    {
        get => GetProperty<bool?>(nameof(Password));
        set => SetProperty(nameof(Password), value);
    }

    /// <summary>
    /// Gets or sets whether this text field supports multiline input.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("multiline")]
    public bool? Multiline
    {
        get => GetProperty<bool?>(nameof(Multiline));
        set => SetProperty(nameof(Multiline), value);
    }

    /// <summary>
    /// Gets or sets the maximum number of lines for this text field.
    /// </summary>
    [JsonPropertyName("maxLines")]
    public int? MaxLines
    {
        get => GetProperty<int?>(nameof(MaxLines));
        set => SetProperty(nameof(MaxLines), value);
    }

    /// <summary>
    /// Gets or sets the minimum number of lines for this text field.
    /// </summary>
    [JsonPropertyName("minLines")]
    public int? MinLines
    {
        get => GetProperty<int?>(nameof(MinLines));
        set => SetProperty(nameof(MinLines), value);
    }

    /// <summary>
    /// Gets or sets the maximum length of the text.
    /// </summary>
    [JsonPropertyName("maxLength")]
    public int? MaxLength
    {
        get => GetProperty<int?>(nameof(MaxLength));
        set => SetProperty(nameof(MaxLength), value);
    }

    /// <summary>
    /// Gets or sets whether this text field should have autocorrect enabled.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("autocorrect")]
    public bool? Autocorrect
    {
        get => GetProperty<bool?>(nameof(Autocorrect));
        set => SetProperty(nameof(Autocorrect), value);
    }

    /// <summary>
    /// Gets or sets the border color of this text field.
    /// </summary>
    [JsonPropertyName("borderColor")]
    public string? BorderColor
    {
        get => GetProperty<string>(nameof(BorderColor));
        set => SetProperty(nameof(BorderColor), value);
    }

    /// <summary>
    /// Gets or sets the border radius of this text field.
    /// </summary>
    [JsonPropertyName("borderRadius")]
    public string? BorderRadius
    {
        get => GetProperty<string>(nameof(BorderRadius));
        set => SetProperty(nameof(BorderRadius), value);
    }

    /// <summary>
    /// Gets or sets the text alignment for this text field.
    /// Values: "left", "right", "center", "justify", "start", "end"
    /// Defaults to "start".
    /// </summary>
    [JsonPropertyName("textAlign")]
    public string? TextAlign
    {
        get => GetProperty<string>(nameof(TextAlign));
        set => SetProperty(nameof(TextAlign), value);
    }

    /// <summary>
    /// Occurs when the text value of this text field changes.
    /// </summary>
    public event EventHandler? Change;

    /// <summary>
    /// Occurs when this text field receives focus.
    /// </summary>
    public event EventHandler? Focus;

    /// <summary>
    /// Occurs when this text field loses focus.
    /// </summary>
    public event EventHandler? Blur;

    /// <summary>
    /// Occurs when the user submits this text field (presses Enter).
    /// </summary>
    public event EventHandler? Submit;
}
