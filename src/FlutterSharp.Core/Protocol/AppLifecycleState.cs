namespace FlutterSharp.Core.Protocol;

/// <summary>
/// Represents the lifecycle states of the Flutter application.
/// Corresponds to Flutter's AppLifecycleState enum.
/// </summary>
public enum AppLifecycleState
{
    /// <summary>
    /// The application is visible and responding to user input.
    /// </summary>
    Resumed = 0,

    /// <summary>
    /// The application is inactive (not receiving user input).
    /// iOS/Android: App is transitioning between foreground and background.
    /// </summary>
    Inactive = 1,

    /// <summary>
    /// The application is hidden (in background).
    /// </summary>
    Hidden = 2,

    /// <summary>
    /// The application is paused (not executing).
    /// Android: App is in background and not visible.
    /// </summary>
    Paused = 3,

    /// <summary>
    /// The application is detached (about to be terminated).
    /// </summary>
    Detached = 4
}
