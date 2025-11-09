using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design text field for user input.
/// Corresponds to Flutter's TextField widget.
/// </summary>
[Control("TextField", Category = "material")]
public sealed class TextField : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextField"/> class.
    /// </summary>
    public TextField()
    {
    }

    /// <summary>
    /// Gets or sets the current text value.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value
    {
        get => GetProperty<string>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets the label text.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label
    {
        get => GetProperty<string>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }

    /// <summary>
    /// Gets or sets the hint text (placeholder).
    /// </summary>
    [JsonPropertyName("hint")]
    public string? Hint
    {
        get => GetProperty<string>(nameof(Hint));
        set => SetProperty(nameof(Hint), value);
    }

    /// <summary>
    /// Gets or sets the helper text displayed below the field.
    /// </summary>
    [JsonPropertyName("helperText")]
    public string? HelperText
    {
        get => GetProperty<string>(nameof(HelperText));
        set => SetProperty(nameof(HelperText), value);
    }

    /// <summary>
    /// Gets or sets the error text displayed when validation fails.
    /// </summary>
    [JsonPropertyName("errorText")]
    public string? ErrorText
    {
        get => GetProperty<string>(nameof(ErrorText));
        set => SetProperty(nameof(ErrorText), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the field is read-only.
    /// </summary>
    [JsonPropertyName("readOnly")]
    public bool? ReadOnly
    {
        get => GetProperty<bool?>(nameof(ReadOnly));
        set => SetProperty(nameof(ReadOnly), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the text should be obscured (for passwords).
    /// </summary>
    [JsonPropertyName("password")]
    public bool? Password
    {
        get => GetProperty<bool?>(nameof(Password));
        set => SetProperty(nameof(Password), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the field can have multiple lines.
    /// </summary>
    [JsonPropertyName("multiline")]
    public bool? Multiline
    {
        get => GetProperty<bool?>(nameof(Multiline));
        set => SetProperty(nameof(Multiline), value);
    }

    /// <summary>
    /// Gets or sets the minimum number of lines for multiline fields.
    /// </summary>
    [JsonPropertyName("minLines")]
    public int? MinLines
    {
        get => GetProperty<int?>(nameof(MinLines));
        set => SetProperty(nameof(MinLines), value);
    }

    /// <summary>
    /// Gets or sets the maximum number of lines for multiline fields.
    /// </summary>
    [JsonPropertyName("maxLines")]
    public int? MaxLines
    {
        get => GetProperty<int?>(nameof(MaxLines));
        set => SetProperty(nameof(MaxLines), value);
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
    /// Gets or sets the keyboard type.
    /// Values: "text", "multiline", "number", "phone", "datetime", "email", "url"
    /// </summary>
    [JsonPropertyName("keyboardType")]
    public string? KeyboardType
    {
        get => GetProperty<string>(nameof(KeyboardType));
        set => SetProperty(nameof(KeyboardType), value);
    }

    /// <summary>
    /// Gets or sets the text capitalization mode.
    /// Values: "none", "characters", "words", "sentences"
    /// </summary>
    [JsonPropertyName("capitalization")]
    public string? Capitalization
    {
        get => GetProperty<string>(nameof(Capitalization));
        set => SetProperty(nameof(Capitalization), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether autocorrect is enabled.
    /// </summary>
    [JsonPropertyName("autocorrect")]
    public bool? Autocorrect
    {
        get => GetProperty<bool?>(nameof(Autocorrect));
        set => SetProperty(nameof(Autocorrect), value);
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
    /// Gets or sets the prefix icon.
    /// </summary>
    [JsonPropertyName("prefixIcon")]
    public string? PrefixIcon
    {
        get => GetProperty<string>(nameof(PrefixIcon));
        set => SetProperty(nameof(PrefixIcon), value);
    }

    /// <summary>
    /// Gets or sets the suffix icon.
    /// </summary>
    [JsonPropertyName("suffixIcon")]
    public string? SuffixIcon
    {
        get => GetProperty<string>(nameof(SuffixIcon));
        set => SetProperty(nameof(SuffixIcon), value);
    }

    /// <summary>
    /// Event handler for when the text changes.
    /// </summary>
    public event EventHandler<TextChangedEventArgs>? Changed;

    /// <summary>
    /// Event handler for when the user submits the field.
    /// </summary>
    public event EventHandler? Submitted;

    /// <summary>
    /// Handles events specific to TextField.
    /// </summary>
    public override void HandleEvent(string eventName, Dictionary<string, object>? eventData = null)
    {
        switch (eventName.ToLowerInvariant())
        {
            case "change":
                if (eventData?.TryGetValue("value", out var value) == true && value is string text)
                {
                    Value = text;
                    Changed?.Invoke(this, new TextChangedEventArgs { Text = text });
                }
                break;

            case "submit":
                Submitted?.Invoke(this, EventArgs.Empty);
                break;

            default:
                base.HandleEvent(eventName, eventData);
                break;
        }
    }
}

/// <summary>
/// Event arguments for text changed events.
/// </summary>
public sealed class TextChangedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the new text value.
    /// </summary>
    public required string Text { get; init; }
}
