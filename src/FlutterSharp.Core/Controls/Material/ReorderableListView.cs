using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A scrollable list of controls that can be reordered via drag and drop.
/// Corresponds to Flutter's ReorderableListView widget.
/// </summary>
[Control("ReorderableListView", Category = "material")]
public sealed class ReorderableListView : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReorderableListView"/> class.
    /// </summary>
    public ReorderableListView()
    {
    }

    /// <summary>
    /// Gets or sets whether the controls should be laid out horizontally.
    /// Defaults to false (vertical layout).
    /// </summary>
    [JsonPropertyName("horizontal")]
    public bool? Horizontal
    {
        get => GetProperty<bool?>(nameof(Horizontal));
        set => SetProperty(nameof(Horizontal), value);
    }

    /// <summary>
    /// Gets or sets whether the scroll view scrolls in the reading direction.
    /// For example, if the reading direction is left-to-right and Horizontal is true,
    /// then the scroll view scrolls from left to right when Reverse is false
    /// and from right to left when Reverse is true.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("reverse")]
    public bool? Reverse
    {
        get => GetProperty<bool?>(nameof(Reverse));
        set => SetProperty(nameof(Reverse), value);
    }

    /// <summary>
    /// Gets or sets the extent (height/width) of each item in the scroll direction.
    /// If non-null, forces the children to have the given extent.
    /// Specifying an item extent is more efficient than letting children determine their own extent.
    /// </summary>
    [JsonPropertyName("itemExtent")]
    public double? ItemExtent
    {
        get => GetProperty<double?>(nameof(ItemExtent));
        set => SetProperty(nameof(ItemExtent), value);
    }

    /// <summary>
    /// Gets or sets whether the dimensions of the first item should be used as a "prototype" for all other items.
    /// If true, all items will have the same height or width as the first item.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("firstItemPrototype")]
    public bool? FirstItemPrototype
    {
        get => GetProperty<bool?>(nameof(FirstItemPrototype));
        set => SetProperty(nameof(FirstItemPrototype), value);
    }

    /// <summary>
    /// Gets or sets the amount of space by which to inset the controls.
    /// </summary>
    [JsonPropertyName("padding")]
    public string? Padding
    {
        get => GetProperty<string>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
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
    /// Gets or sets the cache extent in pixels.
    /// The viewport has an area before and after the visible area to cache items
    /// that are about to become visible when the user scrolls.
    /// </summary>
    [JsonPropertyName("cacheExtent")]
    public double? CacheExtent
    {
        get => GetProperty<double?>(nameof(CacheExtent));
        set => SetProperty(nameof(CacheExtent), value);
    }

    /// <summary>
    /// Gets or sets the relative position of the zero scroll offset.
    /// Defaults to 0.0.
    /// </summary>
    [JsonPropertyName("anchor")]
    public double? Anchor
    {
        get => GetProperty<double?>(nameof(Anchor));
        set => SetProperty(nameof(Anchor), value);
    }

    /// <summary>
    /// Gets or sets the velocity scalar per pixel over scroll.
    /// It represents how the velocity scales with the over scroll distance.
    /// </summary>
    [JsonPropertyName("autoScrollerVelocityScalar")]
    public double? AutoScrollerVelocityScalar
    {
        get => GetProperty<double?>(nameof(AutoScrollerVelocityScalar));
        set => SetProperty(nameof(AutoScrollerVelocityScalar), value);
    }

    /// <summary>
    /// Gets or sets a non-reorderable header item to show before the controls.
    /// </summary>
    [JsonPropertyName("header")]
    public BaseControl? Header
    {
        get => GetProperty<BaseControl>(nameof(Header));
        set => SetProperty(nameof(Header), value);
    }

    /// <summary>
    /// Gets or sets a non-reorderable footer item to show after the controls.
    /// </summary>
    [JsonPropertyName("footer")]
    public BaseControl? Footer
    {
        get => GetProperty<BaseControl>(nameof(Footer));
        set => SetProperty(nameof(Footer), value);
    }

    /// <summary>
    /// Gets or sets whether the controls should be built lazily/on-demand.
    /// This is particularly useful when dealing with a large number of controls.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("buildControlsOnDemand")]
    public bool? BuildControlsOnDemand
    {
        get => GetProperty<bool?>(nameof(BuildControlsOnDemand));
        set => SetProperty(nameof(BuildControlsOnDemand), value);
    }

    /// <summary>
    /// Gets or sets whether to show default drag handles for reordering.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("showDefaultDragHandles")]
    public bool? ShowDefaultDragHandles
    {
        get => GetProperty<bool?>(nameof(ShowDefaultDragHandles));
        set => SetProperty(nameof(ShowDefaultDragHandles), value);
    }

    /// <summary>
    /// Gets or sets the cursor for a mouse pointer hovering over this control.
    /// </summary>
    [JsonPropertyName("mouseCursor")]
    public string? MouseCursor
    {
        get => GetProperty<string>(nameof(MouseCursor));
        set => SetProperty(nameof(MouseCursor), value);
    }

    /// <summary>
    /// Occurs when a child control has been dragged to a new location in the list
    /// and the application should update the order of the items.
    /// </summary>
    public event EventHandler? Reorder;

    /// <summary>
    /// Occurs when an item drag has started.
    /// </summary>
    public event EventHandler? ReorderStart;

    /// <summary>
    /// Occurs when the dragged item is dropped.
    /// </summary>
    public event EventHandler? ReorderEnd;
}
