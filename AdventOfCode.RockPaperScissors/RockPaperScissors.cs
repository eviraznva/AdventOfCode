using BenchmarkDotNet.Attributes;
using System.Text;

namespace AdventOfCode.RockPaperScissors;

[MemoryDiagnoser]
public class RockPaperScissors
{

    private struct RockPaperScissorsRules
    {
        public Func<char, ushort> ReturnPoints = (key) => key switch
        {
            'X' => 1,
            'Y' => 2,
            'Z' => 3,
            _ => 0
        };

        public Func<char, char, bool> WonOrLose = (key, condition) => key switch
        {
            'A' => condition == 'Y',
            'B' => condition == 'Z',
            'C' => condition == 'X',
            'Z' => condition == 'A',
            'X' => condition == 'B',
            'Y' => condition == 'C',
            _ => false
        };

        public Func<char, char, char> ReturnIndicatedSchape = (key, state) => key switch
        {
            'A' => state switch
            {
                'Z' => 'Y',
                'X' => 'Z',
                _ => 'X'
            },

            'B' => state switch
            {
                'Z' => 'Z',
                'X' => 'X',
                _ => 'Y'
            },

            'C' => state switch
            {
                'Z' => 'X',
                'X' => 'Y',
                _ => 'Z'
            },

            _ => '0'
        };

        public RockPaperScissorsRules() { }
    }

    private readonly RockPaperScissorsRules _rules = new();

    [Benchmark]
    public uint RockPaperScissorsPart_1()
    {
        using var stream = new StreamReader(AppContext.BaseDirectory + "/RockPaperScissorsInput.txt", Encoding.UTF8);

        uint points = 0;

        while (!stream.EndOfStream)
        {
            var readLine = stream.ReadLine();

            if (_rules.WonOrLose(readLine[0], readLine[2]))
                points += 6;
            else if (_rules.WonOrLose(readLine[2], readLine[0]))
                points += 0;
            else
                points += 3;

            points += _rules.ReturnPoints(readLine[2]);
        }

        return points;
    }

    [Benchmark]
    public uint RockPaperScissorsPart_2()
    {
        using var stream = new StreamReader(AppContext.BaseDirectory + "/RockPaperScissorsInput.txt", Encoding.UTF8);

        uint points = 0;

        while (!stream.EndOfStream)
        {
            var readLine = stream.ReadLine();

            var indicated = _rules.ReturnIndicatedSchape(readLine[0], readLine[2]);

            if (_rules.WonOrLose(readLine[0], indicated))
                points += 6;
            else if (_rules.WonOrLose(indicated, readLine[0]))
                points += 0;
            else
                points += 3;

            points += _rules.ReturnPoints(indicated);
        }

        return points;
    }
}
