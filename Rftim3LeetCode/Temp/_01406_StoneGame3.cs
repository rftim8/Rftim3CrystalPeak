namespace Rftim3LeetCode.Temp
{
    public class _01406_StoneGame3
    {
        /// <summary>
        /// Alice and Bob continue their games with piles of stones. 
        /// There are several stones arranged in a row, and each stone has an associated value which is an integer given in the array stoneValue.
        /// Alice and Bob take turns, with Alice starting first.On each player's turn, that player can take 1, 2, or 3 stones from the first remaining stones in the row.
        /// The score of each player is the sum of the values of the stones taken.
        /// The score of each player is 0 initially.
        /// The objective of the game is to end with the highest score, and the winner is the player with the highest score and there could be a tie. 
        /// The game continues until all the stones have been taken.
        /// Assume Alice and Bob play optimally.
        /// Return "Alice" if Alice will win, "Bob" if Bob will win, or "Tie" if they will end the game with the same score.
        /// </summary>
        public _01406_StoneGame3()
        {
            Console.WriteLine(StoneGameIII([1, 2, 3, 7]));
            Console.WriteLine(StoneGameIII([1, 2, 3, -9]));
            Console.WriteLine(StoneGameIII([1, 2, 3, 6]));
        }

        private static string StoneGameIII(int[] stoneValue)
        {
            int n = stoneValue.Length;
            int[] dp = new int[n + 1];

            for (int i = n - 1; i > -1; i--)
            {
                dp[i] = stoneValue[i] - dp[i + 1];

                if (i + 2 <= n) dp[i] = Math.Max(dp[i], stoneValue[i] + stoneValue[i + 1] - dp[i + 2]);
                if (i + 3 <= n) dp[i] = Math.Max(dp[i], stoneValue[i] + stoneValue[i + 1] + stoneValue[i + 2] - dp[i + 3]);
            }

            if (dp[0] > 0) return "Alice";
            if (dp[0] < 0) return "Bob";

            return "Tie";
        }

        private static string StoneGameIII0(int[] stoneValue)
        {
            int n = stoneValue.Length;
            int[] dp = new int[4];

            for (int i = n - 1; i > -1; i--)
            {
                dp[i % 4] = stoneValue[i] - dp[(i + 1) % 4];

                if (i + 2 <= n) dp[i % 4] = Math.Max(dp[i % 4], stoneValue[i] + stoneValue[i + 1] - dp[(i + 2) % 4]);
                if (i + 3 <= n) dp[i % 4] = Math.Max(dp[i % 4], stoneValue[i] + stoneValue[i + 1] + stoneValue[i + 2] - dp[(i + 3) % 4]);
            }

            if (dp[0] > 0) return "Alice";
            if (dp[0] < 0) return "Bob";

            return "Tie";
        }
    }
}
