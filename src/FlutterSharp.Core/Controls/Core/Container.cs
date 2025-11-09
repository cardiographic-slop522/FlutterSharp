using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A control that provides a box model container with padding, margin, border, and background.
/// Corresponds to Flutter's Container widget.
/// </summary>
[Control("Container", IsContainer = true, Category = "layout")]
public sealed class Container : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Container"/> class.
    /// </summary>
    public Container()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Container"/> class with a single child.
    /// </summary>
    /// <param name="content">The child control.</param>
    public Container(BaseControl content)
    {
        Content = content;
    }

    /// <summary>
    /// Gets or sets the child content of the container.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set
        {
            var current = Content;
            if (current != null)
            {
                RemoveChild(current);
            }

            SetProperty(nameof(Content), value);

            if (value != null)
            {
                AddChild(value);
            }
        }
    }

    /// <summary>
    /// Gets or sets the padding inside the container.
    /// Can be a single number or "left,top,right,bottom" string.
    /// </summary>
    [JsonPropertyName("padding")]
    public object? Padding
    {
        get => GetProperty<object>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets the margin outside the container.
    /// Can be a single number or "left,top,right,bottom" string.
    /// </summary>
    [JsonPropertyName("margin")]
    public object? Margin
    {
        get => GetProperty<object>(nameof(Margin));
        set => SetProperty(nameof(Margin), value);
    }

    /// <summary>
    /// Gets or sets the background color.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the border configuration.
    /// </summary>
    [JsonPropertyName("border")]
    public object? Border
    {
        get => GetProperty<object>(nameof(Border));
        set => SetProperty(nameof(Border), value);
    }

    /// <summary>
    /// Gets or sets the border radius for rounded corners.
    /// Can be a single number or "topLeft,topRight,bottomRight,bottomLeft" string.
    /// </summary>
    [JsonPropertyName("borderRadius")]
    public object? BorderRadius
    {
        get => GetProperty<object>(nameof(BorderRadius));
        set => SetProperty(nameof(BorderRadius), value);
    }

    /// <summary>
    /// Gets or sets the shadow/elevation.
    /// </summary>
    [JsonPropertyName("shadow")]
    public object? Shadow
    {
        get => GetProperty<object>(nameof(Shadow));
        set => SetProperty(nameof(Shadow), value);
    }

    /// <summary>
    /// Gets or sets the gradient background.
    /// </summary>
    [JsonPropertyName("gradient")]
    public object? Gradient
    {
        get => GetProperty<object>(nameof(Gradient));
        set => SetProperty(nameof(Gradient), value);
    }

    /// <summary>
    /// Gets or sets the background image.
    /// </summary>
    [JsonPropertyName("image")]
    public object? Image
    {
        get => GetProperty<object>(nameof(Image));
        set => SetProperty(nameof(Image), value);
    }

    /// <summary>
    /// Gets or sets the alignment of the content within the container.
    /// Values: "topLeft", "topCenter", "topRight", "centerLeft", "center", "centerRight", "bottomLeft", "bottomCenter", "bottomRight"
    /// </summary>
    [JsonPropertyName("alignment")]
    public string? Alignment
    {
        get => GetProperty<string>(nameof(Alignment));
        set => SetProperty(nameof(Alignment), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the container should clip its content.
    /// </summary>
    [JsonPropertyName("clip")]
    public bool? Clip
    {
        get => GetProperty<bool?>(nameof(Clip));
        set => SetProperty(nameof(Clip), value);
    }

    /// <summary>
    /// Gets or sets the ink effect (Material ripple effect).
    /// </summary>
    [JsonPropertyName("ink")]
    public bool? Ink
    {
        get => GetProperty<bool?>(nameof(Ink));
        set => SetProperty(nameof(Ink), value);
    }
}
