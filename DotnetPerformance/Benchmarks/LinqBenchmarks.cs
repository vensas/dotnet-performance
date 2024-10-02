using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace DotnetPerformance.Benchmarks;

[MemoryDiagnoser(false)]
[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net90)]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class LinqBenchmarks
{
    private static readonly IEnumerable<int> _range = Enumerable.Range(0, 1000);
    private readonly IEnumerable<int> _list = _range.ToList();
    private readonly IEnumerable<int> _arrayDistinct = _range.ToArray().Distinct();
    private readonly IEnumerable<int> _appendSelect = _range.ToArray().Append(42).Select(i => i * 2);
    private readonly IEnumerable<int> _rangeReverse = _range.Reverse();
    private readonly IEnumerable<int> _listDefaultIfEmptySelect = _range.ToList().DefaultIfEmpty().Select(i => i * 2);
    private readonly IEnumerable<int> _listSkipTake = _range.ToList().Skip(500).Take(100);
    private readonly IEnumerable<int> _rangeUnion = _range.Union(Enumerable.Range(500, 1000));

    [Benchmark] public bool Any() => _list.Any(i => i == 1000);
    [Benchmark] public bool All() => _list.All(i => i >= 0);
    [Benchmark] public int Count() => _list.Count(i => i == 0);
    [Benchmark] public int First() => _list.First(i => i == 999);
    [Benchmark] public int Single() => _list.Single(i => i == 0);
    [Benchmark] public int DistinctFirst() => _arrayDistinct.First();
    [Benchmark] public int AppendSelectLast() => _appendSelect.Last();
    [Benchmark] public int RangeReverseCount() => _rangeReverse.Count();
    [Benchmark] public int DefaultIfEmptySelectElementAt() => _listDefaultIfEmptySelect.ElementAt(999);
    [Benchmark] public int ListSkipTakeElementAt() => _listSkipTake.ElementAt(99);
    [Benchmark] public int RangeUnionFirst() => _rangeUnion.First();
}
