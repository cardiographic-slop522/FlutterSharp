using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A text span used for rich text formatting.
/// Can contain text, nested spans, and styling.
/// For the object to be useful, at least one of Text or Spans should be set.
/// Corresponds to Flutter's TextSpan widget.
/// </summary>
[Control("TextSpan", Category = "core")]
public sealed class TextSpan : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextSpan"/> class.
    /// </summary>
    public TextSpan()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TextSpan"/> class with text.
    /// </summary>
    /// <param name="text">The text contained in this span.</param>
    public TextSpan(string? text = null)
    {
        if (text != null) Text = text;
    }

    /// <summary>
    /// Gets or sets the text contained in this span.
    /// If both Text and Spans are defined, the Text takes precedence.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text
    {
        get => GetProperty<string>(nameof(Text));
        set => SetProperty(nameof(Text), value);
    }

    /// <summary>
    /// Gets or sets the URL to open when this span is clicked.
    /// If Click event callback is provided, it is fired after opening the URL.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url
    {
        get => GetProperty<string>(nameof(Url));
        set => SetProperty(nameof(Url), value);
    }

    /// <summary>
    /// Gets or sets an alternative semantics label for this text.
    /// If present, the semantics of this control will contain this value instead of the actual text.
    /// </summary>
    [JsonPropertyName("semanticsLabel")]
    public string? SemanticsLabel
    {
        get => GetProperty<string>(nameof(SemanticsLabel));
        set => SetProperty(nameof(SemanticsLabel), value);
    }

    /// <summary>
    /// Gets or sets whether the assistive technologies should spell out this text character by character.
    /// If the text is 'hello world', setting this to true causes assistive technologies to pronounce 'h-e-l-l-o-space-w-o-r-l-d'.
    /// This is useful for passwords or verification codes.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("spellOut")]
    public bool? SpellOut
    {
        get => GetProperty<bool?>(nameof(SpellOut));
        set => SetProperty(nameof(SpellOut), value);
    }

    /// <summary>
    /// Occurs when this span is clicked.
    /// Note: This hides the Click event from the base Control class.
    /// TextSpan uses Click to provide span-specific click handling for rich text.
    /// </summary>
    public new event EventHandler? Click;

    /// <summary>
    /// Occurs when a mouse pointer has entered this span.
    /// </summary>
    public event EventHandler? Enter;

    /// <summary>
    /// Occurs when a mouse pointer has exited this span.
    /// </summary>
    public event EventHandler? Exit;
}
