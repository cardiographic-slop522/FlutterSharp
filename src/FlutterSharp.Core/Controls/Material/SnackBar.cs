using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A lightweight message with an optional action which briefly displays at the bottom of the screen.
/// Corresponds to Flutter's SnackBar widget.
/// </summary>
[Control("SnackBar", Category = "material")]
public sealed class SnackBar : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SnackBar"/> class.
    /// </summary>
    public SnackBar()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SnackBar"/> class with content.
    /// </summary>
    /// <param name="content">The primary content (text or control).</param>
    public SnackBar(object content)
    {
        Content = content;
    }

    /// <summary>
    /// Gets or sets the primary content of the snack bar.
    /// Can be a string or a BaseControl (typically Text).
    /// </summary>
    [JsonPropertyName("content")]
    public object? Content
    {
        get => GetProperty<object>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets whether the snack bar is currently open.
    /// </summary>
    [JsonPropertyName("open")]
    public bool? Open
    {
        get => GetProperty<bool?>(nameof(Open));
        set => SetProperty(nameof(Open), value);
    }

    /// <summary>
    /// Gets or sets the behavior and location of the snack bar.
    /// Values: "fixed", "floating"
    /// </summary>
    [JsonPropertyName("behavior")]
    public string? Behavior
    {
        get => GetProperty<string>(nameof(Behavior));
        set => SetProperty(nameof(Behavior), value);
    }

    /// <summary>
    /// Gets or sets the direction in which the snack bar can be dismissed.
    /// Values: "none", "vertical", "horizontal", "endToStart", "startToEnd", "up", "down"
    /// </summary>
    [JsonPropertyName("dismissDirection")]
    public string? DismissDirection
    {
        get => GetProperty<string>(nameof(DismissDirection));
        set => SetProperty(nameof(DismissDirection), value);
    }

    /// <summary>
    /// Gets or sets whether to include a "close" icon widget.
    /// </summary>
    [JsonPropertyName("showCloseIcon")]
    public bool? ShowCloseIcon
    {
        get => GetProperty<bool?>(nameof(ShowCloseIcon));
        set => SetProperty(nameof(ShowCloseIcon), value);
    }

    /// <summary>
    /// Gets or sets an optional action text label.
    /// </summary>
    [JsonPropertyName("action")]
    public string? Action
    {
        get => GetProperty<string>(nameof(Action));
        set => SetProperty(nameof(Action), value);
    }

    /// <summary>
    /// Gets or sets the color of the close icon.
    /// </summary>
    [JsonPropertyName("closeIconColor")]
    public string? CloseIconColor
    {
        get => GetProperty<string>(nameof(CloseIconColor));
        set => SetProperty(nameof(CloseIconColor), value);
    }

    /// <summary>
    /// Gets or sets the snack bar background color.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the amount of time (in milliseconds) this snack bar should stay open for.
    /// Default is 4000ms (4 seconds).
    /// </summary>
    [JsonPropertyName("duration")]
    public int? Duration
    {
        get => GetProperty<int?>(nameof(Duration));
        set => SetProperty(nameof(Duration), value);
    }

    /// <summary>
    /// Gets or sets the empty space to surround the snack bar.
    /// Has effect only when behavior is "floating".
    /// </summary>
    [JsonPropertyName("margin")]
    public string? Margin
    {
        get => GetProperty<string>(nameof(Margin));
        set => SetProperty(nameof(Margin), value);
    }

    /// <summary>
    /// Gets or sets the amount of padding to apply to the snack bar's content and optional action.
    /// </summary>
    [JsonPropertyName("padding")]
    public string? Padding
    {
        get => GetProperty<string>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets the width of the snack bar.
    /// Has effect only when behavior is "floating".
    /// </summary>
    [JsonPropertyName("width")]
    public new double? Width
    {
        get => GetProperty<double?>(nameof(Width));
        set => SetProperty(nameof(Width), value);
    }

    /// <summary>
    /// Gets or sets the elevation (z-coordinate) at which to place the snack bar.
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets the shape of this snack bar.
    /// </summary>
    [JsonPropertyName("shape")]
    public string? Shape
    {
        get => GetProperty<string>(nameof(Shape));
        set => SetProperty(nameof(Shape), value);
    }

    /// <summary>
    /// Gets or sets how the content will be clipped.
    /// Values: "none", "hardEdge", "antiAlias", "antiAliasWithSaveLayer"
    /// </summary>
    [JsonPropertyName("clipBehavior")]
    public string? ClipBehavior
    {
        get => GetProperty<string>(nameof(ClipBehavior));
        set => SetProperty(nameof(ClipBehavior), value);
    }

    /// <summary>
    /// Gets or sets the percentage threshold for action's width before it overflows to a new line.
    /// Value should be between 0.0 and 1.0.
    /// </summary>
    [JsonPropertyName("actionOverflowThreshold")]
    public double? ActionOverflowThreshold
    {
        get => GetProperty<double?>(nameof(ActionOverflowThreshold));
        set => SetProperty(nameof(ActionOverflowThreshold), value);
    }
}
