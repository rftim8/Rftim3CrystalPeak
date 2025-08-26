namespace Rftim3LeetCode.Temp
{
    public class _00576_OutofBoundaryPaths
    {
        /// <summary>
        /// There is an m x n grid with a ball. The ball is initially at the position [startRow, startColumn]. 
        /// You are allowed to move the ball to one of the four adjacent cells in the grid (possibly out of the grid crossing the grid boundary). 
        /// You can apply at most maxMove moves to the ball.
        /// 
        /// Given the five integers m, n, maxMove, startRow, startColumn, return the number of paths to move the ball out of the grid boundary.
        /// Since the answer can be very large, return it modulo 109 + 7.
        /// </summary>
        public _00576_OutofBoundaryPaths()
        {
            Console.WriteLine(OutofBoundaryPaths0(2, 2, 2, 0, 0)); // 6
            Console.WriteLine(OutofBoundaryPaths0(1, 3, 3, 0, 1)); // 12
        }

        public static int OutofBoundaryPaths0(int a0, int a1, int a2, int a3, int a4) => RftOutofBoundaryPaths0(a0, a1, a2, a3, a4);

        // DP
        private static int RftOutofBoundaryPaths0(int m, int n, int N, int x, int y)
        {
            int M = 1000000000 + 7;
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
            }

            dp[x][y] = 1;
            int count = 0;

            for (int moves = 1; moves <= N; moves++)
            {
                int[][] temp = new int[m][];
                for (int i = 0; i < m; i++)
                {
                    temp[i] = new int[n];
                }

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == m - 1) count = (count + dp[i][j]) % M;
                        if (j == n - 1) count = (count + dp[i][j]) % M;
                        if (i == 0) count = (count + dp[i][j]) % M;
                        if (j == 0) count = (count + dp[i][j]) % M;
                        temp[i][j] = (
                            ((i > 0 ? dp[i - 1][j] : 0) + (i < m - 1 ? dp[i + 1][j] : 0)) % M +
                            ((j > 0 ? dp[i][j - 1] : 0) + (j < n - 1 ? dp[i][j + 1] : 0)) % M
                        ) % M;
                    }
                }
                dp = temp;
            }

            return count;
        }
    }
}
