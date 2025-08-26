namespace Rftim3LeetCode.Temp
{
    public class _00688_KnightProbabilityInChessboard
    {
        /// <summary>
        /// On an n x n chessboard, a knight starts at the cell (row, column) and attempts to make exactly k moves. 
        /// The rows and columns are 0-indexed, so the top-left cell is (0, 0), and the bottom-right cell is (n - 1, n - 1).
        /// A chess knight has eight possible moves it can make, as illustrated below.
        /// Each move is two cells in a cardinal direction, then one cell in an orthogonal direction.
        /// Each time the knight is to move, it chooses one of eight possible moves uniformly at random (even if the piece would go off the chessboard) and moves there.
        /// The knight continues moving until it has made exactly k moves or has moved off the chessboard.
        /// Return the probability that the knight remains on the board after it has stopped moving.
        /// </summary>
        public _00688_KnightProbabilityInChessboard()
        {
            Console.WriteLine(KnightProbability(3, 2, 0, 0));
            Console.WriteLine(KnightProbability(1, 0, 0, 0));
        }

        // Bottom-Up DP
        private static double KnightProbability(int n, int k, int row, int column)
        {
            int[][] directions = [
                [1, 2],
                [1, -2],
                [-1, 2],
                [-1, -2],
                [2, 1],
                [2, -1],
                [-2, 1],
                [-2, -1]
            ];

            double[][][] dp = new double[k + 1][][];
            for (int i = 0; i < k + 1; i++)
            {
                dp[i] = new double[n][];
                for (int j = 0; j < n; j++)
                {
                    dp[i][j] = new double[n];
                    Array.Fill(dp[i][j], 0);
                }
            }

            dp[0][row][column] = 1.0;

            for (int moves = 1; moves <= k; moves++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        foreach (int[] direction in directions)
                        {
                            int prevI = i - direction[0];
                            int prevJ = j - direction[1];
                            if (prevI >= 0 && prevI < n && prevJ >= 0 && prevJ < n) dp[moves][i][j] += dp[moves - 1][prevI][prevJ] / 8.0;
                        }
                    }
                }
            }

            double totalProbability = 0.0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    totalProbability += dp[k][i][j];
                }
            }

            return totalProbability;
        }

        // Bottom-Up DP Optimized Space
        private static double KnightProbability0(int n, int k, int row, int column)
        {
            int[][] directions = [
                [1, 2],
                [1, -2],
                [-1, 2],
                [-1, -2],
                [2, 1],
                [2, -1],
                [-2, 1],
                [-2, -1]
            ];

            double[][] prevDp = new double[n][];
            for (int i = 0; i < n; i++)
            {
                prevDp[i] = new double[n];
                Array.Fill(prevDp[i], 0);
            }

            double[][] currDp = new double[n][];
            for (int i = 0; i < n; i++)
            {
                currDp[i] = new double[n];
                Array.Fill(currDp[i], 0);
            }

            prevDp[row][column] = 1;

            for (int moves = 1; moves <= k; moves++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        currDp[i][j] = 0;

                        foreach (int[] direction in directions)
                        {
                            int prevI = i - direction[0];
                            int prevJ = j - direction[1];

                            if (prevI >= 0 && prevI < n && prevJ >= 0 && prevJ < n) currDp[i][j] += prevDp[prevI][prevJ] / 8;
                        }
                    }
                }

                (currDp, prevDp) = (prevDp, currDp);
            }

            double totalProbability = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    totalProbability += prevDp[i][j];
                }
            }

            return totalProbability;
        }

        // Top-Down DP Memoization
        private static readonly int[][] directions = [
            [1, 2],
            [1, -2],
            [-1, 2],
            [-1, -2],
            [2, 1],
            [2, -1],
            [-2, 1],
            [-2, -1]
        ];

        private static double KnightProbability1(int n, int k, int row, int column)
        {
            double[][][] dp = new double[k + 1][][];
            for (int i = 0; i < k + 1; i++)
            {
                dp[i] = new double[n][];
                for (int j = 0; j < n; j++)
                {
                    dp[i][j] = new double[n];
                    Array.Fill(dp[i][j], 0);
                }
            }

            foreach (double[][] layer in dp)
            {
                foreach (double[] rowArray in layer)
                {
                    Array.Fill(rowArray, -1);
                }
            }

            double totalProbability = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    totalProbability += CalculateDP(dp, k, i, j, n, row, column);
                }
            }

            return totalProbability;
        }

        private static double CalculateDP(double[][][] dp, int moves, int i, int j, int n, int row, int column)
        {
            if (moves == 0) return i == row && j == column ? 1 : 0;

            if (dp[moves][i][j] != -1) return dp[moves][i][j];

            dp[moves][i][j] = 0;

            foreach (int[] direction in directions)
            {
                int prevI = i - direction[0];
                int prevJ = j - direction[1];

                if (prevI >= 0 && prevI < n && prevJ >= 0 && prevJ < n) dp[moves][i][j] += CalculateDP(dp, moves - 1, prevI, prevJ, n, row, column) / 8.0;
            }

            return dp[moves][i][j];
        }
    }
}
