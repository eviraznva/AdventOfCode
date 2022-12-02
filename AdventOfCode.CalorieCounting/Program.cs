using BenchmarkDotNet.Running;

BenchmarkRunner.Run<CalorieCounting>();
var result = new CalorieCounting().CalorieCountingResult();
Console.WriteLine($"Part 1: {result.Item1}\nPart 2: {result.Item2}");