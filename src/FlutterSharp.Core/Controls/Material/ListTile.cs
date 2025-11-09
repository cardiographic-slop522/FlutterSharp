using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A single fixed-height row that typically contains some text as well as a leading or trailing icon.
/// Corresponds to Flutter's ListTile widget.
/// </summary>
[Control("ListTile", Category = "material")]
public sealed class ListTile : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListTile"/> class.
    /// </summary>
    public ListTile()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ListTile"/> class with title.
    /// </summary>
    /// <param name="title">The primary content text.</param>
    /// <param name="onClick">Optional click handler.</param>
    public ListTile(string title, EventHandler? onClick = null)
    {
        Title = title;
        if (onClick != null)
        {
            Click = onClick;
        }
    }

    /// <summary>
    /// Gets or sets the primary content of the list tile.
    /// Can be a string or a BaseControl.
    /// </summary>
    [JsonPropertyName("title")]
    public object? Title
    {
        get => GetProperty<object>(nameof(Title));
        set => SetProperty(nameof(Title), value);
    }

    /// <summary>
    /// Gets or sets the additional content displayed below the title.
    /// Can be a string or a BaseControl.
    /// </summary>
    [JsonPropertyName("subtitle")]
    public object? Subtitle
    {
        get => GetProperty<object>(nameof(Subtitle));
        set => SetProperty(nameof(Subtitle), value);
    }

    /// <summary>
    /// Gets or sets whether this list tile is intended to display three lines of text.
    /// </summary>
    [JsonPropertyName("isThreeLine")]
    public bool? IsThreeLine
    {
        get => GetProperty<bool?>(nameof(IsThreeLine));
        set => SetProperty(nameof(IsThreeLine), value);
    }

    /// <summary>
    /// Gets or sets the control to display before the title.
    /// </summary>
    [JsonPropertyName("leading")]
    public BaseControl? Leading
    {
        get => GetProperty<BaseControl>(nameof(Leading));
        set => SetProperty(nameof(Leading), value);
    }

    /// <summary>
    /// Gets or sets the control to display after the title.
    /// </summary>
    [JsonPropertyName("trailing")]
    public BaseControl? Trailing
    {
        get => GetProperty<BaseControl>(nameof(Trailing));
        set => SetProperty(nameof(Trailing), value);
    }

    /// <summary>
    /// Gets or sets the tile's internal padding.
    /// </summary>
    [JsonPropertyName("contentPadding")]
    public string? ContentPadding
    {
        get => GetProperty<string>(nameof(ContentPadding));
        set => SetProperty(nameof(ContentPadding), value);
    }

    /// <summary>
    /// Gets or sets the list tile's background color.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the list tile's splash color after the control has been tapped.
    /// </summary>
    [JsonPropertyName("splashColor")]
    public string? SplashColor
    {
        get => GetProperty<string>(nameof(SplashColor));
        set => SetProperty(nameof(SplashColor), value);
    }

    /// <summary>
    /// Gets or sets the tile's color when hovered.
    /// </summary>
    [JsonPropertyName("hoverColor")]
    public string? HoverColor
    {
        get => GetProperty<string>(nameof(HoverColor));
        set => SetProperty(nameof(HoverColor), value);
    }

    /// <summary>
    /// Gets or sets whether this tile is selected.
    /// If this tile is also enabled then icons and text are rendered with the same color.
    /// </summary>
    [JsonPropertyName("selected")]
    public bool? Selected
    {
        get => GetProperty<bool?>(nameof(Selected));
        set => SetProperty(nameof(Selected), value);
    }

    /// <summary>
    /// Gets or sets whether this list tile is part of a vertically dense list.
    /// Dense list tiles default to a smaller height.
    /// </summary>
    [JsonPropertyName("dense")]
    public bool? Dense
    {
        get => GetProperty<bool?>(nameof(Dense));
        set => SetProperty(nameof(Dense), value);
    }

    /// <summary>
    /// Gets or sets whether the control will be selected as the initial focus.
    /// </summary>
    [JsonPropertyName("autofocus")]
    public bool? Autofocus
    {
        get => GetProperty<bool?>(nameof(Autofocus));
        set => SetProperty(nameof(Autofocus), value);
    }

    /// <summary>
    /// Gets or sets whether clicking on a list tile should toggle the state of Radio, Checkbox or Switch inside this tile.
    /// </summary>
    [JsonPropertyName("toggleInputs")]
    public bool? ToggleInputs
    {
        get => GetProperty<bool?>(nameof(ToggleInputs));
        set => SetProperty(nameof(ToggleInputs), value);
    }

    /// <summary>
    /// Gets or sets the color used for icons and text when selected is true.
    /// </summary>
    [JsonPropertyName("selectedColor")]
    public string? SelectedColor
    {
        get => GetProperty<string>(nameof(SelectedColor));
        set => SetProperty(nameof(SelectedColor), value);
    }

    /// <summary>
    /// Gets or sets the background color of ListTile when selected is true.
    /// </summary>
    [JsonPropertyName("selectedTileColor")]
    public string? SelectedTileColor
    {
        get => GetProperty<string>(nameof(SelectedTileColor));
        set => SetProperty(nameof(SelectedTileColor), value);
    }

    /// <summary>
    /// Gets or sets the font used for the title.
    /// Values: "list", "drawer"
    /// </summary>
    [JsonPropertyName("style")]
    public string? Style
    {
        get => GetProperty<string>(nameof(Style));
        set => SetProperty(nameof(Style), value);
    }

    /// <summary>
    /// Gets or sets whether detected gestures should provide acoustic and/or haptic feedback.
    /// </summary>
    [JsonPropertyName("enableFeedback")]
    public bool? EnableFeedback
    {
        get => GetProperty<bool?>(nameof(EnableFeedback));
        set => SetProperty(nameof(EnableFeedback), value);
    }

    /// <summary>
    /// Gets or sets the horizontal gap between the title and the leading and trailing controls.
    /// </summary>
    [JsonPropertyName("horizontalSpacing")]
    public double? HorizontalSpacing
    {
        get => GetProperty<double?>(nameof(HorizontalSpacing));
        set => SetProperty(nameof(HorizontalSpacing), value);
    }

    /// <summary>
    /// Gets or sets the minimum width allocated for the leading control.
    /// </summary>
    [JsonPropertyName("minLeadingWidth")]
    public double? MinLeadingWidth
    {
        get => GetProperty<double?>(nameof(MinLeadingWidth));
        set => SetProperty(nameof(MinLeadingWidth), value);
    }

    /// <summary>
    /// Gets or sets the minimum padding on the top and bottom of the title and subtitle controls.
    /// </summary>
    [JsonPropertyName("minVerticalPadding")]
    public double? MinVerticalPadding
    {
        get => GetProperty<double?>(nameof(MinVerticalPadding));
        set => SetProperty(nameof(MinVerticalPadding), value);
    }

    /// <summary>
    /// Gets or sets the URL to open when this button is clicked.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url
    {
        get => GetProperty<string>(nameof(Url));
        set => SetProperty(nameof(Url), value);
    }

    /// <summary>
    /// Gets or sets how leading and trailing are vertically aligned relative to the titles.
    /// Values: "top", "center", "bottom", "threeLine", "titleHeight"
    /// </summary>
    [JsonPropertyName("titleAlignment")]
    public string? TitleAlignment
    {
        get => GetProperty<string>(nameof(TitleAlignment));
        set => SetProperty(nameof(TitleAlignment), value);
    }

    /// <summary>
    /// Gets or sets the default color for the icons present in leading and trailing.
    /// </summary>
    [JsonPropertyName("iconColor")]
    public string? IconColor
    {
        get => GetProperty<string>(nameof(IconColor));
        set => SetProperty(nameof(IconColor), value);
    }

    /// <summary>
    /// Gets or sets the color used for texts in title, subtitle, leading, and trailing.
    /// </summary>
    [JsonPropertyName("textColor")]
    public string? TextColor
    {
        get => GetProperty<string>(nameof(TextColor));
        set => SetProperty(nameof(TextColor), value);
    }

    /// <summary>
    /// Gets or sets the tile's shape.
    /// </summary>
    [JsonPropertyName("shape")]
    public string? Shape
    {
        get => GetProperty<string>(nameof(Shape));
        set => SetProperty(nameof(Shape), value);
    }

    /// <summary>
    /// Gets or sets the mouse cursor to be displayed when hovering over this control.
    /// </summary>
    [JsonPropertyName("mouseCursor")]
    public string? MouseCursor
    {
        get => GetProperty<string>(nameof(MouseCursor));
        set => SetProperty(nameof(MouseCursor), value);
    }

    /// <summary>
    /// Gets or sets the minimum height allocated for this control.
    /// </summary>
    [JsonPropertyName("minHeight")]
    public double? MinHeight
    {
        get => GetProperty<double?>(nameof(MinHeight));
        set => SetProperty(nameof(MinHeight), value);
    }
}
