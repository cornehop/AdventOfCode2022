namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day01
    {
        private readonly string[] _input = new string[]
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000",
            "",
        };

        [TestMethod]
        public void Day01_GetResult_GivesCorrectCalorieCount()
        {
            // Act
            var result = AdventOfCode.Day01.Program.GetResult(_input);

            // Assert
            Assert.AreEqual(result, 24000);
        }

        [TestMethod]
        public void Day01_GetSecondResult_GivesCorrectCalorieCount()
        {
            // Act
            var result = AdventOfCode.Day01.Program.GetSecondResult(_input);

            // Assert
            Assert.AreEqual(result, 45000);
        }
    }
}