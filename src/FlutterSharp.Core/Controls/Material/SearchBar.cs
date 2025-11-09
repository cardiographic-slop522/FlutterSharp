using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Manages a "search view" route that allows the user to select one of the suggested
/// completions for a search query.
/// Corresponds to Flutter's SearchBar widget.
/// </summary>
[Control("SearchBar", Category = "material", IsContainer = true)]
public sealed class SearchBar : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SearchBar"/> class.
    /// </summary>
    public SearchBar()
    {
    }

    /// <summary>
    /// Gets or sets the text in the search bar.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value
    {
        get => GetProperty<string>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets a control to display before the text input field when the search view is closed.
    /// Typically an Icon or IconButton.
    /// </summary>
    [JsonPropertyName("barLeading")]
    public BaseControl? BarLeading
    {
        get => GetProperty<BaseControl>(nameof(BarLeading));
        set => SetProperty(nameof(BarLeading), value);
    }

    /// <summary>
    /// Gets or sets the hint text to be shown in the search bar when it is empty and the search view is closed.
    /// </summary>
    [JsonPropertyName("barHintText")]
    public string? BarHintText
    {
        get => GetProperty<string>(nameof(BarHintText));
        set => SetProperty(nameof(BarHintText), value);
    }

    /// <summary>
    /// Gets or sets the background color of the search bar.
    /// </summary>
    [JsonPropertyName("barBgcolor")]
    public string? BarBackgroundColor
    {
        get => GetProperty<string>(nameof(BarBackgroundColor));
        set => SetProperty(nameof(BarBackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the highlight color that's typically used to indicate that the search bar is focused, hovered, or pressed.
    /// </summary>
    [JsonPropertyName("barOverlayColor")]
    public string? BarOverlayColor
    {
        get => GetProperty<string>(nameof(BarOverlayColor));
        set => SetProperty(nameof(BarOverlayColor), value);
    }

    /// <summary>
    /// Gets or sets the shadow color of the search bar.
    /// </summary>
    [JsonPropertyName("barShadowColor")]
    public string? BarShadowColor
    {
        get => GetProperty<string>(nameof(BarShadowColor));
        set => SetProperty(nameof(BarShadowColor), value);
    }

    /// <summary>
    /// Gets or sets the elevation of the search bar.
    /// </summary>
    [JsonPropertyName("barElevation")]
    public double? BarElevation
    {
        get => GetProperty<double?>(nameof(BarElevation));
        set => SetProperty(nameof(BarElevation), value);
    }

    /// <summary>
    /// Gets or sets the shape of the search bar.
    /// </summary>
    [JsonPropertyName("barShape")]
    public string? BarShape
    {
        get => GetProperty<string>(nameof(BarShape));
        set => SetProperty(nameof(BarShape), value);
    }

    /// <summary>
    /// Gets or sets the text style to use for the text being edited.
    /// </summary>
    [JsonPropertyName("barTextStyle")]
    public string? BarTextStyle
    {
        get => GetProperty<string>(nameof(BarTextStyle));
        set => SetProperty(nameof(BarTextStyle), value);
    }

    /// <summary>
    /// Gets or sets the text style to use for the hint text.
    /// </summary>
    [JsonPropertyName("barHintTextStyle")]
    public string? BarHintTextStyle
    {
        get => GetProperty<string>(nameof(BarHintTextStyle));
        set => SetProperty(nameof(BarHintTextStyle), value);
    }

    /// <summary>
    /// Gets or sets the padding between the search bar's boundary and its contents.
    /// </summary>
    [JsonPropertyName("barPadding")]
    public string? BarPadding
    {
        get => GetProperty<string>(nameof(BarPadding));
        set => SetProperty(nameof(BarPadding), value);
    }

    /// <summary>
    /// Gets or sets a control to display before the text input field when the search view is open.
    /// Typically an Icon or IconButton. Defaults to a back button which closes the search view.
    /// </summary>
    [JsonPropertyName("viewLeading")]
    public BaseControl? ViewLeading
    {
        get => GetProperty<BaseControl>(nameof(ViewLeading));
        set => SetProperty(nameof(ViewLeading), value);
    }

    /// <summary>
    /// Gets or sets the hint text to be shown in the search view when it is empty.
    /// </summary>
    [JsonPropertyName("viewHintText")]
    public string? ViewHintText
    {
        get => GetProperty<string>(nameof(ViewHintText));
        set => SetProperty(nameof(ViewHintText), value);
    }

    /// <summary>
    /// Gets or sets the background color of the search view.
    /// </summary>
    [JsonPropertyName("viewBgcolor")]
    public string? ViewBackgroundColor
    {
        get => GetProperty<string>(nameof(ViewBackgroundColor));
        set => SetProperty(nameof(ViewBackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the elevation of the search view.
    /// </summary>
    [JsonPropertyName("viewElevation")]
    public double? ViewElevation
    {
        get => GetProperty<double?>(nameof(ViewElevation));
        set => SetProperty(nameof(ViewElevation), value);
    }

    /// <summary>
    /// Gets or sets whether to show a fullscreen scrim when the search view is open.
    /// </summary>
    [JsonPropertyName("fullScreen")]
    public bool? FullScreen
    {
        get => GetProperty<bool?>(nameof(FullScreen));
        set => SetProperty(nameof(FullScreen), value);
    }

    /// <summary>
    /// Gets or sets the text capitalization behavior.
    /// Values: "none", "characters", "words", "sentences"
    /// </summary>
    [JsonPropertyName("capitalization")]
    public string? Capitalization
    {
        get => GetProperty<string>(nameof(Capitalization));
        set => SetProperty(nameof(Capitalization), value);
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
    /// Occurs when the text in the search bar changes.
    /// </summary>
    public event EventHandler? Change;

    /// <summary>
    /// Occurs when the user submits the search query.
    /// </summary>
    public event EventHandler? Submit;

    /// <summary>
    /// Occurs when the user taps on the search bar.
    /// </summary>
    public event EventHandler? Tap;
}
