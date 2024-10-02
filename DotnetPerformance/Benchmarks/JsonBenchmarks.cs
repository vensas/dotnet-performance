using BenchmarkDotNet.Attributes;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;
using BenchmarkDotNet.Jobs;

namespace DotnetPerformance.Benchmarks;

[MemoryDiagnoser(false)]
[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net90)]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class JsonBenchmarks
{
    private static readonly JsonSerializerOptions s_options = new()
    {
        Converters = { new JsonStringEnumConverter() },
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
    };

    [Params(BindingFlags.Default, BindingFlags.NonPublic | BindingFlags.Instance)]
    public BindingFlags _value;

    private byte[]? _jsonValue;
    private Utf8JsonWriter _writer = new(Stream.Null);

    [GlobalSetup]
    public void Setup() => _jsonValue = JsonSerializer.SerializeToUtf8Bytes(_value, s_options);

    [Benchmark]
    public void Serialize()
    {
        _writer.Reset();
        JsonSerializer.Serialize(_writer, _value, s_options);
    }

    [Benchmark]
    public BindingFlags Deserialize() =>
        JsonSerializer.Deserialize<BindingFlags>(_jsonValue, s_options);
}
