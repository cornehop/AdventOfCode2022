namespace AdventOfCode.Day02
{
    public static class Solution2
    {
        public static int PlayGame(string[] input)
        {
            var totalScore = 0;

            foreach (var line in input)
            {
                var plays = line.Split(' ');
                var opponent = Solution1.ConvertLetterToPlay(plays[0]);
                var requiredResult = ConvertLetterToRequiredResult(plays[1]);
                totalScore += PlayRound(opponent, requiredResult);
            }

            return totalScore;
        }

        public static int PlayRound(Play opponent, RequiredResult requiredResult)
        {
            var score = 0;

            var response = DeterminePlayForRequiredResult(opponent, requiredResult);
            switch (response)
            {
                case Play.Rock:
                    score += 1;
                    break;
                case Play.Paper:
                    score += 2;
                    break;
                case Play.Scissors:
                    score += 3;
                    break;
                default:
                    break;
            }

            score += (int)requiredResult;

            return score;
        }

        public static Play DeterminePlayForRequiredResult(Play opponent, RequiredResult requiredResult)
        {
            if (requiredResult == RequiredResult.Draw)
            {
                return opponent;
            }

            switch (opponent)
            {
                case Play.Rock:
                    return requiredResult == RequiredResult.Win ? Play.Paper : Play.Scissors;
                case Play.Paper:
                    return requiredResult == RequiredResult.Win ? Play.Scissors : Play.Rock;
                case Play.Scissors:
                    return requiredResult == RequiredResult.Win ? Play.Rock : Play.Paper;
                default:
                    return Play.Unknown;
            }
        }

        private static RequiredResult ConvertLetterToRequiredResult(string letter)
        {
            switch (letter)
            {
                case "X":
                    return RequiredResult.Lose;
                case "Y":
                    return RequiredResult.Draw;
                case "Z":
                    return RequiredResult.Win;
                default:
                    return RequiredResult.Unknown;
            }
        }
    }
}
