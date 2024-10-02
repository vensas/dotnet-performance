# Dotnet-Performance Benchmarks: Vergleich .NET6, .NET8, .NET9

## Überblick

Dieses Repository enthält Benchmarks, die die Performance-Unterschiede zwischen den .NET-Versionen 6, 8 und 9 beleuchten. Mit jeder neuen Version verspricht Microsoft Verbesserungen und Optimierungen, die die Effizienz und Geschwindigkeit 
von Anwendungen steigern können. Unsere Analysen basieren auf systematischen Tests, die zeigen sollen, ob und wie signifikant diese Verbesserungen in realen Szenarien sind.


## Umgebung

Um die Performance-Verbesserungen in .NET 6, .NET 8 und .NET 9 zu vergleichen, haben wir die offiziellen Benchmarks von Microsoft verwendet und nutzen die 
[.NET Benchmarking Library](https://github.com/dotnet/BenchmarkDotNet) für unsere eigenen Tests.

Alle Benchmarks wurden auf einem Windows 11-System mit einem 13th Gen Intel Core i9-13900H durchgeführt. Die .NET-Versionen, die wir für die Tests verwendet haben, sind:
- .NET 6.0 : .NET 6.0.33 (6.0.3324.36610), X64 RyuJIT AVX2
- .NET 8.0 : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
- .NET 9.0 : .NET 9.0.0 (9.0.24.43107), X64 RyuJIT AVX2

## Was haben wir verglichen?

Wir haben die Performance-Verbesserungen in .NET 6, .NET 8 und .NET 9 anhand von Benchmarks in verschiedenen Bereichen untersucht: LINQ, JSON und Reflections.

## Einrichtung

1. **Repository klonen**:

   ```bash
   git clone https://github.com/vensas/dotnet-performance.git
   cd dotnet-performances
   ```

2. **Program.cs anpassen und Benchmark wählen**:

```csharp
BenchmarkRunner.Run<LinqBenchmarks>();
// BenchmarkRunner.Run<JsonBenchmarks>();
// BenchmarkRunner.Run<ReflectionBenchmarks>();
```

3. **Anwendung bauen und starten**:
   ```bash
   dotnet run
   ```

## Ergebnisse

### Linq

```plaintext
| Method                        | Runtime  | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------ |--------- |--------------|-------|-----------|-------------|
| Any                           | .NET 6.0 | 4,782.516 ns |  1.00 |      40 B |        1.00 |
| Any                           | .NET 8.0 |   765.803 ns |  0.16 |      40 B |        1.00 |
| Any                           | .NET 9.0 |   206.087 ns |  0.04 |         - |        0.00 |
|                               |          |              |       |           |             |
| All                           | .NET 6.0 | 4,991.082 ns |  1.00 |      40 B |        1.00 |
| All                           | .NET 8.0 |   776.467 ns |  0.16 |      40 B |        1.00 |
| All                           | .NET 9.0 |   208.231 ns |  0.04 |         - |        0.00 |
|                               |          |              |       |           |             |
| Count                         | .NET 6.0 | 4,975.124 ns |  1.00 |      40 B |        1.00 |
| Count                         | .NET 8.0 |   778.610 ns |  0.16 |      40 B |        1.00 |
| Count                         | .NET 9.0 |   216.836 ns |  0.04 |         - |        0.00 |
|                               |          |              |       |           |             |
| First                         | .NET 6.0 | 5,004.428 ns |  1.00 |      40 B |        1.00 |
| First                         | .NET 8.0 |   783.574 ns |  0.16 |      40 B |        1.00 |
| First                         | .NET 9.0 |   209.663 ns |  0.04 |         - |        0.00 |
|                               |          |              |       |           |             |
| Single                        | .NET 6.0 | 4,966.573 ns |  1.00 |      40 B |        1.00 |
| Single                        | .NET 8.0 |   809.533 ns |  0.16 |      40 B |        1.00 |
| Single                        | .NET 9.0 |   210.186 ns |  0.04 |         - |        0.00 |
|                               |          |              |       |           |             |
| DistinctFirst                 | .NET 6.0 |    40.904 ns |  1.00 |     328 B |        1.00 |
| DistinctFirst                 | .NET 8.0 |    29.095 ns |  0.71 |     328 B |        1.00 |
| DistinctFirst                 | .NET 9.0 |     7.969 ns |  0.19 |         - |        0.00 |
|                               |          |              |       |           |             |
| AppendSelectLast              | .NET 6.0 | 9,339.431 ns | 1.000 |     144 B |        1.00 |
| AppendSelectLast              | .NET 8.0 | 2,400.576 ns | 0.257 |     144 B |        1.00 |
| AppendSelectLast              | .NET 9.0 |     1.448 ns | 0.000 |         - |        0.00 |
|                               |          |              |       |           |             |
| RangeReverseCount             | .NET 6.0 |    11.119 ns |  1.00 |         - |          NA |
| RangeReverseCount             | .NET 8.0 |     6.998 ns |  0.63 |         - |          NA |
| RangeReverseCount             | .NET 9.0 |     3.249 ns |  0.29 |         - |          NA |
|                               |          |              |       |           |             |
| DefaultIfEmptySelectElementAt | .NET 6.0 | 8,832.188 ns | 1.000 |     144 B |        1.00 |
| DefaultIfEmptySelectElementAt | .NET 8.0 | 1,752.850 ns | 0.198 |     144 B |        1.00 |
| DefaultIfEmptySelectElementAt | .NET 9.0 |     2.840 ns | 0.000 |         - |        0.00 |
|                               |          |              |       |           |             |
| ListSkipTakeElementAt         | .NET 6.0 |     5.729 ns |  1.00 |         - |          NA |
| ListSkipTakeElementAt         | .NET 8.0 |     3.042 ns |  0.53 |         - |          NA |
| ListSkipTakeElementAt         | .NET 9.0 |     1.443 ns |  0.25 |         - |          NA |
|                               |          |              |       |           |             |
| RangeUnionFirst               | .NET 6.0 |    45.731 ns |  1.00 |     344 B |        1.00 |
| RangeUnionFirst               | .NET 8.0 |    29.681 ns |  0.65 |     344 B |        1.00 |
| RangeUnionFirst               | .NET 9.0 |     4.785 ns |  0.10 |         - |        0.00 |
```

### JSON

```plaintext
| Method      | Runtime  | _value              | Mean      | Ratio | Allocated | Alloc Ratio |
|------------ |--------- |-------------------- |----------:|------:|----------:|------------:|
| Serialize   | .NET 6.0 | Default             |  48.62 ns |  1.00 |      24 B |        1.00 |
| Serialize   | .NET 8.0 | Default             |  24.40 ns |  0.50 |      24 B |        1.00 |
| Serialize   | .NET 9.0 | Default             |  20.71 ns |  0.43 |         - |        0.00 |
|             |          |                     |           |       |           |             |
| Deserialize | .NET 6.0 | Default             |  77.15 ns |  1.00 |      40 B |        1.00 |
| Deserialize | .NET 8.0 | Default             |  50.86 ns |  0.66 |         - |        0.00 |
| Deserialize | .NET 9.0 | Default             |  47.24 ns |  0.61 |         - |        0.00 |
|             |          |                     |           |       |           |             |
| Serialize   | .NET 6.0 | Instance, NonPublic |  48.42 ns |  1.00 |      24 B |        1.00 |
| Serialize   | .NET 8.0 | Instance, NonPublic |  24.35 ns |  0.50 |      24 B |        1.00 |
| Serialize   | .NET 9.0 | Instance, NonPublic |  17.85 ns |  0.37 |         - |        0.00 |
|             |          |                     |           |       |           |             |
| Deserialize | .NET 6.0 | Instance, NonPublic | 107.72 ns |  1.00 |      64 B |        1.00 |
| Deserialize | .NET 8.0 | Instance, NonPublic |  66.58 ns |  0.62 |         - |        0.00 |
| Deserialize | .NET 9.0 | Instance, NonPublic |  50.05 ns |  0.46 |         - |        0.00 |
```

### Reflection

```plaintext
| Method                    | Runtime  | Mean      | Ratio | Allocated | Alloc Ratio |
|-------------------------- |--------- |----------:|------:|----------:|------------:|
| GetStaticReferenceField   | .NET 6.0 | 11.302 ns |  1.00 |         - |          NA |
| GetStaticReferenceField   | .NET 8.0 | 12.375 ns |  1.10 |         - |          NA |
| GetStaticReferenceField   | .NET 9.0 |  1.978 ns |  0.18 |         - |          NA |
|                           |          |           |       |           |             |
| SetStaticReferenceField   | .NET 6.0 | 28.215 ns |  1.00 |         - |          NA |
| SetStaticReferenceField   | .NET 8.0 | 22.721 ns |  0.81 |         - |          NA |
| SetStaticReferenceField   | .NET 9.0 |  4.959 ns |  0.18 |         - |          NA |
|                           |          |           |       |           |             |
| GetInstanceReferenceField | .NET 6.0 | 14.215 ns |  1.00 |         - |          NA |
| GetInstanceReferenceField | .NET 8.0 | 16.236 ns |  1.14 |         - |          NA |
| GetInstanceReferenceField | .NET 9.0 |  4.248 ns |  0.30 |         - |          NA |
|                           |          |           |       |           |             |
| SetInstanceReferenceField | .NET 6.0 | 24.403 ns |  1.00 |         - |          NA |
| SetInstanceReferenceField | .NET 8.0 | 20.346 ns |  0.83 |         - |          NA |
| SetInstanceReferenceField | .NET 9.0 |  7.135 ns |  0.29 |         - |          NA |
|                           |          |           |       |           |             |
| GetStaticValueField       | .NET 6.0 | 23.441 ns |  1.00 |      24 B |        1.00 |
| GetStaticValueField       | .NET 8.0 | 24.030 ns |  1.03 |      24 B |        1.00 |
| GetStaticValueField       | .NET 9.0 | 17.607 ns |  0.75 |      24 B |        1.00 |
|                           |          |           |       |           |             |
| SetStaticValueField       | .NET 6.0 | 29.787 ns |  1.00 |      24 B |        1.00 |
| SetStaticValueField       | .NET 8.0 | 25.298 ns |  0.85 |      24 B |        1.00 |
| SetStaticValueField       | .NET 9.0 |  4.421 ns |  0.15 |      24 B |        1.00 |
|                           |          |           |       |           |             |
| GetInstanceValueField     | .NET 6.0 | 23.813 ns |  1.00 |      24 B |        1.00 |
| GetInstanceValueField     | .NET 8.0 | 24.378 ns |  1.02 |      24 B |        1.00 |
| GetInstanceValueField     | .NET 9.0 | 20.536 ns |  0.86 |      24 B |        1.00 |
|                           |          |           |       |           |             |
| SetInstanceValueField     | .NET 6.0 | 28.606 ns |  1.00 |      24 B |        1.00 |
| SetInstanceValueField     | .NET 8.0 | 25.917 ns |  0.91 |      24 B |        1.00 |
| SetInstanceValueField     | .NET 9.0 |  6.929 ns |  0.24 |      24 B |        1.00 |
```

## Fazit

Die Performance-Verbesserungen in .NET 9 sind beeindruckend. Die Benchmarks zeigen, dass .NET 9 in vielen Bereichen eine deutliche Steigerung der Performance bietet.
Wenn ihr also auf der Suche nach einer Möglichkeit seid, die Leistung eurer Anwendungen zu verbessern, kann ein Upgrade auf .NET 9 eine gute Option sein ohne dass ihr euren Code anpassen müsst.

## Blog-Artikel

Du kannst mehr darüber in unserem Blog-Artikel lesen: [.NET Evolution: Ist das Upgrade auf die neuste Version die Mühe wert?](https://vensas.de/blog/dotnet-performance).