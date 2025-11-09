using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design range slider. Used to select a range from a range of values.
/// A range slider can be used to select from either a continuous or a discrete set of values.
/// The default is to use a continuous range of values from min to max.
/// Corresponds to Flutter's RangeSlider widget.
/// </summary>
[Control("RangeSlider", Category = "material", IsContainer = true)]
public sealed class RangeSlider : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RangeSlider"/> class.
    /// </summary>
    public RangeSlider()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RangeSlider"/> class with start and end values.
    /// </summary>
    /// <param name="startValue">The start value of the range.</param>
    /// <param name="endValue">The end value of the range.</param>
    /// <param name="min">The minimum value (default 0.0).</param>
    /// <param name="max">The maximum value (default 1.0).</param>
    public RangeSlider(double startValue, double endValue, double min = 0.0, double max = 1.0)
    {
        StartValue = startValue;
        EndValue = endValue;
        Min = min;
        Max = max;
    }

    /// <summary>
    /// Gets or sets the currently selected start value for the slider.
    /// The slider's left thumb is drawn at a position that corresponds to this value.
    /// </summary>
    [JsonPropertyName("startValue")]
    public double? StartValue
    {
        get => GetProperty<double?>(nameof(StartValue));
        set => SetProperty(nameof(StartValue), value);
    }

    /// <summary>
    /// Gets or sets the currently selected end value for the slider.
    /// The slider's right thumb is drawn at a position that corresponds to this value.
    /// </summary>
    [JsonPropertyName("endValue")]
    public double? EndValue
    {
        get => GetProperty<double?>(nameof(EndValue));
        set => SetProperty(nameof(EndValue), value);
    }

    /// <summary>
    /// Gets or sets a label to show above the slider thumbs when the slider is active.
    /// The value may contain {value} which will be replaced with the current slider values.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label
    {
        get => GetProperty<string>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }

    /// <summary>
    /// Gets or sets the minimum value the user can select.
    /// Defaults to 0.0. Must be less than or equal to Max.
    /// </summary>
    [JsonPropertyName("min")]
    public double? Min
    {
        get => GetProperty<double?>(nameof(Min));
        set => SetProperty(nameof(Min), value);
    }

    /// <summary>
    /// Gets or sets the maximum value the user can select.
    /// Defaults to 1.0. Must be greater than or equal to Min.
    /// </summary>
    [JsonPropertyName("max")]
    public double? Max
    {
        get => GetProperty<double?>(nameof(Max));
        set => SetProperty(nameof(Max), value);
    }

    /// <summary>
    /// Gets or sets the number of discrete divisions.
    /// Typically used with Label to show the current discrete values.
    /// If not set, the slider is continuous.
    /// </summary>
    [JsonPropertyName("divisions")]
    public int? Divisions
    {
        get => GetProperty<int?>(nameof(Divisions));
        set => SetProperty(nameof(Divisions), value);
    }

    /// <summary>
    /// Gets or sets the number of decimals displayed on the label containing {value}.
    /// The default is 0 (displays value rounded to the nearest integer).
    /// </summary>
    [JsonPropertyName("round")]
    public int? Round
    {
        get => GetProperty<int?>(nameof(Round));
        set => SetProperty(nameof(Round), value);
    }

    /// <summary>
    /// Gets or sets the color to use for the portion of the slider track that is active.
    /// The "active" segment of the range slider is the span between the thumbs.
    /// </summary>
    [JsonPropertyName("activeColor")]
    public string? ActiveColor
    {
        get => GetProperty<string>(nameof(ActiveColor));
        set => SetProperty(nameof(ActiveColor), value);
    }

    /// <summary>
    /// Gets or sets the color for the inactive portions of the slider track.
    /// The "inactive" segments are the span of tracks between the min and the start thumb, and the end thumb and the max.
    /// </summary>
    [JsonPropertyName("inactiveColor")]
    public string? InactiveColor
    {
        get => GetProperty<string>(nameof(InactiveColor));
        set => SetProperty(nameof(InactiveColor), value);
    }

    /// <summary>
    /// Gets or sets the highlight color that's typically used to indicate that the range slider thumb is hovered or dragged.
    /// </summary>
    [JsonPropertyName("overlayColor")]
    public string? OverlayColor
    {
        get => GetProperty<string>(nameof(OverlayColor));
        set => SetProperty(nameof(OverlayColor), value);
    }

    /// <summary>
    /// Gets or sets the cursor for a mouse pointer entering or hovering over this control.
    /// </summary>
    [JsonPropertyName("mouseCursor")]
    public string? MouseCursor
    {
        get => GetProperty<string>(nameof(MouseCursor));
        set => SetProperty(nameof(MouseCursor), value);
    }

    /// <summary>
    /// Occurs when the state of the RangeSlider is changed.
    /// </summary>
    public event EventHandler? Change;

    /// <summary>
    /// Occurs when the user starts selecting a new value for the slider.
    /// </summary>
    public event EventHandler? ChangeStart;

    /// <summary>
    /// Occurs when the user is done selecting a new value for the slider.
    /// </summary>
    public event EventHandler? ChangeEnd;
}
