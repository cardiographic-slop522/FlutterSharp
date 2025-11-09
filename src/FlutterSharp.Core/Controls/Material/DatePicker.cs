using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material-style date picker dialog.
/// It can be opened by calling Page.ShowDialog() method.
/// Depending on the DatePickerEntryMode, it will show either a Calendar
/// or an Input (TextField) for picking a date.
/// Corresponds to Flutter's DatePicker widget.
/// </summary>
[Control("DatePicker", Category = "material")]
public sealed class DatePicker : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DatePicker"/> class.
    /// </summary>
    public DatePicker()
    {
    }

    /// <summary>
    /// Gets or sets the selected date that the picker should display.
    /// Defaults to current date.
    /// </summary>
    [JsonPropertyName("value")]
    public DateTime? Value
    {
        get => GetProperty<DateTime?>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets whether this date picker cannot be dismissed by clicking the area outside of it.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("modal")]
    public bool? Modal
    {
        get => GetProperty<bool?>(nameof(Modal));
        set => SetProperty(nameof(Modal), value);
    }

    /// <summary>
    /// Gets or sets the earliest allowable date that the user can select.
    /// Defaults to January 1, 1900.
    /// </summary>
    [JsonPropertyName("firstDate")]
    public DateTime? FirstDate
    {
        get => GetProperty<DateTime?>(nameof(FirstDate));
        set => SetProperty(nameof(FirstDate), value);
    }

    /// <summary>
    /// Gets or sets the latest allowable date that the user can select.
    /// Defaults to January 1, 2050.
    /// </summary>
    [JsonPropertyName("lastDate")]
    public DateTime? LastDate
    {
        get => GetProperty<DateTime?>(nameof(LastDate));
        set => SetProperty(nameof(LastDate), value);
    }

    /// <summary>
    /// Gets or sets the date representing today. It will be highlighted in the day grid.
    /// </summary>
    [JsonPropertyName("currentDate")]
    public DateTime? CurrentDate
    {
        get => GetProperty<DateTime?>(nameof(CurrentDate));
        set => SetProperty(nameof(CurrentDate), value);
    }

    /// <summary>
    /// Gets or sets the type of keyboard to use for editing the text.
    /// Values: "text", "multiline", "number", "phone", "datetime", "email", "url", etc.
    /// Defaults to "datetime".
    /// </summary>
    [JsonPropertyName("keyboardType")]
    public string? KeyboardType
    {
        get => GetProperty<string>(nameof(KeyboardType));
        set => SetProperty(nameof(KeyboardType), value);
    }

    /// <summary>
    /// Gets or sets the initial display mode of a calendar date picker.
    /// Values: "day", "year"
    /// Defaults to "day".
    /// </summary>
    [JsonPropertyName("datePickerMode")]
    public string? DatePickerMode
    {
        get => GetProperty<string>(nameof(DatePickerMode));
        set => SetProperty(nameof(DatePickerMode), value);
    }

    /// <summary>
    /// Gets or sets the initial mode of date entry method for the date picker dialog.
    /// Values: "calendar", "input", "calendarOnly", "inputOnly"
    /// Defaults to "calendar".
    /// </summary>
    [JsonPropertyName("datePickerEntryMode")]
    public string? DatePickerEntryMode
    {
        get => GetProperty<string>(nameof(DatePickerEntryMode));
        set => SetProperty(nameof(DatePickerEntryMode), value);
    }

    /// <summary>
    /// Gets or sets the text that is displayed at the top of the header.
    /// This is used to indicate to the user what they are selecting a date for.
    /// Defaults to "Select date".
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
    /// Gets or sets the error message displayed below the TextField if the entered date is not in the correct format.
    /// Defaults to "Invalid format".
    /// </summary>
    [JsonPropertyName("errorFormatText")]
    public string? ErrorFormatText
    {
        get => GetProperty<string>(nameof(ErrorFormatText));
        set => SetProperty(nameof(ErrorFormatText), value);
    }

    /// <summary>
    /// Gets or sets the error message displayed below the TextField if the date is earlier than FirstDate or later than LastDate.
    /// Defaults to "Out of range".
    /// </summary>
    [JsonPropertyName("errorInvalidText")]
    public string? ErrorInvalidText
    {
        get => GetProperty<string>(nameof(ErrorInvalidText));
        set => SetProperty(nameof(ErrorInvalidText), value);
    }

    /// <summary>
    /// Gets or sets the hint text displayed in the text field.
    /// The default value is the date format string that depends on your locale (e.g., 'mm/dd/yyyy' for en_US).
    /// </summary>
    [JsonPropertyName("fieldHintText")]
    public string? FieldHintText
    {
        get => GetProperty<string>(nameof(FieldHintText));
        set => SetProperty(nameof(FieldHintText), value);
    }

    /// <summary>
    /// Gets or sets the label text displayed in the TextField.
    /// Defaults to "Enter Date".
    /// </summary>
    [JsonPropertyName("fieldLabelText")]
    public string? FieldLabelText
    {
        get => GetProperty<string>(nameof(FieldLabelText));
        set => SetProperty(nameof(FieldLabelText), value);
    }

    /// <summary>
    /// Gets or sets the icon displayed in the corner of the dialog when in INPUT mode.
    /// Clicking on this icon changes the mode to CALENDAR.
    /// Can be an icon name string or a BaseControl.
    /// </summary>
    [JsonPropertyName("switchToCalendarIcon")]
    public object? SwitchToCalendarIcon
    {
        get => GetProperty<object>(nameof(SwitchToCalendarIcon));
        set => SetProperty(nameof(SwitchToCalendarIcon), value);
    }

    /// <summary>
    /// Gets or sets the icon displayed in the corner of the dialog when in CALENDAR mode.
    /// Clicking on this icon changes the mode to INPUT.
    /// Can be an icon name string or a BaseControl.
    /// </summary>
    [JsonPropertyName("switchToInputIcon")]
    public object? SwitchToInputIcon
    {
        get => GetProperty<object>(nameof(SwitchToInputIcon));
        set => SetProperty(nameof(SwitchToInputIcon), value);
    }

    /// <summary>
    /// Gets or sets the color of the modal barrier that darkens everything below the date picker.
    /// </summary>
    [JsonPropertyName("barrierColor")]
    public string? BarrierColor
    {
        get => GetProperty<string>(nameof(BarrierColor));
        set => SetProperty(nameof(BarrierColor), value);
    }

    /// <summary>
    /// Occurs when user clicks confirm button.
    /// Value is updated with selected date.
    /// </summary>
    public event EventHandler? Change;

    /// <summary>
    /// Occurs when the DatePickerEntryMode is changed.
    /// </summary>
    public event EventHandler? EntryModeChange;

    /// <summary>
    /// Occurs when the date picker is dismissed without selecting a date.
    /// </summary>
    public event EventHandler? Dismiss;
}
