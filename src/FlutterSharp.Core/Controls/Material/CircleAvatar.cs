using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A circle that represents a user.
/// If foreground_image_src fails then background_image_src is used,
/// and if this also fails, then bgcolor is used.
/// Corresponds to Flutter's CircleAvatar widget.
/// </summary>
[Control("CircleAvatar", Category = "material", IsContainer = true)]
public sealed class CircleAvatar : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CircleAvatar"/> class.
    /// </summary>
    public CircleAvatar()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CircleAvatar"/> class with content.
    /// </summary>
    /// <param name="content">The content (typically text with user initials).</param>
    /// <param name="backgroundColor">The background color of the avatar.</param>
    /// <param name="foregroundColor">The foreground color for text in the avatar.</param>
    public CircleAvatar(object? content = null, string? backgroundColor = null, string? foregroundColor = null)
    {
        if (content != null) Content = content;
        if (backgroundColor != null) BackgroundColor = backgroundColor;
        if (foregroundColor != null) ForegroundColor = foregroundColor;
    }

    /// <summary>
    /// Gets or sets the content of this avatar.
    /// Can be a string or a BaseControl (typically Text).
    /// If this avatar is to have an image, use ForegroundImageSrc or BackgroundImageSrc instead.
    /// </summary>
    [JsonPropertyName("content")]
    public object? Content
    {
        get => GetProperty<object>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets the source (local asset file or URL) of the foreground image in the circle.
    /// Fallbacks to BackgroundImageSrc.
    /// Typically used as profile image.
    /// </summary>
    [JsonPropertyName("foregroundImageSrc")]
    public string? ForegroundImageSrc
    {
        get => GetProperty<string>(nameof(ForegroundImageSrc));
        set => SetProperty(nameof(ForegroundImageSrc), value);
    }

    /// <summary>
    /// Gets or sets the source (local asset file or URL) of the background image in the circle.
    /// Changing the background image will cause the avatar to animate to the new image.
    /// If this avatar is to have the user's initials, use Content instead.
    /// Typically used as a fallback image for ForegroundImageSrc.
    /// </summary>
    [JsonPropertyName("backgroundImageSrc")]
    public string? BackgroundImageSrc
    {
        get => GetProperty<string>(nameof(BackgroundImageSrc));
        set => SetProperty(nameof(BackgroundImageSrc), value);
    }

    /// <summary>
    /// Gets or sets the default color for text in this avatar.
    /// Defaults to the primary text theme color if no BackgroundColor is specified.
    /// </summary>
    [JsonPropertyName("color")]
    public string? ForegroundColor
    {
        get => GetProperty<string>(nameof(ForegroundColor));
        set => SetProperty(nameof(ForegroundColor), value);
    }

    /// <summary>
    /// Gets or sets the color with which to fill the circle.
    /// Changing the background color will cause this avatar to animate to the new color.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the size of the avatar, expressed as the radius (half the diameter).
    /// If Radius is specified, then neither MinRadius nor MaxRadius may be specified.
    /// </summary>
    [JsonPropertyName("radius")]
    public double? Radius
    {
        get => GetProperty<double?>(nameof(Radius));
        set => SetProperty(nameof(Radius), value);
    }

    /// <summary>
    /// Gets or sets the minimum size of the avatar, expressed as the radius (half the diameter).
    /// If MinRadius is specified, then Radius should not be specified.
    /// Defaults to 0.0.
    /// </summary>
    [JsonPropertyName("minRadius")]
    public double? MinRadius
    {
        get => GetProperty<double?>(nameof(MinRadius));
        set => SetProperty(nameof(MinRadius), value);
    }

    /// <summary>
    /// Gets or sets the maximum size of the avatar, expressed as the radius (half the diameter).
    /// If MaxRadius is specified, then Radius should not be specified.
    /// Defaults to infinity.
    /// </summary>
    [JsonPropertyName("maxRadius")]
    public double? MaxRadius
    {
        get => GetProperty<double?>(nameof(MaxRadius));
        set => SetProperty(nameof(MaxRadius), value);
    }

    /// <summary>
    /// Occurs when an error occurs while loading the BackgroundImageSrc or ForegroundImageSrc.
    /// The event data is a string whose value is either "background" or "foreground" indicating the error's origin.
    /// </summary>
    public event EventHandler? ImageError;
}
