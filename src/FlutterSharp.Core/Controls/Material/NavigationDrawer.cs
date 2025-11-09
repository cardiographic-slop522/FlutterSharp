using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Displays an icon with a label, for use in NavigationDrawer destinations.
/// Corresponds to Flutter's NavigationDrawerDestination widget.
/// </summary>
[Control("NavigationDrawerDestination", Category = "material")]
public sealed class NavigationDrawerDestination : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationDrawerDestination"/> class.
    /// </summary>
    public NavigationDrawerDestination()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationDrawerDestination"/> class with label and icon.
    /// </summary>
    /// <param name="label">The text label.</param>
    /// <param name="icon">The icon name or control.</param>
    public NavigationDrawerDestination(string? label = null, object? icon = null)
    {
        if (label != null) Label = label;
        if (icon != null) Icon = icon;
    }

    /// <summary>
    /// Gets or sets the text label that appears below the icon of this destination.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label
    {
        get => GetProperty<string>(nameof(Label));
        set => SetProperty(nameof(Label), value);
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
    /// If this icon is not provided, the NavigationDrawer will display Icon in either state.
    /// </summary>
    [JsonPropertyName("selectedIcon")]
    public object? SelectedIcon
    {
        get => GetProperty<object>(nameof(SelectedIcon));
        set => SetProperty(nameof(SelectedIcon), value);
    }

    /// <summary>
    /// Gets or sets the background color of this destination.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }
}

/// <summary>
/// Material Design Navigation Drawer component.
/// Navigation Drawer is a panel that slides in horizontally from the left or right edge of
/// a page to show primary destinations in an app.
/// Corresponds to Flutter's NavigationDrawer widget.
/// </summary>
[Control("NavigationDrawer", Category = "material")]
public sealed class NavigationDrawer : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationDrawer"/> class.
    /// </summary>
    public NavigationDrawer()
    {
    }

    /// <summary>
    /// Gets or sets the selected index.
    /// The index for the current selected NavigationDrawerDestination or -1 if no destination is selected.
    /// A valid selected_index is an integer between 0 and number of destinations - 1.
    /// For an invalid selected_index, all destinations will appear unselected.
    /// Defaults to 0.
    /// </summary>
    [JsonPropertyName("selectedIndex")]
    public int? SelectedIndex
    {
        get => GetProperty<int?>(nameof(SelectedIndex));
        set => SetProperty(nameof(SelectedIndex), value);
    }

    /// <summary>
    /// Gets or sets the background color of the navigation drawer itself.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the elevation of the navigation drawer itself.
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets the color of the selected destination indicator.
    /// </summary>
    [JsonPropertyName("indicatorColor")]
    public string? IndicatorColor
    {
        get => GetProperty<string>(nameof(IndicatorColor));
        set => SetProperty(nameof(IndicatorColor), value);
    }

    /// <summary>
    /// Gets or sets the shape of the selected destination indicator.
    /// </summary>
    [JsonPropertyName("indicatorShape")]
    public string? IndicatorShape
    {
        get => GetProperty<string>(nameof(IndicatorShape));
        set => SetProperty(nameof(IndicatorShape), value);
    }

    /// <summary>
    /// Gets or sets the color used for the drop shadow to indicate elevation.
    /// </summary>
    [JsonPropertyName("shadowColor")]
    public string? ShadowColor
    {
        get => GetProperty<string>(nameof(ShadowColor));
        set => SetProperty(nameof(ShadowColor), value);
    }

    /// <summary>
    /// Gets or sets the padding for destination controls.
    /// </summary>
    [JsonPropertyName("tilePadding")]
    public string? TilePadding
    {
        get => GetProperty<string>(nameof(TilePadding));
        set => SetProperty(nameof(TilePadding), value);
    }

    /// <summary>
    /// Occurs when the selected destination changes.
    /// </summary>
    public event EventHandler? Change;

    /// <summary>
    /// Occurs when the drawer is dismissed.
    /// </summary>
    public event EventHandler? Dismiss;
}
