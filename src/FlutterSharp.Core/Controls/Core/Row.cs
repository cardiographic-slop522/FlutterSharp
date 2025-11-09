using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A control that displays its children in a horizontal array.
/// Corresponds to Flutter's Row widget.
/// </summary>
[Control("Row", IsContainer = true, Category = "layout")]
public sealed class Row : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Row"/> class.
    /// </summary>
    public Row()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Row"/> class with the specified children.
    /// </summary>
    /// <param name="children">The child controls to add.</param>
    public Row(params BaseControl[] children)
    {
        foreach (var child in children)
        {
            AddChild(child);
        }
    }

    /// <summary>
    /// Gets or sets the horizontal alignment of children.
    /// Values: "start", "center", "end", "spaceBetween", "spaceAround", "spaceEvenly"
    /// </summary>
    [JsonPropertyName("horizontalAlignment")]
    public string? HorizontalAlignment
    {
        get => GetProperty<string>(nameof(HorizontalAlignment));
        set => SetProperty(nameof(HorizontalAlignment), value);
    }

    /// <summary>
    /// Gets or sets the vertical alignment of children.
    /// Values: "start", "center", "end", "stretch"
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
    /// Gets or sets a value indicating whether the row should scroll when content overflows.
    /// </summary>
    [JsonPropertyName("scroll")]
    public bool? Scroll
    {
        get => GetProperty<bool?>(nameof(Scroll));
        set => SetProperty(nameof(Scroll), value);
    }
}
