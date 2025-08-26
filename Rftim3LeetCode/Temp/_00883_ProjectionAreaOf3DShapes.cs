namespace Rftim3LeetCode.Temp
{
    public class _00883_ProjectionAreaOf3DShapes
    {
        /// <summary>
        /// You are given an n x n grid where we place some 1 x 1 x 1 cubes that are axis-aligned with the x, y, and z axes.
        /// Each value v = grid[i][j] represents a tower of v cubes placed on top of the cell(i, j).
        /// We view the projection of these cubes onto the xy, yz, and zx planes.
        /// A projection is like a shadow, that maps our 3-dimensional figure to a 2-dimensional plane. 
        /// We are viewing the "shadow" when looking at the cubes from the top, the front, and the side.
        /// Return the total area of all three projections.
        /// </summary>
        public _00883_ProjectionAreaOf3DShapes()
        {
            Console.WriteLine(ProjectionArea(
            [
                [1,2],
                [3,4]
            ]));

            Console.WriteLine(ProjectionArea(
            [
                [2]
            ]));

            Console.WriteLine(ProjectionArea(
            [
                [1,0],
                [0,2]
            ]));
        }

        private static int ProjectionArea(int[][] grid)
        {
            int n = grid.Length;
            int ans = 0;

            for (int i = 0; i < n; ++i)
            {
                int bestRow = 0;
                int bestCol = 0;

                for (int j = 0; j < n; ++j)
                {
                    if (grid[i][j] > 0) ans++;
                    bestRow = Math.Max(bestRow, grid[i][j]);
                    bestCol = Math.Max(bestCol, grid[j][i]);
                }
                ans += bestRow + bestCol;
            }

            return ans;
        }
    }
}
