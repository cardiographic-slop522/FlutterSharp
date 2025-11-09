using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Cupertino;

/// <summary>
/// An iOS-styled bottom navigation tab bar.
/// Navigation bars offer a persistent and convenient way to switch between primary destinations in an app.
/// Corresponds to Flutter's CupertinoNavigationBar widget.
/// </summary>
[Control("CupertinoNavigationBar", Category = "cupertino")]
public sealed class CupertinoNavigationBar : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoNavigationBar"/> class.
    /// </summary>
    public CupertinoNavigationBar()
    {
    }

    /// <summary>
    /// Gets or sets the index of the currently selected destination.
    /// Must be a value between 0 and the length of visible destinations, inclusive.
    /// Defaults to 0.
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
    public string? BgColor
    {
        get => GetProperty<string>(nameof(BgColor));
        set => SetProperty(nameof(BgColor), value);
    }

    /// <summary>
    /// Gets or sets the foreground color of the icon and title of the selected destination.
    /// </summary>
    [JsonPropertyName("activeColor")]
    public string? ActiveColor
    {
        get => GetProperty<string>(nameof(ActiveColor));
        set => SetProperty(nameof(ActiveColor), value);
    }

    /// <summary>
    /// Gets or sets the foreground color of the icon and title of the unselected destinations.
    /// Defaults to iOS inactive gray.
    /// </summary>
    [JsonPropertyName("inactiveColor")]
    public string? InactiveColor
    {
        get => GetProperty<string>(nameof(InactiveColor));
        set => SetProperty(nameof(InactiveColor), value);
    }

    /// <summary>
    /// Gets or sets the border of this navigation bar.
    /// </summary>
    [JsonPropertyName("border")]
    public string? Border
    {
        get => GetProperty<string>(nameof(Border));
        set => SetProperty(nameof(Border), value);
    }

    /// <summary>
    /// Gets or sets the size of all destination icons.
    /// Defaults to 30.
    /// </summary>
    [JsonPropertyName("iconSize")]
    public double? IconSize
    {
        get => GetProperty<double?>(nameof(IconSize));
        set => SetProperty(nameof(IconSize), value);
    }

    /// <summary>
    /// Occurs when the selected destination changed.
    /// </summary>
    public event EventHandler? Change;
}
