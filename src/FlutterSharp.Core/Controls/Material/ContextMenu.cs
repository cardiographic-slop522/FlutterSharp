using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Wraps its content and displays contextual menus for specific mouse events.
/// Corresponds to Flutter's ContextMenu widget.
/// </summary>
[Control("ContextMenu", Category = "material")]
public sealed class ContextMenu : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContextMenu"/> class.
    /// </summary>
    public ContextMenu()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ContextMenu"/> class with content.
    /// </summary>
    /// <param name="content">The child control that listens for mouse interaction.</param>
    public ContextMenu(BaseControl? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the child control that listens for mouse interaction.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets the trigger mode for the display of primary items (usually left mouse button).
    /// Values: "down", "longPress", null (disabled)
    /// </summary>
    [JsonPropertyName("primaryTrigger")]
    public string? PrimaryTrigger
    {
        get => GetProperty<string>(nameof(PrimaryTrigger));
        set => SetProperty(nameof(PrimaryTrigger), value);
    }

    /// <summary>
    /// Gets or sets the trigger mode for the display of secondary items (usually right mouse button).
    /// Values: "down", "longPress", null (disabled)
    /// Defaults to "down".
    /// </summary>
    [JsonPropertyName("secondaryTrigger")]
    public string? SecondaryTrigger
    {
        get => GetProperty<string>(nameof(SecondaryTrigger));
        set => SetProperty(nameof(SecondaryTrigger), value);
    }

    /// <summary>
    /// Gets or sets the trigger mode for the display of tertiary items (usually middle mouse button).
    /// Values: "down", "longPress", null (disabled)
    /// Defaults to "down".
    /// </summary>
    [JsonPropertyName("tertiaryTrigger")]
    public string? TertiaryTrigger
    {
        get => GetProperty<string>(nameof(TertiaryTrigger));
        set => SetProperty(nameof(TertiaryTrigger), value);
    }

    /// <summary>
    /// Occurs when a context menu item is selected.
    /// </summary>
    public event EventHandler? Select;

    /// <summary>
    /// Occurs when the menu is dismissed without a selection.
    /// </summary>
    public event EventHandler? Dismiss;
}
