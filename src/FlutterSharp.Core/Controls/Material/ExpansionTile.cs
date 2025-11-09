using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A single-line ListTile with an expansion arrow icon that expands or collapses the
/// tile to reveal or hide its controls.
/// Corresponds to Flutter's ExpansionTile widget.
/// </summary>
[Control("ExpansionTile", Category = "material", IsContainer = true)]
public sealed class ExpansionTile : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpansionTile"/> class.
    /// </summary>
    public ExpansionTile()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpansionTile"/> class with title.
    /// </summary>
    /// <param name="title">The primary content of the tile.</param>
    /// <param name="subtitle">Optional subtitle content.</param>
    /// <param name="expanded">Whether the tile is initially expanded.</param>
    public ExpansionTile(object title, object? subtitle = null, bool expanded = false)
    {
        Title = title;
        if (subtitle != null) Subtitle = subtitle;
        Expanded = expanded;
    }

    /// <summary>
    /// Gets or sets the primary content of this tile.
    /// Can be a string or a BaseControl (typically Text).
    /// </summary>
    [JsonPropertyName("title")]
    public object? Title
    {
        get => GetProperty<object>(nameof(Title));
        set => SetProperty(nameof(Title), value);
    }

    /// <summary>
    /// Gets or sets the additional content displayed below the title.
    /// Can be a string or a BaseControl (typically Text).
    /// </summary>
    [JsonPropertyName("subtitle")]
    public object? Subtitle
    {
        get => GetProperty<object>(nameof(Subtitle));
        set => SetProperty(nameof(Subtitle), value);
    }

    /// <summary>
    /// Gets or sets a control to display before the title.
    /// Can be an icon name string or a BaseControl (typically CircleAvatar).
    /// </summary>
    [JsonPropertyName("leading")]
    public object? Leading
    {
        get => GetProperty<object>(nameof(Leading));
        set => SetProperty(nameof(Leading), value);
    }

    /// <summary>
    /// Gets or sets a control to display after the title.
    /// Can be an icon name string or a BaseControl (typically Icon).
    /// </summary>
    [JsonPropertyName("trailing")]
    public object? Trailing
    {
        get => GetProperty<object>(nameof(Trailing));
        set => SetProperty(nameof(Trailing), value);
    }

    /// <summary>
    /// Gets or sets the padding around the controls when expanded.
    /// </summary>
    [JsonPropertyName("controlsPadding")]
    public string? ControlsPadding
    {
        get => GetProperty<string>(nameof(ControlsPadding));
        set => SetProperty(nameof(ControlsPadding), value);
    }

    /// <summary>
    /// Gets or sets the tile's padding.
    /// Defines the insets for the leading, title, subtitle and trailing controls.
    /// </summary>
    [JsonPropertyName("tilePadding")]
    public string? TilePadding
    {
        get => GetProperty<string>(nameof(TilePadding));
        set => SetProperty(nameof(TilePadding), value);
    }

    /// <summary>
    /// Gets or sets where to place the expansion arrow icon.
    /// Values: "leading", "trailing", "platform"
    /// Default is "trailing".
    /// </summary>
    [JsonPropertyName("affinity")]
    public string? Affinity
    {
        get => GetProperty<string>(nameof(Affinity));
        set => SetProperty(nameof(Affinity), value);
    }

    /// <summary>
    /// Gets or sets the alignment of controls when the tile is expanded.
    /// </summary>
    [JsonPropertyName("expandedAlignment")]
    public string? ExpandedAlignment
    {
        get => GetProperty<string>(nameof(ExpandedAlignment));
        set => SetProperty(nameof(ExpandedAlignment), value);
    }

    /// <summary>
    /// Gets or sets the cross axis alignment of each child control when the tile is expanded.
    /// Values: "start", "center", "end", "stretch"
    /// Default is "center".
    /// </summary>
    [JsonPropertyName("expandedCrossAxisAlignment")]
    public string? ExpandedCrossAxisAlignment
    {
        get => GetProperty<string>(nameof(ExpandedCrossAxisAlignment));
        set => SetProperty(nameof(ExpandedCrossAxisAlignment), value);
    }

    /// <summary>
    /// Gets or sets how the content of this tile is clipped.
    /// Values: "none", "hardEdge", "antiAlias", "antiAliasWithSaveLayer"
    /// </summary>
    [JsonPropertyName("clipBehavior")]
    public string? ClipBehavior
    {
        get => GetProperty<string>(nameof(ClipBehavior));
        set => SetProperty(nameof(ClipBehavior), value);
    }

    /// <summary>
    /// Gets or sets whether the state of the controls is maintained when the tile expands and collapses.
    /// When true, children are kept in the tree while collapsed.
    /// When false (default), controls are removed when collapsed and recreated upon expansion.
    /// </summary>
    [JsonPropertyName("maintainState")]
    public bool? MaintainState
    {
        get => GetProperty<bool?>(nameof(MaintainState));
        set => SetProperty(nameof(MaintainState), value);
    }

    /// <summary>
    /// Gets or sets the color of this tile's titles when the sublist is expanded.
    /// </summary>
    [JsonPropertyName("textColor")]
    public string? TextColor
    {
        get => GetProperty<string>(nameof(TextColor));
        set => SetProperty(nameof(TextColor), value);
    }

    /// <summary>
    /// Gets or sets the icon color of this tile's expansion arrow icon when the sublist is expanded.
    /// </summary>
    [JsonPropertyName("iconColor")]
    public string? IconColor
    {
        get => GetProperty<string>(nameof(IconColor));
        set => SetProperty(nameof(IconColor), value);
    }

    /// <summary>
    /// Gets or sets the border shape of this tile when the sublist is expanded.
    /// </summary>
    [JsonPropertyName("shape")]
    public string? Shape
    {
        get => GetProperty<string>(nameof(Shape));
        set => SetProperty(nameof(Shape), value);
    }

    /// <summary>
    /// Gets or sets the color to display behind the sublist when expanded.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the background color of this tile when the sublist is collapsed.
    /// </summary>
    [JsonPropertyName("collapsedBgcolor")]
    public string? CollapsedBackgroundColor
    {
        get => GetProperty<string>(nameof(CollapsedBackgroundColor));
        set => SetProperty(nameof(CollapsedBackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the icon color of this tile's expansion arrow icon when the sublist is collapsed.
    /// </summary>
    [JsonPropertyName("collapsedIconColor")]
    public string? CollapsedIconColor
    {
        get => GetProperty<string>(nameof(CollapsedIconColor));
        set => SetProperty(nameof(CollapsedIconColor), value);
    }

    /// <summary>
    /// Gets or sets the color of this tile's titles when the sublist is collapsed.
    /// </summary>
    [JsonPropertyName("collapsedTextColor")]
    public string? CollapsedTextColor
    {
        get => GetProperty<string>(nameof(CollapsedTextColor));
        set => SetProperty(nameof(CollapsedTextColor), value);
    }

    /// <summary>
    /// Gets or sets the tile's border shape when the sublist is collapsed.
    /// </summary>
    [JsonPropertyName("collapsedShape")]
    public string? CollapsedShape
    {
        get => GetProperty<string>(nameof(CollapsedShape));
        set => SetProperty(nameof(CollapsedShape), value);
    }

    /// <summary>
    /// Gets or sets whether this list tile is part of a vertically dense list.
    /// Dense tiles default to having a smaller height.
    /// </summary>
    [JsonPropertyName("dense")]
    public bool? Dense
    {
        get => GetProperty<bool?>(nameof(Dense));
        set => SetProperty(nameof(Dense), value);
    }

    /// <summary>
    /// Gets or sets whether detected gestures should provide acoustic and/or haptic feedback.
    /// </summary>
    [JsonPropertyName("enableFeedback")]
    public bool? EnableFeedback
    {
        get => GetProperty<bool?>(nameof(EnableFeedback));
        set => SetProperty(nameof(EnableFeedback), value);
    }

    /// <summary>
    /// Gets or sets whether this tile should build/show a default trailing icon, if Trailing is null.
    /// </summary>
    [JsonPropertyName("showTrailingIcon")]
    public bool? ShowTrailingIcon
    {
        get => GetProperty<bool?>(nameof(ShowTrailingIcon));
        set => SetProperty(nameof(ShowTrailingIcon), value);
    }

    /// <summary>
    /// Gets or sets the minimum height of this tile.
    /// </summary>
    [JsonPropertyName("minTileHeight")]
    public double? MinTileHeight
    {
        get => GetProperty<double?>(nameof(MinTileHeight));
        set => SetProperty(nameof(MinTileHeight), value);
    }

    /// <summary>
    /// Gets or sets the expansion state of this tile.
    /// True - expanded, False - collapsed.
    /// </summary>
    [JsonPropertyName("expanded")]
    public bool? Expanded
    {
        get => GetProperty<bool?>(nameof(Expanded));
        set => SetProperty(nameof(Expanded), value);
    }

    /// <summary>
    /// Gets or sets the visual density to define how compact this tile's layout will be.
    /// </summary>
    [JsonPropertyName("visualDensity")]
    public string? VisualDensity
    {
        get => GetProperty<string>(nameof(VisualDensity));
        set => SetProperty(nameof(VisualDensity), value);
    }

    /// <summary>
    /// Occurs when a user clicks or taps the list tile.
    /// The event data is a boolean representing the expanded state after the change.
    /// </summary>
    public event EventHandler? Change;
}
