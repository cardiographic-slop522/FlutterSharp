using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design thin horizontal line (divider), with padding on either side.
/// Corresponds to Flutter's Divider widget.
/// </summary>
[Control("Divider", Category = "material")]
public sealed class Divider : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Divider"/> class.
    /// </summary>
    public Divider()
    {
    }

    /// <summary>
    /// Gets or sets the color to use when painting the line.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color
    {
        get => GetProperty<string>(nameof(Color));
        set => SetProperty(nameof(Color), value);
    }

    /// <summary>
    /// Gets or sets the divider's height extent.
    /// The divider itself is always drawn as a horizontal line that is centered within the height specified by this value.
    /// </summary>
    [JsonPropertyName("height")]
    public new double? Height
    {
        get => GetProperty<double?>(nameof(Height));
        set => SetProperty(nameof(Height), value);
    }

    /// <summary>
    /// Gets or sets the amount of empty space to the leading edge of the divider.
    /// </summary>
    [JsonPropertyName("leadingIndent")]
    public double? LeadingIndent
    {
        get => GetProperty<double?>(nameof(LeadingIndent));
        set => SetProperty(nameof(LeadingIndent), value);
    }

    /// <summary>
    /// Gets or sets the thickness of the line drawn within the divider.
    /// A divider with a thickness of 0.0 is always drawn as a line with a height of exactly one device pixel.
    /// </summary>
    [JsonPropertyName("thickness")]
    public double? Thickness
    {
        get => GetProperty<double?>(nameof(Thickness));
        set => SetProperty(nameof(Thickness), value);
    }

    /// <summary>
    /// Gets or sets the amount of empty space to the trailing edge of the divider.
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
