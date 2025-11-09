using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design switch.
/// Corresponds to Flutter's Switch widget.
/// </summary>
[Control("Switch", Category = "material")]
public sealed class Switch : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Switch"/> class.
    /// </summary>
    public Switch()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Switch"/> class with the specified state.
    /// </summary>
    /// <param name="value">The initial switch state.</param>
    /// <param name="label">Optional label text.</param>
    /// <param name="onChanged">Optional change event handler.</param>
    public Switch(bool value, string? label = null, EventHandler<SwitchChangedEventArgs>? onChanged = null)
    {
        Value = value;
        Label = label;
        if (onChanged != null)
        {
            Changed = onChanged;
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the switch is on.
    /// </summary>
    [JsonPropertyName("value")]
    public bool? Value
    {
        get => GetProperty<bool?>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets the label text displayed next to the switch.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label
    {
        get => GetProperty<string>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }

    /// <summary>
    /// Gets or sets the active color (color when on).
    /// </summary>
    [JsonPropertyName("activeColor")]
    public string? ActiveColor
    {
        get => GetProperty<string>(nameof(ActiveColor));
        set => SetProperty(nameof(ActiveColor), value);
    }

    /// <summary>
    /// Gets or sets the active track color.
    /// </summary>
    [JsonPropertyName("activeTrackColor")]
    public string? ActiveTrackColor
    {
        get => GetProperty<string>(nameof(ActiveTrackColor));
        set => SetProperty(nameof(ActiveTrackColor), value);
    }

    /// <summary>
    /// Gets or sets the inactive thumb color.
    /// </summary>
    [JsonPropertyName("inactiveThumbColor")]
    public string? InactiveThumbColor
    {
        get => GetProperty<string>(nameof(InactiveThumbColor));
        set => SetProperty(nameof(InactiveThumbColor), value);
    }

    /// <summary>
    /// Gets or sets the inactive track color.
    /// </summary>
    [JsonPropertyName("inactiveTrackColor")]
    public string? InactiveTrackColor
    {
        get => GetProperty<string>(nameof(InactiveTrackColor));
        set => SetProperty(nameof(InactiveTrackColor), value);
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
    /// Event raised when the switch state changes.
    /// </summary>
    public event EventHandler<SwitchChangedEventArgs>? Changed;

    /// <summary>
    /// Handles events specific to Switch.
    /// </summary>
    public override void HandleEvent(string eventName, Dictionary<string, object>? eventData = null)
    {
        switch (eventName.ToLowerInvariant())
        {
            case "change":
                if (eventData?.TryGetValue("value", out var value) == true)
                {
                    var newValue = value switch
                    {
                        bool b => b,
                        string s when bool.TryParse(s, out var b) => b,
                        _ => false
                    };

                    Value = newValue;
                    Changed?.Invoke(this, new SwitchChangedEventArgs { Value = newValue });
                }
                break;

            default:
                base.HandleEvent(eventName, eventData);
                break;
        }
    }
}

/// <summary>
/// Event arguments for switch change events.
/// </summary>
public sealed class SwitchChangedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the new switch value.
    /// </summary>
    public bool Value { get; init; }
}
