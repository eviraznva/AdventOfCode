using BenchmarkDotNet.Attributes;
using System.Text;

namespace AdventOfCode.RucksackReorganization;

[MemoryDiagnoser]
public class RucksackReorganization
{

    [Benchmark]
    public int RucksackReorganizationPart_1()
    {
        var priorities = Enumerable.Range(0, 26 * 2).ToDictionary(x => x >= 26 ? (char?)(x - 26 + 'A') : (char?)(x + 'a'), x => ++x);

        using var stream = new StreamReader(AppContext.BaseDirectory + "/RucksackReorganizationInput.txt", Encoding.UTF8);

        int prioritiesSum = 0;

        while (!stream.EndOfStream)
        {
            var readLine = stream.ReadLine();

            string[] compartments = readLine.Insert(readLine.Length / 2, "|").Split("|", StringSplitOptions.RemoveEmptyEntries);

            foreach (var prioritie in priorities)
            {
                if (compartments[0].Contains((char)prioritie.Key) &&
                    compartments[1].Contains((char)prioritie.Key))
                {
                    prioritiesSum += prioritie.Value;
                    break;
                }
            }
        }

        return prioritiesSum;
    }

    [Benchmark]
    public int RucksackReorganizationPart_2()
    {
        var priorities = Enumerable.Range(0, 26 * 2).ToDictionary(x => x >= 26 ? (char?)(x - 26 + 'A') : (char?)(x + 'a'), x => ++x);

        var group = new List<string>();

        using var stream = new StreamReader(AppContext.BaseDirectory + "/RucksackReorganizationInput.txt", Encoding.UTF8);

        int prioritiesSum = 0;

        while (!stream.EndOfStream)
        {
            var readLine = stream.ReadLine();

            group.Add(readLine);

            if (group.Count == 3)
            {
                foreach (var prioritie in priorities)
                {
                    if (group[0].Contains((char)prioritie.Key) &&
                        group[1].Contains((char)prioritie.Key) &&
                        group[2].Contains((char)prioritie.Key))
                    {
                        prioritiesSum += prioritie.Value;
                        break;
                    }
                }

                group.Clear();
            }
        }

        return prioritiesSum;
    }
}
