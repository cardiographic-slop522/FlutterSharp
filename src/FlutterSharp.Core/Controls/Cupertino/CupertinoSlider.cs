using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Cupertino;

/// <summary>
/// An iOS-style slider.
/// Provides a visual indication of adjustable content, as well as the current setting in the total range of content.
/// Use a slider when you want people to set defined values (such as volume or brightness), or when people would benefit from instant feedback.
/// Corresponds to Flutter's CupertinoSlider widget.
/// </summary>
[Control("CupertinoSlider", Category = "cupertino")]
public sealed class CupertinoSlider : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoSlider"/> class.
    /// </summary>
    public CupertinoSlider()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoSlider"/> class with a value.
    /// </summary>
    /// <param name="value">The initial value of this slider.</param>
    public CupertinoSlider(double value = 0.0)
    {
        Value = value;
    }

    /// <summary>
    /// Gets or sets the currently selected value for this slider.
    /// The slider's thumb is drawn at a position that corresponds to this value.
    /// Must be between min and max.
    /// </summary>
    [JsonPropertyName("value")]
    public double? Value
    {
        get => GetProperty<double?>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets the minimum value the user can select.
    /// Must be less than or equal to max.
    /// If the max is equal to the min, then this slider is disabled.
    /// Defaults to 0.0.
    /// </summary>
    [JsonPropertyName("min")]
    public double? Min
    {
        get => GetProperty<double?>(nameof(Min));
        set => SetProperty(nameof(Min), value);
    }

    /// <summary>
    /// Gets or sets the maximum value the user can select.
    /// Must be greater than or equal to min.
    /// If the min is equal to the max, then this slider is disabled.
    /// Defaults to 1.0.
    /// </summary>
    [JsonPropertyName("max")]
    public double? Max
    {
        get => GetProperty<double?>(nameof(Max));
        set => SetProperty(nameof(Max), value);
    }

    /// <summary>
    /// Gets or sets the number of discrete divisions.
    /// If null, the slider is continuous.
    /// </summary>
    [JsonPropertyName("divisions")]
    public int? Divisions
    {
        get => GetProperty<int?>(nameof(Divisions));
        set => SetProperty(nameof(Divisions), value);
    }

    /// <summary>
    /// Gets or sets the color to use for the portion of the slider track that is active.
    /// The "active" side of the slider is the side between the thumb and the minimum value.
    /// </summary>
    [JsonPropertyName("activeColor")]
    public string? ActiveColor
    {
        get => GetProperty<string>(nameof(ActiveColor));
        set => SetProperty(nameof(ActiveColor), value);
    }

    /// <summary>
    /// Gets or sets the color of this slider's thumb.
    /// </summary>
    [JsonPropertyName("thumbColor")]
    public string? ThumbColor
    {
        get => GetProperty<string>(nameof(ThumbColor));
        set => SetProperty(nameof(ThumbColor), value);
    }

    /// <summary>
    /// Occurs when the state of this slider changed.
    /// </summary>
    public event EventHandler? Change;

    /// <summary>
    /// Occurs when the user starts selecting a new value for this slider.
    /// </summary>
    public event EventHandler? ChangeStart;

    /// <summary>
    /// Occurs when the user is done selecting a new value for this slider.
    /// </summary>
    public event EventHandler? ChangeEnd;

    /// <summary>
    /// Occurs when this slider has received focus.
    /// </summary>
    public event EventHandler? Focus;

    /// <summary>
    /// Occurs when this slider has lost focus.
    /// </summary>
    public event EventHandler? Blur;
}
