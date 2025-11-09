using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A scrollable list of controls.
/// Corresponds to Flutter's ListView widget.
/// </summary>
[Control("ListView", IsContainer = true, Category = "layout")]
public sealed class ListView : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListView"/> class.
    /// </summary>
    public ListView()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ListView"/> class with the specified children.
    /// </summary>
    /// <param name="children">The child controls to add.</param>
    public ListView(params BaseControl[] children)
    {
        foreach (var child in children)
        {
            AddChild(child);
        }
    }

    /// <summary>
    /// Gets or sets the horizontal alignment of children.
    /// Values: "start", "center", "end", "stretch"
    /// </summary>
    [JsonPropertyName("horizontalAlignment")]
    public string? HorizontalAlignment
    {
        get => GetProperty<string>(nameof(HorizontalAlignment));
        set => SetProperty(nameof(HorizontalAlignment), value);
    }

    /// <summary>
    /// Gets or sets the spacing between children in pixels.
    /// </summary>
    [JsonPropertyName("spacing")]
    public double? Spacing
    {
        get => GetProperty<double?>(nameof(Spacing));
        set => SetProperty(nameof(Spacing), value);
    }

    /// <summary>
    /// Gets or sets the padding around the list.
    /// </summary>
    [JsonPropertyName("padding")]
    public object? Padding
    {
        get => GetProperty<object>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the list is scrollable horizontally.
    /// </summary>
    [JsonPropertyName("horizontal")]
    public bool? Horizontal
    {
        get => GetProperty<bool?>(nameof(Horizontal));
        set => SetProperty(nameof(Horizontal), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the list should auto-scroll to the bottom.
    /// </summary>
    [JsonPropertyName("autoScroll")]
    public bool? AutoScroll
    {
        get => GetProperty<bool?>(nameof(AutoScroll));
        set => SetProperty(nameof(AutoScroll), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the list has a divider between items.
    /// </summary>
    [JsonPropertyName("divider")]
    public bool? Divider
    {
        get => GetProperty<bool?>(nameof(Divider));
        set => SetProperty(nameof(Divider), value);
    }

    /// <summary>
    /// Gets or sets the divider thickness.
    /// </summary>
    [JsonPropertyName("dividerThickness")]
    public double? DividerThickness
    {
        get => GetProperty<double?>(nameof(DividerThickness));
        set => SetProperty(nameof(DividerThickness), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether items should be cached.
    /// </summary>
    [JsonPropertyName("cacheExtent")]
    public double? CacheExtent
    {
        get => GetProperty<double?>(nameof(CacheExtent));
        set => SetProperty(nameof(CacheExtent), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the list should be reversed.
    /// </summary>
    [JsonPropertyName("reverse")]
    public bool? Reverse
    {
        get => GetProperty<bool?>(nameof(Reverse));
        set => SetProperty(nameof(Reverse), value);
    }
}
