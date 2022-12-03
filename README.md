``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19045.2251)
AMD Ryzen Threadripper 1950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|                       Method |     Mean |   Error |  StdDev |    Gen0 | Allocated |
|-----------------------------:|---------:|--------:|--------:|--------:|----------:|
| CalorieCountingResult        | 159.0 μs | 1.06 μs | 0.99 μs | 18.3105 |  74.84 KB |
| RockPaperScissorsPart_1      | 171.0 us | 3.39 us | 3.77 us | 21.4844 |  88.14 KB |
| RockPaperScissorsPart_2      | 198.4 us | 1.54 us | 1.44 us | 21.4844 |  88.14 KB |
| RucksackReorganizationPart_1 | 364.6 μs | 6.96 μs | 8.55 μs | 26.8555 | 111.59 KB |
| RucksackReorganizationPart_2 | 181.9 μs | 1.06 μs | 1.00 μs |  9.7656 |  40.42 KB |