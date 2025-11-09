using FlutterSharp.Core.Protocol;
using MessagePack;
using Xunit;

namespace FlutterSharp.Core.Tests.Protocol;

public class MessagePackSerializationTests
{
    [Fact]
    public void RegisterClientMessage_ShouldSerializeAndDeserialize()
    {
        var message = new RegisterClientMessage
        {
            Action = ClientAction.RegisterClient,
            MessageId = "test-123",
            SessionId = "session-456",
            PageName = "/home",
            Platform = "web"
        };

        var bytes = MessagePackSerializer.Serialize(message, FlutterSharpMessagePackOptions.Standard);
        var deserialized = MessagePackSerializer.Deserialize<RegisterClientMessage>(bytes, FlutterSharpMessagePackOptions.Standard);

        Assert.Equal(message.Action, deserialized.Action);
        Assert.Equal(message.MessageId, deserialized.MessageId);
        Assert.Equal(message.SessionId, deserialized.SessionId);
        Assert.Equal(message.PageName, deserialized.PageName);
        Assert.Equal(message.Platform, deserialized.Platform);
    }

    [Fact]
    public void ControlEventMessage_ShouldSerializeAndDeserialize()
    {
        var message = new ControlEventMessage
        {
            Action = ClientAction.ControlEvent,
            ControlId = "button_1",
            EventName = "click",
            Data = new Dictionary<string, object>
            {
                ["x"] = 100,
                ["y"] = 200
            }
        };

        var bytes = MessagePackSerializer.Serialize(message, FlutterSharpMessagePackOptions.Standard);
        var deserialized = MessagePackSerializer.Deserialize<ControlEventMessage>(bytes, FlutterSharpMessagePackOptions.Standard);

        Assert.Equal(message.ControlId, deserialized.ControlId);
        Assert.Equal(message.EventName, deserialized.EventName);
        Assert.NotNull(deserialized.Data);
        Assert.Equal(2, deserialized.Data.Count);
    }

    [Fact]
    public void PatchOperation_ShouldSerializeAndDeserialize()
    {
        var patch = new PatchOperation
        {
            Op = "replace",
            Path = "/controls/0/value",
            Value = "New Value"
        };

        var bytes = MessagePackSerializer.Serialize(patch, FlutterSharpMessagePackOptions.Standard);
        var deserialized = MessagePackSerializer.Deserialize<PatchOperation>(bytes, FlutterSharpMessagePackOptions.Standard);

        Assert.Equal(patch.Op, deserialized.Op);
        Assert.Equal(patch.Path, deserialized.Path);
        Assert.Equal(patch.Value, deserialized.Value);
    }

    [Fact]
    public void DateTime_ShouldSerializeAsIso8601String()
    {
        var dateTime = new DateTime(2025, 11, 9, 12, 30, 45, DateTimeKind.Utc);
        var bytes = MessagePackSerializer.Serialize(dateTime, FlutterSharpMessagePackOptions.Standard);
        var deserialized = MessagePackSerializer.Deserialize<DateTime>(bytes, FlutterSharpMessagePackOptions.Standard);

        Assert.Equal(dateTime.Year, deserialized.Year);
        Assert.Equal(dateTime.Month, deserialized.Month);
        Assert.Equal(dateTime.Day, deserialized.Day);
    }

    [Fact]
    public void TimeSpan_ShouldSerializeAsMilliseconds()
    {
        var timeSpan = TimeSpan.FromMinutes(5);
        var bytes = MessagePackSerializer.Serialize(timeSpan, FlutterSharpMessagePackOptions.Standard);
        var deserialized = MessagePackSerializer.Deserialize<TimeSpan>(bytes, FlutterSharpMessagePackOptions.Standard);

        Assert.Equal(timeSpan.TotalMilliseconds, deserialized.TotalMilliseconds);
    }
}
