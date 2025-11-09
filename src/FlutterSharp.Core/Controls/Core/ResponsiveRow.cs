using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// Allows aligning child controls to virtual columns.
/// By default, a virtual grid has 12 columns, but that can be customized with the Columns property.
/// Similar to the expand property, every control has a col property which allows specifying how many columns a control should span.
/// Corresponds to Flutter's ResponsiveRow widget.
/// </summary>
[Control("ResponsiveRow", Category = "core", IsContainer = true)]
public sealed class ResponsiveRow : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ResponsiveRow"/> class.
    /// </summary>
    public ResponsiveRow()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ResponsiveRow"/> class with columns.
    /// </summary>
    /// <param name="columns">The number of virtual columns to layout children.</param>
    public ResponsiveRow(int columns = 12)
    {
        Columns = columns;
    }

    /// <summary>
    /// Gets or sets the number of virtual columns to layout children.
    /// Defaults to 12.
    /// </summary>
    [JsonPropertyName("columns")]
    public int? Columns
    {
        get => GetProperty<int?>(nameof(Columns));
        set => SetProperty(nameof(Columns), value);
    }

    /// <summary>
    /// Gets or sets how the child controls should be placed horizontally.
    /// Values: "start", "end", "center", "spaceBetween", "spaceAround", "spaceEvenly"
    /// Defaults to "start".
    /// </summary>
    [JsonPropertyName("alignment")]
    public string? Alignment
    {
        get => GetProperty<string>(nameof(Alignment));
        set => SetProperty(nameof(Alignment), value);
    }

    /// <summary>
    /// Gets or sets how the child controls should be placed vertically.
    /// Values: "start", "center", "end", "stretch", "baseline"
    /// Defaults to "start".
    /// </summary>
    [JsonPropertyName("verticalAlignment")]
    public string? VerticalAlignment
    {
        get => GetProperty<string>(nameof(VerticalAlignment));
        set => SetProperty(nameof(VerticalAlignment), value);
    }

    /// <summary>
    /// Gets or sets the spacing between controls in a row in virtual pixels.
    /// Has effect only when Alignment is set to "start", "end", or "center".
    /// Defaults to 10.
    /// </summary>
    [JsonPropertyName("spacing")]
    public double? Spacing
    {
        get => GetProperty<double?>(nameof(Spacing));
        set => SetProperty(nameof(Spacing), value);
    }

    /// <summary>
    /// Gets or sets the spacing between runs when row content is wrapped on multiple lines.
    /// Defaults to 10.
    /// </summary>
    [JsonPropertyName("runSpacing")]
    public double? RunSpacing
    {
        get => GetProperty<double?>(nameof(RunSpacing));
        set => SetProperty(nameof(RunSpacing), value);
    }
}
