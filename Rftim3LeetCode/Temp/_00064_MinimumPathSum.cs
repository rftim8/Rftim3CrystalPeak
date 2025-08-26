namespace Rftim3LeetCode.Temp
{
    public class _00064_MinimumPathSum
    {
        /// <summary>
        /// Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.
        ///  Note: You can only move either down or right at any point in time.
        /// </summary>
        public _00064_MinimumPathSum()
        {
            Console.WriteLine(MinPathSum(new int[][]
            {
                new int[] { 1,3,1 },
                new int[] { 1,5,1 },
                new int[] { 4,2,1 }
            }));
        }

        private static int MinPathSum(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            int[][] dp = new int[n][];

            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[m];
                Array.Fill(dp[i], 0);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dp[i][j] = grid[i][j];
                    if (i > 0 && j > 0) dp[i][j] += Math.Min(dp[i - 1][j], dp[i][j - 1]);
                    else if (i > 0) dp[i][j] += dp[i - 1][j];
                    else if (j > 0) dp[i][j] += dp[i][j - 1];
                }
            }

            return dp[^1][^1];
        }

        private static int MinPathSum0(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    switch (i)
                    {
                        case 0 when j == 0:
                            continue;
                        case 0:
                            grid[i][j] += grid[i][j - 1];
                            continue;
                    }

                    if (j == 0)
                    {
                        grid[i][j] += grid[i - 1][j];
                        continue;
                    }

                    grid[i][j] += Math.Min(grid[i][j - 1], grid[i - 1][j]);
                }
            }

            return grid[^1][grid[0].Length - 1];
        }
    }
}
