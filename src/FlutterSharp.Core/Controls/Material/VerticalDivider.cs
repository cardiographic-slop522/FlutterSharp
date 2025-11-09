using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A thin vertical line, with padding on either side.
/// In the Material Design language, this represents a divider.
/// Corresponds to Flutter's VerticalDivider widget.
/// </summary>
[Control("VerticalDivider", Category = "material")]
public sealed class VerticalDivider : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VerticalDivider"/> class.
    /// </summary>
    public VerticalDivider()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VerticalDivider"/> class with optional parameters.
    /// </summary>
    /// <param name="width">The divider's width.</param>
    /// <param name="thickness">The thickness of the line.</param>
    /// <param name="color">The color of the divider.</param>
    public VerticalDivider(double? width = null, double? thickness = null, string? color = null)
    {
        if (width.HasValue) Width = width.Value;
        if (thickness.HasValue) Thickness = thickness.Value;
        if (color != null) Color = color;
    }

    /// <summary>
    /// Gets or sets the divider's width. The divider itself is always drawn as a vertical line
    /// that is centered within the width specified by this value.
    /// If null, defaults to 16.0 (or DividerTheme.space if defined).
    /// Note: This hides the Width property from the base Control class because VerticalDivider
    /// uses Width to define the horizontal space occupied (not layout width).
    /// </summary>
    [JsonPropertyName("width")]
    public new double? Width
    {
        get => GetProperty<double?>(nameof(Width));
        set => SetProperty(nameof(Width), value);
    }

    /// <summary>
    /// Gets or sets the thickness of this divider.
    /// A divider with a thickness of 0.0 is always drawn as a line with a width of exactly one device pixel.
    /// If null, defaults to 0.0 (or DividerTheme.thickness if defined).
    /// </summary>
    [JsonPropertyName("thickness")]
    public double? Thickness
    {
        get => GetProperty<double?>(nameof(Thickness));
        set => SetProperty(nameof(Thickness), value);
    }

    /// <summary>
    /// Gets or sets the color to use when painting the line.
    /// If null, DividerTheme.color is used.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color
    {
        get => GetProperty<string>(nameof(Color));
        set => SetProperty(nameof(Color), value);
    }

    /// <summary>
    /// Gets or sets the amount of empty space to the leading edge (top) of the divider.
    /// If null, defaults to 0.0 (or DividerTheme.leadingIndent if defined).
    /// </summary>
    [JsonPropertyName("leadingIndent")]
    public double? LeadingIndent
    {
        get => GetProperty<double?>(nameof(LeadingIndent));
        set => SetProperty(nameof(LeadingIndent), value);
    }

    /// <summary>
    /// Gets or sets the amount of empty space to the trailing edge (bottom) of the divider.
    /// If null, defaults to 0.0 (or DividerTheme.trailingIndent if defined).
    /// </summary>
    [JsonPropertyName("trailingIndent")]
    public double? TrailingIndent
    {
        get => GetProperty<double?>(nameof(TrailingIndent));
        set => SetProperty(nameof(TrailingIndent), value);
    }

    /// <summary>
    /// Gets or sets the border radius of the divider.
    /// </summary>
    [JsonPropertyName("radius")]
    public string? Radius
    {
        get => GetProperty<string>(nameof(Radius));
        set => SetProperty(nameof(Radius), value);
    }
}
