using FlutterSharp.Core.Controls.Core;
using FlutterSharp.Core.Patching;
using Xunit;

namespace FlutterSharp.Core.Tests.Patching;

public class ControlPatcherTests
{
    [Fact]
    public void CreateFullTreePatch_ShouldGenerateAddOperation()
    {
        var root = new Column();
        root.AddChild(new Text("Hello"));
        root.AddChild(new Text("World"));

        var patches = ControlPatcher.CreateFullTreePatch(root);

        Assert.Single(patches);
        Assert.Equal("add", patches[0].Op);
        Assert.Equal("/controls", patches[0].Path);
        Assert.NotNull(patches[0].Value);
    }

    [Fact]
    public void CreateReplacePatch_ShouldGenerateReplaceOperation()
    {
        var patches = ControlPatcher.CreateReplacePatch("/controls/0", "Value", "New Text");

        Assert.Single(patches);
        Assert.Equal("replace", patches[0].Op);
        Assert.Equal("/controls/0/value", patches[0].Path);
        Assert.Equal("New Text", patches[0].Value);
    }

    [Fact]
    public void CreateRemovePatch_ShouldGenerateRemoveOperation()
    {
        var patches = ControlPatcher.CreateRemovePatch("control_1", "/controls/0");

        Assert.Single(patches);
        Assert.Equal("remove", patches[0].Op);
        Assert.Equal("/controls/0", patches[0].Path);
    }

    [Fact]
    public void CreateUpdatePatch_ShouldGenerateMultipleReplaceOperations()
    {
        var properties = new Dictionary<string, object?>
        {
            ["Value"] = "Updated",
            ["Size"] = 20,
            ["Color"] = "red"
        };

        var patches = ControlPatcher.CreateUpdatePatch("/controls/0", properties);

        Assert.Equal(3, patches.Count);
        Assert.All(patches, p => Assert.Equal("replace", p.Op));
    }

    [Fact]
    public void ControlChangeTracker_ShouldRecordChanges()
    {
        var tracker = new ControlChangeTracker();

        tracker.RecordChange("control_1", "Value", "Test");
        tracker.RecordChange("control_1", "Color", "blue");
        tracker.RecordChange("control_2", "Size", 24);

        Assert.True(tracker.HasChanges);
    }

    [Fact]
    public void ControlChangeTracker_GeneratePatches_ShouldClearChanges()
    {
        var tracker = new ControlChangeTracker();
        tracker.RecordChange("control_1", "Value", "Test");

        var patches = tracker.GeneratePatches();

        Assert.False(tracker.HasChanges);
        Assert.NotEmpty(patches);
    }
}
