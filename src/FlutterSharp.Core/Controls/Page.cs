using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls;

/// <summary>
/// Represents a page in a FlutterSharp application.
/// The page is the root container for all controls and manages the overall application state.
/// </summary>
[Control("Page", IsContainer = true, Category = "core")]
public sealed class Page : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Page"/> class.
    /// </summary>
    public Page()
    {
    }

    /// <summary>
    /// Gets or sets the page title (displayed in browser tab or window title).
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title
    {
        get => GetProperty<string>(nameof(Title));
        set => SetProperty(nameof(Title), value);
    }

    /// <summary>
    /// Gets or sets the current route/URL path.
    /// </summary>
    [JsonPropertyName("route")]
    public string? Route
    {
        get => GetProperty<string>(nameof(Route));
        set => SetProperty(nameof(Route), value);
    }

    /// <summary>
    /// Gets or sets the page's padding.
    /// Can be a single number or "left,top,right,bottom" string.
    /// </summary>
    [JsonPropertyName("padding")]
    public object? Padding
    {
        get => GetProperty<object>(nameof(Padding));
        set => SetProperty(nameof(Padding), value);
    }

    /// <summary>
    /// Gets or sets the page's background color.
    /// </summary>
    [JsonPropertyName("bgcolor")]
    public string? BackgroundColor
    {
        get => GetProperty<string>(nameof(BackgroundColor));
        set => SetProperty(nameof(BackgroundColor), value);
    }

    /// <summary>
    /// Gets or sets the horizontal alignment of page content.
    /// Values: "start", "center", "end", "stretch"
    /// </summary>
    [JsonPropertyName("horizontalAlignment")]
    public string? HorizontalAlignment
    {
        get => GetProperty<string>(nameof(HorizontalAlignment));
        set => SetProperty(nameof(HorizontalAlignment), value);
    }

    /// <summary>
    /// Gets or sets the vertical alignment of page content.
    /// Values: "start", "center", "end", "spaceBetween", "spaceAround", "spaceEvenly"
    /// </summary>
    [JsonPropertyName("verticalAlignment")]
    public string? VerticalAlignment
    {
        get => GetProperty<string>(nameof(VerticalAlignment));
        set => SetProperty(nameof(VerticalAlignment), value);
    }

    /// <summary>
    /// Gets or sets the spacing between child controls.
    /// </summary>
    [JsonPropertyName("spacing")]
    public double? Spacing
    {
        get => GetProperty<double?>(nameof(Spacing));
        set => SetProperty(nameof(Spacing), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the page should scroll when content overflows.
    /// </summary>
    [JsonPropertyName("scroll")]
    public bool? Scroll
    {
        get => GetProperty<bool?>(nameof(Scroll));
        set => SetProperty(nameof(Scroll), value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the page should auto-scroll to the bottom.
    /// </summary>
    [JsonPropertyName("autoScroll")]
    public bool? AutoScroll
    {
        get => GetProperty<bool?>(nameof(AutoScroll));
        set => SetProperty(nameof(AutoScroll), value);
    }

    /// <summary>
    /// Gets or sets the theme mode.
    /// Values: "light", "dark", "system"
    /// </summary>
    [JsonPropertyName("theme")]
    public string? Theme
    {
        get => GetProperty<string>(nameof(Theme));
        set => SetProperty(nameof(Theme), value);
    }

    /// <summary>
    /// Gets or sets the platform brightness (read-only, set by client).
    /// Values: "light", "dark"
    /// </summary>
    [JsonPropertyName("platformBrightness")]
    public string? PlatformBrightness
    {
        get => GetProperty<string>(nameof(PlatformBrightness));
        private set => SetProperty(nameof(PlatformBrightness), value);
    }

    /// <summary>
    /// Gets or sets user-defined session data.
    /// </summary>
    [JsonIgnore]
    public Dictionary<string, object?> SessionData { get; } = new();

    /// <summary>
    /// Event raised when the route changes.
    /// </summary>
    public event EventHandler<RouteChangedEventArgs>? RouteChanged;

    /// <summary>
    /// Event raised when the window is resized.
    /// </summary>
    public event EventHandler<WindowResizedEventArgs>? WindowResized;

    /// <summary>
    /// Event raised when a view is popped from the navigation stack.
    /// </summary>
    public event EventHandler? ViewPopped;

    /// <summary>
    /// Event raised when an error occurs.
    /// </summary>
    public event EventHandler<ErrorEventArgs>? Error;

    /// <summary>
    /// Handles events specific to the Page.
    /// </summary>
    public override void HandleEvent(string eventName, Dictionary<string, object>? eventData = null)
    {
        switch (eventName.ToLowerInvariant())
        {
            case "route_change":
                if (eventData?.TryGetValue("route", out var route) == true && route is string routeStr)
                {
                    Route = routeStr;
                    RouteChanged?.Invoke(this, new RouteChangedEventArgs { Route = routeStr });
                }
                break;

            case "resize":
                if (eventData != null)
                {
                    WindowResized?.Invoke(this, new WindowResizedEventArgs
                    {
                        Width = eventData.TryGetValue("width", out var w) && w is double width ? width : 0,
                        Height = eventData.TryGetValue("height", out var h) && h is double height ? height : 0
                    });
                }
                break;

            case "view_pop":
                ViewPopped?.Invoke(this, EventArgs.Empty);
                break;

            case "error":
                if (eventData?.TryGetValue("error", out var error) == true && error is string errorStr)
                {
                    Error?.Invoke(this, new ErrorEventArgs(new Exception(errorStr)));
                }
                break;

            default:
                base.HandleEvent(eventName, eventData);
                break;
        }
    }

    /// <summary>
    /// Updates the page to trigger a re-render.
    /// This should be called after making changes to controls.
    /// </summary>
    public void Update()
    {
        // Trigger update mechanism
        // In a full implementation, this would notify the session to send patches
        OnPropertyChanged("update");
    }
}

/// <summary>
/// Event arguments for route changes.
/// </summary>
public sealed class RouteChangedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the new route.
    /// </summary>
    public required string Route { get; init; }
}

/// <summary>
/// Event arguments for window resize events.
/// </summary>
public sealed class WindowResizedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the new window width.
    /// </summary>
    public double Width { get; init; }

    /// <summary>
    /// Gets the new window height.
    /// </summary>
    public double Height { get; init; }
}
