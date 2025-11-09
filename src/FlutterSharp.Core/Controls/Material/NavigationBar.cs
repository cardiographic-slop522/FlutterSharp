using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Material 3 Navigation Bar component.
/// Navigation bars offer a persistent and convenient way to switch between primary destinations in an app.
/// Corresponds to Flutter's NavigationBar widget.
/// </summary>
[Control("NavigationBar", Category = "material")]
public sealed class NavigationBar : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationBar"/> class.
    /// </summary>
    public NavigationBar()
    {
    }

    /// <summary>
    /// Gets or sets the index of the current selected destination.
    /// </summary>
    [JsonPropertyName("selectedIndex")]
    public int? SelectedIndex
    {
        get => GetProperty<int?>(nameof(SelectedIndex));
        set => SetProperty(nameof(SelectedIndex), value);
    }

    /// <summary>
    /// Gets or sets the color of the navigation bar itself.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets how the destinations' labels will be laid out and when they'll be displayed.
    /// Values: "alwaysShow", "alwaysHide", "onlyShowSelected"
    /// </summary>
    [JsonPropertyName("labelBehavior")]
    public string? LabelBehavior
    {
        get => GetProperty<string>(nameof(LabelBehavior));
        set => SetProperty(nameof(LabelBehavior), value);
    }

    /// <summary>
    /// Gets or sets the padding around the destination labels.
    /// </summary>
    [JsonPropertyName("labelPadding")]
    public string? LabelPadding
    {
        get => GetProperty<string>(nameof(LabelPadding));
        set => SetProperty(nameof(LabelPadding), value);
    }

    /// <summary>
    /// Gets or sets the elevation of the navigation bar itself.
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
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
    /// Gets or sets the border of the navigation bar.
    /// </summary>
    [JsonPropertyName("border")]
    public string? Border
    {
        get => GetProperty<string>(nameof(Border));
        set => SetProperty(nameof(Border), value);
    }

    /// <summary>
    /// Gets or sets the transition time (in milliseconds) for each destination as it goes between selected and unselected.
    /// </summary>
    [JsonPropertyName("animationDuration")]
    public int? AnimationDuration
    {
        get => GetProperty<int?>(nameof(AnimationDuration));
        set => SetProperty(nameof(AnimationDuration), value);
    }
}

/// <summary>
/// Defines the appearance of the button items that are arrayed within the navigation bar.
/// </summary>
[Control("NavigationBarDestination", Category = "material")]
public sealed class NavigationBarDestination : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationBarDestination"/> class.
    /// </summary>
    public NavigationBarDestination()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationBarDestination"/> class with icon and label.
    /// </summary>
    /// <param name="icon">The icon name or control.</param>
    /// <param name="label">The text label.</param>
    public NavigationBarDestination(string icon, string? label = null)
    {
        Icon = icon;
        Label = label;
    }

    /// <summary>
    /// Gets or sets the icon of the destination.
    /// Can be an icon name string or a BaseControl.
    /// </summary>
    [JsonPropertyName("icon")]
    public object? Icon
    {
        get => GetProperty<object>(nameof(Icon));
        set => SetProperty(nameof(Icon), value);
    }

    /// <summary>
    /// Gets or sets the text label that appears below the icon.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label
    {
        get => GetProperty<string>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }

    /// <summary>
    /// Gets or sets the alternative icon displayed when this destination is selected.
    /// Can be an icon name string or a BaseControl.
    /// </summary>
    [JsonPropertyName("selectedIcon")]
    public object? SelectedIcon
    {
        get => GetProperty<object>(nameof(SelectedIcon));
        set => SetProperty(nameof(SelectedIcon), value);
    }

    /// <summary>
    /// Gets or sets the color of this destination.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }
}
