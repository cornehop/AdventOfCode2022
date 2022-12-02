namespace AdventOfCode.Day01
{
    /// <summary>
    /// Calorie Counting: https://adventofcode.com/2022/day/1
    /// </summary>
    public static class Program
    {
        public static Task Main()
        {
            var lines = File.ReadLines(@"Day01/Input.txt");
            
            var result = GetResult(lines.ToArray());
            Console.WriteLine($"The elf with {result} calories carries the most!");

            var secondResult = GetSecondResult(lines.ToArray());
            Console.WriteLine($"The three elves carrying the most have {secondResult} calories combined!");

            return Task.CompletedTask;
        }

        public static int GetResult(string[] input)
        {
            var highestValue = -1;
            var calories = 0;

            foreach (string line in input)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    calories += int.Parse(line);
                    continue;
                }

                if (calories > highestValue)
                {
                    highestValue = calories;
                }
                
                calories = 0;
            }

            return highestValue;
        }

        public static int GetSecondResult(string[] input)
        {
            var values = new List<int>();
            var calories = 0;

            foreach (string line in input)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    calories += int.Parse(line);
                    continue;
                }

                values.Add(calories);
                calories = 0;
            }

            var totalValue = 0;
            var sortedResult = values.OrderByDescending(x => x).ToArray();
            for (var i = 0; i < 3; i++)
            {
                totalValue += sortedResult[i];
            }

            return totalValue;
        }
    }
}
