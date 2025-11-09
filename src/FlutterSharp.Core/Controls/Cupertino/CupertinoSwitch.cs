using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Cupertino;

/// <summary>
/// An iOS-style switch.
/// Used to toggle the on/off state of a single setting with iOS design language.
/// Corresponds to Flutter's CupertinoSwitch widget.
/// </summary>
[Control("CupertinoSwitch", Category = "cupertino")]
public sealed class CupertinoSwitch : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoSwitch"/> class.
    /// </summary>
    public CupertinoSwitch()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoSwitch"/> class with a value.
    /// </summary>
    /// <param name="value">The initial value of this switch.</param>
    public CupertinoSwitch(bool value = false)
    {
        Value = value;
    }

    /// <summary>
    /// Gets or sets the clickable label to display on the right of this switch.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label
    {
        get => GetProperty<string>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }

    /// <summary>
    /// Gets or sets the current value of this switch.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("value")]
    public bool? Value
    {
        get => GetProperty<bool?>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets the position of the label relative to this switch.
    /// Values: "left", "right"
    /// Defaults to "right".
    /// </summary>
    [JsonPropertyName("labelPosition")]
    public string? LabelPosition
    {
        get => GetProperty<string>(nameof(LabelPosition));
        set => SetProperty(nameof(LabelPosition), value);
    }

    /// <summary>
    /// Gets or sets the color of this switch's thumb.
    /// </summary>
    [JsonPropertyName("thumbColor")]
    public string? ThumbColor
    {
        get => GetProperty<string>(nameof(ThumbColor));
        set => SetProperty(nameof(ThumbColor), value);
    }

    /// <summary>
    /// Gets or sets the color to use for the focus highlight for keyboard interactions.
    /// </summary>
    [JsonPropertyName("focusColor")]
    public string? FocusColor
    {
        get => GetProperty<string>(nameof(FocusColor));
        set => SetProperty(nameof(FocusColor), value);
    }

    /// <summary>
    /// Gets or sets whether this switch will be selected as the initial focus.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("autofocus")]
    public bool? Autofocus
    {
        get => GetProperty<bool?>(nameof(Autofocus));
        set => SetProperty(nameof(Autofocus), value);
    }

    /// <summary>
    /// Gets or sets the color to use for the accessibility label when the switch is on.
    /// </summary>
    [JsonPropertyName("onLabelColor")]
    public string? OnLabelColor
    {
        get => GetProperty<string>(nameof(OnLabelColor));
        set => SetProperty(nameof(OnLabelColor), value);
    }

    /// <summary>
    /// Gets or sets the color to use for the accessibility label when the switch is off.
    /// </summary>
    [JsonPropertyName("offLabelColor")]
    public string? OffLabelColor
    {
        get => GetProperty<string>(nameof(OffLabelColor));
        set => SetProperty(nameof(OffLabelColor), value);
    }

    /// <summary>
    /// Gets or sets an image to use on the thumb of this switch when the switch is on.
    /// Can be a local file path or URL.
    /// </summary>
    [JsonPropertyName("activeThumbImage")]
    public string? ActiveThumbImage
    {
        get => GetProperty<string>(nameof(ActiveThumbImage));
        set => SetProperty(nameof(ActiveThumbImage), value);
    }

    /// <summary>
    /// Gets or sets an image to use on the thumb of this switch when the switch is off.
    /// Can be a local file path or URL.
    /// </summary>
    [JsonPropertyName("inactiveThumbImage")]
    public string? InactiveThumbImage
    {
        get => GetProperty<string>(nameof(InactiveThumbImage));
        set => SetProperty(nameof(InactiveThumbImage), value);
    }

    /// <summary>
    /// Gets or sets the color to use on the track when this switch is on.
    /// </summary>
    [JsonPropertyName("activeTrackColor")]
    public string? ActiveTrackColor
    {
        get => GetProperty<string>(nameof(ActiveTrackColor));
        set => SetProperty(nameof(ActiveTrackColor), value);
    }

    /// <summary>
    /// Gets or sets the color to use on the thumb when this switch is off.
    /// If null, defaults to ThumbColor, and if this is also null, defaults to white.
    /// </summary>
    [JsonPropertyName("inactiveThumbColor")]
    public string? InactiveThumbColor
    {
        get => GetProperty<string>(nameof(InactiveThumbColor));
        set => SetProperty(nameof(InactiveThumbColor), value);
    }

    /// <summary>
    /// Gets or sets the color to use on the track when this switch is off.
    /// </summary>
    [JsonPropertyName("inactiveTrackColor")]
    public string? InactiveTrackColor
    {
        get => GetProperty<string>(nameof(InactiveTrackColor));
        set => SetProperty(nameof(InactiveTrackColor), value);
    }

    /// <summary>
    /// Gets or sets the outline color of this switch's track.
    /// Can be a single color or a JSON map of ControlState values.
    /// </summary>
    [JsonPropertyName("trackOutlineColor")]
    public string? TrackOutlineColor
    {
        get => GetProperty<string>(nameof(TrackOutlineColor));
        set => SetProperty(nameof(TrackOutlineColor), value);
    }

    /// <summary>
    /// Gets or sets the outline width of this switch's track.
    /// Can be a single value or a JSON map of ControlState values.
    /// </summary>
    [JsonPropertyName("trackOutlineWidth")]
    public string? TrackOutlineWidth
    {
        get => GetProperty<string>(nameof(TrackOutlineWidth));
        set => SetProperty(nameof(TrackOutlineWidth), value);
    }

    /// <summary>
    /// Gets or sets the icon of this switch's thumb.
    /// Can be a single icon name or a JSON map of ControlState values.
    /// </summary>
    [JsonPropertyName("thumbIcon")]
    public string? ThumbIcon
    {
        get => GetProperty<string>(nameof(ThumbIcon));
        set => SetProperty(nameof(ThumbIcon), value);
    }

    /// <summary>
    /// Occurs when the state of this switch is changed.
    /// </summary>
    public event EventHandler? Change;

    /// <summary>
    /// Occurs when this switch has received focus.
    /// </summary>
    public event EventHandler? Focus;

    /// <summary>
    /// Occurs when this switch has lost focus.
    /// </summary>
    public event EventHandler? Blur;

    /// <summary>
    /// Occurs when active_thumb_image or inactive_thumb_image fails to load.
    /// </summary>
    public event EventHandler? ImageError;
}
