using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Radio buttons let people select a single option from two or more choices.
/// RadioGroup manages the selection state of multiple Radio controls.
/// Corresponds to Flutter's RadioGroup widget.
/// </summary>
[Control("RadioGroup", Category = "material")]
public sealed class RadioGroup : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RadioGroup"/> class.
    /// </summary>
    public RadioGroup()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RadioGroup"/> class with content.
    /// </summary>
    /// <param name="content">The content containing Radio controls.</param>
    /// <param name="value">Optional initial selected value.</param>
    public RadioGroup(BaseControl? content = null, string? value = null)
    {
        if (content != null) Content = content;
        if (value != null) Value = value;
    }

    /// <summary>
    /// Gets or sets the content of the RadioGroup.
    /// Typically a list of Radio controls nested in a container control (e.g., Column, Row).
    /// </summary>
    [JsonPropertyName("content")]
    public BaseControl? Content
    {
        get => GetProperty<BaseControl>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets the current value of the RadioGroup.
    /// This should match the value of one of the Radio controls in the group.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value
    {
        get => GetProperty<string>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Occurs when the state of the RadioGroup is changed.
    /// </summary>
    public event EventHandler? Change;
}
