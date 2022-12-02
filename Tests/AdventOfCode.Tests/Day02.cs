using AdventOfCode.Day02;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day02
    {
        private readonly string[] _input = new string[]
        {
            "A Y",
            "B X",
            "C Z"
        };

        [TestMethod]
        [DataRow(Play.Rock, Play.Paper, 8)]
        [DataRow(Play.Paper, Play.Rock, 1)]
        [DataRow(Play.Scissors, Play.Scissors, 6)]
        public void Day02Solution1_PlayRound_GivesTheCorrectScore(Play opponent, Play response, int expectedResult)
        {
            // Act
            var result = Solution1.PlayRound(opponent, response);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Day02Solution1_PlayGame_GivesTheCorrectScore()
        {
            // Act
            var result = Solution1.PlayGame(_input);

            // Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        [DataRow(Play.Rock, RequiredResult.Draw, 4)]
        [DataRow(Play.Paper, RequiredResult.Lose, 1)]
        [DataRow(Play.Scissors, RequiredResult.Win, 7)]
        public void Day02Solution2_PlayRound_GivesTheCorrectScore(Play opponent, RequiredResult requiredResult, int expectedResult)
        {
            // Act
            var result = Solution2.PlayRound(opponent, requiredResult);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Day02Solution2_PlayGame_GivesTheCorrectScore()
        {
            // Act
            var result = Solution2.PlayGame(_input);

            // Assert
            Assert.AreEqual(12, result);
        }
    }
}
