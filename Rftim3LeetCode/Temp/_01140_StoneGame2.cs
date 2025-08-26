namespace Rftim3LeetCode.Temp
{
    public class _01140_StoneGame2
    {
        /// <summary>
        /// Alice and Bob continue their games with piles of stones.  
        /// There are a number of piles arranged in a row, and each pile has a positive integer number of stones piles[i].  
        /// The objective of the game is to end with the most stones. 
        /// Alice and Bob take turns, with Alice starting first.Initially, M = 1.
        /// On each player's turn, that player can take all the stones in the first X remaining piles, where 1 <= X <= 2M.  
        /// Then, we set M = max(M, X).
        /// The game continues until all the stones have been taken.
        /// Assuming Alice and Bob play optimally, return the maximum number of stones Alice can get.
        /// </summary>
        public _01140_StoneGame2()
        {
            Console.WriteLine(StoneGameII([2, 7, 9, 4, 4]));
            Console.WriteLine(StoneGameII([1, 2, 3, 4, 5, 100]));
        }

        private static int StoneGameII(int[] piles)
        {
            int n = piles.Length;
            int[][][] dp = new int[2][][];
            for (int i = 0; i < 2; i++)
            {
                dp[i] = new int[n + 1][];
                for (int j = 0; j < n + 1; j++)
                {
                    dp[i][j] = new int[n + 1];
                }
            }

            for (int p = 0; p < 2; p++)
            {
                for (int i = 0; i <= n; i++)
                {
                    for (int m = 0; m <= n; m++)
                    {
                        dp[p][i][m] = -1;
                    }
                }
            }

            return Rec(piles, dp, 0, 0, 1);
        }

        private static int Rec(int[] piles, int[][][] dp, int p, int i, int m)
        {
            if (i == piles.Length) return 0;

            if (dp[p][i][m] != -1) return dp[p][i][m];

            int res = p == 1 ? 1000000 : -1, s = 0;
            for (int x = 1; x <= Math.Min(2 * m, piles.Length - i); x++)
            {
                s += piles[i + x - 1];
                if (p == 0) res = Math.Max(res, s + Rec(piles, dp, 1, i + x, Math.Max(m, x)));
                else res = Math.Min(res, Rec(piles, dp, 0, i + x, Math.Max(m, x)));
            }

            return dp[p][i][m] = res;
        }

        private static int StoneGameII0(int[] piles)
        {
            int[,] dp = new int[piles.Length, piles.Length];
            for (int i = piles.Length - 2; i >= 0; i--)
            {
                piles[i] += piles[i + 1];
            }

            return StoneGameIIUntil(piles, dp, 0, 1);
        }

        private static int StoneGameIIUntil(int[] pilesSuffixSum, int[,] dp, int idx, int M)
        {
            int max_stones = 0, moves_possible = Math.Min(pilesSuffixSum.Length, 2 * M + idx);

            if (moves_possible >= pilesSuffixSum.Length) return pilesSuffixSum[idx];

            if (dp[idx, M] != 0) return dp[idx, M];

            for (int i = idx; i < moves_possible; i++)
            {
                max_stones = Math.Max(max_stones, pilesSuffixSum[idx] - StoneGameIIUntil(pilesSuffixSum, dp, i + 1, Math.Max(i - idx + 1, M)));
            }

            dp[idx, M] = max_stones;

            return dp[idx, M];
        }
    }
}
