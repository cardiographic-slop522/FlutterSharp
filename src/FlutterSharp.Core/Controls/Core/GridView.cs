using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A scrollable, 2D array of controls.
/// Corresponds to Flutter's GridView widget.
/// Very effective for large lists (thousands of items).
/// </summary>
[Control("GridView", Category = "layout", IsContainer = true)]
public sealed class GridView : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GridView"/> class.
    /// </summary>
    public GridView()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GridView"/> class with runs count.
    /// </summary>
    /// <param name="runsCount">The number of children in the cross axis.</param>
    public GridView(int runsCount)
    {
        RunsCount = runsCount;
    }

    /// <summary>
    /// Gets or sets whether to layout the grid items horizontally.
    /// </summary>
    [JsonPropertyName("horizontal")]
    public bool? Horizontal
    {
        get => GetProperty<bool?>(nameof(Horizontal));
        set => SetProperty(nameof(Horizontal), value);
    }

    /// <summary>
    /// Gets or sets whether the scroll view scrolls in the reverse direction.
    /// </summary>
    [JsonPropertyName("reverse")]
    public bool? Reverse
    {
        get => GetProperty<bool?>(nameof(Reverse));
        set => SetProperty(nameof(Reverse), value);
    }

    /// <summary>
    /// Gets or sets the number of children in the cross axis.
    /// </summary>
    [JsonPropertyName("runsCount")]
    public int? RunsCount
    {
        get => GetProperty<int?>(nameof(RunsCount));
        set => SetProperty(nameof(RunsCount), value);
    }

    /// <summary>
    /// Gets or sets the maximum width or height of the grid item.
    /// </summary>
    [JsonPropertyName("maxExtent")]
    public int? MaxExtent
    {
        get => GetProperty<int?>(nameof(MaxExtent));
        set => SetProperty(nameof(MaxExtent), value);
    }

    /// <summary>
    /// Gets or sets the number of logical pixels between each child along the main axis.
    /// </summary>
    [JsonPropertyName("spacing")]
    public double? Spacing
    {
        get => GetProperty<double?>(nameof(Spacing));
        set => SetProperty(nameof(Spacing), value);
    }

    /// <summary>
    /// Gets or sets the number of logical pixels between each child along the cross axis.
    /// </summary>
    [JsonPropertyName("runSpacing")]
    public double? RunSpacing
    {
        get => GetProperty<double?>(nameof(RunSpacing));
        set => SetProperty(nameof(RunSpacing), value);
    }

    /// <summary>
    /// Gets or sets the ratio of the cross-axis to the main-axis extent of each child.
    /// </summary>
    [JsonPropertyName("childAspectRatio")]
    public double? ChildAspectRatio
    {
        get => GetProperty<double?>(nameof(ChildAspectRatio));
        set => SetProperty(nameof(ChildAspectRatio), value);
    }

    /// <summary>
    /// Gets or sets the amount of space by which to inset the children.
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
    /// </summary>
    [JsonPropertyName("clipBehavior")]
    public string? ClipBehavior
    {
        get => GetProperty<string>(nameof(ClipBehavior));
        set => SetProperty(nameof(ClipBehavior), value);
    }

    /// <summary>
    /// Gets or sets the number of children that will contribute semantic information.
    /// </summary>
    [JsonPropertyName("semanticChildCount")]
    public int? SemanticChildCount
    {
        get => GetProperty<int?>(nameof(SemanticChildCount));
        set => SetProperty(nameof(SemanticChildCount), value);
    }

    /// <summary>
    /// Gets or sets how many pixels the cache area extends before the leading edge and after the trailing edge of the viewport.
    /// </summary>
    [JsonPropertyName("cacheExtent")]
    public double? CacheExtent
    {
        get => GetProperty<double?>(nameof(CacheExtent));
        set => SetProperty(nameof(CacheExtent), value);
    }

    /// <summary>
    /// Gets or sets whether to build controls on demand.
    /// </summary>
    [JsonPropertyName("buildControlsOnDemand")]
    public bool? BuildControlsOnDemand
    {
        get => GetProperty<bool?>(nameof(BuildControlsOnDemand));
        set => SetProperty(nameof(BuildControlsOnDemand), value);
    }
}
