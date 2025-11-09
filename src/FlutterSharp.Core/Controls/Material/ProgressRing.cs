using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design circular progress indicator, which spins to indicate that the application is busy.
/// Corresponds to Flutter's CircularProgressIndicator widget.
/// </summary>
[Control("ProgressRing", Category = "material")]
public sealed class ProgressRing : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressRing"/> class.
    /// </summary>
    public ProgressRing()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressRing"/> class with a value.
    /// </summary>
    /// <param name="value">The progress value (0.0 to 1.0), or null for indeterminate.</param>
    public ProgressRing(double? value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets or sets the value of this progress indicator.
    /// A value of 0.0 means no progress and 1.0 means that progress is complete.
    /// If null, displays indeterminate progress (spinning animation).
    /// </summary>
    [JsonPropertyName("value")]
    public double? Value
    {
        get => GetProperty<double?>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets the width of the line used to draw the circle.
    /// </summary>
    [JsonPropertyName("strokeWidth")]
    public double? StrokeWidth
    {
        get => GetProperty<double?>(nameof(StrokeWidth));
        set => SetProperty(nameof(StrokeWidth), value);
    }

    /// <summary>
    /// Gets or sets the progress indicator's color.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color
    {
        get => GetProperty<string>(nameof(Color));
        set => SetProperty(nameof(Color), value);
    }

    /// <summary>
    /// Gets or sets the color of the circular track being filled by the circular indicator.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the relative position of the stroke.
    /// Value typically ranges between -1.0 (inside stroke) and 1.0 (outside stroke).
    /// A value of 0 (center stroke) will center the border on the edge of the control.
    /// </summary>
    [JsonPropertyName("strokeAlign")]
    public double? StrokeAlign
    {
        get => GetProperty<double?>(nameof(StrokeAlign));
        set => SetProperty(nameof(StrokeAlign), value);
    }

    /// <summary>
    /// Gets or sets the progress indicator's line ending.
    /// Values: "butt", "round", "square"
    /// </summary>
    [JsonPropertyName("strokeCap")]
    public string? StrokeCap
    {
        get => GetProperty<string>(nameof(StrokeCap));
        set => SetProperty(nameof(StrokeCap), value);
    }

    /// <summary>
    /// Gets or sets the semantics label for accessibility.
    /// </summary>
    [JsonPropertyName("semanticsLabel")]
    public string? SemanticsLabel
    {
        get => GetProperty<string>(nameof(SemanticsLabel));
        set => SetProperty(nameof(SemanticsLabel), value);
    }

    /// <summary>
    /// Gets or sets the semantics value for determinate progress indicators.
    /// </summary>
    [JsonPropertyName("semanticsValue")]
    public double? SemanticsValue
    {
        get => GetProperty<double?>(nameof(SemanticsValue));
        set => SetProperty(nameof(SemanticsValue), value);
    }

    /// <summary>
    /// Gets or sets the gap between the active indicator and the background track.
    /// Set to 0 to hide the track gap.
    /// </summary>
    [JsonPropertyName("trackGap")]
    public double? TrackGap
    {
        get => GetProperty<double?>(nameof(TrackGap));
        set => SetProperty(nameof(TrackGap), value);
    }

    /// <summary>
    /// Gets or sets the padding around the indicator track.
    /// </summary>
    [JsonPropertyName("padding")]
    public string? Padding
    {
        get => GetProperty<string>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets whether to use the 2023 Material Design 3 appearance.
    /// </summary>
    [JsonPropertyName("year2023")]
    public bool? Year2023
    {
        get => GetProperty<bool?>(nameof(Year2023));
        set => SetProperty(nameof(Year2023), value);
    }
}
