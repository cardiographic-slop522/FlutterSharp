using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Displays a modal bottom sheet.
/// A bottom sheet is an alternative to a menu or dialog and prevents the user
/// from interacting with the rest of the app.
/// Corresponds to Flutter's BottomSheet widget.
/// </summary>
[Control("BottomSheet", Category = "material")]
public sealed class BottomSheet : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BottomSheet"/> class.
    /// </summary>
    public BottomSheet()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BottomSheet"/> class with content.
    /// </summary>
    /// <param name="content">The content control.</param>
    /// <param name="open">Whether the bottom sheet is open.</param>
    public BottomSheet(BaseControl? content = null, bool open = false)
    {
        if (content != null) Content = content;
        Open = open;
    }

    /// <summary>
    /// Gets or sets the content of this bottom sheet.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets whether the bottom sheet is currently open.
    /// </summary>
    [JsonPropertyName("open")]
    public bool? Open
    {
        get => GetProperty<bool?>(nameof(Open));
        set => SetProperty(nameof(Open), value);
    }

    /// <summary>
    /// Gets or sets the elevation of this bottom sheet.
    /// Defines the size of the shadow below the bottom sheet.
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets the background color of this bottom sheet.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets whether this bottom sheet will be dismissed when user taps on the scrim.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("dismissible")]
    public bool? Dismissible
    {
        get => GetProperty<bool?>(nameof(Dismissible));
        set => SetProperty(nameof(Dismissible), value);
    }

    /// <summary>
    /// Gets or sets whether this bottom sheet can be dragged up and down and dismissed by swiping downwards.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("enableDrag")]
    public bool? EnableDrag
    {
        get => GetProperty<bool?>(nameof(EnableDrag));
        set => SetProperty(nameof(EnableDrag), value);
    }

    /// <summary>
    /// Gets or sets whether to display drag handle at the top of sheet or not.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("showDragHandle")]
    public bool? ShowDragHandle
    {
        get => GetProperty<bool?>(nameof(ShowDragHandle));
        set => SetProperty(nameof(ShowDragHandle), value);
    }

    /// <summary>
    /// Gets or sets whether the sheet will avoid system intrusions on the top, left, and right.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("useSafeArea")]
    public bool? UseSafeArea
    {
        get => GetProperty<bool?>(nameof(UseSafeArea));
        set => SetProperty(nameof(UseSafeArea), value);
    }

    /// <summary>
    /// Gets or sets whether this bottom sheet contains scrollable content, such as ListView or GridView.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("scrollControlled")]
    public bool? ScrollControlled
    {
        get => GetProperty<bool?>(nameof(ScrollControlled));
        set => SetProperty(nameof(ScrollControlled), value);
    }

    /// <summary>
    /// Gets or sets whether to add a padding at the bottom to avoid obstructing the bottom sheet's
    /// content with on-screen keyboard or other system elements.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("maintainBottomViewInsetsPadding")]
    public bool? MaintainBottomViewInsetsPadding
    {
        get => GetProperty<bool?>(nameof(MaintainBottomViewInsetsPadding));
        set => SetProperty(nameof(MaintainBottomViewInsetsPadding), value);
    }

    /// <summary>
    /// Gets or sets how the content of this bottom sheet should be clipped.
    /// Values: "none", "hardEdge", "antiAlias", "antiAliasWithSaveLayer"
    /// </summary>
    [JsonPropertyName("clipBehavior")]
    public string? ClipBehavior
    {
        get => GetProperty<string>(nameof(ClipBehavior));
        set => SetProperty(nameof(ClipBehavior), value);
    }

    /// <summary>
    /// Gets or sets the shape of this bottom sheet.
    /// </summary>
    [JsonPropertyName("shape")]
    public string? Shape
    {
        get => GetProperty<string>(nameof(Shape));
        set => SetProperty(nameof(Shape), value);
    }

    /// <summary>
    /// Gets or sets the color of the scrim that obscures content behind this bottom sheet.
    /// </summary>
    [JsonPropertyName("barrierColor")]
    public string? BarrierColor
    {
        get => GetProperty<string>(nameof(BarrierColor));
        set => SetProperty(nameof(BarrierColor), value);
    }
}
