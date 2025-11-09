using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Cupertino;

/// <summary>
/// An iOS-style button.
/// Provides a button with iOS design language including opacity on press and rounded corners.
/// Corresponds to Flutter's CupertinoButton widget.
/// </summary>
[Control("CupertinoButton", Category = "cupertino")]
public sealed class CupertinoButton : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoButton"/> class.
    /// </summary>
    public CupertinoButton()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoButton"/> class with content.
    /// </summary>
    /// <param name="content">The content of this button (can be string or control).</param>
    public CupertinoButton(object? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the content of this button.
    /// Can be a string or a BaseControl.
    /// </summary>
    [JsonPropertyName("content")]
    public object? Content
    {
        get => GetProperty<object>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets an icon shown in this button.
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon
    {
        get => GetProperty<string>(nameof(Icon));
        set => SetProperty(nameof(Icon), value);
    }

    /// <summary>
    /// Gets or sets the foreground color of the icon.
    /// </summary>
    [JsonPropertyName("iconColor")]
    public string? IconColor
    {
        get => GetProperty<string>(nameof(IconColor));
        set => SetProperty(nameof(IconColor), value);
    }

    /// <summary>
    /// Gets or sets the background color of this button.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BgColor
    {
        get => GetProperty<string>(nameof(BgColor));
        set => SetProperty(nameof(BgColor), value);
    }

    /// <summary>
    /// Gets or sets the color of this button's text.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color
    {
        get => GetProperty<string>(nameof(Color));
        set => SetProperty(nameof(Color), value);
    }

    /// <summary>
    /// Gets or sets the background color of this button when disabled.
    /// </summary>
    [JsonPropertyName("disabledBgcolor")]
    public string? DisabledBgColor
    {
        get => GetProperty<string>(nameof(DisabledBgColor));
        set => SetProperty(nameof(DisabledBgColor), value);
    }

    /// <summary>
    /// Gets or sets the opacity of the button when it is clicked.
    /// When not pressed, the button has an opacity of 1.0.
    /// Defaults to 0.4.
    /// </summary>
    [JsonPropertyName("opacityOnClick")]
    public double? OpacityOnClick
    {
        get => GetProperty<double?>(nameof(OpacityOnClick));
        set => SetProperty(nameof(OpacityOnClick), value);
    }

    /// <summary>
    /// Gets or sets the minimum size of this button.
    /// </summary>
    [JsonPropertyName("minSize")]
    public string? MinSize
    {
        get => GetProperty<string>(nameof(MinSize));
        set => SetProperty(nameof(MinSize), value);
    }

    /// <summary>
    /// Gets or sets the size of this button.
    /// Values: "small", "medium", "large"
    /// Defaults to "large".
    /// </summary>
    [JsonPropertyName("size")]
    public string? Size
    {
        get => GetProperty<string>(nameof(Size));
        set => SetProperty(nameof(Size), value);
    }

    /// <summary>
    /// Gets or sets the amount of space to surround the content control inside the bounds of the button.
    /// </summary>
    [JsonPropertyName("padding")]
    public string? Padding
    {
        get => GetProperty<string>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets the alignment of this button's content.
    /// Typically buttons are sized to be just big enough to contain the child and its padding.
    /// Values: "topLeft", "center", "bottomRight", etc.
    /// Defaults to "center".
    /// </summary>
    [JsonPropertyName("alignment")]
    public string? Alignment
    {
        get => GetProperty<string>(nameof(Alignment));
        set => SetProperty(nameof(Alignment), value);
    }

    /// <summary>
    /// Gets or sets the radius of the button's corners when it has a background color.
    /// Defaults to 8.0.
    /// </summary>
    [JsonPropertyName("borderRadius")]
    public string? BorderRadius
    {
        get => GetProperty<string>(nameof(BorderRadius));
        set => SetProperty(nameof(BorderRadius), value);
    }

    /// <summary>
    /// Gets or sets the URL to open when this button is clicked.
    /// If Click event callback is provided, it is fired after that.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url
    {
        get => GetProperty<string>(nameof(Url));
        set => SetProperty(nameof(Url), value);
    }

    /// <summary>
    /// Gets or sets whether this button should be selected as the initial focus.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("autofocus")]
    public bool? Autofocus
    {
        get => GetProperty<bool?>(nameof(Autofocus));
        set => SetProperty(nameof(Autofocus), value);
    }

    /// <summary>
    /// Gets or sets the color to use for the focus highlight for keyboard interactions.
    /// </summary>
    [JsonPropertyName("focusColor")]
    public string? FocusColor
    {
        get => GetProperty<string>(nameof(FocusColor));
        set => SetProperty(nameof(FocusColor), value);
    }

    /// <summary>
    /// Gets or sets the cursor for a mouse pointer when it enters or is hovering over this button.
    /// </summary>
    [JsonPropertyName("mouseCursor")]
    public string? MouseCursor
    {
        get => GetProperty<string>(nameof(MouseCursor));
        set => SetProperty(nameof(MouseCursor), value);
    }

    /// <summary>
    /// Occurs when a user clicks this button.
    /// Note: This hides the Click event from the base Control class.
    /// CupertinoButton uses Click to provide iOS-specific button click handling.
    /// </summary>
    public new event EventHandler? Click;

    /// <summary>
    /// Occurs when a user long-presses this button.
    /// </summary>
    public event EventHandler? LongPress;

    /// <summary>
    /// Occurs when this button receives focus.
    /// </summary>
    public event EventHandler? Focus;

    /// <summary>
    /// Occurs when this button loses focus.
    /// </summary>
    public event EventHandler? Blur;
}
