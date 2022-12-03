using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day03
    {
        private readonly string[] _input = new string[]
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw",
        };

        [TestMethod]
        [DataRow("vJrwpWtwJgWrhcsFMMfFFhFp", 16)]
        [DataRow("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 38)]
        [DataRow("PmmdzqPrVvPwwTWBwg", 42)]
        [DataRow("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 22)]
        [DataRow("ttgJtRGJQctTZtZT", 20)]
        [DataRow("CrZsJsPPZsGzwwsLwLmpwMDw", 19)]
        public void Day03_GetValueForString_ReturnsCorrectValue(string line, int expectedResult)
        {
            // Act
            var result = AdventOfCode.Day03.Program.GetPriorityForRucksack(line);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Day03_GetTotalPriority_ReturnsCorrectValue()
        {
            // Act
            var expectedResult = 157;
            var result = AdventOfCode.Day03.Program.GetTotalPriority(_input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow('a', 1)]
        [DataRow('b', 2)]
        [DataRow('z', 26)]
        [DataRow('A', 27)]
        [DataRow('B', 28)]
        [DataRow('Z', 52)]
        public void Day03_GetPriorityForCharacter_ReturnsCorrectValue(char character, int expectedValue)
        {
            // Act
            var result = AdventOfCode.Day03.Program.GetPriorityForCharacter(character);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        [DataRow("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
        [DataRow("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
        [DataRow("PmmdzqPrVvPwwTWBwg", 'P')]
        [DataRow("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
        [DataRow("ttgJtRGJQctTZtZT", 't')]
        [DataRow("CrZsJsPPZsGzwwsLwLmpwMDw", 's')]
        public void Day03_GetItemInBothCompartments_ReturnsCorrectCharacter(string line, char expectedResult)
        {
            // Act
            var result = AdventOfCode.Day03.Program.GetItemInBothCompartments(line);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg", 'r')]
        [DataRow("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw", 'Z')]
        public void Day03_GetGroupLetter_ReturnsCorrectLetter(string line1, string line2, string line3, char expectedLetter)
        {
            // Act
            var result = AdventOfCode.Day03.Program.GetGroupLetter(new string[] { line1, line2, line3 });

            // Asset
            Assert.AreEqual(expectedLetter, result);
        }

        [TestMethod]
        public void Day03_GetTotalPriority2_ReturnsCorrectValue()
        {
            // Act
            var expectedResult = 70;
            var result = AdventOfCode.Day03.Program.GetTotalPriority2(_input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
