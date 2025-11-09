using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design slider for selecting a value from a range.
/// Corresponds to Flutter's Slider widget.
/// </summary>
[Control("Slider", Category = "material")]
public sealed class Slider : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Slider"/> class.
    /// </summary>
    public Slider()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Slider"/> class with the specified range.
    /// </summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="value">The initial value.</param>
    public Slider(double min, double max, double value = 0)
    {
        Min = min;
        Max = max;
        Value = value;
    }

    /// <summary>
    /// Gets or sets the current value of the slider.
    /// </summary>
    [JsonPropertyName("value")]
    public double? Value
    {
        get => GetProperty<double?>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    [JsonPropertyName("min")]
    public double? Min
    {
        get => GetProperty<double?>(nameof(Min));
        set => SetProperty(nameof(Min), value);
    }

    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    [JsonPropertyName("max")]
    public double? Max
    {
        get => GetProperty<double?>(nameof(Max));
        set => SetProperty(nameof(Max), value);
    }

    /// <summary>
    /// Gets or sets the number of discrete divisions.
    /// If set, the slider will snap to discrete values.
    /// </summary>
    [JsonPropertyName("divisions")]
    public int? Divisions
    {
        get => GetProperty<int?>(nameof(Divisions));
        set => SetProperty(nameof(Divisions), value);
    }

    /// <summary>
    /// Gets or sets the label displayed above the slider thumb.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label
    {
        get => GetProperty<string>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }

    /// <summary>
    /// Gets or sets the active color.
    /// </summary>
    [JsonPropertyName("activeColor")]
    public string? ActiveColor
    {
        get => GetProperty<string>(nameof(ActiveColor));
        set => SetProperty(nameof(ActiveColor), value);
    }

    /// <summary>
    /// Gets or sets the inactive color.
    /// </summary>
    [JsonPropertyName("inactiveColor")]
    public string? InactiveColor
    {
        get => GetProperty<string>(nameof(InactiveColor));
        set => SetProperty(nameof(InactiveColor), value);
    }

    /// <summary>
    /// Gets or sets the thumb color.
    /// </summary>
    [JsonPropertyName("thumbColor")]
    public string? ThumbColor
    {
        get => GetProperty<string>(nameof(ThumbColor));
        set => SetProperty(nameof(ThumbColor), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether autofocus is enabled.
    /// </summary>
    [JsonPropertyName("autofocus")]
    public bool? Autofocus
    {
        get => GetProperty<bool?>(nameof(Autofocus));
        set => SetProperty(nameof(Autofocus), value);
    }

    /// <summary>
    /// Event raised when the slider value changes.
    /// </summary>
    public event EventHandler<SliderChangedEventArgs>? Changed;

    /// <summary>
    /// Event raised when the user finishes changing the slider value.
    /// </summary>
    public event EventHandler<SliderChangedEventArgs>? ChangeEnd;

    /// <summary>
    /// Handles events specific to Slider.
    /// </summary>
    public override void HandleEvent(string eventName, Dictionary<string, object>? eventData = null)
    {
        switch (eventName.ToLowerInvariant())
        {
            case "change":
                if (eventData?.TryGetValue("value", out var value) == true)
                {
                    var newValue = Convert.ToDouble(value);
                    Value = newValue;
                    Changed?.Invoke(this, new SliderChangedEventArgs { Value = newValue });
                }
                break;

            case "change_end":
                if (eventData?.TryGetValue("value", out var endValue) == true)
                {
                    var newValue = Convert.ToDouble(endValue);
                    ChangeEnd?.Invoke(this, new SliderChangedEventArgs { Value = newValue });
                }
                break;

            default:
                base.HandleEvent(eventName, eventData);
                break;
        }
    }
}

/// <summary>
/// Event arguments for slider change events.
/// </summary>
public sealed class SliderChangedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the new slider value.
    /// </summary>
    public double Value { get; init; }
}
