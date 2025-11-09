using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// Allows you to pan, zoom, and rotate its content.
/// Provides interactive viewing capabilities for images, charts, or any other content.
/// Corresponds to Flutter's InteractiveViewer widget.
/// </summary>
[Control("InteractiveViewer", Category = "core")]
public sealed class InteractiveViewer : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InteractiveViewer"/> class.
    /// </summary>
    public InteractiveViewer()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InteractiveViewer"/> class with content.
    /// </summary>
    /// <param name="content">The control to be transformed.</param>
    public InteractiveViewer(BaseControl? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the control to be transformed.
    /// Must be visible.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets whether panning is enabled.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("panEnabled")]
    public bool? PanEnabled
    {
        get => GetProperty<bool?>(nameof(PanEnabled));
        set => SetProperty(nameof(PanEnabled), value);
    }

    /// <summary>
    /// Gets or sets whether scaling is enabled.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("scaleEnabled")]
    public bool? ScaleEnabled
    {
        get => GetProperty<bool?>(nameof(ScaleEnabled));
        set => SetProperty(nameof(ScaleEnabled), value);
    }

    /// <summary>
    /// Gets or sets whether scrolling up/down on a trackpad should cause scaling instead of panning.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("trackpadScrollCausesScale")]
    public bool? TrackpadScrollCausesScale
    {
        get => GetProperty<bool?>(nameof(TrackpadScrollCausesScale));
        set => SetProperty(nameof(TrackpadScrollCausesScale), value);
    }

    /// <summary>
    /// Gets or sets whether the normal size constraints at this point in the widget tree are applied to the child.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("constrained")]
    public bool? Constrained
    {
        get => GetProperty<bool?>(nameof(Constrained));
        set => SetProperty(nameof(Constrained), value);
    }

    /// <summary>
    /// Gets or sets the maximum allowed scale.
    /// Defaults to 2.5.
    /// </summary>
    [JsonPropertyName("maxScale")]
    public double? MaxScale
    {
        get => GetProperty<double?>(nameof(MaxScale));
        set => SetProperty(nameof(MaxScale), value);
    }

    /// <summary>
    /// Gets or sets the minimum allowed scale.
    /// Defaults to 0.8.
    /// </summary>
    [JsonPropertyName("minScale")]
    public double? MinScale
    {
        get => GetProperty<double?>(nameof(MinScale));
        set => SetProperty(nameof(MinScale), value);
    }

    /// <summary>
    /// Gets or sets the deceleration behavior after a gesture.
    /// Defaults to 0.0000135.
    /// </summary>
    [JsonPropertyName("interactionEndFrictionCoefficient")]
    public double? InteractionEndFrictionCoefficient
    {
        get => GetProperty<double?>(nameof(InteractionEndFrictionCoefficient));
        set => SetProperty(nameof(InteractionEndFrictionCoefficient), value);
    }

    /// <summary>
    /// Gets or sets the amount of scale to be performed per pointer scroll.
    /// Defaults to 200.
    /// </summary>
    [JsonPropertyName("scaleFactor")]
    public double? ScaleFactor
    {
        get => GetProperty<double?>(nameof(ScaleFactor));
        set => SetProperty(nameof(ScaleFactor), value);
    }

    /// <summary>
    /// Gets or sets how to clip the content.
    /// Values: "none", "hardEdge", "antiAlias", "antiAliasWithSaveLayer"
    /// Defaults to "hardEdge".
    /// </summary>
    [JsonPropertyName("clipBehavior")]
    public string? ClipBehavior
    {
        get => GetProperty<string>(nameof(ClipBehavior));
        set => SetProperty(nameof(ClipBehavior), value);
    }

    /// <summary>
    /// Gets or sets the alignment of the content within this viewer.
    /// </summary>
    [JsonPropertyName("alignment")]
    public string? Alignment
    {
        get => GetProperty<string>(nameof(Alignment));
        set => SetProperty(nameof(Alignment), value);
    }

    /// <summary>
    /// Gets or sets a margin for the visible boundaries of the content.
    /// </summary>
    [JsonPropertyName("boundaryMargin")]
    public string? BoundaryMargin
    {
        get => GetProperty<string>(nameof(BoundaryMargin));
        set => SetProperty(nameof(BoundaryMargin), value);
    }

    /// <summary>
    /// Gets or sets the interval (in milliseconds) at which the InteractionUpdate event is fired.
    /// Defaults to 200.
    /// </summary>
    [JsonPropertyName("interactionUpdateInterval")]
    public int? InteractionUpdateInterval
    {
        get => GetProperty<int?>(nameof(InteractionUpdateInterval));
        set => SetProperty(nameof(InteractionUpdateInterval), value);
    }

    /// <summary>
    /// Occurs when the user begins a pan or scale gesture.
    /// </summary>
    public event EventHandler? InteractionStart;

    /// <summary>
    /// Occurs when the user updates a pan or scale gesture.
    /// </summary>
    public event EventHandler? InteractionUpdate;

    /// <summary>
    /// Occurs when the user ends a pan or scale gesture.
    /// </summary>
    public event EventHandler? InteractionEnd;
}
