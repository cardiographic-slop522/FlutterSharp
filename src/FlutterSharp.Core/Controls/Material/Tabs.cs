using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Used for navigating frequently accessed, distinct content categories.
/// Tabs allow for navigation between two or more content views.
/// Corresponds to Flutter's Tabs widget.
/// </summary>
[Control("Tabs", Category = "material", IsContainer = true)]
public sealed class Tabs : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Tabs"/> class.
    /// </summary>
    public Tabs()
    {
    }

    /// <summary>
    /// Gets or sets the total number of tabs.
    /// Typically greater than one.
    /// </summary>
    [JsonPropertyName("length")]
    public int? Length
    {
        get => GetProperty<int?>(nameof(Length));
        set => SetProperty(nameof(Length), value);
    }

    /// <summary>
    /// Gets or sets the index of the currently selected tab.
    /// </summary>
    [JsonPropertyName("selectedIndex")]
    public int? SelectedIndex
    {
        get => GetProperty<int?>(nameof(SelectedIndex));
        set => SetProperty(nameof(SelectedIndex), value);
    }

    /// <summary>
    /// Gets or sets the animation duration (in milliseconds) when switching tabs.
    /// Default is 100ms.
    /// </summary>
    [JsonPropertyName("animationDuration")]
    public int? AnimationDuration
    {
        get => GetProperty<int?>(nameof(AnimationDuration));
        set => SetProperty(nameof(AnimationDuration), value);
    }

    /// <summary>
    /// Gets or sets the content to display.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }
}

/// <summary>
/// A Material Design tab bar with multiple tabs.
/// Part of the Tabs component.
/// </summary>
[Control("TabBar", Category = "material")]
public sealed class TabBar : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TabBar"/> class.
    /// </summary>
    public TabBar()
    {
    }

    /// <summary>
    /// Gets or sets whether this tab bar can be scrolled horizontally.
    /// </summary>
    [JsonPropertyName("scrollable")]
    public bool? Scrollable
    {
        get => GetProperty<bool?>(nameof(Scrollable));
        set => SetProperty(nameof(Scrollable), value);
    }

    /// <summary>
    /// Gets or sets how tabs are aligned horizontally.
    /// Values: "start", "startOffset", "fill", "center"
    /// </summary>
    [JsonPropertyName("alignment")]
    public string? Alignment
    {
        get => GetProperty<string>(nameof(Alignment));
        set => SetProperty(nameof(Alignment), value);
    }

    /// <summary>
    /// Gets or sets the color of selected tab labels.
    /// </summary>
    [JsonPropertyName("labelColor")]
    public string? LabelColor
    {
        get => GetProperty<string>(nameof(LabelColor));
        set => SetProperty(nameof(LabelColor), value);
    }

    /// <summary>
    /// Gets or sets the color of unselected tab labels.
    /// </summary>
    [JsonPropertyName("unselectedLabelColor")]
    public string? UnselectedLabelColor
    {
        get => GetProperty<string>(nameof(UnselectedLabelColor));
        set => SetProperty(nameof(UnselectedLabelColor), value);
    }

    /// <summary>
    /// Gets or sets the color of the line that appears below the selected tab.
    /// </summary>
    [JsonPropertyName("indicatorColor")]
    public string? IndicatorColor
    {
        get => GetProperty<string>(nameof(IndicatorColor));
        set => SetProperty(nameof(IndicatorColor), value);
    }

    /// <summary>
    /// Gets or sets how the bounds of the selected tab indicator are computed.
    /// Values: "tab", "label"
    /// </summary>
    [JsonPropertyName("indicatorSize")]
    public string? IndicatorSize
    {
        get => GetProperty<string>(nameof(IndicatorSize));
        set => SetProperty(nameof(IndicatorSize), value);
    }

    /// <summary>
    /// Gets or sets the thickness of the line that appears below the selected tab.
    /// </summary>
    [JsonPropertyName("indicatorThickness")]
    public double? IndicatorThickness
    {
        get => GetProperty<double?>(nameof(IndicatorThickness));
        set => SetProperty(nameof(IndicatorThickness), value);
    }

    /// <summary>
    /// Gets or sets the border radius of the indicator.
    /// </summary>
    [JsonPropertyName("indicatorBorderRadius")]
    public string? IndicatorBorderRadius
    {
        get => GetProperty<string>(nameof(IndicatorBorderRadius));
        set => SetProperty(nameof(IndicatorBorderRadius), value);
    }

    /// <summary>
    /// Gets or sets the padding for the indicator.
    /// </summary>
    [JsonPropertyName("indicatorPadding")]
    public string? IndicatorPadding
    {
        get => GetProperty<string>(nameof(IndicatorPadding));
        set => SetProperty(nameof(IndicatorPadding), value);
    }

    /// <summary>
    /// Gets or sets the color of the divider.
    /// </summary>
    [JsonPropertyName("dividerColor")]
    public string? DividerColor
    {
        get => GetProperty<string>(nameof(DividerColor));
        set => SetProperty(nameof(DividerColor), value);
    }

    /// <summary>
    /// Gets or sets the height of the divider.
    /// </summary>
    [JsonPropertyName("dividerHeight")]
    public double? DividerHeight
    {
        get => GetProperty<double?>(nameof(DividerHeight));
        set => SetProperty(nameof(DividerHeight), value);
    }

    /// <summary>
    /// Gets or sets how the tab indicator animates when the selected tab changes.
    /// Values: "linear", "elastic"
    /// </summary>
    [JsonPropertyName("indicatorAnimation")]
    public string? IndicatorAnimation
    {
        get => GetProperty<string>(nameof(IndicatorAnimation));
        set => SetProperty(nameof(IndicatorAnimation), value);
    }

    /// <summary>
    /// Gets or sets whether tab labels should be uppercase.
    /// </summary>
    [JsonPropertyName("labelUppercase")]
    public bool? LabelUppercase
    {
        get => GetProperty<bool?>(nameof(LabelUppercase));
        set => SetProperty(nameof(LabelUppercase), value);
    }
}

/// <summary>
/// A single tab for use in a TabBar.
/// </summary>
[Control("Tab", Category = "material")]
public sealed class Tab : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Tab"/> class.
    /// </summary>
    public Tab()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Tab"/> class with text.
    /// </summary>
    /// <param name="text">The tab text.</param>
    /// <param name="icon">Optional icon name.</param>
    public Tab(string text, string? icon = null)
    {
        Text = text;
        if (icon != null) Icon = icon;
    }

    /// <summary>
    /// Gets or sets the tab text.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text
    {
        get => GetProperty<string>(nameof(Text));
        set => SetProperty(nameof(Text), value);
    }

    /// <summary>
    /// Gets or sets the tab icon.
    /// Can be an icon name string or a BaseControl.
    /// </summary>
    [JsonPropertyName("icon")]
    public object? Icon
    {
        get => GetProperty<object>(nameof(Icon));
        set => SetProperty(nameof(Icon), value);
    }

    /// <summary>
    /// Gets or sets the content control for custom tab appearance.
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }
}
