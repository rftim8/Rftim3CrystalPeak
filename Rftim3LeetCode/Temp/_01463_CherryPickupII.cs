namespace Rftim3LeetCode.Temp
{
    public class _01463_CherryPickupII
    {
        /// <summary>
        /// You are given a rows x cols matrix grid representing a field of cherries where grid[i][j] 
        /// represents the number of cherries that you can collect from the (i, j) cell.
        /// 
        /// You have two robots that can collect cherries for you:
        /// 
        /// Robot #1 is located at the top-left corner (0, 0), and
        /// Robot #2 is located at the top-right corner (0, cols - 1).
        /// Return the maximum number of cherries collection using both robots by following the rules below:
        /// 
        /// From a cell(i, j), robots can move to cell(i + 1, j - 1), (i + 1, j), or(i + 1, j + 1).
        /// When any robot passes through a cell, It picks up all cherries, and the cell becomes an empty cell.
        /// When both robots stay in the same cell, only one takes the cherries.
        /// Both robots cannot move outside of the grid at any moment.
        /// Both robots should reach the bottom row in grid.
        /// </summary>
        public _01463_CherryPickupII()
        {
            Console.WriteLine(CherryPickupII0([[3, 1, 1], [2, 5, 1], [1, 5, 5], [2, 1, 1]]));
            Console.WriteLine(CherryPickupII0([[1, 0, 0, 0, 0, 0, 1], [2, 0, 0, 0, 0, 3, 0], [2, 0, 9, 0, 0, 0, 0], [0, 3, 0, 5, 4, 0, 0], [1, 0, 2, 3, 0, 0, 6]]));
        }

        public static int CherryPickupII0(int[][] a0) => RftCherryPickupII0(a0);

        public static int CherryPickupII1(int[][] a0) => RftCherryPickupII1(a0);

        public static int CherryPickupII2(int[][] a0) => RftCherryPickupII2(a0);

        // Top-Down DP
        private static int RftCherryPickupII0(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[][][] dpCache = new int[m][][];
            for (int i = 0; i < m; i++)
            {
                dpCache[i] = new int[n][];
                for (int j = 0; j < n; j++)
                {
                    dpCache[i][j] = new int[n];
                    for (int k = 0; k < n; k++)
                    {
                        dpCache[i][j][k] = -1;
                    }
                }
            }

            return Dp(0, 0, n - 1, grid, dpCache);
        }

        private static int Dp(int row, int col1, int col2, int[][] grid, int[][][] dpCache)
        {
            if (col1 < 0 || col1 >= grid[0].Length || col2 < 0 || col2 >= grid[0].Length) return 0;

            if (dpCache[row][col1][col2] != -1) return dpCache[row][col1][col2];

            int result = 0;
            result += grid[row][col1];
            if (col1 != col2) result += grid[row][col2];

            if (row != grid.Length - 1)
            {
                int max = 0;
                for (int newCol1 = col1 - 1; newCol1 <= col1 + 1; newCol1++)
                {
                    for (int newCol2 = col2 - 1; newCol2 <= col2 + 1; newCol2++)
                    {
                        max = Math.Max(max, Dp(row + 1, newCol1, newCol2, grid, dpCache));
                    }
                }
                result += max;
            }

            dpCache[row][col1][col2] = result;

            return result;
        }

        // Bottom-Up DP
        private static int RftCherryPickupII1(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[][][] dp = new int[m][][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n][];
                for (int j = 0; j < n; j++)
                {
                    dp[i][j] = new int[n];
                }
            }

            for (int row = m - 1; row >= 0; row--)
            {
                for (int col1 = 0; col1 < n; col1++)
                {
                    for (int col2 = 0; col2 < n; col2++)
                    {
                        int result = 0;
                        result += grid[row][col1];
                        if (col1 != col2) result += grid[row][col2];

                        if (row != m - 1)
                        {
                            int max = 0;
                            for (int newCol1 = col1 - 1; newCol1 <= col1 + 1; newCol1++)
                            {
                                for (int newCol2 = col2 - 1; newCol2 <= col2 + 1; newCol2++)
                                {
                                    if (newCol1 >= 0 && newCol1 < n && newCol2 >= 0 && newCol2 < n) max = Math.Max(max, dp[row + 1][newCol1][newCol2]);
                                }
                            }
                            result += max;
                        }
                        dp[row][col1][col2] = result;
                    }
                }
            }

            return dp[0][0][n - 1];
        }

        private static int RftCherryPickupII2(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            int[,,] res = new int[n, m, m];
            res[0, 0, m - 1] = grid[0][0] + grid[0][m - 1];

            int Get(int i1, int i2, int i3) => i2 < 0 || i2 >= m || i3 < 0 || i3 >= m ? 0 : res[i1, i2, i3];

            for (int i = 1; i < n; i++)
            {
                for (int a = 0; a < Math.Min(i + 1, m); a++)
                {
                    for (int b = m - 1; b >= Math.Max(m - 1 - i, 0); b--)
                    {
                        int cur = a == b ? grid[i][a] : grid[i][a] + grid[i][b];
                        int k = res[i - 1, a, b];
                        k = Math.Max(k, Get(i - 1, a - 1, b - 1));
                        k = Math.Max(k, Get(i - 1, a - 1, b));
                        k = Math.Max(k, Get(i - 1, a - 1, b + 1));
                        k = Math.Max(k, Get(i - 1, a, b - 1));
                        k = Math.Max(k, Get(i - 1, a, b));
                        k = Math.Max(k, Get(i - 1, a, b + 1));
                        k = Math.Max(k, Get(i - 1, a + 1, b - 1));
                        k = Math.Max(k, Get(i - 1, a + 1, b));
                        k = Math.Max(k, Get(i - 1, a + 1, b + 1));
                        res[i, a, b] = cur + k;
                    }
                }
            }

            int r = 0;

            for (int a = 0; a < Math.Min(n, m); a++)
            {
                for (int b = m - 1; b >= Math.Max(m - n, 0); b--)
                {
                    r = Math.Max(r, res[n - 1, a, b]);
                }
            }

            return r;
        }
    }
}
