using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day06
    {
        [TestMethod]
        [DataRow("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 4, 7)]
        [DataRow("bvwbjplbgvbhsrlpgdmjqwftvncz", 4, 5)]
        [DataRow("nppdvjthqldpwncqszvftbrmjlhg", 4, 6)]
        [DataRow("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4, 10)]
        [DataRow("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4, 11)]
        [DataRow("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14, 19)]
        [DataRow("bvwbjplbgvbhsrlpgdmjqwftvncz", 14, 23)]
        [DataRow("nppdvjthqldpwncqszvftbrmjlhg", 14, 23)]
        [DataRow("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 14, 29)]
        [DataRow("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 14, 26)]
        public void Day06_GetMarkerIndex_ReturnsCorrectIndex(string input, int requiredDistinctCharacters, int expectedResult)
        {
            // Act
            var result = AdventOfCode.Day06.Program.GetMarkerIndex(input, requiredDistinctCharacters);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
