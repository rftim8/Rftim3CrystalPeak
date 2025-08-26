namespace Rftim3LeetCode.Temp
{
    public class _02660_DetermineTheWinnerOfABowlingGame
    {
        /// <summary>
        /// You are given two 0-indexed integer arrays player1 and player2, that represent the number of pins that player 1 and player 2 hit in a bowling game, respectively.
        /// The bowling game consists of n turns, and the number of pins in each turn is exactly 10.
        /// Assume a player hit xi pins in the ith turn.The value of the ith turn for the player is:
        /// 2xi if the player hit 10 pins in any of the previous two turns.
        /// Otherwise, It is xi.
        /// The score of the player is the sum of the values of their n turns.
        /// Return
        /// 1 if the score of player 1 is more than the score of player 2,
        /// 2 if the score of player 2 is more than the score of player 1, and
        /// 0 in case of a draw.
        /// </summary>
        public _02660_DetermineTheWinnerOfABowlingGame()
        {
            Console.WriteLine(IsWinner([4, 10, 7, 9], [6, 5, 2, 3]));
            Console.WriteLine(IsWinner([3, 5, 7, 6], [8, 10, 10, 2]));
            Console.WriteLine(IsWinner([2, 3], [4, 1]));
            Console.WriteLine(IsWinner([9, 7, 10, 7], [10, 2, 4, 10]));
        }

        private static int IsWinner(int[] player1, int[] player2)
        {
            int diff = GetScore(player1) - GetScore(player2);

            return diff == 0 ? 0 : diff > 0 ? 1 : 2;
        }

        private static int GetScore(int[] hits)
        {
            int doubling = 0;
            int score = 0;

            foreach (int h in hits)
            {
                score += doubling-- > 0 ? 2 * h : h;

                if (h == 10) doubling = 2;
            }

            return score;
        }
    }
}
