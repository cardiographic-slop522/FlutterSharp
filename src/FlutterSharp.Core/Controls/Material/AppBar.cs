using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design app bar (toolbar).
/// Corresponds to Flutter's AppBar widget.
/// </summary>
[Control("AppBar", IsContainer = true, Category = "material")]
public sealed class AppBar : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppBar"/> class.
    /// </summary>
    public AppBar()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppBar"/> class with a title.
    /// </summary>
    /// <param name="title">The app bar title.</param>
    public AppBar(string title)
    {
        Title = new Core.Text(title);
    }

    /// <summary>
    /// Gets or sets the title control.
    /// </summary>
    [JsonPropertyName("title")]
    public BaseControl? Title
    {
        get => GetProperty<BaseControl>(nameof(Title));
        set => SetProperty(nameof(Title), value);
    }

    /// <summary>
    /// Gets or sets the leading control (typically a back button or menu icon).
    /// </summary>
    [JsonPropertyName("leading")]
    public BaseControl? Leading
    {
        get => GetProperty<BaseControl>(nameof(Leading));
        set => SetProperty(nameof(Leading), value);
    }

    /// <summary>
    /// Gets or sets the list of action controls (typically icon buttons).
    /// </summary>
    [JsonPropertyName("actions")]
    public List<BaseControl>? Actions
    {
        get => GetProperty<List<BaseControl>>(nameof(Actions));
        set => SetProperty(nameof(Actions), value);
    }

    /// <summary>
    /// Gets or sets the background color.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the foreground (text/icon) color.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color
    {
        get => GetProperty<string>(nameof(Color));
        set => SetProperty(nameof(Color), value);
    }

    /// <summary>
    /// Gets or sets the elevation (shadow depth).
    /// </summary>
    [JsonPropertyName("elevation")]
    public double? Elevation
    {
        get => GetProperty<double?>(nameof(Elevation));
        set => SetProperty(nameof(Elevation), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the title should be centered.
    /// </summary>
    [JsonPropertyName("centerTitle")]
    public bool? CenterTitle
    {
        get => GetProperty<bool?>(nameof(CenterTitle));
        set => SetProperty(nameof(CenterTitle), value);
    }

    /// <summary>
    /// Gets or sets the toolbar height.
    /// </summary>
    [JsonPropertyName("toolbarHeight")]
    public double? ToolbarHeight
    {
        get => GetProperty<double?>(nameof(ToolbarHeight));
        set => SetProperty(nameof(ToolbarHeight), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether to automatically imply leading (back button).
    /// </summary>
    [JsonPropertyName("automaticallyImplyLeading")]
    public bool? AutomaticallyImplyLeading
    {
        get => GetProperty<bool?>(nameof(AutomaticallyImplyLeading));
        set => SetProperty(nameof(AutomaticallyImplyLeading), value);
    }

    /// <summary>
    /// Adds an action control to the app bar.
    /// </summary>
    /// <param name="action">The action control to add.</param>
    public void AddAction(BaseControl action)
    {
        Actions ??= new List<BaseControl>();
        Actions.Add(action);
    }
}
