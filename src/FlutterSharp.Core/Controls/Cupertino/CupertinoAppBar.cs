using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Cupertino;

/// <summary>
/// An iOS-styled app bar.
/// Provides a navigation bar at the top of the screen with iOS design language.
/// The alignment of the title depends on whether this app bar is large or not.
/// If large is true, the title is left-aligned; if false (the default), the title is centered.
/// Corresponds to Flutter's CupertinoAppBar widget.
/// </summary>
[Control("CupertinoAppBar", Category = "cupertino")]
public sealed class CupertinoAppBar : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoAppBar"/> class.
    /// </summary>
    public CupertinoAppBar()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoAppBar"/> class with a title.
    /// </summary>
    /// <param name="title">The title to display in the middle of this app bar.</param>
    public CupertinoAppBar(object? title = null)
    {
        if (title != null) Title = title;
    }

    /// <summary>
    /// Gets or sets a control to display at the start of this app bar.
    /// Typically the leading control is an Icon or an IconButton.
    /// If it is null and AutomaticallyImplyLeading is true, an appropriate button will be automatically created.
    /// </summary>
    [JsonPropertyName("leading")]
    public BaseControl? Leading
    {
        get => GetProperty<BaseControl>(nameof(Leading));
        set => SetProperty(nameof(Leading), value);
    }

    /// <summary>
    /// Gets or sets a string or a control to display in the middle of this app bar.
    /// Can be a string or a control (typically Text).
    /// </summary>
    [JsonPropertyName("title")]
    public object? Title
    {
        get => GetProperty<object>(nameof(Title));
        set => SetProperty(nameof(Title), value);
    }

    /// <summary>
    /// Gets or sets a control to place at the end of the app bar.
    /// Typically used for actions such as searching or editing.
    /// </summary>
    [JsonPropertyName("trailing")]
    public BaseControl? Trailing
    {
        get => GetProperty<BaseControl>(nameof(Trailing));
        set => SetProperty(nameof(Trailing), value);
    }

    /// <summary>
    /// Gets or sets the fill color to use for this app bar.
    /// Default color is defined by current theme.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BgColor
    {
        get => GetProperty<string>(nameof(BgColor));
        set => SetProperty(nameof(BgColor), value);
    }

    /// <summary>
    /// Gets or sets whether we should try to imply the leading control if null.
    /// If true and Leading is null, the app bar will automatically determine an appropriate leading control.
    /// If false and Leading is null, the space is allocated to the Title.
    /// If a Leading control is provided, this parameter has no effect.
    /// </summary>
    [JsonPropertyName("automaticallyImplyLeading")]
    public bool? AutomaticallyImplyLeading
    {
        get => GetProperty<bool?>(nameof(AutomaticallyImplyLeading));
        set => SetProperty(nameof(AutomaticallyImplyLeading), value);
    }

    /// <summary>
    /// Gets or sets whether we should try to imply the title control if null.
    /// If true and Title is null, a Text control containing the current route's title will be automatically filled in.
    /// If the Title is not null, this parameter has no effect.
    /// </summary>
    [JsonPropertyName("automaticallyImplyTitle")]
    public bool? AutomaticallyImplyTitle
    {
        get => GetProperty<bool?>(nameof(AutomaticallyImplyTitle));
        set => SetProperty(nameof(AutomaticallyImplyTitle), value);
    }

    /// <summary>
    /// Gets or sets the border of the app bar.
    /// By default, a single pixel bottom border side is rendered.
    /// </summary>
    [JsonPropertyName("border")]
    public string? Border
    {
        get => GetProperty<string>(nameof(Border));
        set => SetProperty(nameof(Border), value);
    }

    /// <summary>
    /// Gets or sets the padding for the contents of the app bar.
    /// If null, the app bar will adopt iOS default padding specifications.
    /// Note: Vertical padding (top and bottom) won't change the height of this app bar.
    /// </summary>
    [JsonPropertyName("padding")]
    public string? Padding
    {
        get => GetProperty<string>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets whether the app bar transitions between routes.
    /// If true, this app bar will animate on top of route transitions when the destination route also contains a CupertinoAppBar.
    /// This transition also occurs during edge back swipe gestures, mimicking native iOS behavior.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("transitionBetweenRoutes")]
    public bool? TransitionBetweenRoutes
    {
        get => GetProperty<bool?>(nameof(TransitionBetweenRoutes));
        set => SetProperty(nameof(TransitionBetweenRoutes), value);
    }

    /// <summary>
    /// Gets or sets the previous route's title when automatically implying the leading back button.
    /// Overrides the text shown with the back chevron instead of automatically showing the previous route's title.
    /// Has no effect if Leading is not null or if AutomaticallyImplyLeading is false.
    /// </summary>
    [JsonPropertyName("previousPageTitle")]
    public string? PreviousPageTitle
    {
        get => GetProperty<string>(nameof(PreviousPageTitle));
        set => SetProperty(nameof(PreviousPageTitle), value);
    }

    /// <summary>
    /// Gets or sets the brightness of the specified BgColor.
    /// Setting this value changes the style of the system status bar.
    /// Values: "light", "dark"
    /// If null, its value will be inferred from the relative luminance of the BgColor.
    /// </summary>
    [JsonPropertyName("brightness")]
    public string? Brightness
    {
        get => GetProperty<string>(nameof(Brightness));
        set => SetProperty(nameof(Brightness), value);
    }

    /// <summary>
    /// Gets or sets whether the navigation bar should appear transparent when content is scrolled under it.
    /// If false, the navigation bar will display its BgColor.
    /// </summary>
    [JsonPropertyName("automaticBackgroundVisibility")]
    public bool? AutomaticBackgroundVisibility
    {
        get => GetProperty<bool?>(nameof(AutomaticBackgroundVisibility));
        set => SetProperty(nameof(AutomaticBackgroundVisibility), value);
    }

    /// <summary>
    /// Gets or sets whether to have a blur effect when a non-opaque BgColor is used.
    /// This will only be respected when AutomaticBackgroundVisibility is false or until content scrolls under the navigation bar.
    /// </summary>
    [JsonPropertyName("enableBackgroundFilterBlur")]
    public bool? EnableBackgroundFilterBlur
    {
        get => GetProperty<bool?>(nameof(EnableBackgroundFilterBlur));
        set => SetProperty(nameof(EnableBackgroundFilterBlur), value);
    }

    /// <summary>
    /// Gets or sets whether to use a large app bar layout.
    /// If true, the title is left-aligned; if false, the title is centered.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("large")]
    public bool? Large
    {
        get => GetProperty<bool?>(nameof(Large));
        set => SetProperty(nameof(Large), value);
    }
}
