using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design card: a panel with slightly rounded corners and an elevation shadow.
/// Corresponds to Flutter's Card widget.
/// </summary>
[Control("Card", Category = "material", IsContainer = true)]
public sealed class Card : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Card"/> class.
    /// </summary>
    public Card()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Card"/> class with content.
    /// </summary>
    /// <param name="content">The control to display inside the card.</param>
    public Card(BaseControl content)
    {
        Content = content;
    }

    /// <summary>
    /// Gets or sets the control to display inside the card.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets the z-coordinate at which to place this card.
    /// Defines the size of the shadow below the card.
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets the card's background color.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the color to paint the shadow below this card.
    /// </summary>
    [JsonPropertyName("shadowColor")]
    public string? ShadowColor
    {
        get => GetProperty<string>(nameof(ShadowColor));
        set => SetProperty(nameof(ShadowColor), value);
    }

    /// <summary>
    /// Gets or sets the color to paint the surface tint.
    /// </summary>
    [JsonPropertyName("surfaceTintColor")]
    public string? SurfaceTintColor
    {
        get => GetProperty<string>(nameof(SurfaceTintColor));
        set => SetProperty(nameof(SurfaceTintColor), value);
    }

    /// <summary>
    /// Gets or sets the shape of this card.
    /// </summary>
    [JsonPropertyName("shape")]
    public string? Shape
    {
        get => GetProperty<string>(nameof(Shape));
        set => SetProperty(nameof(Shape), value);
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
    /// Gets or sets whether this card represents a single semantic container.
    /// </summary>
    [JsonPropertyName("semanticContainer")]
    public bool? SemanticContainer
    {
        get => GetProperty<bool?>(nameof(SemanticContainer));
        set => SetProperty(nameof(SemanticContainer), value);
    }

    /// <summary>
    /// Gets or sets whether the shape of the border should be painted in front of the content or behind.
    /// </summary>
    [JsonPropertyName("showBorderOnForeground")]
    public bool? ShowBorderOnForeground
    {
        get => GetProperty<bool?>(nameof(ShowBorderOnForeground));
        set => SetProperty(nameof(ShowBorderOnForeground), value);
    }

    /// <summary>
    /// Gets or sets the card variant.
    /// Values: "elevated", "filled", "outlined"
    /// </summary>
    [JsonPropertyName("variant")]
    public string? Variant
    {
        get => GetProperty<string>(nameof(Variant));
        set => SetProperty(nameof(Variant), value);
    }

    /// <summary>
    /// Gets or sets the margin around the card.
    /// </summary>
    [JsonPropertyName("margin")]
    public string? Margin
    {
        get => GetProperty<string>(nameof(Margin));
        set => SetProperty(nameof(Margin), value);
    }
}
