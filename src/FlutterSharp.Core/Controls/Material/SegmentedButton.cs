using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A segment for a SegmentedButton.
/// Corresponds to Flutter's Segment widget.
/// </summary>
[Control("Segment", Category = "material")]
public sealed class Segment : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Segment"/> class.
    /// </summary>
    public Segment()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Segment"/> class with value and label.
    /// </summary>
    /// <param name="value">The value to identify the segment.</param>
    /// <param name="label">The label to display.</param>
    /// <param name="icon">Optional icon to display.</param>
    public Segment(string value, object? label = null, object? icon = null)
    {
        Value = value;
        if (label != null) Label = label;
        if (icon != null) Icon = icon;
    }

    /// <summary>
    /// Gets or sets the value used to identify the segment.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value
    {
        get => GetProperty<string>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets the icon to be displayed in the segment.
    /// Can be an icon name string or a BaseControl (typically Icon).
    /// </summary>
    [JsonPropertyName("icon")]
    public object? Icon
    {
        get => GetProperty<object>(nameof(Icon));
        set => SetProperty(nameof(Icon), value);
    }

    /// <summary>
    /// Gets or sets the label to be displayed in the segment.
    /// Can be a string or a BaseControl (typically Text).
    /// At least one of Icon or Label must be set.
    /// </summary>
    [JsonPropertyName("label")]
    public object? Label
    {
        get => GetProperty<object>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }
}

/// <summary>
/// A segmented button control that allows selecting one or more options from a set of segments.
/// Corresponds to Flutter's SegmentedButton widget.
/// </summary>
[Control("SegmentedButton", Category = "material")]
public sealed class SegmentedButton : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SegmentedButton"/> class.
    /// </summary>
    public SegmentedButton()
    {
    }

    /// <summary>
    /// Gets or sets the button style.
    /// </summary>
    [JsonPropertyName("style")]
    public string? Style
    {
        get => GetProperty<string>(nameof(Style));
        set => SetProperty(nameof(Style), value);
    }

    /// <summary>
    /// Gets or sets whether having no selected segments is allowed.
    /// If true, it is acceptable for none of the segments to be selected.
    /// If false (default), there must be at least one segment selected.
    /// </summary>
    [JsonPropertyName("allowEmptySelection")]
    public bool? AllowEmptySelection
    {
        get => GetProperty<bool?>(nameof(AllowEmptySelection));
        set => SetProperty(nameof(AllowEmptySelection), value);
    }

    /// <summary>
    /// Gets or sets whether multiple segments can be selected at one time.
    /// If true, more than one segment can be selected.
    /// If false (default), only one segment can be selected at a time.
    /// </summary>
    [JsonPropertyName("allowMultipleSelection")]
    public bool? AllowMultipleSelection
    {
        get => GetProperty<bool?>(nameof(AllowMultipleSelection));
        set => SetProperty(nameof(AllowMultipleSelection), value);
    }

    /// <summary>
    /// Gets or sets whether the segments should be displayed in a single column or row.
    /// Values: "horizontal", "vertical"
    /// Defaults to "horizontal".
    /// </summary>
    [JsonPropertyName("direction")]
    public string? Direction
    {
        get => GetProperty<string>(nameof(Direction));
        set => SetProperty(nameof(Direction), value);
    }

    /// <summary>
    /// Gets or sets whether the label text should be displayed or not.
    /// </summary>
    [JsonPropertyName("showSelectedIcon")]
    public bool? ShowSelectedIcon
    {
        get => GetProperty<bool?>(nameof(ShowSelectedIcon));
        set => SetProperty(nameof(ShowSelectedIcon), value);
    }

    /// <summary>
    /// Gets or sets the selected icon to display.
    /// Can be an icon name string or a BaseControl.
    /// </summary>
    [JsonPropertyName("selectedIcon")]
    public object? SelectedIcon
    {
        get => GetProperty<object>(nameof(SelectedIcon));
        set => SetProperty(nameof(SelectedIcon), value);
    }

    /// <summary>
    /// Occurs when the selection changes.
    /// </summary>
    public event EventHandler? Change;
}
