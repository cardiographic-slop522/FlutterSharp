using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls;

/// <summary>
/// Base class for all visual controls with common display properties.
/// Extends <see cref="BaseControl"/> with properties like visibility, opacity, tooltips, etc.
/// </summary>
public abstract class Control : BaseControl
{
    /// <summary>
    /// Gets or sets a value indicating whether the control is visible.
    /// </summary>
    [JsonPropertyName("visible")]
    public bool? Visible
    {
        get => GetProperty<bool?>(nameof(Visible));
        set => SetProperty(nameof(Visible), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the control is disabled (non-interactive).
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled
    {
        get => GetProperty<bool?>(nameof(Disabled));
        set => SetProperty(nameof(Disabled), value);
    }

    /// <summary>
    /// Gets or sets the opacity of the control (0.0 = fully transparent, 1.0 = fully opaque).
    /// </summary>
    [JsonPropertyName("opacity")]
    public double? Opacity
    {
        get => GetProperty<double?>(nameof(Opacity));
        set => SetProperty(nameof(Opacity), value);
    }

    /// <summary>
    /// Gets or sets how the control should expand to fill available space.
    /// </summary>
    [JsonPropertyName("expand")]
    public int? Expand
    {
        get => GetProperty<int?>(nameof(Expand));
        set => SetProperty(nameof(Expand), value);
    }

    /// <summary>
    /// Gets or sets the tooltip text displayed when hovering over the control.
    /// </summary>
    [JsonPropertyName("tooltip")]
    public string? Tooltip
    {
        get => GetProperty<string>(nameof(Tooltip));
        set => SetProperty(nameof(Tooltip), value);
    }

    /// <summary>
    /// Gets or sets the badge to display on the control.
    /// </summary>
    [JsonPropertyName("badge")]
    public BaseControl? Badge
    {
        get => GetProperty<BaseControl>(nameof(Badge));
        set => SetProperty(nameof(Badge), value);
    }

    /// <summary>
    /// Gets or sets the width of the control.
    /// </summary>
    [JsonPropertyName("width")]
    public double? Width
    {
        get => GetProperty<double?>(nameof(Width));
        set => SetProperty(nameof(Width), value);
    }

    /// <summary>
    /// Gets or sets the height of the control.
    /// </summary>
    [JsonPropertyName("height")]
    public double? Height
    {
        get => GetProperty<double?>(nameof(Height));
        set => SetProperty(nameof(Height), value);
    }

    /// <summary>
    /// Gets or sets the left coordinate for absolute positioning.
    /// </summary>
    [JsonPropertyName("left")]
    public double? Left
    {
        get => GetProperty<double?>(nameof(Left));
        set => SetProperty(nameof(Left), value);
    }

    /// <summary>
    /// Gets or sets the top coordinate for absolute positioning.
    /// </summary>
    [JsonPropertyName("top")]
    public double? Top
    {
        get => GetProperty<double?>(nameof(Top));
        set => SetProperty(nameof(Top), value);
    }

    /// <summary>
    /// Gets or sets the right coordinate for absolute positioning.
    /// </summary>
    [JsonPropertyName("right")]
    public double? Right
    {
        get => GetProperty<double?>(nameof(Right));
        set => SetProperty(nameof(Right), value);
    }

    /// <summary>
    /// Gets or sets the bottom coordinate for absolute positioning.
    /// </summary>
    [JsonPropertyName("bottom")]
    public double? Bottom
    {
        get => GetProperty<double?>(nameof(Bottom));
        set => SetProperty(nameof(Bottom), value);
    }

    /// <summary>
    /// Event handler for when the control is clicked.
    /// </summary>
    [JsonIgnore]
    public EventHandler? Click { get; set; }

    /// <summary>
    /// Handles an event raised by this control.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="eventData">Optional event data.</param>
    public virtual void HandleEvent(string eventName, Dictionary<string, object>? eventData = null)
    {
        switch (eventName.ToLowerInvariant())
        {
            case "click":
                Click?.Invoke(this, EventArgs.Empty);
                break;
        }
    }
}
