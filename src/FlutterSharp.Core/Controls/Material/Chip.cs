using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Chips are compact elements that represent an attribute, text, entity, or action.
/// Corresponds to Flutter's Chip widget.
/// </summary>
[Control("Chip", Category = "material")]
public sealed class Chip : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Chip"/> class.
    /// </summary>
    public Chip()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Chip"/> class with a label.
    /// </summary>
    /// <param name="label">The chip label text.</param>
    /// <param name="onClick">Optional click handler.</param>
    public Chip(string label, EventHandler? onClick = null)
    {
        Label = label;
        if (onClick != null)
        {
            Click = onClick;
        }
    }

    /// <summary>
    /// Gets or sets the primary content of this chip.
    /// Can be a string or a BaseControl.
    /// </summary>
    [JsonPropertyName("label")]
    public object? Label
    {
        get => GetProperty<object>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }

    /// <summary>
    /// Gets or sets a control to display to the left of this chip's label.
    /// Typically an Icon or CircleAvatar.
    /// </summary>
    [JsonPropertyName("leading")]
    public BaseControl? Leading
    {
        get => GetProperty<BaseControl>(nameof(Leading));
        set => SetProperty(nameof(Leading), value);
    }

    /// <summary>
    /// Gets or sets whether this chip is selected.
    /// Used when OnSelect event is specified.
    /// </summary>
    [JsonPropertyName("selected")]
    public bool? Selected
    {
        get => GetProperty<bool?>(nameof(Selected));
        set => SetProperty(nameof(Selected), value);
    }

    /// <summary>
    /// Gets or sets the color used for this chip's background when it is selected.
    /// </summary>
    [JsonPropertyName("selectedColor")]
    public string? SelectedColor
    {
        get => GetProperty<string>(nameof(SelectedColor));
        set => SetProperty(nameof(SelectedColor), value);
    }

    /// <summary>
    /// Gets or sets the elevation (shadow size) below this chip.
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets the color for the unselected, enabled chip's background.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets whether to show a checkmark when the chip is selected.
    /// </summary>
    [JsonPropertyName("showCheckmark")]
    public bool? ShowCheckmark
    {
        get => GetProperty<bool?>(nameof(ShowCheckmark));
        set => SetProperty(nameof(ShowCheckmark), value);
    }

    /// <summary>
    /// Gets or sets the color of this chip's check mark when visible.
    /// </summary>
    [JsonPropertyName("checkColor")]
    public string? CheckColor
    {
        get => GetProperty<string>(nameof(CheckColor));
        set => SetProperty(nameof(CheckColor), value);
    }

    /// <summary>
    /// Gets or sets the shadow color when elevation is greater than 0 and chip is not selected.
    /// </summary>
    [JsonPropertyName("shadowColor")]
    public string? ShadowColor
    {
        get => GetProperty<string>(nameof(ShadowColor));
        set => SetProperty(nameof(ShadowColor), value);
    }

    /// <summary>
    /// Gets or sets the shape of the border around this chip.
    /// </summary>
    [JsonPropertyName("shape")]
    public string? Shape
    {
        get => GetProperty<string>(nameof(Shape));
        set => SetProperty(nameof(Shape), value);
    }

    /// <summary>
    /// Gets or sets the padding between the label and the outside shape.
    /// </summary>
    [JsonPropertyName("padding")]
    public string? Padding
    {
        get => GetProperty<string>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets a control to display to the right of this chip's label for deletion.
    /// </summary>
    [JsonPropertyName("deleteIcon")]
    public BaseControl? DeleteIcon
    {
        get => GetProperty<BaseControl>(nameof(DeleteIcon));
        set => SetProperty(nameof(DeleteIcon), value);
    }

    /// <summary>
    /// Gets or sets the tooltip for the delete icon.
    /// </summary>
    [JsonPropertyName("deleteIconTooltip")]
    public string? DeleteIconTooltip
    {
        get => GetProperty<string>(nameof(DeleteIconTooltip));
        set => SetProperty(nameof(DeleteIconTooltip), value);
    }

    /// <summary>
    /// Gets or sets the color of the delete icon.
    /// </summary>
    [JsonPropertyName("deleteIconColor")]
    public string? DeleteIconColor
    {
        get => GetProperty<string>(nameof(DeleteIconColor));
        set => SetProperty(nameof(DeleteIconColor), value);
    }

    /// <summary>
    /// Gets or sets the color used for this chip's background if it is disabled.
    /// </summary>
    [JsonPropertyName("disabledColor")]
    public string? DisabledColor
    {
        get => GetProperty<string>(nameof(DisabledColor));
        set => SetProperty(nameof(DisabledColor), value);
    }

    /// <summary>
    /// Gets or sets the padding around the label.
    /// </summary>
    [JsonPropertyName("labelPadding")]
    public string? LabelPadding
    {
        get => GetProperty<string>(nameof(LabelPadding));
        set => SetProperty(nameof(LabelPadding), value);
    }

    /// <summary>
    /// Gets or sets the shadow color when elevation is greater than 0 and chip is selected.
    /// </summary>
    [JsonPropertyName("selectedShadowColor")]
    public string? SelectedShadowColor
    {
        get => GetProperty<string>(nameof(SelectedShadowColor));
        set => SetProperty(nameof(SelectedShadowColor), value);
    }

    /// <summary>
    /// Gets or sets whether this chip will be selected as the initial focus.
    /// </summary>
    [JsonPropertyName("autofocus")]
    public bool? Autofocus
    {
        get => GetProperty<bool?>(nameof(Autofocus));
        set => SetProperty(nameof(Autofocus), value);
    }

    /// <summary>
    /// Gets or sets how the content will be clipped.
    /// Values: "none", "hardEdge", "antiAlias", "antiAliasWithSaveLayer"
    /// </summary>
    [JsonPropertyName("clipBehavior")]
    public string? ClipBehavior
    {
        get => GetProperty<string>(nameof(ClipBehavior));
        set => SetProperty(nameof(ClipBehavior), value);
    }

    /// <summary>
    /// Gets or sets the URL to open when this chip is clicked.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url
    {
        get => GetProperty<string>(nameof(Url));
        set => SetProperty(nameof(Url), value);
    }
}
