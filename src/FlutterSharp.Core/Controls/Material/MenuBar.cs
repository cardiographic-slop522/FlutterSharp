using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A button for use in a MenuBar or on its own, that can be activated by click or keyboard navigation.
/// Corresponds to Flutter's MenuItemButton widget.
/// </summary>
[Control("MenuItemButton", Category = "material")]
public sealed class MenuItemButton : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MenuItemButton"/> class.
    /// </summary>
    public MenuItemButton()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MenuItemButton"/> class with content.
    /// </summary>
    /// <param name="content">The content of the menu item button.</param>
    public MenuItemButton(object? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the child control or text to be displayed in the center of this button.
    /// Typically this is the button's label, using a Text control.
    /// Can be a string or a BaseControl.
    /// </summary>
    [JsonPropertyName("content")]
    public object? Content
    {
        get => GetProperty<object>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets an optional control to display before the content.
    /// Typically an Icon control.
    /// </summary>
    [JsonPropertyName("leading")]
    public BaseControl? Leading
    {
        get => GetProperty<BaseControl>(nameof(Leading));
        set => SetProperty(nameof(Leading), value);
    }

    /// <summary>
    /// Gets or sets an optional control to display after the content.
    /// Typically an Icon control.
    /// </summary>
    [JsonPropertyName("trailing")]
    public BaseControl? Trailing
    {
        get => GetProperty<BaseControl>(nameof(Trailing));
        set => SetProperty(nameof(Trailing), value);
    }

    /// <summary>
    /// Gets or sets whether the menu will be closed when the MenuItemButton is clicked.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("closeOnClick")]
    public bool? CloseOnClick
    {
        get => GetProperty<bool?>(nameof(CloseOnClick));
        set => SetProperty(nameof(CloseOnClick), value);
    }

    /// <summary>
    /// Gets or sets whether hovering can request focus.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("focusOnHover")]
    public bool? FocusOnHover
    {
        get => GetProperty<bool?>(nameof(FocusOnHover));
        set => SetProperty(nameof(FocusOnHover), value);
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
    /// Gets or sets the button style.
    /// </summary>
    [JsonPropertyName("style")]
    public string? Style
    {
        get => GetProperty<string>(nameof(Style));
        set => SetProperty(nameof(Style), value);
    }

    /// <summary>
    /// Gets or sets a string that describes the button's action to assistive technologies.
    /// </summary>
    [JsonPropertyName("semanticLabel")]
    public string? SemanticLabel
    {
        get => GetProperty<string>(nameof(SemanticLabel));
        set => SetProperty(nameof(SemanticLabel), value);
    }

    /// <summary>
    /// Gets or sets whether this button should automatically request focus.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("autofocus")]
    public bool? Autofocus
    {
        get => GetProperty<bool?>(nameof(Autofocus));
        set => SetProperty(nameof(Autofocus), value);
    }

    /// <summary>
    /// Gets or sets the direction in which the menu item expands.
    /// Values: "horizontal", "vertical"
    /// If the menu item button is a descendant of MenuBar, then this property is ignored.
    /// Defaults to "horizontal".
    /// </summary>
    [JsonPropertyName("overflowAxis")]
    public string? OverflowAxis
    {
        get => GetProperty<string>(nameof(OverflowAxis));
        set => SetProperty(nameof(OverflowAxis), value);
    }

    /// <summary>
    /// Occurs when the button is clicked.
    /// If not defined the button will be disabled.
    /// Note: This hides the Click event from the base Control class.
    /// MenuItemButton uses Click to specifically handle menu item selection.
    /// </summary>
    public new event EventHandler? Click;

    /// <summary>
    /// Occurs when the button is hovered.
    /// </summary>
    public event EventHandler? Hover;

    /// <summary>
    /// Occurs when the button receives focus.
    /// </summary>
    public event EventHandler? Focus;

    /// <summary>
    /// Occurs when this button loses focus.
    /// </summary>
    public event EventHandler? Blur;
}

/// <summary>
/// A menu button that displays a cascading menu.
/// Typically used in a MenuBar control.
/// Corresponds to Flutter's SubmenuButton widget.
/// </summary>
[Control("SubmenuButton", Category = "material")]
public sealed class SubmenuButton : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubmenuButton"/> class.
    /// </summary>
    public SubmenuButton()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SubmenuButton"/> class with content.
    /// </summary>
    /// <param name="content">The content of the submenu button.</param>
    public SubmenuButton(object? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the child control to be displayed in the middle portion of this button.
    /// Typically this is the button's label, using a Text control.
    /// Can be a string or a BaseControl.
    /// </summary>
    [JsonPropertyName("content")]
    public object? Content
    {
        get => GetProperty<object>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets an optional control to display before the content.
    /// Typically an Icon control.
    /// </summary>
    [JsonPropertyName("leading")]
    public BaseControl? Leading
    {
        get => GetProperty<BaseControl>(nameof(Leading));
        set => SetProperty(nameof(Leading), value);
    }

    /// <summary>
    /// Gets or sets an optional control to display after the content.
    /// Typically an Icon control.
    /// </summary>
    [JsonPropertyName("trailing")]
    public BaseControl? Trailing
    {
        get => GetProperty<BaseControl>(nameof(Trailing));
        set => SetProperty(nameof(Trailing), value);
    }

    /// <summary>
    /// Gets or sets how the content will be clipped.
    /// Values: "none", "hardEdge", "antiAlias", "antiAliasWithSaveLayer"
    /// Defaults to "hardEdge".
    /// </summary>
    [JsonPropertyName("clipBehavior")]
    public string? ClipBehavior
    {
        get => GetProperty<string>(nameof(ClipBehavior));
        set => SetProperty(nameof(ClipBehavior), value);
    }

    /// <summary>
    /// Gets or sets the menu style.
    /// </summary>
    [JsonPropertyName("menuStyle")]
    public string? MenuStyle
    {
        get => GetProperty<string>(nameof(MenuStyle));
        set => SetProperty(nameof(MenuStyle), value);
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
    /// Gets or sets the offset of the menu relative to the alignment origin.
    /// </summary>
    [JsonPropertyName("alignmentOffset")]
    public string? AlignmentOffset
    {
        get => GetProperty<string>(nameof(AlignmentOffset));
        set => SetProperty(nameof(AlignmentOffset), value);
    }

    /// <summary>
    /// Occurs when the menu is opened.
    /// </summary>
    public event EventHandler? Open;

    /// <summary>
    /// Occurs when the menu is closed.
    /// </summary>
    public event EventHandler? Close;

    /// <summary>
    /// Occurs when the button is hovered.
    /// </summary>
    public event EventHandler? Hover;

    /// <summary>
    /// Occurs when the button receives focus.
    /// </summary>
    public event EventHandler? Focus;

    /// <summary>
    /// Occurs when this button loses focus.
    /// </summary>
    public event EventHandler? Blur;
}

/// <summary>
/// A menu bar that manages cascading child menus.
/// It could be placed anywhere but typically resides above the main body of the
/// application and defines a menu system for invoking callbacks in response to user
/// selection of a menu item.
/// Corresponds to Flutter's MenuBar widget.
/// </summary>
[Control("MenuBar", Category = "material")]
public sealed class MenuBar : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MenuBar"/> class.
    /// </summary>
    public MenuBar()
    {
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
    /// Gets or sets the menu bar style.
    /// </summary>
    [JsonPropertyName("style")]
    public string? Style
    {
        get => GetProperty<string>(nameof(Style));
        set => SetProperty(nameof(Style), value);
    }
}
