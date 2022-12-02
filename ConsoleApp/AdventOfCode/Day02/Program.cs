using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day02
{
    public static class Program
    {
        public static Task Main()
        {
            var lines = File.ReadLines(@"Day02/Input.txt");
            
            var firstScore = Solution1.PlayGame(lines.ToArray());

            Console.WriteLine($"The total score for the first solution is: {firstScore}");
            
            var secondScore = Solution2.PlayGame(lines.ToArray());
            
            Console.WriteLine($"The total score for the second solution is: {secondScore}");
            
            return Task.CompletedTask;
        }

        
    }
}
