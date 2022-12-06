using AdventOfCode.Day05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day06
{
    public static class Program
    {
        public static Task Main()
        {
            var input = File.ReadAllText(@"Day06/input.txt");
            Console.WriteLine($"The end index of the starting marker is: {GetMarkerIndex(input, 4)}");
            Console.WriteLine($"The end index of the message marker is: {GetMarkerIndex(input, 14)}");
            return Task.CompletedTask;
        }

        public static int GetMarkerIndex(string input, int requiredDistinctCharacters)
        {
            var charArray = input.ToCharArray();
            
            for (var i = requiredDistinctCharacters; i < charArray.Length; i++)
            {
                var marker = charArray.Skip(i - requiredDistinctCharacters).Take(requiredDistinctCharacters).ToArray();
                if (AllCharsAreUnique(marker))
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool AllCharsAreUnique(char[] marker)
        {
            return marker.Distinct().Count() == marker.Length;
        }
    }
}
