using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Enables selection for its child control.
/// Flet controls are not selectable by default. SelectionArea is used to enable
/// selection for text and other content.
/// Corresponds to Flutter's SelectionArea widget.
/// </summary>
[Control("SelectionArea", Category = "material")]
public sealed class SelectionArea : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SelectionArea"/> class.
    /// </summary>
    public SelectionArea()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SelectionArea"/> class with content.
    /// </summary>
    /// <param name="content">The child control this selection area applies to.</param>
    public SelectionArea(BaseControl? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the child control this selection area applies to.
    /// If you need to have multiple selectable controls, use container-like controls
    /// like Row or Column, which have a controls property.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Occurs when the selected content changes.
    /// </summary>
    public event EventHandler? Change;
}
