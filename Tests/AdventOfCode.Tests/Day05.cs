using AdventOfCode.Day05;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day05
    {
        private readonly Dictionary<int, Stack<char>> _stacks = new Dictionary<int, Stack<char>>()
        {
            { 1, new Stack<char>(new char[]
                {
                    'Z', 'N'
                })
            },
            { 2, new Stack<char>(new char[]
                {
                    'M', 'C', 'D'
                })
            },
            { 3, new Stack<char>(new char[]
                {
                    'P'
                })
            }
        };

        [TestInitialize]
        public void Initialize()
        {
            var mockedStacks = new Mock<IStacks>();
            mockedStacks.Setup(s => s.GetStacks()).Returns(_stacks);

            AdventOfCode.Day05.Program.Initialize(mockedStacks.Object);
        }

        [TestMethod]
        [DataRow("move 1 from 2 to 1", 1, 2, 1)]
        [DataRow("move 3 from 1 to 3", 3, 1, 3)]
        [DataRow("move 2 from 2 to 1", 2, 2, 1)]
        [DataRow("move 1 from 1 to 2", 1, 1, 2)]
        [DataRow("move 4 from 9 to 2", 4, 9, 2)]
        public void Day05_GetMoveFromLine_ReturnsRightMove(string line, int amount, int from, int to)
        {
            // Act
            var result = AdventOfCode.Day05.Program.GetMoveFromLine(line);

            // Assert
            Assert.AreEqual(amount, result.Amount);
            Assert.AreEqual(from, result.From);
            Assert.AreEqual(to, result.To);
        }

        [TestMethod]
        public void Day05_MoveItemsOneByOne_MovesItemsToRightStack()
        {
            // Act 1
            AdventOfCode.Day05.Program.MoveItemsOneByOne("move 1 from 2 to 1");
            Assert.AreEqual('D', _stacks[1].First());
            Assert.AreEqual('C', _stacks[2].First());
            Assert.AreEqual('P', _stacks[3].First());

            // Act 2
            AdventOfCode.Day05.Program.MoveItemsOneByOne("move 3 from 1 to 3");
            Assert.AreEqual(0, _stacks[1].Count);
            Assert.AreEqual('C', _stacks[2].First());
            Assert.AreEqual('Z', _stacks[3].First());

            // Act 3
            AdventOfCode.Day05.Program.MoveItemsOneByOne("move 2 from 2 to 1");
            Assert.AreEqual('M', _stacks[1].First());
            Assert.AreEqual(0, _stacks[2].Count);
            Assert.AreEqual('Z', _stacks[3].First());

            // Act 4
            AdventOfCode.Day05.Program.MoveItemsOneByOne("move 1 from 1 to 2");
            Assert.AreEqual('C', _stacks[1].First());
            Assert.AreEqual('M', _stacks[2].First());
            Assert.AreEqual('Z', _stacks[3].First());
        }

        [TestMethod]
        public void Day05_MoveMultipleItems_MovesItemsToRightStack()
        {
            // Act 1
            AdventOfCode.Day05.Program.MoveMultipleItems("move 1 from 2 to 1");
            Assert.AreEqual('D', _stacks[1].First());
            Assert.AreEqual('C', _stacks[2].First());
            Assert.AreEqual('P', _stacks[3].First());

            // Act 2
            AdventOfCode.Day05.Program.MoveMultipleItems("move 3 from 1 to 3");
            Assert.AreEqual(0, _stacks[1].Count);
            Assert.AreEqual('C', _stacks[2].First());
            Assert.AreEqual('D', _stacks[3].First());

            // Act 3
            AdventOfCode.Day05.Program.MoveMultipleItems("move 2 from 2 to 1");
            Assert.AreEqual('C', _stacks[1].First());
            Assert.AreEqual(0, _stacks[2].Count);
            Assert.AreEqual('D', _stacks[3].First());

            // Act 4
            AdventOfCode.Day05.Program.MoveMultipleItems("move 1 from 1 to 2");
            Assert.AreEqual('M', _stacks[1].First());
            Assert.AreEqual('C', _stacks[2].First());
            Assert.AreEqual('D', _stacks[3].First());
        }

        [TestMethod]
        public void Day05_GetTopCrates_ReturnsRightValue()
        {
            // Act
            var result = AdventOfCode.Day05.Program.GetTopCrates();

            // Assert
            Assert.AreEqual("NDP", result);
        }
    }
}
