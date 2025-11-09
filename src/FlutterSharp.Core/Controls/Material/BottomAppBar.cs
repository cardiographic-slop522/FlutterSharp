using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design bottom app bar.
/// Typically used for bottom navigation with optional notch for FloatingActionButton.
/// Corresponds to Flutter's BottomAppBar widget.
/// </summary>
[Control("BottomAppBar", Category = "material")]
public sealed class BottomAppBar : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BottomAppBar"/> class.
    /// </summary>
    public BottomAppBar()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BottomAppBar"/> class with content.
    /// </summary>
    /// <param name="content">The content of this bottom app bar.</param>
    public BottomAppBar(BaseControl? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the content of this bottom app bar.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets the fill color to use for this app bar.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the color of the shadow below this app bar.
    /// </summary>
    [JsonPropertyName("shadowColor")]
    public string? ShadowColor
    {
        get => GetProperty<string>(nameof(ShadowColor));
        set => SetProperty(nameof(ShadowColor), value);
    }

    /// <summary>
    /// Gets or sets empty space to inscribe inside the container.
    /// </summary>
    [JsonPropertyName("padding")]
    public string? Padding
    {
        get => GetProperty<string>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets how the content of this app bar should be clipped.
    /// Values: "none", "hardEdge", "antiAlias", "antiAliasWithSaveLayer"
    /// </summary>
    [JsonPropertyName("clipBehavior")]
    public string? ClipBehavior
    {
        get => GetProperty<string>(nameof(ClipBehavior));
        set => SetProperty(nameof(ClipBehavior), value);
    }

    /// <summary>
    /// Gets or sets the notch that is made for the floating action button.
    /// Values: "circular", "auto"
    /// </summary>
    [JsonPropertyName("shape")]
    public string? Shape
    {
        get => GetProperty<string>(nameof(Shape));
        set => SetProperty(nameof(Shape), value);
    }

    /// <summary>
    /// Gets or sets the margin between the FloatingActionButton and this app bar's notch.
    /// Has effect only if Shape is not null.
    /// Defaults to 4.0.
    /// </summary>
    [JsonPropertyName("notchMargin")]
    public double? NotchMargin
    {
        get => GetProperty<double?>(nameof(NotchMargin));
        set => SetProperty(nameof(NotchMargin), value);
    }

    /// <summary>
    /// Gets or sets the z-coordinate at which to place this bottom app bar relative to its parent.
    /// It controls the size of the shadow below this app bar.
    /// Defaults to 3.
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets the border radius to apply when clipping and painting this app bar.
    /// </summary>
    [JsonPropertyName("borderRadius")]
    public string? BorderRadius
    {
        get => GetProperty<string>(nameof(BorderRadius));
        set => SetProperty(nameof(BorderRadius), value);
    }
}
