using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Helps the user make a selection by entering some text and choosing from among a list of displayed options.
/// Corresponds to Flutter's AutoComplete widget.
/// </summary>
[Control("AutoComplete", Category = "material")]
public sealed class AutoComplete : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AutoComplete"/> class.
    /// </summary>
    public AutoComplete()
    {
    }

    /// <summary>
    /// Gets or sets the current text displayed in the input field.
    /// This value reflects user input even if it does not match any provided suggestion.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value
    {
        get => GetProperty<string>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets the maximum visual height of the suggestions list.
    /// Defaults to 200.
    /// </summary>
    [JsonPropertyName("suggestionsMaxHeight")]
    public double? SuggestionsMaxHeight
    {
        get => GetProperty<double?>(nameof(SuggestionsMaxHeight));
        set => SetProperty(nameof(SuggestionsMaxHeight), value);
    }

    /// <summary>
    /// Occurs when a suggestion is selected.
    /// </summary>
    public event EventHandler? Select;

    /// <summary>
    /// Occurs when the input text changes.
    /// </summary>
    public event EventHandler? Change;
}
