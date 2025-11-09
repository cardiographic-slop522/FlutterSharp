using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A placeholder box that draws a rectangle with crossed diagonal lines.
/// Useful during development to indicate where a control will eventually be placed.
/// Corresponds to Flutter's Placeholder widget.
/// </summary>
[Control("Placeholder", Category = "core")]
public sealed class Placeholder : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Placeholder"/> class.
    /// </summary>
    public Placeholder()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Placeholder"/> class with optional content.
    /// </summary>
    /// <param name="content">An optional control to display inside the placeholder.</param>
    public Placeholder(BaseControl? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets an optional control to display inside the placeholder.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets the color of the placeholder box.
    /// Defaults to blue grey.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color
    {
        get => GetProperty<string>(nameof(Color));
        set => SetProperty(nameof(Color), value);
    }

    /// <summary>
    /// Gets or sets the height to use when the placeholder is in a situation with an unbounded height.
    /// Defaults to 400.
    /// </summary>
    [JsonPropertyName("fallbackHeight")]
    public double? FallbackHeight
    {
        get => GetProperty<double?>(nameof(FallbackHeight));
        set => SetProperty(nameof(FallbackHeight), value);
    }

    /// <summary>
    /// Gets or sets the width to use when the placeholder is in a situation with an unbounded width.
    /// Defaults to 400.
    /// </summary>
    [JsonPropertyName("fallbackWidth")]
    public double? FallbackWidth
    {
        get => GetProperty<double?>(nameof(FallbackWidth));
        set => SetProperty(nameof(FallbackWidth), value);
    }

    /// <summary>
    /// Gets or sets the width of the lines in the placeholder box.
    /// Defaults to 2.0.
    /// </summary>
    [JsonPropertyName("strokeWidth")]
    public double? StrokeWidth
    {
        get => GetProperty<double?>(nameof(StrokeWidth));
        set => SetProperty(nameof(StrokeWidth), value);
    }
}
