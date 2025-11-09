using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A popup menu item displayed in a PopupMenuButton.
/// Corresponds to Flutter's PopupMenuItem widget.
/// </summary>
[Control("PopupMenuItem", Category = "material")]
public sealed class PopupMenuItem : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PopupMenuItem"/> class.
    /// </summary>
    public PopupMenuItem()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PopupMenuItem"/> class with content.
    /// </summary>
    /// <param name="content">The content of the menu item.</param>
    public PopupMenuItem(object? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the content of this menu item.
    /// Can be a string or a BaseControl.
    /// </summary>
    [JsonPropertyName("content")]
    public object? Content
    {
        get => GetProperty<object>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets an icon to draw before the text label of this menu item.
    /// Can be an icon name string or a BaseControl.
    /// </summary>
    [JsonPropertyName("icon")]
    public object? Icon
    {
        get => GetProperty<object>(nameof(Icon));
        set => SetProperty(nameof(Icon), value);
    }

    /// <summary>
    /// Gets or sets whether this menu item is checked.
    /// If set to true, a checkmark will be shown on the left of the content.
    /// </summary>
    [JsonPropertyName("checked")]
    public bool? Checked
    {
        get => GetProperty<bool?>(nameof(Checked));
        set => SetProperty(nameof(Checked), value);
    }

    /// <summary>
    /// Gets or sets the minimum height of this menu item.
    /// Defaults to 48.0.
    /// Note: This hides the Height property from the base Control class because PopupMenuItem
    /// uses Height to define the minimum item height (not layout height).
    /// </summary>
    [JsonPropertyName("height")]
    public new double? Height
    {
        get => GetProperty<double?>(nameof(Height));
        set => SetProperty(nameof(Height), value);
    }

    /// <summary>
    /// Gets or sets the padding of this menu item.
    /// Defaults to horizontal padding of 12.
    /// </summary>
    [JsonPropertyName("padding")]
    public string? Padding
    {
        get => GetProperty<string>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets the text style of the label of this menu item.
    /// </summary>
    [JsonPropertyName("labelTextStyle")]
    public string? LabelTextStyle
    {
        get => GetProperty<string>(nameof(LabelTextStyle));
        set => SetProperty(nameof(LabelTextStyle), value);
    }

    /// <summary>
    /// Gets or sets the cursor to be displayed when a mouse pointer enters or is hovering over this item.
    /// </summary>
    [JsonPropertyName("mouseCursor")]
    public string? MouseCursor
    {
        get => GetProperty<string>(nameof(MouseCursor));
        set => SetProperty(nameof(MouseCursor), value);
    }
}

/// <summary>
/// An icon button which displays a menu when clicked.
/// Corresponds to Flutter's PopupMenuButton widget.
/// </summary>
[Control("PopupMenuButton", Category = "material")]
public sealed class PopupMenuButton : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PopupMenuButton"/> class.
    /// </summary>
    public PopupMenuButton()
    {
    }

    /// <summary>
    /// Gets or sets a control that will be displayed instead of "more" icon.
    /// Can be a string or a BaseControl.
    /// </summary>
    [JsonPropertyName("content")]
    public object? Content
    {
        get => GetProperty<object>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets an icon to draw on the button.
    /// Can be an icon name string or a BaseControl.
    /// </summary>
    [JsonPropertyName("icon")]
    public object? Icon
    {
        get => GetProperty<object>(nameof(Icon));
        set => SetProperty(nameof(Icon), value);
    }

    /// <summary>
    /// Gets or sets the menu's background color.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the icon's color.
    /// </summary>
    [JsonPropertyName("iconColor")]
    public string? IconColor
    {
        get => GetProperty<string>(nameof(IconColor));
        set => SetProperty(nameof(IconColor), value);
    }

    /// <summary>
    /// Gets or sets the color used to paint the shadow below the menu.
    /// </summary>
    [JsonPropertyName("shadowColor")]
    public string? ShadowColor
    {
        get => GetProperty<string>(nameof(ShadowColor));
        set => SetProperty(nameof(ShadowColor), value);
    }

    /// <summary>
    /// Gets or sets the icon's size.
    /// </summary>
    [JsonPropertyName("iconSize")]
    public double? IconSize
    {
        get => GetProperty<double?>(nameof(IconSize));
        set => SetProperty(nameof(IconSize), value);
    }

    /// <summary>
    /// Gets or sets the splash radius.
    /// </summary>
    [JsonPropertyName("splashRadius")]
    public double? SplashRadius
    {
        get => GetProperty<double?>(nameof(SplashRadius));
        set => SetProperty(nameof(SplashRadius), value);
    }

    /// <summary>
    /// Gets or sets the menu's elevation when opened.
    /// Defaults to 8.
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets the position of the popup menu relative to the button.
    /// Values: "over", "under"
    /// Defaults to "over".
    /// </summary>
    [JsonPropertyName("menuPosition")]
    public string? MenuPosition
    {
        get => GetProperty<string>(nameof(MenuPosition));
        set => SetProperty(nameof(MenuPosition), value);
    }

    /// <summary>
    /// Gets or sets how the content will be clipped.
    /// Values: "none", "hardEdge", "antiAlias", "antiAliasWithSaveLayer"
    /// Defaults to "none".
    /// </summary>
    [JsonPropertyName("clipBehavior")]
    public string? ClipBehavior
    {
        get => GetProperty<string>(nameof(ClipBehavior));
        set => SetProperty(nameof(ClipBehavior), value);
    }

    /// <summary>
    /// Gets or sets whether detected gestures should provide acoustic and/or haptic feedback.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("enableFeedback")]
    public bool? EnableFeedback
    {
        get => GetProperty<bool?>(nameof(EnableFeedback));
        set => SetProperty(nameof(EnableFeedback), value);
    }

    /// <summary>
    /// Gets or sets the menu's shape.
    /// </summary>
    [JsonPropertyName("shape")]
    public string? Shape
    {
        get => GetProperty<string>(nameof(Shape));
        set => SetProperty(nameof(Shape), value);
    }

    /// <summary>
    /// Gets or sets the button padding.
    /// </summary>
    [JsonPropertyName("padding")]
    public string? Padding
    {
        get => GetProperty<string>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets the menu padding.
    /// </summary>
    [JsonPropertyName("menuPadding")]
    public string? MenuPadding
    {
        get => GetProperty<string>(nameof(MenuPadding));
        set => SetProperty(nameof(MenuPadding), value);
    }

    /// <summary>
    /// Gets or sets the button style.
    /// </summary>
    [JsonPropertyName("style")]
    public string? Style
    {
        get => GetProperty<string>(nameof(Style));
        set => SetProperty(nameof(Style), value);
    }

    /// <summary>
    /// Occurs when the popup menu is shown.
    /// </summary>
    public event EventHandler? Open;

    /// <summary>
    /// Occurs when the user dismisses/cancels the popup menu without selecting an item.
    /// </summary>
    public event EventHandler? Cancel;

    /// <summary>
    /// Occurs when a menu item is selected.
    /// </summary>
    public event EventHandler? Select;
}
