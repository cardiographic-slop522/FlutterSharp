using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design linear progress indicator, also known as a progress bar.
/// Corresponds to Flutter's ProgressBar widget.
/// </summary>
[Control("ProgressBar", Category = "material")]
public sealed class ProgressBar : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressBar"/> class.
    /// </summary>
    public ProgressBar()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressBar"/> class with a value.
    /// </summary>
    /// <param name="value">The progress value (0.0 to 1.0), or null for indeterminate.</param>
    public ProgressBar(double? value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets or sets the value of this progress indicator.
    /// A value of 0.0 means no progress and 1.0 means that progress is complete.
    /// The value will be clamped to be in the range 0.0 - 1.0.
    /// If null, displays indeterminate progress (predetermined animation).
    /// </summary>
    [JsonPropertyName("value")]
    public double? Value
    {
        get => GetProperty<double?>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets the minimum height of the line used to draw the linear indicator.
    /// </summary>
    [JsonPropertyName("barHeight")]
    public double? BarHeight
    {
        get => GetProperty<double?>(nameof(BarHeight));
        set => SetProperty(nameof(BarHeight), value);
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
    /// Gets or sets the color of the track being filled by the linear indicator.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the border radius of both the indicator and the track.
    /// </summary>
    [JsonPropertyName("borderRadius")]
    public string? BorderRadius
    {
        get => GetProperty<string>(nameof(BorderRadius));
        set => SetProperty(nameof(BorderRadius), value);
    }

    /// <summary>
    /// Gets or sets the semantics label for this progress indicator.
    /// </summary>
    [JsonPropertyName("semanticsLabel")]
    public string? SemanticsLabel
    {
        get => GetProperty<string>(nameof(SemanticsLabel));
        set => SetProperty(nameof(SemanticsLabel), value);
    }

    /// <summary>
    /// Gets or sets the semantics value for this progress indicator.
    /// </summary>
    [JsonPropertyName("semanticsValue")]
    public double? SemanticsValue
    {
        get => GetProperty<double?>(nameof(SemanticsValue));
        set => SetProperty(nameof(SemanticsValue), value);
    }

    /// <summary>
    /// Gets or sets the color of the stop indicator.
    /// </summary>
    [JsonPropertyName("stopIndicatorColor")]
    public string? StopIndicatorColor
    {
        get => GetProperty<string>(nameof(StopIndicatorColor));
        set => SetProperty(nameof(StopIndicatorColor), value);
    }

    /// <summary>
    /// Gets or sets the radius of the stop indicator.
    /// Set to 0 to hide the stop indicator.
    /// </summary>
    [JsonPropertyName("stopIndicatorRadius")]
    public double? StopIndicatorRadius
    {
        get => GetProperty<double?>(nameof(StopIndicatorRadius));
        set => SetProperty(nameof(StopIndicatorRadius), value);
    }

    /// <summary>
    /// Gets or sets the gap between the indicator and the track.
    /// Set to 0 to hide the track gap.
    /// </summary>
    [JsonPropertyName("trackGap")]
    public double? TrackGap
    {
        get => GetProperty<double?>(nameof(TrackGap));
        set => SetProperty(nameof(TrackGap), value);
    }

    /// <summary>
    /// Gets or sets whether to use the 2023 Material Design 3 appearance.
    /// If false, uses the latest appearance introduced in December 2023.
    /// </summary>
    [JsonPropertyName("year2023")]
    public bool? Year2023
    {
        get => GetProperty<bool?>(nameof(Year2023));
        set => SetProperty(nameof(Year2023), value);
    }
}
