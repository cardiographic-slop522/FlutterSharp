using System.Text.Json;
using System.Text.Json.Serialization;
using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Protocol;

namespace FlutterSharp.Core.Patching;

/// <summary>
/// Generates JSON Patch (RFC 6902) operations for control tree updates.
/// Implements differential updates to minimize data transfer between C# and Flutter.
/// </summary>
public static class ControlPatcher
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    /// <summary>
    /// Generates a patch to add a control to the tree.
    /// </summary>
    /// <param name="control">The control to add.</param>
    /// <param name="parentPath">The JSON pointer path to the parent (e.g., "/controls/0").</param>
    /// <returns>A list of patch operations.</returns>
    public static List<PatchOperation> CreateAddPatch(BaseControl control, string parentPath = "")
    {
        var patches = new List<PatchOperation>();
        var controlData = SerializeControl(control);

        patches.Add(new PatchOperation
        {
            Op = "add",
            Path = $"{parentPath}/controls/-",
            Value = controlData
        });

        return patches;
    }

    /// <summary>
    /// Generates a patch to remove a control from the tree.
    /// </summary>
    /// <param name="controlId">The ID of the control to remove.</param>
    /// <param name="path">The JSON pointer path to the control.</param>
    /// <returns>A list of patch operations.</returns>
    public static List<PatchOperation> CreateRemovePatch(string controlId, string path)
    {
        var patches = new List<PatchOperation>
        {
            new()
            {
                Op = "remove",
                Path = path
            }
        };

        return patches;
    }

    /// <summary>
    /// Generates a patch to replace a control property.
    /// </summary>
    /// <param name="controlPath">The JSON pointer path to the control.</param>
    /// <param name="propertyName">The property name.</param>
    /// <param name="value">The new value.</param>
    /// <returns>A list of patch operations.</returns>
    public static List<PatchOperation> CreateReplacePatch(string controlPath, string propertyName, object? value)
    {
        var patches = new List<PatchOperation>
        {
            new()
            {
                Op = "replace",
                Path = $"{controlPath}/{ToCamelCase(propertyName)}",
                Value = value
            }
        };

        return patches;
    }

    /// <summary>
    /// Generates a patch for the entire control tree (used for initial page load).
    /// </summary>
    /// <param name="rootControl">The root control of the tree.</param>
    /// <returns>A list of patch operations.</returns>
    public static List<PatchOperation> CreateFullTreePatch(BaseControl rootControl)
    {
        var patches = new List<PatchOperation>();
        var controlData = SerializeControl(rootControl);

        patches.Add(new PatchOperation
        {
            Op = "add",
            Path = "/controls",
            Value = new[] { controlData }
        });

        return patches;
    }

    /// <summary>
    /// Generates patches to update multiple properties on a control.
    /// </summary>
    /// <param name="controlPath">The JSON pointer path to the control.</param>
    /// <param name="properties">Dictionary of property names and values.</param>
    /// <returns>A list of patch operations.</returns>
    public static List<PatchOperation> CreateUpdatePatch(string controlPath, Dictionary<string, object?> properties)
    {
        var patches = new List<PatchOperation>();

        foreach (var (key, value) in properties)
        {
            patches.Add(new PatchOperation
            {
                Op = "replace",
                Path = $"{controlPath}/{ToCamelCase(key)}",
                Value = value
            });
        }

        return patches;
    }

    /// <summary>
    /// Serializes a control to a dictionary suitable for JSON Patch.
    /// </summary>
    /// <param name="control">The control to serialize.</param>
    /// <returns>A dictionary representing the control.</returns>
    private static Dictionary<string, object?> SerializeControl(BaseControl control)
    {
        var data = new Dictionary<string, object?>
        {
            ["id"] = control.Id,
            ["type"] = control.ControlType
        };

        // Add all properties
        foreach (var (key, value) in control.Properties)
        {
            var camelCaseKey = ToCamelCase(key);
            data[camelCaseKey] = SerializeValue(value);
        }

        // Add children if any
        if (control.Children.Count > 0)
        {
            data["controls"] = control.Children.Select(SerializeControl).ToList();
        }

        return data;
    }

    /// <summary>
    /// Serializes a value, handling special types like controls.
    /// </summary>
    private static object? SerializeValue(object? value)
    {
        return value switch
        {
            null => null,
            BaseControl control => SerializeControl(control),
            IEnumerable<BaseControl> controls => controls.Select(SerializeControl).ToList(),
            _ => value
        };
    }

    /// <summary>
    /// Converts a PascalCase string to camelCase.
    /// </summary>
    private static string ToCamelCase(string str)
    {
        if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
        {
            return str;
        }

        return char.ToLowerInvariant(str[0]) + str[1..];
    }
}

/// <summary>
/// Tracks changes to controls for automatic patch generation.
/// </summary>
public sealed class ControlChangeTracker
{
    private readonly Dictionary<string, Dictionary<string, object?>> _changes = new();

    /// <summary>
    /// Records a property change on a control.
    /// </summary>
    /// <param name="controlId">The control ID.</param>
    /// <param name="propertyName">The property name.</param>
    /// <param name="value">The new value.</param>
    public void RecordChange(string controlId, string propertyName, object? value)
    {
        if (!_changes.TryGetValue(controlId, out var properties))
        {
            properties = new Dictionary<string, object?>();
            _changes[controlId] = properties;
        }

        properties[propertyName] = value;
    }

    /// <summary>
    /// Generates patches for all recorded changes and clears the tracker.
    /// </summary>
    /// <returns>A list of patch operations.</returns>
    public List<PatchOperation> GeneratePatches()
    {
        var patches = new List<PatchOperation>();

        foreach (var (controlId, properties) in _changes)
        {
            var controlPath = $"/controls/{controlId}"; // Simplified; real implementation needs path resolution
            patches.AddRange(ControlPatcher.CreateUpdatePatch(controlPath, properties));
        }

        _changes.Clear();
        return patches;
    }

    /// <summary>
    /// Clears all recorded changes.
    /// </summary>
    public void Clear()
    {
        _changes.Clear();
    }

    /// <summary>
    /// Gets a value indicating whether there are any recorded changes.
    /// </summary>
    public bool HasChanges => _changes.Count > 0;
}
