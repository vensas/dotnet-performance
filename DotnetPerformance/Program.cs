using BenchmarkDotNet.Running;
using DotnetPerformance.Benchmarks;

BenchmarkRunner.Run<LinqBenchmarks>();
// BenchmarkRunner.Run<JsonBenchmarks>();
// BenchmarkRunner.Run<ReflectionBenchmarks>();

