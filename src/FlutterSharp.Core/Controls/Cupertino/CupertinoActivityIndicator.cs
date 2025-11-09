using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Cupertino;

/// <summary>
/// An iOS-style activity indicator that spins clockwise.
/// Provides a circular loading indicator with iOS design language.
/// Corresponds to Flutter's CupertinoActivityIndicator widget.
/// </summary>
[Control("CupertinoActivityIndicator", Category = "cupertino")]
public sealed class CupertinoActivityIndicator : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoActivityIndicator"/> class.
    /// </summary>
    public CupertinoActivityIndicator()
    {
    }

    /// <summary>
    /// Gets or sets the radius of this indicator.
    /// Must be strictly greater than 0.
    /// Defaults to 10.
    /// </summary>
    [JsonPropertyName("radius")]
    public double? Radius
    {
        get => GetProperty<double?>(nameof(Radius));
        set => SetProperty(nameof(Radius), value);
    }

    /// <summary>
    /// Gets or sets the color of this indicator.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color
    {
        get => GetProperty<string>(nameof(Color));
        set => SetProperty(nameof(Color), value);
    }

    /// <summary>
    /// Gets or sets whether this indicator is running its animation.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("animating")]
    public bool? Animating
    {
        get => GetProperty<bool?>(nameof(Animating));
        set => SetProperty(nameof(Animating), value);
    }
}
