namespace Rftim3LeetCode.Temp
{
    public class _00063_UniquePathsII
    {
        /// <summary>
        /// You are given an m x n integer array grid. There is a robot initially located at the top-left corner (i.e., grid[0][0]). 
        /// The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.
        /// An obstacle and space are marked as 1 or 0 respectively in grid.A path that the robot takes cannot include any square that is an obstacle.
        /// Return the number of possible unique paths that the robot can take to reach the bottom-right corner.
        /// The testcases are generated so that the answer will be less than or equal to 2 * 109.
        /// </summary>
        public _00063_UniquePathsII()
        {
            Console.WriteLine(UniquePathsII0(
            [
                [0, 0, 0],
                [0, 1, 0],
                [0, 0, 0]
            ]));

            Console.WriteLine(UniquePathsII0(
            [
                [0, 1],
                [0, 0]
            ]));
        }

        private static int m = 0, n = 0;

        public static int UniquePathsII0(int[][] a0) => RftUniquePathsII0(a0);

        private static int RftUniquePathsII0(int[][] obstacleGrid)
        {
            int n = obstacleGrid.Length;
            int m = obstacleGrid[0].Length;
            int[] board = new int[m];
            Array.Fill(board, 0);
            board[0] = 1;
            for (int i = 0; i < n; i++)
            {
                for (int c = 0; c < m; c++)
                {
                    if (obstacleGrid[i][c] == 1) board[c] = 0;
                    else if (c > 0) board[c] += board[c - 1];
                }
            }

            return board[m - 1];
        }

        private static int RftUniquePathsII1(int[][] obstacleGrid)
        {
            m = obstacleGrid.Length;
            n = obstacleGrid[0].Length;
            if (obstacleGrid[0][0] == 1) return 0;
            obstacleGrid[0][0] = 1;
            for (int i = 1; i < m; i++)
            {
                obstacleGrid[i][0] = obstacleGrid[i][0] == 0 && obstacleGrid[i - 1][0] == 1 ? 1 : 0;
            }

            for (int i = 1; i < n; i++)
            {
                obstacleGrid[0][i] = obstacleGrid[0][i] == 0 && obstacleGrid[0][i - 1] == 1 ? 1 : 0;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 0) obstacleGrid[i][j] = obstacleGrid[i - 1][j] + obstacleGrid[i][j - 1];
                    else obstacleGrid[i][j] = 0;
                }
            }

            return obstacleGrid[m - 1][n - 1];
        }
    }
}
