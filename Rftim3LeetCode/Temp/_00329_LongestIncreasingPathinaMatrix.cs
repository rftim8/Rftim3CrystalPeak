namespace Rftim3LeetCode.Temp
{
    public class _00329_LongestIncreasingPathInAMatrix
    {
        /// <summary>
        /// Given an m x n integers matrix, return the length of the longest increasing path in matrix.
        /// From each cell, you can either move in four directions: left, right, up, or down.
        /// You may not move diagonally or move outside the boundary (i.e., wrap-around is not allowed).
        /// </summary>
        public _00329_LongestIncreasingPathInAMatrix()
        {
            Console.WriteLine(LongestIncreasingPathInAMatrix0([[9, 9, 4], [6, 6, 8], [2, 1, 1]]));
            Console.WriteLine(LongestIncreasingPathInAMatrix0([[3, 4, 5], [3, 2, 6], [2, 2, 1]]));
            Console.WriteLine(LongestIncreasingPathInAMatrix0([[1]]));
        }

        public static int LongestIncreasingPathInAMatrix0(int[][] a0) => RftLongestIncreasingPathInAMatrix0(a0);

        public static int LongestIncreasingPathInAMatrix1(int[][] a0) => RftLongestIncreasingPathInAMatrix1(a0);

        public static int LongestIncreasingPathInAMatrix2(int[][] a0) => RftLongestIncreasingPathInAMatrix2(a0);

        // DFS + Memoization
        private static readonly int[][] dirs = [[0, 1], [1, 0], [0, -1], [-1, 0]];
        private static int m, n;

        private static int RftLongestIncreasingPathInAMatrix0(int[][] matrix)
        {
            if (matrix.Length == 0) return 0;

            m = matrix.Length; n = matrix[0].Length;
            int[][] cache = new int[m][];
            for (int i = 0; i < m; i++)
            {
                cache[i] = new int[n];
            }
            int ans = 0;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ans = Math.Max(ans, Dfs(matrix, i, j, cache));
                }
            }

            return ans;
        }

        private static int Dfs(int[][] matrix, int i, int j, int[][] cache)
        {
            if (cache[i][j] != 0) return cache[i][j];

            foreach (int[] d in dirs)
            {
                int x = i + d[0], y = j + d[1];
                if (0 <= x && x < m && 0 <= y && y < n && matrix[x][y] > matrix[i][j]) cache[i][j] = Math.Max(cache[i][j], Dfs(matrix, x, y, cache));
            }

            return ++cache[i][j];
        }

        // Peeling Onion, Kahn's Algorithm
        private static int RftLongestIncreasingPathInAMatrix1(int[][] grid)
        {
            int m = grid.Length;

            if (m == 0) return 0;

            int n = grid[0].Length;
            int[][] matrix = new int[m + 2][];
            for (int i = 0; i < m + 2; i++)
            {
                matrix[i] = new int[n + 2];
            }
            for (int i = 0; i < m; ++i)
            {
                Array.Copy(grid[i], 0, matrix[i + 1], 1, n);
            }

            int[][] outdegree = new int[m + 2][];
            for (int i = 0; i < m + 2; i++)
            {
                outdegree[i] = new int[n + 2];
            }
            for (int i = 1; i <= m; ++i)
            {
                for (int j = 1; j <= n; ++j)
                {
                    foreach (int[] d in dirs)
                    {
                        if (matrix[i][j] < matrix[i + d[0]][j + d[1]]) outdegree[i][j]++;
                    }
                }
            }

            n += 2;
            m += 2;
            List<int[]> leaves = [];
            for (int i = 1; i < m - 1; ++i)
            {
                for (int j = 1; j < n - 1; ++j)
                {
                    if (outdegree[i][j] == 0) leaves.Add([i, j]);
                }
            }

            int height = 0;
            while (leaves.Count != 0)
            {
                height++;
                List<int[]> newLeaves = [];
                foreach (int[] node in leaves)
                {
                    foreach (int[] d in dirs)
                    {
                        int x = node[0] + d[0], y = node[1] + d[1];
                        if (matrix[node[0]][node[1]] > matrix[x][y])
                        {
                            if (--outdegree[x][y] == 0) newLeaves.Add([x, y]);
                        }
                    }
                }
                leaves = newLeaves;
            }

            return height;
        }

        private static int RftLongestIncreasingPathInAMatrix2(int[][] matrix)
        {
            int max = 0;
            int[,] largestMap = new int[matrix.Length, matrix[0].Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    max = Math.Max(max, LongestIncreasingPath2(i, j));
                }
            }

            return max;

            int LongestIncreasingPath2(int x, int y)
            {
                if (largestMap[x, y] != 0) return largestMap[x, y];

                int curMax = 0;
                if (x > 0 && matrix[x][y] < matrix[x - 1][y]) curMax = Math.Max(curMax, LongestIncreasingPath2(x - 1, y));
                if (x < matrix.Length - 1 && matrix[x][y] < matrix[x + 1][y]) curMax = Math.Max(curMax, LongestIncreasingPath2(x + 1, y));
                if (y > 0 && matrix[x][y] < matrix[x][y - 1]) curMax = Math.Max(curMax, LongestIncreasingPath2(x, y - 1));
                if (y < matrix[0].Length - 1 && matrix[x][y] < matrix[x][y + 1]) curMax = Math.Max(curMax, LongestIncreasingPath2(x, y + 1));

                largestMap[x, y] = curMax + 1;

                return largestMap[x, y];
            }
        }
    }
}
