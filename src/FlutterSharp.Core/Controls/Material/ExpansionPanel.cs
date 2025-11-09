using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A material expansion panel. It can either be expanded or collapsed.
/// Its body is only visible when it is expanded.
/// Corresponds to Flutter's ExpansionPanel widget.
/// </summary>
[Control("ExpansionPanel", Category = "material")]
public sealed class ExpansionPanel : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpansionPanel"/> class.
    /// </summary>
    public ExpansionPanel()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpansionPanel"/> class with header and content.
    /// </summary>
    /// <param name="header">The header control.</param>
    /// <param name="content">The content control.</param>
    /// <param name="expanded">Whether the panel is initially expanded.</param>
    public ExpansionPanel(BaseControl? header = null, BaseControl? content = null, bool expanded = false)
    {
        if (header != null) Header = header;
        if (content != null) Content = content;
        Expanded = expanded;
    }

    /// <summary>
    /// Gets or sets the control to be found in the header of the ExpansionPanel.
    /// </summary>
    [JsonPropertyName("header")]
    public BaseControl? Header
    {
        get => GetProperty<BaseControl>(nameof(Header));
        set => SetProperty(nameof(Header), value);
    }

    /// <summary>
    /// Gets or sets the control to be found in the body of the ExpansionPanel.
    /// It is displayed below the header when the panel is expanded.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets the background color of the panel.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets whether the panel is expanded (true) or collapsed (false).
    /// </summary>
    [JsonPropertyName("expanded")]
    public bool? Expanded
    {
        get => GetProperty<bool?>(nameof(Expanded));
        set => SetProperty(nameof(Expanded), value);
    }

    /// <summary>
    /// Gets or sets whether tapping on the panel's header will expand or collapse it.
    /// </summary>
    [JsonPropertyName("canTapHeader")]
    public bool? CanTapHeader
    {
        get => GetProperty<bool?>(nameof(CanTapHeader));
        set => SetProperty(nameof(CanTapHeader), value);
    }

    /// <summary>
    /// Gets or sets the splash color when the header is tapped.
    /// </summary>
    [JsonPropertyName("splashColor")]
    public string? SplashColor
    {
        get => GetProperty<string>(nameof(SplashColor));
        set => SetProperty(nameof(SplashColor), value);
    }

    /// <summary>
    /// Gets or sets the highlight color when the header is pressed.
    /// </summary>
    [JsonPropertyName("highlightColor")]
    public string? HighlightColor
    {
        get => GetProperty<string>(nameof(HighlightColor));
        set => SetProperty(nameof(HighlightColor), value);
    }
}

/// <summary>
/// A material expansion panel list that lays out its children and animates expansions.
/// Corresponds to Flutter's ExpansionPanelList widget.
/// </summary>
[Control("ExpansionPanelList", Category = "material", IsContainer = true)]
public sealed class ExpansionPanelList : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpansionPanelList"/> class.
    /// </summary>
    public ExpansionPanelList()
    {
    }

    /// <summary>
    /// Gets or sets the color of the divider when panels are collapsed.
    /// </summary>
    [JsonPropertyName("dividerColor")]
    public string? DividerColor
    {
        get => GetProperty<string>(nameof(DividerColor));
        set => SetProperty(nameof(DividerColor), value);
    }

    /// <summary>
    /// Gets or sets the elevation of the panels when expanded.
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets the padding around the header when expanded.
    /// </summary>
    [JsonPropertyName("expandedHeaderPadding")]
    public string? ExpandedHeaderPadding
    {
        get => GetProperty<string>(nameof(ExpandedHeaderPadding));
        set => SetProperty(nameof(ExpandedHeaderPadding), value);
    }

    /// <summary>
    /// Gets or sets the color of the expand/collapse icon.
    /// </summary>
    [JsonPropertyName("expandIconColor")]
    public string? ExpandIconColor
    {
        get => GetProperty<string>(nameof(ExpandIconColor));
        set => SetProperty(nameof(ExpandIconColor), value);
    }

    /// <summary>
    /// Gets or sets the size of the gap between panels when expanded.
    /// </summary>
    [JsonPropertyName("spacing")]
    public double? Spacing
    {
        get => GetProperty<double?>(nameof(Spacing));
        set => SetProperty(nameof(Spacing), value);
    }
}
