using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// A Material Design dropdown button.
/// Corresponds to Flutter's DropdownButton widget.
/// </summary>
[Control("Dropdown", Category = "material")]
public sealed class Dropdown : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Dropdown"/> class.
    /// </summary>
    public Dropdown()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Dropdown"/> class with options.
    /// </summary>
    /// <param name="options">The dropdown options.</param>
    public Dropdown(params DropdownOption[] options)
    {
        Options = options.ToList();
    }

    /// <summary>
    /// Gets or sets the selected value.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value
    {
        get => GetProperty<string>(nameof(Value));
        set => SetProperty(nameof(Value), value);
    }

    /// <summary>
    /// Gets or sets the label text.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label
    {
        get => GetProperty<string>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }

    /// <summary>
    /// Gets or sets the hint text.
    /// </summary>
    [JsonPropertyName("hint")]
    public string? Hint
    {
        get => GetProperty<string>(nameof(Hint));
        set => SetProperty(nameof(Hint), value);
    }

    /// <summary>
    /// Gets or sets the list of dropdown options.
    /// </summary>
    [JsonPropertyName("options")]
    public List<DropdownOption>? Options
    {
        get => GetProperty<List<DropdownOption>>(nameof(Options));
        set => SetProperty(nameof(Options), value);
    }

    /// <summary>
    /// Gets or sets the icon.
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon
    {
        get => GetProperty<string>(nameof(Icon));
        set => SetProperty(nameof(Icon), value);
    }

    /// <summary>
    /// Gets or sets the border width.
    /// </summary>
    [JsonPropertyName("borderWidth")]
    public double? BorderWidth
    {
        get => GetProperty<double?>(nameof(BorderWidth));
        set => SetProperty(nameof(BorderWidth), value);
    }

    /// <summary>
    /// Gets or sets the border color.
    /// </summary>
    [JsonPropertyName("borderColor")]
    public string? BorderColor
    {
        get => GetProperty<string>(nameof(BorderColor));
        set => SetProperty(nameof(BorderColor), value);
    }

    /// <summary>
    /// Gets or sets the border radius.
    /// </summary>
    [JsonPropertyName("borderRadius")]
    public double? BorderRadius
    {
        get => GetProperty<double?>(nameof(BorderRadius));
        set => SetProperty(nameof(BorderRadius), value);
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
    /// Gets or sets a value indicating whether autofocus is enabled.
    /// </summary>
    [JsonPropertyName("autofocus")]
    public bool? Autofocus
    {
        get => GetProperty<bool?>(nameof(Autofocus));
        set => SetProperty(nameof(Autofocus), value);
    }

    /// <summary>
    /// Event raised when the selection changes.
    /// </summary>
    public event EventHandler<DropdownChangedEventArgs>? Changed;

    /// <summary>
    /// Handles events specific to Dropdown.
    /// </summary>
    public override void HandleEvent(string eventName, Dictionary<string, object>? eventData = null)
    {
        switch (eventName.ToLowerInvariant())
        {
            case "change":
                if (eventData?.TryGetValue("value", out var value) == true && value is string newValue)
                {
                    Value = newValue;
                    Changed?.Invoke(this, new DropdownChangedEventArgs { Value = newValue });
                }
                break;

            default:
                base.HandleEvent(eventName, eventData);
                break;
        }
    }

    /// <summary>
    /// Adds an option to the dropdown.
    /// </summary>
    /// <param name="key">The option key/value.</param>
    /// <param name="text">The display text.</param>
    public void AddOption(string key, string text)
    {
        Options ??= new List<DropdownOption>();
        Options.Add(new DropdownOption { Key = key, Text = text });
    }
}

/// <summary>
/// Represents a dropdown option.
/// </summary>
public sealed class DropdownOption
{
    /// <summary>
    /// Gets or sets the option key/value.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// Gets or sets the display text.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }
}

/// <summary>
/// Event arguments for dropdown change events.
/// </summary>
public sealed class DropdownChangedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the selected value.
    /// </summary>
    public required string Value { get; init; }
}
