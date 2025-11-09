using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// Displays an image.
/// Corresponds to Flutter's Image widget.
/// Supports JPEG, PNG, SVG, GIF, Animated GIF, WebP, Animated WebP, BMP, and WBMP formats.
/// </summary>
[Control("Image", Category = "display")]
public sealed class Image : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Image"/> class.
    /// </summary>
    public Image()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Image"/> class with a source.
    /// </summary>
    /// <param name="src">The image source URL or asset path.</param>
    public Image(string src)
    {
        Src = src;
    }

    /// <summary>
    /// Gets or sets the image source.
    /// This could be an external URL or a local asset file.
    /// </summary>
    [JsonPropertyName("src")]
    public string? Src
    {
        get => GetProperty<string>(nameof(Src));
        set => SetProperty(nameof(Src), value);
    }

    /// <summary>
    /// Gets or sets a string representing an image encoded in Base64 format.
    /// </summary>
    [JsonPropertyName("srcBase64")]
    public string? SrcBase64
    {
        get => GetProperty<string>(nameof(SrcBase64));
        set => SetProperty(nameof(SrcBase64), value);
    }

    /// <summary>
    /// Gets or sets how to paint any portions of the layout bounds not covered by the image.
    /// Values: "noRepeat", "repeat", "repeatX", "repeatY"
    /// </summary>
    [JsonPropertyName("repeat")]
    public string? Repeat
    {
        get => GetProperty<string>(nameof(Repeat));
        set => SetProperty(nameof(Repeat), value);
    }

    /// <summary>
    /// Gets or sets how to inscribe the image into the space allocated during layout.
    /// Values: "contain", "cover", "fill", "fitHeight", "fitWidth", "none", "scaleDown"
    /// </summary>
    [JsonPropertyName("fit")]
    public string? Fit
    {
        get => GetProperty<string>(nameof(Fit));
        set => SetProperty(nameof(Fit), value);
    }

    /// <summary>
    /// Gets or sets the border radius to clip image with rounded corners.
    /// </summary>
    [JsonPropertyName("borderRadius")]
    public string? BorderRadius
    {
        get => GetProperty<string>(nameof(BorderRadius));
        set => SetProperty(nameof(BorderRadius), value);
    }

    /// <summary>
    /// Gets or sets the color to blend with each image pixel.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color
    {
        get => GetProperty<string>(nameof(Color));
        set => SetProperty(nameof(Color), value);
    }

    /// <summary>
    /// Gets or sets the blend mode used to combine color with the image.
    /// </summary>
    [JsonPropertyName("colorBlendMode")]
    public string? ColorBlendMode
    {
        get => GetProperty<string>(nameof(ColorBlendMode));
        set => SetProperty(nameof(ColorBlendMode), value);
    }

    /// <summary>
    /// Gets or sets whether to continue showing the old image when the image provider changes.
    /// </summary>
    [JsonPropertyName("gaplessPlayback")]
    public bool? GaplessPlayback
    {
        get => GetProperty<bool?>(nameof(GaplessPlayback));
        set => SetProperty(nameof(GaplessPlayback), value);
    }

    /// <summary>
    /// Gets or sets a semantic description of the image for accessibility.
    /// </summary>
    [JsonPropertyName("semanticsLabel")]
    public string? SemanticsLabel
    {
        get => GetProperty<string>(nameof(SemanticsLabel));
        set => SetProperty(nameof(SemanticsLabel), value);
    }

    /// <summary>
    /// Gets or sets whether to exclude this image from semantics.
    /// </summary>
    [JsonPropertyName("excludeFromSemantics")]
    public bool? ExcludeFromSemantics
    {
        get => GetProperty<bool?>(nameof(ExcludeFromSemantics));
        set => SetProperty(nameof(ExcludeFromSemantics), value);
    }

    /// <summary>
    /// Gets or sets the rendering quality of the image.
    /// Values: "none", "low", "medium", "high"
    /// </summary>
    [JsonPropertyName("filterQuality")]
    public string? FilterQuality
    {
        get => GetProperty<string>(nameof(FilterQuality));
        set => SetProperty(nameof(FilterQuality), value);
    }

    /// <summary>
    /// Gets or sets whether to paint the image with anti-aliasing.
    /// </summary>
    [JsonPropertyName("antiAlias")]
    public bool? AntiAlias
    {
        get => GetProperty<bool?>(nameof(AntiAlias));
        set => SetProperty(nameof(AntiAlias), value);
    }
}
