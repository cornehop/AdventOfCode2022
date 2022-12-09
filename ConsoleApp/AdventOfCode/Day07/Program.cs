using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day07
{
    public static class Program
    {
        public static Task Main()
        {
            var input = File.ReadLines(@"Day07/input.txt");
            var directories = GetDirectoriesFromInput(input.ToArray());

            var sum = GetSumForDirectories(directories, 100000);
            Console.WriteLine($"The sum of sizes is: {sum}");

            var cleanupDirectory = GetDirectoryToCleanUp(directories);
            Console.WriteLine($"The size of the directory to cleanup is: {cleanupDirectory}");

            return Task.CompletedTask;
        }

        public static int GetDirectoryToCleanUp(List<Directory> directories)
        {
            var requiredSpaceForUpdate = 30000000;
            var availableSpace = 70000000 - directories.First(dir => dir.Name.Equals("/")).Size;
            var spaceNeeded = requiredSpaceForUpdate - availableSpace;

            var directory = directories.OrderBy(dir => dir.Size).Where(dir => dir.Size >= spaceNeeded).First();
            return directory.Size;
        }

        public static int GetSumForDirectories(List<Directory> directories, int maxSize)
        {
            var sum = 0;

            foreach (var directory in directories)
            {
                if (directory.Size <= maxSize)
                {
                    sum += directory.Size;
                }
            }

            return sum;
        }

        public static List<Directory> GetDirectoriesFromInput(string[] lines)
        {
            var directories = new List<Directory>();
            var breadCrumbs = new Stack<Directory>();

            foreach (var line in lines)
            {
                if (line.StartsWith("$ ls") || line.StartsWith("dir "))
                {
                    continue;
                }
                else if (line.Equals("$ cd /"))
                {
                    breadCrumbs.Clear();
                    breadCrumbs.Push(new Directory("/"));
                }
                else if (line.Equals("$ cd .."))
                {
                    var directory = breadCrumbs.Pop();
                    breadCrumbs.Peek().Size += directory.Size;
                    directories.Add(directory);
                }
                else if (line.StartsWith("$ cd"))
                {
                    breadCrumbs.Push(new Directory(line[5..]));
                }
                else
                {
                    var splittedLine = line.Split(' ');
                    breadCrumbs.Peek().Size += int.Parse(splittedLine[0]);
                }
            }

            while (breadCrumbs.Count > 0)
            {
                var directory = breadCrumbs.Pop();
                if (breadCrumbs.Count > 0)
                {
                    breadCrumbs.Peek().Size += directory.Size;
                }
                directories.Add(directory);
            }

            return directories;
        }
    }

    public record Directory(string Name)
    {
        public int Size { get; set;  }
    }
}
