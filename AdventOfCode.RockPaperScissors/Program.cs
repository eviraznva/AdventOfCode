using AdventOfCode.RockPaperScissors;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<RockPaperScissors>();
Console.WriteLine(new RockPaperScissors().RockPaperScissorsPart_1());
Console.WriteLine(new RockPaperScissors().RockPaperScissorsPart_2());