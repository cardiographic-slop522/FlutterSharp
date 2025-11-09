using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material-style date range picker dialog.
/// Depending on the date picker entry mode, it will show either a Calendar or an Input (TextField) for picking a date range.
/// Corresponds to Flutter's DateRangePicker dialog.
/// </summary>
[Control("DateRangePicker", Category = "material")]
public sealed class DateRangePicker : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DateRangePicker"/> class.
    /// </summary>
    public DateRangePicker()
    {
    }

    /// <summary>
    /// Gets or sets the selected start date that the picker should display.
    /// Defaults to current date.
    /// </summary>
    [JsonPropertyName("startValue")]
    public DateTime? StartValue
    {
        get => GetProperty<DateTime?>(nameof(StartValue));
        set => SetProperty(nameof(StartValue), value);
    }

    /// <summary>
    /// Gets or sets the selected end date that the picker should display.
    /// Defaults to current date.
    /// </summary>
    [JsonPropertyName("endValue")]
    public DateTime? EndValue
    {
        get => GetProperty<DateTime?>(nameof(EndValue));
        set => SetProperty(nameof(EndValue), value);
    }

    /// <summary>
    /// Gets or sets the label on the save button for the fullscreen calendar mode.
    /// </summary>
    [JsonPropertyName("saveText")]
    public string? SaveText
    {
        get => GetProperty<string>(nameof(SaveText));
        set => SetProperty(nameof(SaveText), value);
    }

    /// <summary>
    /// Gets or sets the message used when the date range is invalid (e.g. start date is after end date).
    /// </summary>
    [JsonPropertyName("errorInvalidRangeText")]
    public string? ErrorInvalidRangeText
    {
        get => GetProperty<string>(nameof(ErrorInvalidRangeText));
        set => SetProperty(nameof(ErrorInvalidRangeText), value);
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
    /// Gets or sets the earliest allowable date on the date range.
    /// Defaults to January 1, 1900.
    /// </summary>
    [JsonPropertyName("firstDate")]
    public DateTime? FirstDate
    {
        get => GetProperty<DateTime?>(nameof(FirstDate));
        set => SetProperty(nameof(FirstDate), value);
    }

    /// <summary>
    /// Gets or sets the latest allowable date on the date range.
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
    /// Defaults to current date.
    /// </summary>
    [JsonPropertyName("currentDate")]
    public DateTime? CurrentDate
    {
        get => GetProperty<DateTime?>(nameof(CurrentDate));
        set => SetProperty(nameof(CurrentDate), value);
    }

    /// <summary>
    /// Gets or sets the initial mode of date entry method for the date picker dialog.
    /// Values: "calendar", "calendarOnly", "input", "inputOnly"
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
    /// </summary>
    [JsonPropertyName("helpText")]
    public string? HelpText
    {
        get => GetProperty<string>(nameof(HelpText));
        set => SetProperty(nameof(HelpText), value);
    }

    /// <summary>
    /// Gets or sets the text that is displayed on the cancel button.
    /// </summary>
    [JsonPropertyName("cancelText")]
    public string? CancelText
    {
        get => GetProperty<string>(nameof(CancelText));
        set => SetProperty(nameof(CancelText), value);
    }

    /// <summary>
    /// Gets or sets the text that is displayed on the confirm button.
    /// </summary>
    [JsonPropertyName("confirmText")]
    public string? ConfirmText
    {
        get => GetProperty<string>(nameof(ConfirmText));
        set => SetProperty(nameof(ConfirmText), value);
    }

    /// <summary>
    /// Gets or sets the error message displayed below the TextField if the entered date is not in the correct format.
    /// </summary>
    [JsonPropertyName("errorFormatText")]
    public string? ErrorFormatText
    {
        get => GetProperty<string>(nameof(ErrorFormatText));
        set => SetProperty(nameof(ErrorFormatText), value);
    }

    /// <summary>
    /// Gets or sets the error message displayed below the TextField if the date is earlier than FirstDate or later than LastDate.
    /// </summary>
    [JsonPropertyName("errorInvalidText")]
    public string? ErrorInvalidText
    {
        get => GetProperty<string>(nameof(ErrorInvalidText));
        set => SetProperty(nameof(ErrorInvalidText), value);
    }

    /// <summary>
    /// Gets or sets the text used to prompt the user when no text has been entered in the start field.
    /// </summary>
    [JsonPropertyName("fieldStartHintText")]
    public string? FieldStartHintText
    {
        get => GetProperty<string>(nameof(FieldStartHintText));
        set => SetProperty(nameof(FieldStartHintText), value);
    }

    /// <summary>
    /// Gets or sets the text used to prompt the user when no text has been entered in the end field.
    /// </summary>
    [JsonPropertyName("fieldEndHintText")]
    public string? FieldEndHintText
    {
        get => GetProperty<string>(nameof(FieldEndHintText));
        set => SetProperty(nameof(FieldEndHintText), value);
    }

    /// <summary>
    /// Gets or sets the label for the start date text input field.
    /// </summary>
    [JsonPropertyName("fieldStartLabelText")]
    public string? FieldStartLabelText
    {
        get => GetProperty<string>(nameof(FieldStartLabelText));
        set => SetProperty(nameof(FieldStartLabelText), value);
    }

    /// <summary>
    /// Gets or sets the label for the end date text input field.
    /// </summary>
    [JsonPropertyName("fieldEndLabelText")]
    public string? FieldEndLabelText
    {
        get => GetProperty<string>(nameof(FieldEndLabelText));
        set => SetProperty(nameof(FieldEndLabelText), value);
    }

    /// <summary>
    /// Gets or sets the name of the icon displayed when switching to calendar mode.
    /// </summary>
    [JsonPropertyName("switchToCalendarIcon")]
    public string? SwitchToCalendarIcon
    {
        get => GetProperty<string>(nameof(SwitchToCalendarIcon));
        set => SetProperty(nameof(SwitchToCalendarIcon), value);
    }

    /// <summary>
    /// Gets or sets the name of the icon displayed when switching to input mode.
    /// </summary>
    [JsonPropertyName("switchToInputIcon")]
    public string? SwitchToInputIcon
    {
        get => GetProperty<string>(nameof(SwitchToInputIcon));
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
    /// StartValue and EndValue are updated with selected dates.
    /// </summary>
    public event EventHandler? Change;
}
