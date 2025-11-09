using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Cupertino;

/// <summary>
/// An iOS-style alert dialog.
/// Informs the user about situations that require acknowledgement with an optional title and list of actions.
/// The title is displayed above the content and the actions are displayed below the content.
/// Corresponds to Flutter's CupertinoAlertDialog widget.
/// </summary>
[Control("CupertinoAlertDialog", Category = "cupertino")]
public sealed class CupertinoAlertDialog : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoAlertDialog"/> class.
    /// </summary>
    public CupertinoAlertDialog()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CupertinoAlertDialog"/> class with content.
    /// </summary>
    /// <param name="content">The content of this dialog.</param>
    public CupertinoAlertDialog(object? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets whether this dialog cannot be dismissed by clicking the area outside of it.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("modal")]
    public bool? Modal
    {
        get => GetProperty<bool?>(nameof(Modal));
        set => SetProperty(nameof(Modal), value);
    }

    /// <summary>
    /// Gets or sets the title of this dialog, displayed in a large font at the top of this dialog.
    /// Can be a string or a control (typically Text).
    /// </summary>
    [JsonPropertyName("title")]
    public object? Title
    {
        get => GetProperty<object>(nameof(Title));
        set => SetProperty(nameof(Title), value);
    }

    /// <summary>
    /// Gets or sets the content of this dialog, displayed in a light font at the center of this dialog.
    /// Typically a Column that contains the dialog's Text message.
    /// </summary>
    [JsonPropertyName("content")]
    public object? Content
    {
        get => GetProperty<object>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets whether this dialog is visible.
    /// </summary>
    [JsonPropertyName("open")]
    public bool? Open
    {
        get => GetProperty<bool?>(nameof(Open));
        set => SetProperty(nameof(Open), value);
    }

    /// <summary>
    /// Occurs when this dialog is dismissed.
    /// </summary>
    public event EventHandler? Dismiss;
}
