using BenchmarkDotNet.Attributes;
using System.Text;

[MemoryDiagnoser]
public class CalorieCounting
{

    [Benchmark]
    public (uint, uint) CalorieCountingResult()
    {
        using var stream = new StreamReader(AppContext.BaseDirectory + "/CalorieInput.txt", Encoding.UTF8);

        int index = 0;
        int prevIndex = -1;

        List<uint> calories = new List<uint>();

        while (!stream.EndOfStream)
        {
            var readLine = stream.ReadLine();

            if (!string.IsNullOrEmpty(readLine))
            {
                if (index == prevIndex)
                    calories[index] += uint.Parse(readLine);
                else
                {
                    calories.Add(uint.Parse(readLine));
                    prevIndex = index;
                }
            }
            else
                index++;
        }

        calories.Sort();
        calories.Reverse();

        return (calories[0], calories[0] + calories[1] + calories[2]);
    }
}