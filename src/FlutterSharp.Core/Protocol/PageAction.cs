namespace FlutterSharp.Core.Protocol;

/// <summary>
/// Represents actions related to page management.
/// </summary>
public enum PageAction
{
    /// <summary>
    /// Add a new page to the application.
    /// </summary>
    Add = 1,

    /// <summary>
    /// Replace an existing page.
    /// </summary>
    Replace = 2,

    /// <summary>
    /// Remove a page from the application.
    /// </summary>
    Remove = 3,

    /// <summary>
    /// Clear all pages.
    /// </summary>
    Clear = 4
}
