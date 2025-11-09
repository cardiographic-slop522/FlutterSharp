using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Badges are used to show notifications, counts, or status information on navigation items or buttons.
/// Corresponds to Flutter's Badge widget.
/// </summary>
[Control("Badge", Category = "material")]
public sealed class Badge : BaseControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Badge"/> class.
    /// </summary>
    public Badge()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Badge"/> class with a label.
    /// </summary>
    /// <param name="label">The badge label text (typically 1-4 characters).</param>
    public Badge(string label)
    {
        Label = label;
    }

    /// <summary>
    /// Gets or sets the label of this badge.
    /// Typically a 1 to 4 characters text.
    /// If not provided, the badge is shown as a filled circle.
    /// Can be a string or a BaseControl.
    /// </summary>
    [JsonPropertyName("label")]
    public object? Label
    {
        get => GetProperty<object>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }

    /// <summary>
    /// Gets or sets the offset combined with alignment to determine the location of the label relative to the content.
    /// </summary>
    [JsonPropertyName("offset")]
    public string? Offset
    {
        get => GetProperty<string>(nameof(Offset));
        set => SetProperty(nameof(Offset), value);
    }

    /// <summary>
    /// Gets or sets the alignment of the label relative to the content of the badge.
    /// </summary>
    [JsonPropertyName("alignment")]
    public string? Alignment
    {
        get => GetProperty<string>(nameof(Alignment));
        set => SetProperty(nameof(Alignment), value);
    }

    /// <summary>
    /// Gets or sets the background color of the label.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets whether the label should be visible.
    /// Can be used to create a badge only shown under certain conditions.
    /// </summary>
    [JsonPropertyName("labelVisible")]
    public bool? LabelVisible
    {
        get => GetProperty<bool?>(nameof(LabelVisible));
        set => SetProperty(nameof(LabelVisible), value);
    }

    /// <summary>
    /// Gets or sets the badge's label height if label is provided.
    /// </summary>
    [JsonPropertyName("largeSize")]
    public double? LargeSize
    {
        get => GetProperty<double?>(nameof(LargeSize));
        set => SetProperty(nameof(LargeSize), value);
    }

    /// <summary>
    /// Gets or sets the padding added to the label.
    /// </summary>
    [JsonPropertyName("padding")]
    public string? Padding
    {
        get => GetProperty<string>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets the badge's label diameter if label is not provided.
    /// </summary>
    [JsonPropertyName("smallSize")]
    public double? SmallSize
    {
        get => GetProperty<double?>(nameof(SmallSize));
        set => SetProperty(nameof(SmallSize), value);
    }

    /// <summary>
    /// Gets or sets the color of the text shown in the label.
    /// </summary>
    [JsonPropertyName("textColor")]
    public string? TextColor
    {
        get => GetProperty<string>(nameof(TextColor));
        set => SetProperty(nameof(TextColor), value);
    }
}
