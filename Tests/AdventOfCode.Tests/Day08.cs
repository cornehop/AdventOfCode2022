using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day08
    {
        private readonly string[] _input =
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390",
        };

        [TestMethod]
        public void Day08_CreateVerticalCharArrays_CreatesArrays()
        {
            // Arrange
            var expectedArray1 = new List<int> { 3, 2, 6, 3, 3 };
            var expectedArray2 = new List<int> { 0, 5, 5, 3, 5 };
            var expectedArray3 = new List<int> { 3, 5, 3, 5, 3 };
            var expectedArray4 = new List<int> { 7, 1, 3, 4, 9 };
            var expectedArray5 = new List<int> { 3, 2, 2, 9, 0 };

            // Act
            var result = AdventOfCode.Day08.Program.CreateVerticalCharArrays(_input);

            // Assert
            Assert.AreEqual(5, result.Count);
            
            Assert.AreEqual(expectedArray1[0], result[0][0]);
            Assert.AreEqual(expectedArray1[1], result[0][1]);
            Assert.AreEqual(expectedArray1[2], result[0][2]);
            Assert.AreEqual(expectedArray1[3], result[0][3]);
            Assert.AreEqual(expectedArray1[4], result[0][4]);

            Assert.AreEqual(expectedArray2[0], result[1][0]);
            Assert.AreEqual(expectedArray2[1], result[1][1]);
            Assert.AreEqual(expectedArray2[2], result[1][2]);
            Assert.AreEqual(expectedArray2[3], result[1][3]);
            Assert.AreEqual(expectedArray2[4], result[1][4]);

            Assert.AreEqual(expectedArray3[0], result[2][0]);
            Assert.AreEqual(expectedArray3[1], result[2][1]);
            Assert.AreEqual(expectedArray3[2], result[2][2]);
            Assert.AreEqual(expectedArray3[3], result[2][3]);
            Assert.AreEqual(expectedArray3[4], result[2][4]);

            Assert.AreEqual(expectedArray4[0], result[3][0]);
            Assert.AreEqual(expectedArray4[1], result[3][1]);
            Assert.AreEqual(expectedArray4[2], result[3][2]);
            Assert.AreEqual(expectedArray4[3], result[3][3]);
            Assert.AreEqual(expectedArray4[4], result[3][4]);

            Assert.AreEqual(expectedArray5[0], result[4][0]);
            Assert.AreEqual(expectedArray5[1], result[4][1]);
            Assert.AreEqual(expectedArray5[2], result[4][2]);
            Assert.AreEqual(expectedArray5[3], result[4][3]);
            Assert.AreEqual(expectedArray5[4], result[4][4]);
        }

        [TestMethod]
        [DataRow("25512", 1, 4)]
        [DataRow("65332", 2, 4)]
        [DataRow("33549", 3, 3)]
        public void Day08_TreesAreVisible_ReturnsCorrectAmount(string line, int verticalIndex, int expectedResult)
        {
            // Arrange 
            var verticalLines = AdventOfCode.Day08.Program.CreateVerticalCharArrays(_input);

            // Act
            var result = AdventOfCode.Day08.Program.TreesAreVisible(line, verticalIndex, verticalLines);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Day08_GetAmountOfVisibleTrees_ReturnsCorrectAmount()
        {
            // Arrange
            var verticalLines = AdventOfCode.Day08.Program.CreateVerticalCharArrays(_input);

            // Act
            var result = AdventOfCode.Day08.Program.GetAmountOfVisibleTrees(verticalLines, _input);

            // Assert
            Assert.AreEqual(21, result);
        }

        [TestMethod]
        [DataRow(new int[] { 5, 2 }, 5, 1)]
        [DataRow(new int[] { 1, 2 }, 5, 2)]
        [DataRow(new int[] { 3 }, 5, 1)]
        [DataRow(new int[] { 3, 5, 3 }, 5, 2)]
        [DataRow(new int[] { 3, 5, 3 }, 5, 2)]
        [DataRow(new int[] { 3, 3 }, 5, 2)]
        [DataRow(new int[] { 3 }, 5, 1)]
        [DataRow(new int[] { 4, 9 }, 5, 2)]
        public void Day08_GetVisibleTrees_ReturnsRightValue(int[] input, int value, int expectedResult)
        {
            // Act
            var result = AdventOfCode.Day08.Program.GetVisibleTrees(input, value);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Day08_GetHighestScenicView_ReturnsCorrectValue()
        {
            // Arrange
            var verticalLines = AdventOfCode.Day08.Program.CreateVerticalCharArrays(_input);

            // Act
            var result = AdventOfCode.Day08.Program.GetHighestScenicView(verticalLines, _input);

            // Assert
            Assert.AreEqual(8, result);
        }
    }
}
