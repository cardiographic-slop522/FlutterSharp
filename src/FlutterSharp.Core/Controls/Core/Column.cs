using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A control that displays its children in a vertical array.
/// Corresponds to Flutter's Column widget.
/// </summary>
[Control("Column", IsContainer = true, Category = "layout")]
public sealed class Column : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Column"/> class.
    /// </summary>
    public Column()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Column"/> class with the specified children.
    /// </summary>
    /// <param name="children">The child controls to add.</param>
    public Column(params BaseControl[] children)
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
    /// Gets or sets the vertical alignment of children.
    /// Values: "start", "center", "end", "spaceBetween", "spaceAround", "spaceEvenly"
    /// </summary>
    [JsonPropertyName("verticalAlignment")]
    public string? VerticalAlignment
    {
        get => GetProperty<string>(nameof(VerticalAlignment));
        set => SetProperty(nameof(VerticalAlignment), value);
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
    /// Gets or sets a value indicating whether children should be tightly packed.
    /// </summary>
    [JsonPropertyName("tight")]
    public bool? Tight
    {
        get => GetProperty<bool?>(nameof(Tight));
        set => SetProperty(nameof(Tight), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the column should scroll when content overflows.
    /// </summary>
    [JsonPropertyName("scroll")]
    public bool? Scroll
    {
        get => GetProperty<bool?>(nameof(Scroll));
        set => SetProperty(nameof(Scroll), value);
    }
}
