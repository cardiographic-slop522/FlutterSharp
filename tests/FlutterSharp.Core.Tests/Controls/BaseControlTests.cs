using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Controls.Core;
using Xunit;

namespace FlutterSharp.Core.Tests.Controls;

public class BaseControlTests
{
    [Fact]
    public void BaseControl_ShouldGenerateUniqueId()
    {
        var control1 = new Text();
        var control2 = new Text();

        Assert.NotEqual(control1.Id, control2.Id);
    }

    [Fact]
    public void BaseControl_ShouldSetControlType()
    {
        var text = new Text();
        Assert.Equal("Text", text.ControlType);

        var column = new Column();
        Assert.Equal("Column", column.ControlType);
    }

    [Fact]
    public void AddChild_ShouldAddToChildren()
    {
        var parent = new Column();
        var child = new Text("Hello");

        parent.AddChild(child);

        Assert.Single(parent.Children);
        Assert.Same(child, parent.Children[0]);
        Assert.Same(parent, child.Parent);
    }

    [Fact]
    public void AddChild_ShouldMountWhenParentIsMounted()
    {
        var parent = new Column();
        // Use reflection to call internal Mount method for testing
        var mountMethod = typeof(BaseControl).GetMethod("Mount",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        mountMethod?.Invoke(parent, null);

        var child = new Text("Hello");
        parent.AddChild(child);

        Assert.True(child.IsMounted);
    }

    [Fact]
    public void RemoveChild_ShouldRemoveFromChildren()
    {
        var parent = new Column();
        var child = new Text("Hello");

        parent.AddChild(child);
        var removed = parent.RemoveChild(child);

        Assert.True(removed);
        Assert.Empty(parent.Children);
        Assert.Null(child.Parent);
    }

    [Fact]
    public void RemoveChild_ShouldUnmountChild()
    {
        var parent = new Column();
        var child = new Text("Hello");

        parent.AddChild(child);
        // Use reflection to call internal Mount method for testing
        var mountMethod = typeof(BaseControl).GetMethod("Mount",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        mountMethod?.Invoke(parent, null);
        parent.RemoveChild(child);

        Assert.False(child.IsMounted);
    }

    [Fact]
    public void ClearChildren_ShouldRemoveAllChildren()
    {
        var parent = new Column();
        parent.AddChild(new Text("One"));
        parent.AddChild(new Text("Two"));
        parent.AddChild(new Text("Three"));

        parent.ClearChildren();

        Assert.Empty(parent.Children);
    }

    [Fact]
    public void Properties_ShouldStoreValues()
    {
        var control = new Text
        {
            Value = "Test",
            Size = 24,
            Color = "blue"
        };

        Assert.Equal("Test", control.Value);
        Assert.Equal(24, control.Size);
        Assert.Equal("blue", control.Color);
    }
}
