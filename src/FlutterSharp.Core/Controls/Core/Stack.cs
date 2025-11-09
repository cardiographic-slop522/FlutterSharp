using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// A control that overlays its children on top of each other.
/// Corresponds to Flutter's Stack widget.
/// </summary>
[Control("Stack", IsContainer = true, Category = "layout")]
public sealed class Stack : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Stack"/> class.
    /// </summary>
    public Stack()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Stack"/> class with the specified children.
    /// </summary>
    /// <param name="children">The child controls to add.</param>
    public Stack(params BaseControl[] children)
    {
        foreach (var child in children)
        {
            AddChild(child);
        }
    }

    /// <summary>
    /// Gets or sets the alignment of children that are not explicitly positioned.
    /// Values: "topLeft", "topCenter", "topRight", "centerLeft", "center", "centerRight", "bottomLeft", "bottomCenter", "bottomRight"
    /// </summary>
    [JsonPropertyName("alignment")]
    public string? Alignment
    {
        get => GetProperty<string>(nameof(Alignment));
        set => SetProperty(nameof(Alignment), value);
    }

    /// <summary>
    /// Gets or sets how to size the stack.
    /// Values: "loose", "expand", "passthrough"
    /// </summary>
    [JsonPropertyName("fit")]
    public string? Fit
    {
        get => GetProperty<string>(nameof(Fit));
        set => SetProperty(nameof(Fit), value);
    }

    /// <summary>
    /// Gets or sets how children should clip their content.
    /// Values: "none", "hardEdge", "antiAlias", "antiAliasWithSaveLayer"
    /// </summary>
    [JsonPropertyName("clipBehavior")]
    public string? ClipBehavior
    {
        get => GetProperty<string>(nameof(ClipBehavior));
        set => SetProperty(nameof(ClipBehavior), value);
    }
}
