using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A floating action button is a circular icon button that hovers over content to promote a primary action.
/// Corresponds to Flutter's FloatingActionButton widget.
/// </summary>
[Control("FloatingActionButton", Category = "material")]
public sealed class FloatingActionButton : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FloatingActionButton"/> class.
    /// </summary>
    public FloatingActionButton()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FloatingActionButton"/> class with an icon.
    /// </summary>
    /// <param name="icon">The icon name or control.</param>
    /// <param name="onClick">Optional click handler.</param>
    public FloatingActionButton(string icon, EventHandler? onClick = null)
    {
        Icon = icon;
        if (onClick != null)
        {
            Click = onClick;
        }
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
    /// Gets or sets the icon shown in this button.
    /// Can be an icon name string or a BaseControl.
    /// </summary>
    [JsonPropertyName("icon")]
    public object? Icon
    {
        get => GetProperty<object>(nameof(Icon));
        set => SetProperty(nameof(Icon), value);
    }

    /// <summary>
    /// Gets or sets the button background color.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the shape of the FAB's border.
    /// </summary>
    [JsonPropertyName("shape")]
    public string? Shape
    {
        get => GetProperty<string>(nameof(Shape));
        set => SetProperty(nameof(Shape), value);
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
    /// Gets or sets whether this is a mini FAB (40x40 vs 56x56 pixels).
    /// </summary>
    [JsonPropertyName("mini")]
    public bool? Mini
    {
        get => GetProperty<bool?>(nameof(Mini));
        set => SetProperty(nameof(Mini), value);
    }

    /// <summary>
    /// Gets or sets the default foreground color for icons and text within this button.
    /// </summary>
    [JsonPropertyName("foregroundColor")]
    public string? ForegroundColor
    {
        get => GetProperty<string>(nameof(ForegroundColor));
        set => SetProperty(nameof(ForegroundColor), value);
    }

    /// <summary>
    /// Gets or sets the color to use for filling this button when it has input focus.
    /// </summary>
    [JsonPropertyName("focusColor")]
    public string? FocusColor
    {
        get => GetProperty<string>(nameof(FocusColor));
        set => SetProperty(nameof(FocusColor), value);
    }

    /// <summary>
    /// Gets or sets how the content is clipped.
    /// Values: "none", "hardEdge", "antiAlias", "antiAliasWithSaveLayer"
    /// </summary>
    [JsonPropertyName("clipBehavior")]
    public string? ClipBehavior
    {
        get => GetProperty<string>(nameof(ClipBehavior));
        set => SetProperty(nameof(ClipBehavior), value);
    }

    /// <summary>
    /// Gets or sets the elevation of this button. Default is 6.
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets the elevation of this button when disabled.
    /// </summary>
    [JsonPropertyName("disabledElevation")]
    public double? DisabledElevation
    {
        get => GetProperty<double?>(nameof(DisabledElevation));
        set => SetProperty(nameof(DisabledElevation), value);
    }

    /// <summary>
    /// Gets or sets the elevation of this button when it has input focus. Default is 8.
    /// </summary>
    [JsonPropertyName("focusElevation")]
    public double? FocusElevation
    {
        get => GetProperty<double?>(nameof(FocusElevation));
        set => SetProperty(nameof(FocusElevation), value);
    }

    /// <summary>
    /// Gets or sets the elevation when the button is being touched/hovered.
    /// </summary>
    [JsonPropertyName("hoverElevation")]
    public double? HoverElevation
    {
        get => GetProperty<double?>(nameof(HoverElevation));
        set => SetProperty(nameof(HoverElevation), value);
    }

    /// <summary>
    /// Gets or sets the elevation when the button is being pressed.
    /// </summary>
    [JsonPropertyName("highlightElevation")]
    public double? HighlightElevation
    {
        get => GetProperty<double?>(nameof(HighlightElevation));
        set => SetProperty(nameof(HighlightElevation), value);
    }

    /// <summary>
    /// Gets or sets the text shown in this button (alternative to icon).
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text
    {
        get => GetProperty<string>(nameof(Text));
        set => SetProperty(nameof(Text), value);
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
}
