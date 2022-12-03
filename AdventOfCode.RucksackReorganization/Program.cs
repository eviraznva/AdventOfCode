using AdventOfCode.RucksackReorganization;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<RucksackReorganization>();
Console.WriteLine(new RucksackReorganization().RucksackReorganizationPart_1());
Console.WriteLine(new RucksackReorganization().RucksackReorganizationPart_2());