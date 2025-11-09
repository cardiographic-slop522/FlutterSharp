using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;

namespace FlutterSharp.Core.Protocol;

/// <summary>
/// Custom MessagePack formatter for DateTime that serializes to ISO 8601 string format.
/// Flet protocol expects dates in string format for compatibility with Python/JavaScript.
/// </summary>
public sealed class DateTimeFormatter : IMessagePackFormatter<DateTime>
{
    public void Serialize(ref MessagePackWriter writer, DateTime value, MessagePackSerializerOptions options)
    {
        writer.Write(value.ToString("O")); // ISO 8601 format
    }

    public DateTime Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        var str = reader.ReadString();
        return string.IsNullOrEmpty(str) ? DateTime.MinValue : DateTime.Parse(str);
    }
}

/// <summary>
/// Custom MessagePack formatter for DateOnly that serializes to ISO 8601 date format.
/// </summary>
public sealed class DateOnlyFormatter : IMessagePackFormatter<DateOnly>
{
    public void Serialize(ref MessagePackWriter writer, DateOnly value, MessagePackSerializerOptions options)
    {
        writer.Write(value.ToString("O")); // ISO 8601 date format (yyyy-MM-dd)
    }

    public DateOnly Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        var str = reader.ReadString();
        return string.IsNullOrEmpty(str) ? DateOnly.MinValue : DateOnly.Parse(str);
    }
}

/// <summary>
/// Custom MessagePack formatter for TimeOnly that serializes to ISO 8601 time format.
/// </summary>
public sealed class TimeOnlyFormatter : IMessagePackFormatter<TimeOnly>
{
    public void Serialize(ref MessagePackWriter writer, TimeOnly value, MessagePackSerializerOptions options)
    {
        writer.Write(value.ToString("O")); // ISO 8601 time format (HH:mm:ss.fffffff)
    }

    public TimeOnly Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        var str = reader.ReadString();
        return string.IsNullOrEmpty(str) ? TimeOnly.MinValue : TimeOnly.Parse(str);
    }
}

/// <summary>
/// Custom MessagePack formatter for TimeSpan that serializes to total milliseconds.
/// Matches Flutter's Duration representation.
/// </summary>
public sealed class TimeSpanFormatter : IMessagePackFormatter<TimeSpan>
{
    public void Serialize(ref MessagePackWriter writer, TimeSpan value, MessagePackSerializerOptions options)
    {
        writer.Write((long)value.TotalMilliseconds);
    }

    public TimeSpan Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        var milliseconds = reader.ReadInt64();
        return TimeSpan.FromMilliseconds(milliseconds);
    }
}

/// <summary>
/// Custom resolver that combines built-in resolvers with custom formatters.
/// This should be used as the standard resolver for all FlutterSharp MessagePack operations.
/// </summary>
public sealed class FlutterSharpResolver : IFormatterResolver
{
    public static readonly FlutterSharpResolver Instance = new();

    private FlutterSharpResolver()
    {
    }

    public IMessagePackFormatter<T>? GetFormatter<T>()
    {
        return FormatterCache<T>.Formatter;
    }

    private static class FormatterCache<T>
    {
        public static readonly IMessagePackFormatter<T>? Formatter;

        static FormatterCache()
        {
            Formatter = (IMessagePackFormatter<T>?)FlutterSharpResolverGetFormatterHelper.GetFormatter(typeof(T));
        }
    }

    private static class FlutterSharpResolverGetFormatterHelper
    {
        private static readonly Dictionary<Type, object> FormatterMap = new()
        {
            { typeof(DateTime), new DateTimeFormatter() },
            { typeof(DateOnly), new DateOnlyFormatter() },
            { typeof(TimeOnly), new TimeOnlyFormatter() },
            { typeof(TimeSpan), new TimeSpanFormatter() }
        };

        internal static object? GetFormatter(Type t)
        {
            if (FormatterMap.TryGetValue(t, out var formatter))
            {
                return formatter;
            }

            // Fall back to standard resolvers - use reflection to call generic method
            var method = typeof(IFormatterResolver).GetMethod(nameof(IFormatterResolver.GetFormatter))!;
            var genericMethod = method.MakeGenericMethod(t);
            return genericMethod.Invoke(StandardResolver.Instance, null);
        }
    }
}

/// <summary>
/// Provides pre-configured MessagePack serializer options for FlutterSharp.
/// Use this for all serialization/deserialization operations to ensure consistency.
/// </summary>
public static class FlutterSharpMessagePackOptions
{
    /// <summary>
    /// Standard options for FlutterSharp protocol communication.
    /// </summary>
    public static readonly MessagePackSerializerOptions Standard =
        MessagePackSerializerOptions.Standard
            .WithResolver(CompositeResolver.Create(
                FlutterSharpResolver.Instance,
                StandardResolver.Instance
            ));

    /// <summary>
    /// Options with compression enabled for large payloads.
    /// </summary>
    public static readonly MessagePackSerializerOptions Compressed =
        Standard.WithCompression(MessagePackCompression.Lz4BlockArray);
}
