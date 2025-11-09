using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material-style time picker dialog.
/// Can be opened by calling Page.ShowDialog() method.
/// Depending on the TimePickerEntryMode, it will show either a Dial or
/// an Input (hour and minute text fields) for picking a time.
/// Corresponds to Flutter's TimePicker widget.
/// </summary>
[Control("TimePicker", Category = "material")]
public sealed class TimePicker : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TimePicker"/> class.
    /// </summary>
    public TimePicker()
    {
    }

    /// <summary>
    /// Gets or sets the selected time that the picker should display.
    /// The default value is equal to the current time.
    /// </summary>
    [JsonPropertyName("value")]
    public TimeOnly? Value
    {
        get => GetProperty<TimeOnly?>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets whether this time picker cannot be dismissed by clicking the area outside of it.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("modal")]
    public bool? Modal
    {
        get => GetProperty<bool?>(nameof(Modal));
        set => SetProperty(nameof(Modal), value);
    }

    /// <summary>
    /// Gets or sets the initial mode of time entry method for the time picker dialog.
    /// Values: "dial", "input", "dialOnly", "inputOnly"
    /// Defaults to "dial".
    /// </summary>
    [JsonPropertyName("timePickerEntryMode")]
    public string? TimePickerEntryMode
    {
        get => GetProperty<string>(nameof(TimePickerEntryMode));
        set => SetProperty(nameof(TimePickerEntryMode), value);
    }

    /// <summary>
    /// Gets or sets the text that is displayed below the hour input text field.
    /// Defaults to "Hour".
    /// </summary>
    [JsonPropertyName("hourLabelText")]
    public string? HourLabelText
    {
        get => GetProperty<string>(nameof(HourLabelText));
        set => SetProperty(nameof(HourLabelText), value);
    }

    /// <summary>
    /// Gets or sets the text that is displayed below the minute input text field.
    /// Defaults to "Minute".
    /// </summary>
    [JsonPropertyName("minuteLabelText")]
    public string? MinuteLabelText
    {
        get => GetProperty<string>(nameof(MinuteLabelText));
        set => SetProperty(nameof(MinuteLabelText), value);
    }

    /// <summary>
    /// Gets or sets the text that is displayed at the top of the header.
    /// This is used to indicate to the user what they are selecting a time for.
    /// Defaults to "Enter time".
    /// </summary>
    [JsonPropertyName("helpText")]
    public string? HelpText
    {
        get => GetProperty<string>(nameof(HelpText));
        set => SetProperty(nameof(HelpText), value);
    }

    /// <summary>
    /// Gets or sets the text that is displayed on the cancel button.
    /// Defaults to "Cancel".
    /// </summary>
    [JsonPropertyName("cancelText")]
    public string? CancelText
    {
        get => GetProperty<string>(nameof(CancelText));
        set => SetProperty(nameof(CancelText), value);
    }

    /// <summary>
    /// Gets or sets the text that is displayed on the confirm button.
    /// Defaults to "OK".
    /// </summary>
    [JsonPropertyName("confirmText")]
    public string? ConfirmText
    {
        get => GetProperty<string>(nameof(ConfirmText));
        set => SetProperty(nameof(ConfirmText), value);
    }

    /// <summary>
    /// Gets or sets the error message displayed below the input text field if the input is not a valid hour/minute.
    /// Defaults to "Enter a valid time".
    /// </summary>
    [JsonPropertyName("errorInvalidText")]
    public string? ErrorInvalidText
    {
        get => GetProperty<string>(nameof(ErrorInvalidText));
        set => SetProperty(nameof(ErrorInvalidText), value);
    }

    /// <summary>
    /// Gets or sets the orientation of the dialog when displayed.
    /// Values: "portrait", "landscape"
    /// </summary>
    [JsonPropertyName("orientation")]
    public string? Orientation
    {
        get => GetProperty<string>(nameof(Orientation));
        set => SetProperty(nameof(Orientation), value);
    }

    /// <summary>
    /// Gets or sets the color of the modal barrier that darkens everything below the time picker.
    /// </summary>
    [JsonPropertyName("barrierColor")]
    public string? BarrierColor
    {
        get => GetProperty<string>(nameof(BarrierColor));
        set => SetProperty(nameof(BarrierColor), value);
    }

    /// <summary>
    /// Occurs when user clicks confirm button.
    /// Value property is updated with selected time.
    /// </summary>
    public event EventHandler? Change;

    /// <summary>
    /// Occurs when the TimePickerEntryMode is changed.
    /// </summary>
    public event EventHandler? EntryModeChange;

    /// <summary>
    /// Occurs when the time picker is dismissed without selecting a time.
    /// </summary>
    public event EventHandler? Dismiss;
}
