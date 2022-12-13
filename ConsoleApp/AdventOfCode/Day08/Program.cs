using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day08
{
    public static class Program
    {
        public static Task Main()
        {
            var input = File.ReadLines(@"Day08/input.txt");
            var verticalArrays = CreateVerticalCharArrays(input.ToArray());
            var amount = GetAmountOfVisibleTrees(verticalArrays, input.ToArray());

            Console.WriteLine($"The amount of visible trees is: {amount}");

            var scenicScore = GetHighestScenicView(verticalArrays, input.ToArray());
            Console.WriteLine($"The highest scenic view is {scenicScore}");

            return Task.CompletedTask;
        }

        #region part1
        public static int GetAmountOfVisibleTrees(Dictionary<int, List<int>> verticalLines, string[] horizontalLines)
        {
            var visibleTrees = 0;

            for (var lineIndex = 0; lineIndex < horizontalLines.Length; lineIndex++)
            {
                // First and last line are all visible
                if (lineIndex == 0 || lineIndex == horizontalLines.Length - 1)
                {
                    visibleTrees += horizontalLines[lineIndex].Length;
                    continue;
                }

                visibleTrees += TreesAreVisible(horizontalLines[lineIndex], lineIndex, verticalLines);
            }

            return visibleTrees;
        }

        public static int TreesAreVisible(string horizontalLine, int verticalIndex, Dictionary<int, List<int>> verticalLines)
        {
            var visibleTrees = 0;
            var numbers = horizontalLine.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();

            for (var horizontalIndex = 0; horizontalIndex < numbers.Length; horizontalIndex++)
            {
                // Outer trees are always visible
                if (horizontalIndex == 0 || horizontalIndex == numbers.Length - 1)
                {
                    visibleTrees++;
                    continue;
                }

                var value = numbers[horizontalIndex];
                var verticalLine = verticalLines[horizontalIndex];
                var left = numbers.Take(horizontalIndex).ToArray().Max();
                var right = numbers.Skip(horizontalIndex + 1).ToArray().Max();
                var top = verticalLine.Take(verticalIndex).ToArray().Max();
                var bottom = verticalLine.Skip(verticalIndex + 1).ToArray().Max();

                if (value > left || value > right || value > top || value > bottom)
                {
                    visibleTrees++;
                }
            }

            return visibleTrees;
        }
        #endregion

        #region part2

        public static int GetHighestScenicView(Dictionary<int, List<int>> verticalLines, string[] horizontalLines)
        {
            var scenicView = 0;

            for (var lineIndex = 0; lineIndex < horizontalLines.Length; lineIndex++)
            {
                var numbers = horizontalLines[lineIndex].ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();

                for (var horizontalIndex = 0; horizontalIndex < numbers.Length; horizontalIndex++)
                {
                    var value = numbers[horizontalIndex];
                    var verticalLine = verticalLines[horizontalIndex];

                    // Check left
                    var leftTrees = numbers.Take(horizontalIndex).Reverse().ToArray();
                    var leftScore = GetVisibleTrees(leftTrees, value);

                    // Check right
                    var rightTrees = numbers.Skip(horizontalIndex + 1).ToArray();
                    var rightScore = GetVisibleTrees(rightTrees, value);

                    // Check top
                    var upperTrees = verticalLine.Take(lineIndex).Reverse().ToArray();
                    var topScore = GetVisibleTrees(upperTrees, value);

                    // Check bottom
                    var bottomTrees = verticalLine.Skip(lineIndex + 1).ToArray();
                    var bottomScore = GetVisibleTrees(bottomTrees, value);

                    var totalScore = leftScore * rightScore * topScore * bottomScore;
                    
                    scenicView = totalScore > scenicView ? totalScore : scenicView;
                }

            }

            return scenicView;
        }

        public static int GetVisibleTrees(int[] trees, int value)
        {
            var visibleTrees = 0;

            for (var index = 0; index < trees.Length; index++)
            {
                if (trees[index] >= value)
                {
                    visibleTrees++;
                    break;
                }

                visibleTrees++;
            }

            return visibleTrees;
        }

        #endregion

        public static Dictionary<int, List<int>> CreateVerticalCharArrays(string[] lines)
        {
            var verticalChars = new Dictionary<int, List<int>>();

            var length = lines[0].Length;
            for (var i = 0; i < length; i++)
            {
                verticalChars.Add(i, new List<int>());
            }

            foreach (var line in lines)
            {
                var chars = line.ToCharArray();
                for (var i = 0; i < chars.Length; i++)
                {
                    verticalChars[i].Add(int.Parse(chars[i].ToString()));
                }
            }

            return verticalChars;
        }
    }
}
