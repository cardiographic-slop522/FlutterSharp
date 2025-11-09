using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// An alert dialog informs the user about situations that require acknowledgement.
/// Corresponds to Flutter's AlertDialog widget.
/// </summary>
[Control("AlertDialog", Category = "material")]
public sealed class AlertDialog : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AlertDialog"/> class.
    /// </summary>
    public AlertDialog()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AlertDialog"/> class with title and content.
    /// </summary>
    /// <param name="title">The title text or control.</param>
    /// <param name="content">The content control.</param>
    public AlertDialog(object? title = null, BaseControl? content = null)
    {
        if (title != null) Title = title;
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the content of this dialog displayed in the center.
    /// Typically a Column that contains Text messages.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets whether dialog can be dismissed by clicking outside of it.
    /// </summary>
    [JsonPropertyName("modal")]
    public bool? Modal
    {
        get => GetProperty<bool?>(nameof(Modal));
        set => SetProperty(nameof(Modal), value);
    }

    /// <summary>
    /// Gets or sets the title of this dialog displayed in a large font at the top.
    /// Can be a string or a BaseControl.
    /// </summary>
    [JsonPropertyName("title")]
    public object? Title
    {
        get => GetProperty<object>(nameof(Title));
        set => SetProperty(nameof(Title), value);
    }

    /// <summary>
    /// Gets or sets whether the dialog is currently open.
    /// </summary>
    [JsonPropertyName("open")]
    public bool? Open
    {
        get => GetProperty<bool?>(nameof(Open));
        set => SetProperty(nameof(Open), value);
    }

    /// <summary>
    /// Gets or sets the background color of this dialog's surface.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the elevation (z-coordinate) at which this dialog should appear.
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets a control displayed at the top of this dialog.
    /// Typically an Icon control.
    /// </summary>
    [JsonPropertyName("icon")]
    public BaseControl? Icon
    {
        get => GetProperty<BaseControl>(nameof(Icon));
        set => SetProperty(nameof(Icon), value);
    }

    /// <summary>
    /// Gets or sets the padding around the title.
    /// </summary>
    [JsonPropertyName("titlePadding")]
    public string? TitlePadding
    {
        get => GetProperty<string>(nameof(TitlePadding));
        set => SetProperty(nameof(TitlePadding), value);
    }

    /// <summary>
    /// Gets or sets the padding around the content.
    /// </summary>
    [JsonPropertyName("contentPadding")]
    public string? ContentPadding
    {
        get => GetProperty<string>(nameof(ContentPadding));
        set => SetProperty(nameof(ContentPadding), value);
    }

    /// <summary>
    /// Gets or sets the padding around the set of actions at the bottom.
    /// </summary>
    [JsonPropertyName("actionsPadding")]
    public string? ActionsPadding
    {
        get => GetProperty<string>(nameof(ActionsPadding));
        set => SetProperty(nameof(ActionsPadding), value);
    }

    /// <summary>
    /// Gets or sets the horizontal layout of the actions.
    /// Values: "start", "end", "center", "spaceBetween", "spaceAround", "spaceEvenly"
    /// </summary>
    [JsonPropertyName("actionsAlignment")]
    public string? ActionsAlignment
    {
        get => GetProperty<string>(nameof(ActionsAlignment));
        set => SetProperty(nameof(ActionsAlignment), value);
    }

    /// <summary>
    /// Gets or sets the shape of this dialog.
    /// </summary>
    [JsonPropertyName("shape")]
    public string? Shape
    {
        get => GetProperty<string>(nameof(Shape));
        set => SetProperty(nameof(Shape), value);
    }

    /// <summary>
    /// Gets or sets the padding around this dialog itself.
    /// </summary>
    [JsonPropertyName("insetPadding")]
    public string? InsetPadding
    {
        get => GetProperty<string>(nameof(InsetPadding));
        set => SetProperty(nameof(InsetPadding), value);
    }

    /// <summary>
    /// Gets or sets the padding around the icon.
    /// </summary>
    [JsonPropertyName("iconPadding")]
    public string? IconPadding
    {
        get => GetProperty<string>(nameof(IconPadding));
        set => SetProperty(nameof(IconPadding), value);
    }

    /// <summary>
    /// Gets or sets the padding that surrounds each button in actions.
    /// </summary>
    [JsonPropertyName("actionButtonPadding")]
    public string? ActionButtonPadding
    {
        get => GetProperty<string>(nameof(ActionButtonPadding));
        set => SetProperty(nameof(ActionButtonPadding), value);
    }

    /// <summary>
    /// Gets or sets the shadow color under this dialog.
    /// </summary>
    [JsonPropertyName("shadowColor")]
    public string? ShadowColor
    {
        get => GetProperty<string>(nameof(ShadowColor));
        set => SetProperty(nameof(ShadowColor), value);
    }

    /// <summary>
    /// Gets or sets the color for the icon.
    /// </summary>
    [JsonPropertyName("iconColor")]
    public string? IconColor
    {
        get => GetProperty<string>(nameof(IconColor));
        set => SetProperty(nameof(IconColor), value);
    }

    /// <summary>
    /// Gets or sets whether the title and content are wrapped in a scrollable.
    /// </summary>
    [JsonPropertyName("scrollable")]
    public bool? Scrollable
    {
        get => GetProperty<bool?>(nameof(Scrollable));
        set => SetProperty(nameof(Scrollable), value);
    }

    /// <summary>
    /// Gets or sets the spacing between actions when they overflow to a column layout.
    /// </summary>
    [JsonPropertyName("actionsOverflowButtonSpacing")]
    public double? ActionsOverflowButtonSpacing
    {
        get => GetProperty<double?>(nameof(ActionsOverflowButtonSpacing));
        set => SetProperty(nameof(ActionsOverflowButtonSpacing), value);
    }

    /// <summary>
    /// Gets or sets how to align this dialog.
    /// </summary>
    [JsonPropertyName("alignment")]
    public string? Alignment
    {
        get => GetProperty<string>(nameof(Alignment));
        set => SetProperty(nameof(Alignment), value);
    }

    /// <summary>
    /// Gets or sets how the contents are clipped to the given shape.
    /// Values: "none", "hardEdge", "antiAlias", "antiAliasWithSaveLayer"
    /// </summary>
    [JsonPropertyName("clipBehavior")]
    public string? ClipBehavior
    {
        get => GetProperty<string>(nameof(ClipBehavior));
        set => SetProperty(nameof(ClipBehavior), value);
    }

    /// <summary>
    /// Gets or sets the semantic label for accessibility frameworks.
    /// </summary>
    [JsonPropertyName("semanticsLabel")]
    public string? SemanticsLabel
    {
        get => GetProperty<string>(nameof(SemanticsLabel));
        set => SetProperty(nameof(SemanticsLabel), value);
    }

    /// <summary>
    /// Gets or sets the color of the modal barrier that darkens everything below the dialog.
    /// </summary>
    [JsonPropertyName("barrierColor")]
    public string? BarrierColor
    {
        get => GetProperty<string>(nameof(BarrierColor));
        set => SetProperty(nameof(BarrierColor), value);
    }
}
