using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design radio button.
/// Corresponds to Flutter's Radio widget.
/// </summary>
[Control("Radio", Category = "material")]
public sealed class Radio : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Radio"/> class.
    /// </summary>
    public Radio()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Radio"/> class with the specified value.
    /// </summary>
    /// <param name="value">The value this radio button represents.</param>
    /// <param name="groupValue">The currently selected value in the radio group.</param>
    /// <param name="label">Optional label text.</param>
    public Radio(string value, string? groupValue = null, string? label = null)
    {
        Value = value;
        GroupValue = groupValue;
        Label = label;
    }

    /// <summary>
    /// Gets or sets the value this radio button represents.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value
    {
        get => GetProperty<string>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets the currently selected value in the radio group.
    /// When this matches Value, the radio button appears selected.
    /// </summary>
    [JsonPropertyName("groupValue")]
    public string? GroupValue
    {
        get => GetProperty<string>(nameof(GroupValue));
        set => SetProperty(nameof(GroupValue), value);
    }

    /// <summary>
    /// Gets or sets the label text displayed next to the radio button.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label
    {
        get => GetProperty<string>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }

    /// <summary>
    /// Gets or sets the active color (color when selected).
    /// </summary>
    [JsonPropertyName("activeColor")]
    public string? ActiveColor
    {
        get => GetProperty<string>(nameof(ActiveColor));
        set => SetProperty(nameof(ActiveColor), value);
    }

    /// <summary>
    /// Gets or sets the fill color.
    /// </summary>
    [JsonPropertyName("fillColor")]
    public string? FillColor
    {
        get => GetProperty<string>(nameof(FillColor));
        set => SetProperty(nameof(FillColor), value);
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
    /// Event raised when the radio button is selected.
    /// </summary>
    public event EventHandler<RadioChangedEventArgs>? Changed;

    /// <summary>
    /// Handles events specific to Radio.
    /// </summary>
    public override void HandleEvent(string eventName, Dictionary<string, object>? eventData = null)
    {
        switch (eventName.ToLowerInvariant())
        {
            case "change":
                if (eventData?.TryGetValue("value", out var value) == true && value is string newValue)
                {
                    GroupValue = newValue;
                    Changed?.Invoke(this, new RadioChangedEventArgs { Value = newValue });
                }
                break;

            default:
                base.HandleEvent(eventName, eventData);
                break;
        }
    }
}

/// <summary>
/// Event arguments for radio button change events.
/// </summary>
public sealed class RadioChangedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the selected value.
    /// </summary>
    public required string Value { get; init; }
}
