using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design checkbox.
/// Corresponds to Flutter's Checkbox widget.
/// </summary>
[Control("Checkbox", Category = "material")]
public sealed class Checkbox : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Checkbox"/> class.
    /// </summary>
    public Checkbox()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Checkbox"/> class with the specified state.
    /// </summary>
    /// <param name="value">The initial checked state.</param>
    /// <param name="label">Optional label text.</param>
    /// <param name="onChanged">Optional change event handler.</param>
    public Checkbox(bool value, string? label = null, EventHandler<CheckboxChangedEventArgs>? onChanged = null)
    {
        Value = value;
        Label = label;
        if (onChanged != null)
        {
            Changed = onChanged;
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the checkbox is checked.
    /// </summary>
    [JsonPropertyName("value")]
    public bool? Value
    {
        get => GetProperty<bool?>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets the label text displayed next to the checkbox.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label
    {
        get => GetProperty<string>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the checkbox is in a tristate mode.
    /// When true, the checkbox can have three states: true, false, or null.
    /// </summary>
    [JsonPropertyName("tristate")]
    public bool? Tristate
    {
        get => GetProperty<bool?>(nameof(Tristate));
        set => SetProperty(nameof(Tristate), value);
    }

    /// <summary>
    /// Gets or sets the active color (color when checked).
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
    /// Gets or sets the check color (color of the checkmark).
    /// </summary>
    [JsonPropertyName("checkColor")]
    public string? CheckColor
    {
        get => GetProperty<string>(nameof(CheckColor));
        set => SetProperty(nameof(CheckColor), value);
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
    /// Event raised when the checkbox state changes.
    /// </summary>
    public event EventHandler<CheckboxChangedEventArgs>? Changed;

    /// <summary>
    /// Handles events specific to Checkbox.
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
                        bool b => (bool?)b,
                        string s when bool.TryParse(s, out var b) => b,
                        _ => null
                    };

                    Value = newValue;
                    Changed?.Invoke(this, new CheckboxChangedEventArgs { Value = newValue });
                }
                break;

            default:
                base.HandleEvent(eventName, eventData);
                break;
        }
    }
}

/// <summary>
/// Event arguments for checkbox change events.
/// </summary>
public sealed class CheckboxChangedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the new checkbox value.
    /// </summary>
    public bool? Value { get; init; }
}
