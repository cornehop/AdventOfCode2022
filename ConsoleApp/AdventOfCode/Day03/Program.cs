using AdventOfCode.Day02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day03
{
    public static class Program
    {
        public static Task Main()
        {
            var lines = File.ReadLines(@"Day03/Input.txt");
            var totalPriority = GetTotalPriority(lines.ToArray());

            Console.WriteLine($"The sum of all priorities is {totalPriority}");

            var totalPriority2 = GetTotalPriority2(lines.ToArray());

            Console.WriteLine($"The sum of the group priorities is {totalPriority2}");

            return Task.CompletedTask;
        }

        #region part1

        public static int GetTotalPriority(string[] input)
        {
            var totalPriority = 0;

            foreach (var line in input)
            {
                totalPriority += GetPriorityForRucksack(line);
            }

            return totalPriority;
        }

        public static int GetPriorityForRucksack(string line)
        {
            var character = GetItemInBothCompartments(line);
            return GetPriorityForCharacter(character);
        }

        public static char GetItemInBothCompartments(string line)
        {
            var firstCompartment = line[..(line.Length / 2)];
            var secondCompartment = line.Substring(line.Length / 2, line.Length / 2);

            return firstCompartment.ToCharArray().First(charac => secondCompartment.ToCharArray().Contains(charac));
        }

        #endregion

        #region part2

        public static int GetTotalPriority2(string[] input)
        {
            var totalPriority = 0;

            var skip = 0;
            while (skip < input.Length)
            {
                var items = input.Skip(skip).Take(3).ToArray();
                var letter = GetGroupLetter(items);
                totalPriority += GetPriorityForCharacter(letter);
                
                skip += 3;
            }

            return totalPriority;
        }

        public static char GetGroupLetter(string[] lines)
        {
            var line1 = lines[0].ToCharArray();
            var line2 = lines[1].ToCharArray();
            var line3 = lines[2].ToCharArray();
            
            return line1.First(charac => line2.Contains(charac) && line3.Contains(charac));
        }

        #endregion

        public static int GetPriorityForCharacter(char character)
        {
            return char.IsUpper(character) ? character - 38 : character - 96;
        }
    }
}
