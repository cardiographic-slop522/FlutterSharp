using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Represents a destination in a NavigationRail.
/// Corresponds to Flutter's NavigationRailDestination widget.
/// </summary>
[Control("NavigationRailDestination", Category = "material")]
public sealed class NavigationRailDestination : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationRailDestination"/> class.
    /// </summary>
    public NavigationRailDestination()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationRailDestination"/> class with icon and label.
    /// </summary>
    /// <param name="icon">The icon of the destination.</param>
    /// <param name="label">The label of the destination.</param>
    /// <param name="selectedIcon">Optional icon displayed when selected.</param>
    public NavigationRailDestination(object icon, object? label = null, object? selectedIcon = null)
    {
        Icon = icon;
        if (label != null) Label = label;
        if (selectedIcon != null) SelectedIcon = selectedIcon;
    }

    /// <summary>
    /// Gets or sets the icon of the destination.
    /// Can be an icon name string or a BaseControl.
    /// If SelectedIcon is provided, this will only be displayed when the destination is not selected.
    /// </summary>
    [JsonPropertyName("icon")]
    public object? Icon
    {
        get => GetProperty<object>(nameof(Icon));
        set => SetProperty(nameof(Icon), value);
    }

    /// <summary>
    /// Gets or sets the alternative icon displayed when this destination is selected.
    /// Can be an icon name string or a BaseControl.
    /// If not provided, Icon will be displayed in either state.
    /// </summary>
    [JsonPropertyName("selectedIcon")]
    public object? SelectedIcon
    {
        get => GetProperty<object>(nameof(SelectedIcon));
        set => SetProperty(nameof(SelectedIcon), value);
    }

    /// <summary>
    /// Gets or sets the destination's label.
    /// Can be a string or a BaseControl.
    /// </summary>
    [JsonPropertyName("label")]
    public object? Label
    {
        get => GetProperty<object>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }

    /// <summary>
    /// Gets or sets the amount of space to inset the destination item.
    /// </summary>
    [JsonPropertyName("padding")]
    public string? Padding
    {
        get => GetProperty<string>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets the color of the indicator shape when this destination is selected.
    /// </summary>
    [JsonPropertyName("indicatorColor")]
    public string? IndicatorColor
    {
        get => GetProperty<string>(nameof(IndicatorColor));
        set => SetProperty(nameof(IndicatorColor), value);
    }

    /// <summary>
    /// Gets or sets the shape of the selection indicator.
    /// </summary>
    [JsonPropertyName("indicatorShape")]
    public string? IndicatorShape
    {
        get => GetProperty<string>(nameof(IndicatorShape));
        set => SetProperty(nameof(IndicatorShape), value);
    }
}

/// <summary>
/// A material widget that is meant to be displayed at the left or right of an app to
/// navigate between a small number of views, typically between three and five.
/// Corresponds to Flutter's NavigationRail widget.
/// </summary>
[Control("NavigationRail", Category = "material")]
public sealed class NavigationRail : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationRail"/> class.
    /// </summary>
    public NavigationRail()
    {
    }

    /// <summary>
    /// Gets or sets the elevation of the navigation rail.
    /// Controls the size of the shadow below the NavigationRail.
    /// Defaults to 0.0.
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets the index into destinations for the current selected destination.
    /// Set to null if no destination is selected.
    /// </summary>
    [JsonPropertyName("selectedIndex")]
    public int? SelectedIndex
    {
        get => GetProperty<int?>(nameof(SelectedIndex));
        set => SetProperty(nameof(SelectedIndex), value);
    }

    /// <summary>
    /// Gets or sets whether the NavigationRail should be in the extended state.
    /// The extended state has a wider rail container, and the labels are positioned next to the icons.
    /// </summary>
    [JsonPropertyName("extended")]
    public bool? Extended
    {
        get => GetProperty<bool?>(nameof(Extended));
        set => SetProperty(nameof(Extended), value);
    }

    /// <summary>
    /// Gets or sets the layout and behavior of the labels for the default, unextended navigation rail.
    /// Values: "none", "all", "selected"
    /// When extended, labels are always shown.
    /// </summary>
    [JsonPropertyName("labelType")]
    public string? LabelType
    {
        get => GetProperty<string>(nameof(LabelType));
        set => SetProperty(nameof(LabelType), value);
    }

    /// <summary>
    /// Gets or sets the color of the Container that holds all of the NavigationRail's contents.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the color of the navigation rail's indicator.
    /// </summary>
    [JsonPropertyName("indicatorColor")]
    public string? IndicatorColor
    {
        get => GetProperty<string>(nameof(IndicatorColor));
        set => SetProperty(nameof(IndicatorColor), value);
    }

    /// <summary>
    /// Gets or sets the shape of the navigation rail's indicator.
    /// Defaults to StadiumBorder.
    /// </summary>
    [JsonPropertyName("indicatorShape")]
    public string? IndicatorShape
    {
        get => GetProperty<string>(nameof(IndicatorShape));
        set => SetProperty(nameof(IndicatorShape), value);
    }

    /// <summary>
    /// Gets or sets an optional leading control in the rail that is placed above the destinations.
    /// Typically a FloatingActionButton, but may also be a non-button, such as a logo.
    /// </summary>
    [JsonPropertyName("leading")]
    public BaseControl? Leading
    {
        get => GetProperty<BaseControl>(nameof(Leading));
        set => SetProperty(nameof(Leading), value);
    }

    /// <summary>
    /// Gets or sets an optional trailing control in the rail that is placed below the destinations.
    /// This is commonly a list of additional options or destinations that is usually only rendered when Extended is true.
    /// </summary>
    [JsonPropertyName("trailing")]
    public BaseControl? Trailing
    {
        get => GetProperty<BaseControl>(nameof(Trailing));
        set => SetProperty(nameof(Trailing), value);
    }

    /// <summary>
    /// Gets or sets the smallest possible width for the rail regardless of the destination's icon or label size.
    /// Defaults to 72. To make a compact rail, set this to 56 and use LabelType='none'.
    /// </summary>
    [JsonPropertyName("minWidth")]
    public double? MinWidth
    {
        get => GetProperty<double?>(nameof(MinWidth));
        set => SetProperty(nameof(MinWidth), value);
    }

    /// <summary>
    /// Gets or sets the final width when the animation is complete for setting Extended to true.
    /// Defaults to 256.
    /// </summary>
    [JsonPropertyName("minExtendedWidth")]
    public double? MinExtendedWidth
    {
        get => GetProperty<double?>(nameof(MinExtendedWidth));
        set => SetProperty(nameof(MinExtendedWidth), value);
    }

    /// <summary>
    /// Gets or sets the vertical alignment for the group of destinations within the rail.
    /// The value must be between -1.0 and 1.0.
    /// -1.0 = top aligned, 0.0 = center aligned, 1.0 = bottom aligned.
    /// Defaults to -1.0.
    /// </summary>
    [JsonPropertyName("groupAlignment")]
    public double? GroupAlignment
    {
        get => GetProperty<double?>(nameof(GroupAlignment));
        set => SetProperty(nameof(GroupAlignment), value);
    }

    /// <summary>
    /// Gets or sets the text style of a destination's label when it is selected.
    /// </summary>
    [JsonPropertyName("selectedLabelTextStyle")]
    public string? SelectedLabelTextStyle
    {
        get => GetProperty<string>(nameof(SelectedLabelTextStyle));
        set => SetProperty(nameof(SelectedLabelTextStyle), value);
    }

    /// <summary>
    /// Gets or sets the text style of a destination's label when it is not selected.
    /// </summary>
    [JsonPropertyName("unselectedLabelTextStyle")]
    public string? UnselectedLabelTextStyle
    {
        get => GetProperty<string>(nameof(UnselectedLabelTextStyle));
        set => SetProperty(nameof(UnselectedLabelTextStyle), value);
    }

    /// <summary>
    /// Gets or sets whether to add a rounded navigation indicator behind the selected destination's icon.
    /// </summary>
    [JsonPropertyName("useIndicator")]
    public bool? UseIndicator
    {
        get => GetProperty<bool?>(nameof(UseIndicator));
        set => SetProperty(nameof(UseIndicator), value);
    }

    /// <summary>
    /// Occurs when the selected destination changes.
    /// </summary>
    public event EventHandler? Change;
}
