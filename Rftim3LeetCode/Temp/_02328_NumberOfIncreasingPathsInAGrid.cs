namespace Rftim3LeetCode.Temp
{
    public class _02328_NumberOfIncreasingPathsInAGrid
    {
        /// <summary>
        /// You are given an m x n integer matrix grid, where you can move from a cell to any adjacent cell in all 4 directions.
        /// Return the number of strictly increasing paths in the grid such that you can start from any cell and end at any cell.
        /// Since the answer may be very large, return it modulo 109 + 7.
        /// Two paths are considered different if they do not have exactly the same sequence of visited cells.
        /// </summary>
        public _02328_NumberOfIncreasingPathsInAGrid()
        {
            Console.WriteLine(CountPaths(
            [
                [1,1],
                [3,4]
            ]));

            Console.WriteLine(CountPaths(
            [
                [1],
                [2]
            ]));
        }

        private static int CountPaths(int[][] grid)
        {
            int[][] directions =
            [
                [0, 1],
                [0, -1],
                [1, 0],
                [-1, 0]
            ];

            int m = grid.Length, n = grid[0].Length;
            int mod = 1_000_000_007;

            int[][] dp = new int[m][];

            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
                Array.Fill(dp[i], 1);
            }

            int[][] cellList = new int[m * n][];

            for (int i = 0; i < m * n; i++)
            {
                cellList[i] = new int[2];
            }

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    int index = i * n + j;
                    cellList[index][0] = i;
                    cellList[index][1] = j;
                }
            }

            Array.Sort(cellList, (a, b) => grid[a[0]][a[1]] - grid[b[0]][b[1]]);

            foreach (int[] cell in cellList)
            {
                int i = cell[0], j = cell[1];

                foreach (int[] d in directions)
                {
                    int currI = i + d[0], currJ = j + d[1];
                    if (0 <= currI && currI < m && 0 <= currJ && currJ < n && grid[currI][currJ] > grid[i][j])
                    {
                        dp[currI][currJ] += dp[i][j];
                        dp[currI][currJ] %= mod;
                    }
                }
            }

            int answer = 0;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    answer += dp[i][j];
                    answer %= mod;
                }
            }

            return answer;
        }

        private static int[][]? dp;
        private static readonly int[][] directions = [[0, 1], [0, -1], [1, 0], [-1, 0]];
        private static readonly int mod = 1_000_000_007;

        private static int DFS(int[][] grid, int i, int j)
        {
            if (dp![i][j] != 0) return dp[i][j];

            int answer = 1;
            foreach (int[] d in directions)
            {
                int prevI = i + d[0], prevJ = j + d[1];
                if (0 <= prevI && prevI < grid.Length && 0 <= prevJ &&
                    prevJ < grid[0].Length && grid[prevI][prevJ] < grid[i][j])
                {
                    answer += DFS(grid, prevI, prevJ);
                    answer %= mod;
                }
            }
            dp[i][j] = answer;

            return answer;
        }

        private static int CountPaths0(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            dp = new int[m][];

            for (int i = 0; i < m; i++) dp[i] = new int[n];

            int answer = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    answer = (answer + DFS(grid, i, j)) % mod;
                }
            }

            return answer;
        }
    }
}
