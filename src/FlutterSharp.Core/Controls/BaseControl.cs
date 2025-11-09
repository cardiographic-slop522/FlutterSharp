using System.Collections.Concurrent;
using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls;

/// <summary>
/// Base class for all FlutterSharp controls.
/// Provides core functionality for control lifecycle, property tracking, and parent-child relationships.
/// </summary>
public abstract class BaseControl
{
    private static long _nextId = 0;
    private readonly ConcurrentDictionary<string, object?> _properties = new();
    private readonly List<BaseControl> _children = new();
    private BaseControl? _parent;
    private bool _isMounted;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseControl"/> class.
    /// </summary>
    protected BaseControl()
    {
        Id = $"{GetType().Name}_{Interlocked.Increment(ref _nextId)}";
    }

    /// <summary>
    /// Gets the unique identifier for this control instance.
    /// Used for communication with the Flutter client.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; }

    /// <summary>
    /// Gets the Flutter widget type name for this control.
    /// This is typically set by the [Control] attribute.
    /// </summary>
    [JsonPropertyName("type")]
    public virtual string ControlType
    {
        get
        {
            var attr = GetType().GetCustomAttributes(typeof(ControlAttribute), false)
                .FirstOrDefault() as ControlAttribute;
            return attr?.FlutterWidgetName ?? GetType().Name;
        }
    }

    /// <summary>
    /// Gets the parent control, if any.
    /// </summary>
    [JsonIgnore]
    public BaseControl? Parent => _parent;

    /// <summary>
    /// Gets the children of this control.
    /// </summary>
    [JsonPropertyName("children")]
    public IReadOnlyList<BaseControl> Children => _children.AsReadOnly();

    /// <summary>
    /// Gets or sets user-defined data attached to this control.
    /// This property is not sent to the Flutter client.
    /// </summary>
    [JsonIgnore]
    public object? Data { get; set; }

    /// <summary>
    /// Gets a value indicating whether this control has been mounted (added to the control tree).
    /// </summary>
    [JsonIgnore]
    public bool IsMounted => _isMounted;

    /// <summary>
    /// Gets all properties as a dictionary for serialization.
    /// </summary>
    [JsonIgnore]
    public IReadOnlyDictionary<string, object?> Properties => _properties;

    /// <summary>
    /// Adds a child control to this control.
    /// </summary>
    /// <param name="child">The child control to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when child is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the child already has a parent.</exception>
    public virtual void AddChild(BaseControl child)
    {
        if (child == null)
        {
            throw new ArgumentNullException(nameof(child));
        }

        if (child._parent != null)
        {
            throw new InvalidOperationException($"Control {child.Id} already has a parent.");
        }

        _children.Add(child);
        child._parent = this;

        if (_isMounted)
        {
            child.Mount();
        }

        OnChildrenChanged();
    }

    /// <summary>
    /// Removes a child control from this control.
    /// </summary>
    /// <param name="child">The child control to remove.</param>
    /// <returns>True if the child was removed; otherwise, false.</returns>
    public virtual bool RemoveChild(BaseControl child)
    {
        if (child == null)
        {
            throw new ArgumentNullException(nameof(child));
        }

        if (_children.Remove(child))
        {
            if (child._isMounted)
            {
                child.Unmount();
            }

            child._parent = null;
            OnChildrenChanged();
            return true;
        }

        return false;
    }

    /// <summary>
    /// Removes all children from this control.
    /// </summary>
    public virtual void ClearChildren()
    {
        foreach (var child in _children.ToList())
        {
            RemoveChild(child);
        }
    }

    /// <summary>
    /// Gets a property value.
    /// </summary>
    /// <typeparam name="T">The type of the property.</typeparam>
    /// <param name="name">The property name.</param>
    /// <param name="defaultValue">The default value if the property is not set.</param>
    /// <returns>The property value or default value.</returns>
    protected T? GetProperty<T>(string name, T? defaultValue = default)
    {
        if (_properties.TryGetValue(name, out var value) && value is T typedValue)
        {
            return typedValue;
        }

        return defaultValue;
    }

    /// <summary>
    /// Sets a property value.
    /// </summary>
    /// <param name="name">The property name.</param>
    /// <param name="value">The property value.</param>
    protected void SetProperty(string name, object? value)
    {
        _properties[name] = value;
        OnPropertyChanged(name);
    }

    /// <summary>
    /// Called when this control is mounted (added to the control tree).
    /// Override this to perform initialization that requires the control to be part of the tree.
    /// </summary>
    protected internal virtual void OnMount()
    {
    }

    /// <summary>
    /// Called when this control is unmounted (removed from the control tree).
    /// Override this to perform cleanup.
    /// </summary>
    protected internal virtual void OnUnmount()
    {
    }

    /// <summary>
    /// Called when a property value changes.
    /// Override this to react to property changes.
    /// </summary>
    /// <param name="propertyName">The name of the property that changed.</param>
    protected virtual void OnPropertyChanged(string propertyName)
    {
    }

    /// <summary>
    /// Called when the children collection changes.
    /// Override this to react to child additions/removals.
    /// </summary>
    protected virtual void OnChildrenChanged()
    {
    }

    /// <summary>
    /// Builds the control. Override this to construct child controls dynamically.
    /// </summary>
    /// <returns>The control to render (typically 'this', but can return a different control).</returns>
    public virtual BaseControl Build()
    {
        return this;
    }

    /// <summary>
    /// Mounts this control and all its children.
    /// </summary>
    internal void Mount()
    {
        if (_isMounted)
        {
            return;
        }

        _isMounted = true;
        OnMount();

        foreach (var child in _children)
        {
            child.Mount();
        }
    }

    /// <summary>
    /// Unmounts this control and all its children.
    /// </summary>
    internal void Unmount()
    {
        if (!_isMounted)
        {
            return;
        }

        foreach (var child in _children)
        {
            child.Unmount();
        }

        OnUnmount();
        _isMounted = false;
    }

    /// <summary>
    /// Returns a string representation of this control.
    /// </summary>
    public override string ToString()
    {
        return $"{ControlType}(id: {Id}, children: {_children.Count})";
    }
}
