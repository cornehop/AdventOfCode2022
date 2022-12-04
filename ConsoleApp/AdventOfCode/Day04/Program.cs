using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day04
{
    public static class Program
    {
        public static Task Main()
        {
            var lines = File.ReadLines(@"Day04/Input.txt");
            var count = GetSectionOverlapCount(lines.ToArray(), true);
            Console.WriteLine($"The amount of pairs that fully overlap is {count}!");

            var count2 = GetSectionOverlapCount(lines.ToArray(), false);
            Console.WriteLine($"The amount of pairs that partially overlap is {count2}!");

            return Task.CompletedTask;
        }

        public static int GetSectionOverlapCount(string[] lines, bool shouldFullyOverlap)
        {
            var count = 0;

            foreach (var line in lines)
            {
                if (GetSectionsOverlap(line, shouldFullyOverlap))
                {
                    count++;
                }
            }

            return count;
        }

        public static bool GetSectionsOverlap(string input, bool shouldOverlapFully)
        {
            var splittedInput = input.Split(',');
            var firstSections = GetAllSectionsForElve(splittedInput[0]);
            var secondSections = GetAllSectionsForElve(splittedInput[1]);

            if (firstSections.Equals(secondSections)) return true;

            var overlap = firstSections.Intersect(secondSections).ToArray();

            if (shouldOverlapFully)
            {
                return overlap.Length.Equals(firstSections.Length) || overlap.Length.Equals(secondSections.Length);
            }

            return overlap.Any();
        }

        public static int[] GetAllSectionsForElve(string sections)
        {
            var numbers = sections.Split("-");
            var length = int.Parse(numbers[1]) - int.Parse(numbers[0]) + 1;
            return Enumerable.Range(int.Parse(numbers[0]), length).ToArray();
        }
    }
}
