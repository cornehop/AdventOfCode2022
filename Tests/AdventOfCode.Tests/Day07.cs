using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day07
    {
        private readonly string[] _input = new string[]
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k"
        };

        [TestMethod]
        public void Day07_GetDirectoriesFromInput_GeneratesTheCorrectDirectories()
        {
            // Act
            var result = AdventOfCode.Day07.Program.GetDirectoriesFromInput(_input);

            // Assert
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        [DataRow(100000, 95437)]
        public void Day07_GetSumForDirectories_ReturnsCorrectSum(int maxSize, int expectedResult)
        {
            // Arrange
            var directories = AdventOfCode.Day07.Program.GetDirectoriesFromInput(_input);

            // Act
            var result = AdventOfCode.Day07.Program.GetSumForDirectories(directories, maxSize);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Day07_GetDirectoryToCleanUp_ReturnsCorrectValue()
        {
            // Arrange
            var directories = AdventOfCode.Day07.Program.GetDirectoriesFromInput(_input);

            // Act
            var result = AdventOfCode.Day07.Program.GetDirectoryToCleanUp(directories);

            // Assert
            Assert.AreEqual(24933642, result);
        }
    }
}
