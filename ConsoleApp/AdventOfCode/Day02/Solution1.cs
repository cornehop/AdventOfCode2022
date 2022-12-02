using static AdventOfCode.Day02.Program;

namespace AdventOfCode.Day02
{
    public static class Solution1
    {
        public static int PlayGame(string[] input)
        {
            var totalScore = 0;

            foreach (var line in input)
            {
                var plays = line.Split(' ');
                var opponent = ConvertLetterToPlay(plays[0]);
                var response = ConvertLetterToPlay(plays[1]);
                totalScore += PlayRound(opponent, response);
            }

            return totalScore;
        }

        public static int PlayRound(Play opponent, Play response)
        {
            var score = 0;

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

            score += GetResult(opponent, response);

            return score;
        }

        private static int GetResult(Play opponent, Play response)
        {
            if (opponent.Equals(response))
            {
                return 3; // Draw
            }

            switch (opponent)
            {
                case Play.Rock:
                    return response == Play.Paper ? 6 : 0;
                case Play.Paper:
                    return response == Play.Scissors ? 6 : 0;
                case Play.Scissors:
                    return response == Play.Rock ? 6 : 0;
                default:
                    return 0;
            }
        }

        public static Play ConvertLetterToPlay(string letter)
        {
            switch (letter)
            {
                case "A":
                case "X":
                    return Play.Rock;
                case "B":
                case "Y":
                    return Play.Paper;
                case "C":
                case "Z":
                    return Play.Scissors;
                default:
                    return Play.Unknown;
            }
        }
    }
}
