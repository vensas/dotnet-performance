using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Reflection;

namespace DotnetPerformance.Benchmarks;

[MemoryDiagnoser(false)]
[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net90)]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class ReflectionBenchmarks
{
    private static object s_staticReferenceField = new object();
    private object _instanceReferenceField = new object();
    private static int s_staticValueField = 1;
    private int _instanceValueField = 2;
    private object _obj = new();

    private readonly FieldInfo _staticReferenceFieldInfo = typeof(ReflectionBenchmarks).GetField(nameof(s_staticReferenceField), BindingFlags.NonPublic | BindingFlags.Static)!;
    private readonly FieldInfo _instanceReferenceFieldInfo = typeof(ReflectionBenchmarks).GetField(nameof(_instanceReferenceField), BindingFlags.NonPublic | BindingFlags.Instance)!;
    private readonly FieldInfo _staticValueFieldInfo = typeof(ReflectionBenchmarks).GetField(nameof(s_staticValueField), BindingFlags.NonPublic | BindingFlags.Static)!;
    private readonly FieldInfo _instanceValueFieldInfo = typeof(ReflectionBenchmarks).GetField(nameof(_instanceValueField), BindingFlags.NonPublic | BindingFlags.Instance)!;

    [Benchmark] public object? GetStaticReferenceField() => _staticReferenceFieldInfo.GetValue(null);
    [Benchmark] public void SetStaticReferenceField() => _staticReferenceFieldInfo.SetValue(null, _obj);

    [Benchmark] public object? GetInstanceReferenceField() => _instanceReferenceFieldInfo.GetValue(this);
    [Benchmark] public void SetInstanceReferenceField() => _instanceReferenceFieldInfo.SetValue(this, _obj);

    [Benchmark] public int GetStaticValueField() => (int)_staticValueFieldInfo.GetValue(null)!;
    [Benchmark] public void SetStaticValueField() => _staticValueFieldInfo.SetValue(null, 3);

    [Benchmark] public int GetInstanceValueField() => (int)_instanceValueFieldInfo.GetValue(this)!;
    [Benchmark] public void SetInstanceValueField() => _instanceValueFieldInfo.SetValue(this, 4);
}
