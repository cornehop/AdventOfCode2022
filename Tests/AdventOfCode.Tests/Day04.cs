using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day04
    {
        private readonly string[] _input = new string[]
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8",
            "6-6,58-61",
        };

        [TestMethod]
        [DataRow("2-4", "2-3-4")]
        [DataRow("6-8", "6-7-8")]
        [DataRow("2-3", "2-3")]
        [DataRow("4-5", "4-5")]
        [DataRow("5-7", "5-6-7")]
        [DataRow("7-9", "7-8-9")]
        [DataRow("2-8", "2-3-4-5-6-7-8")]
        [DataRow("3-7", "3-4-5-6-7")]
        [DataRow("6-6", "6")]
        [DataRow("4-6", "4-5-6")]
        [DataRow("2-6", "2-3-4-5-6")]
        [DataRow("4-8", "4-5-6-7-8")]
        [DataRow("58-61", "58-59-60-61")]
        public void Day04_GetAllSectionsForElve_ReturnsCorrectValue(string input, string expectedResult)
        {
            // Act
            var result = AdventOfCode.Day04.Program.GetAllSectionsForElve(input);
            var stringifiedResult = string.Join('-', result);

            // Assert
            Assert.AreEqual(expectedResult, stringifiedResult);
        }

        [TestMethod]
        [DataRow("2-4,6-8", true, false)]
        [DataRow("2-3,4-5", true, false)]
        [DataRow("5-7,7-9", true, false)]
        [DataRow("2-8,3-7", true, true)]
        [DataRow("6-6,4-6", true, true)]
        [DataRow("2-6,4-8", true, false)]
        [DataRow("6-6,58-61", true, false)]
        [DataRow("11-13,11-13", true, true)]
        [DataRow("2-4,6-8", false, false)]
        [DataRow("2-3,4-5", false, false)]
        [DataRow("5-7,7-9", false, true)]
        [DataRow("2-8,3-7", false, true)]
        [DataRow("6-6,4-6", false, true)]
        [DataRow("2-6,4-8", false, true)]
        [DataRow("6-6,58-61", false, false)]
        [DataRow("11-13,11-13", false, true)]
        public void Day04_GetSectionsOverlap_ReturnsCorrectValue(string input, bool shouldFullyOverlap, bool expectedResult)
        {
            // Act
            var result = AdventOfCode.Day04.Program.GetSectionsOverlap(input, shouldFullyOverlap);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow(true, 2)]
        [DataRow(false, 4)]
        public void Day04_GetSectionOverlapCount_ReturnsCorrectValue(bool shouldFullyOverlap, int expectedResult)
        {
            // Act
            var result = AdventOfCode.Day04.Program.GetSectionOverlapCount(_input, shouldFullyOverlap);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}