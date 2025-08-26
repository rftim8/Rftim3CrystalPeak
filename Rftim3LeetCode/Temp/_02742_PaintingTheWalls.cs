namespace Rftim3LeetCode.Temp
{
    public class _02742_PaintingTheWalls
    {
        /// <summary>
        /// You are given two 0-indexed integer arrays, cost and time, of size n representing the costs and the time taken to paint 
        /// n different walls respectively. 
        /// There are two painters available:
        /// A paid painter that paints the ith wall in time[i] units of time and takes cost[i] units of money.
        /// A free painter that paints any wall in 1 unit of time at a cost of 0. But the free painter can only be used if 
        /// the paid painter is already occupied.
        /// Return the minimum amount of money required to paint the n walls.
        /// </summary>
        public _02742_PaintingTheWalls()
        {
            Console.WriteLine(PaintWalls([1, 2, 3, 2], [1, 2, 3, 2]));
            Console.WriteLine(PaintWalls([2, 3, 4, 2], [1, 1, 1, 1]));
        }

        // Bottom-Up DP
        private static int PaintWalls(int[] cost, int[] time)
        {
            int n = cost.Length;
            int[][] dp = new int[n + 1][];
            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = new int[n + 1];
            }

            for (int i = 1; i <= n; i++)
            {
                dp[n][i] = (int)1e9;
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int remain = 1; remain <= n; remain++)
                {
                    int paint = cost[i] + dp[i + 1][Math.Max(0, remain - 1 - time[i])];
                    int dontPaint = dp[i + 1][remain];
                    dp[i][remain] = Math.Min(paint, dontPaint);
                }
            }

            return dp[0][n];
        }

        // Bottom-Up DP space optimized
        private static int PaintWalls0(int[] cost, int[] time)
        {
            int n = cost.Length;
            int[] dp = new int[n + 1];
            int[] prevDp = new int[n + 1];
            Array.Fill(prevDp, (int)1e9);
            prevDp[0] = 0;

            for (int i = n - 1; i >= 0; i--)
            {
                dp = new int[n + 1];
                for (int remain = 1; remain <= n; remain++)
                {
                    int paint = cost[i] + prevDp[Math.Max(0, remain - 1 - time[i])];
                    int dontPaint = prevDp[remain];
                    dp[remain] = Math.Min(paint, dontPaint);
                }

                prevDp = dp;
            }

            return dp[n];
        }

        // Top-Down DP
        private static int[][]? memo;
        private static int n;

        private static int PaintWalls1(int[] cost, int[] time)
        {
            n = cost.Length;
            memo = new int[n][];
            for (int i = 0; i < n; i++)
            {
                memo[i] = new int[n + 1];
            }

            return Dp(0, n, cost, time);
        }

        private static int Dp(int i, int remain, int[] cost, int[] time)
        {
            if (remain <= 0) return 0;

            if (i == n) return (int)1e9;

            if (memo![i][remain] != 0) return memo[i][remain];

            int paint = cost[i] + Dp(i + 1, remain - 1 - time[i], cost, time);
            int dontPaint = Dp(i + 1, remain, cost, time);
            memo[i][remain] = Math.Min(paint, dontPaint);

            return memo[i][remain];
        }
    }
}
