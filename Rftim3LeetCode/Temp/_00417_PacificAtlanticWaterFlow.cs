using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00417_PacificAtlanticWaterFlow
    {
        /// <summary>
        /// There is an m x n rectangular island that borders both the Pacific Ocean and Atlantic Ocean. 
        /// The Pacific Ocean touches the island's left and top edges, and the Atlantic Ocean touches the island's right and bottom edges.
        /// The island is partitioned into a grid of square cells.You are given an m x n integer matrix heights where 
        /// heights[r][c] represents the height above sea level of the cell at coordinate(r, c).
        /// The island receives a lot of rain, and the rain water can flow to neighboring cells directly north, south, east, 
        /// and west if the neighboring cell's height is less than or equal to the current cell's height.Water can flow from any cell adjacent to an ocean into the ocean.
        /// Return a 2D list of grid coordinates result where result[i] = [ri, ci] denotes that rain water can flow from cell (ri, ci) to both the Pacific and Atlantic oceans.
        /// </summary>
        public _00417_PacificAtlanticWaterFlow()
        {
            IList<IList<int>> x = PacificAtlantic([
                [1,2,2,3,5],
                [3,2,3,4,4],
                [2,4,5,3,1],
                [6,7,1,4,5],
                [5,1,1,2,4]
            ]);

            RftTerminal.RftReadResult(x);
        }

        private static IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            int n = heights.Length;
            int m = heights[0].Length;
            List<IList<int>> x = [];

            bool[,] pacific = new bool[n, m];
            bool[,] atlantic = new bool[n, m];

            for (int i = 0; i < n; i++)
            {
                DFS(i, 0, heights, pacific, heights[i][0]);
                DFS(i, m - 1, heights, atlantic, heights[i][m - 1]);
            }

            for (int i = 0; i < m; i++)
            {
                DFS(0, i, heights, pacific, heights[0][i]);
                DFS(n - 1, i, heights, atlantic, heights[n - 1][i]);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (pacific[i, j] && atlantic[i, j]) x.Add([i, j]);
                }
            }

            return x;
        }

        private static void DFS(int i, int j, int[][] matrix, bool[,] side, int prev)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;

            if (i < 0 || i >= n || j < 0 || j >= m || side[i, j] || matrix[i][j] < prev) return;

            side[i, j] = true;
            DFS(i, j + 1, matrix, side, matrix[i][j]);
            DFS(i, j - 1, matrix, side, matrix[i][j]);
            DFS(i + 1, j, matrix, side, matrix[i][j]);
            DFS(i - 1, j, matrix, side, matrix[i][j]);
        }
    }
}
