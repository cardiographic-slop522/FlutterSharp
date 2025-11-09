namespace FlutterSharp.Core.Controls;

/// <summary>
/// Marks a class as a FlutterSharp control and specifies its Flutter widget mapping.
/// This attribute provides metadata for control registration and code generation.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class ControlAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ControlAttribute"/> class.
    /// </summary>
    /// <param name="flutterWidgetName">The name of the corresponding Flutter widget (e.g., "Column", "Text", "ElevatedButton").</param>
    public ControlAttribute(string flutterWidgetName)
    {
        FlutterWidgetName = flutterWidgetName ?? throw new ArgumentNullException(nameof(flutterWidgetName));
    }

    /// <summary>
    /// Gets the name of the Flutter widget this control maps to.
    /// </summary>
    public string FlutterWidgetName { get; }

    /// <summary>
    /// Gets or sets a value indicating whether this control is a container that can have children.
    /// </summary>
    public bool IsContainer { get; init; }

    /// <summary>
    /// Gets or sets the category of the control (e.g., "layout", "input", "material", "cupertino").
    /// Used for documentation and tooling.
    /// </summary>
    public string? Category { get; init; }

    /// <summary>
    /// Gets or sets additional metadata as a JSON string.
    /// Can be used for custom properties specific to certain controls.
    /// </summary>
    public string? Metadata { get; init; }
}
