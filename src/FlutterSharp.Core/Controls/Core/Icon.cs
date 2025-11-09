using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A control that displays an icon from Material Icons or Cupertino Icons.
/// Corresponds to Flutter's Icon widget.
/// </summary>
[Control("Icon", Category = "display")]
public sealed class Icon : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Icon"/> class.
    /// </summary>
    public Icon()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Icon"/> class with the specified icon name.
    /// </summary>
    /// <param name="name">The icon name (e.g., "home", "settings", "favorite").</param>
    public Icon(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Gets or sets the icon name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name
    {
        get => GetProperty<string>(nameof(Name));
        set => SetProperty(nameof(Name), value);
    }

    /// <summary>
    /// Gets or sets the icon color.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color
    {
        get => GetProperty<string>(nameof(Color));
        set => SetProperty(nameof(Color), value);
    }

    /// <summary>
    /// Gets or sets the icon size in pixels.
    /// </summary>
    [JsonPropertyName("size")]
    public double? Size
    {
        get => GetProperty<double?>(nameof(Size));
        set => SetProperty(nameof(Size), value);
    }

    /// <summary>
    /// Gets or sets the semantic label for accessibility.
    /// </summary>
    [JsonPropertyName("semanticLabel")]
    public string? SemanticLabel
    {
        get => GetProperty<string>(nameof(SemanticLabel));
        set => SetProperty(nameof(SemanticLabel), value);
    }
}
