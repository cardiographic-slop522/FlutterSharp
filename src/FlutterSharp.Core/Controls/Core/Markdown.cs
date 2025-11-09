using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Core;

/// <summary>
/// Renders text in markdown format.
/// Supports various markdown extensions and code syntax highlighting.
/// Corresponds to Flutter's Markdown widget.
/// </summary>
[Control("Markdown", Category = "core")]
public sealed class Markdown : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Markdown"/> class.
    /// </summary>
    public Markdown()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Markdown"/> class with markdown content.
    /// </summary>
    /// <param name="value">Markdown content to render.</param>
    public Markdown(string? value = null)
    {
        if (value != null) Value = value;
    }

    /// <summary>
    /// Gets or sets the markdown content to render.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value
    {
        get => GetProperty<string>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets whether rendered text is selectable or not.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("selectable")]
    public bool? Selectable
    {
        get => GetProperty<bool?>(nameof(Selectable));
        set => SetProperty(nameof(Selectable), value);
    }

    /// <summary>
    /// Gets or sets the extensions to use when rendering the markdown content.
    /// Values: "none", "commonMark", "gitHubWeb", "gitHubFlavored"
    /// Defaults to "none".
    /// </summary>
    [JsonPropertyName("extensionSet")]
    public string? ExtensionSet
    {
        get => GetProperty<string>(nameof(ExtensionSet));
        set => SetProperty(nameof(ExtensionSet), value);
    }

    /// <summary>
    /// Gets or sets a syntax highlighting theme for code blocks.
    /// Many themes available (e.g., "github", "monokai", "vs", "dracula").
    /// Defaults to "github".
    /// </summary>
    [JsonPropertyName("codeTheme")]
    public string? CodeTheme
    {
        get => GetProperty<string>(nameof(CodeTheme));
        set => SetProperty(nameof(CodeTheme), value);
    }

    /// <summary>
    /// Gets or sets whether to automatically open URLs in the document.
    /// If registered, TapLink event is fired after that.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("autoFollowLinks")]
    public bool? AutoFollowLinks
    {
        get => GetProperty<bool?>(nameof(AutoFollowLinks));
        set => SetProperty(nameof(AutoFollowLinks), value);
    }

    /// <summary>
    /// Gets or sets where to open URL in the web mode.
    /// Values: "_blank", "_self"
    /// </summary>
    [JsonPropertyName("autoFollowLinksTarget")]
    public string? AutoFollowLinksTarget
    {
        get => GetProperty<string>(nameof(AutoFollowLinksTarget));
        set => SetProperty(nameof(AutoFollowLinksTarget), value);
    }

    /// <summary>
    /// Gets or sets whether the extent of the scroll view should be determined by the contents.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("shrinkWrap")]
    public bool? ShrinkWrap
    {
        get => GetProperty<bool?>(nameof(ShrinkWrap));
        set => SetProperty(nameof(ShrinkWrap), value);
    }

    /// <summary>
    /// Gets or sets whether to allow the widget to fit the child content.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("fitContent")]
    public bool? FitContent
    {
        get => GetProperty<bool?>(nameof(FitContent));
        set => SetProperty(nameof(FitContent), value);
    }

    /// <summary>
    /// Gets or sets the soft line break behavior.
    /// Used to identify spaces at the end of a line of text and leading spaces in the following line.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("softLineBreak")]
    public bool? SoftLineBreak
    {
        get => GetProperty<bool?>(nameof(SoftLineBreak));
        set => SetProperty(nameof(SoftLineBreak), value);
    }

    /// <summary>
    /// Gets or sets the control to display when an image fails to load.
    /// </summary>
    [JsonPropertyName("imageErrorContent")]
    public BaseControl? ImageErrorContent
    {
        get => GetProperty<BaseControl>(nameof(ImageErrorContent));
        set => SetProperty(nameof(ImageErrorContent), value);
    }

    /// <summary>
    /// Occurs when some text is clicked/tapped.
    /// </summary>
    public event EventHandler? TapText;

    /// <summary>
    /// Occurs when the text selection changes.
    /// </summary>
    public event EventHandler? SelectionChange;

    /// <summary>
    /// Occurs when a link within Markdown document is clicked/tapped.
    /// The event data contains the clicked URL.
    /// </summary>
    public event EventHandler? TapLink;
}
