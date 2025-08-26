namespace Rftim3LeetCode.Temp
{
    public class _00892_SurfaceAreaOf3DShapes
    {
        /// <summary>
        /// You are given an n x n grid where you have placed some 1 x 1 x 1 cubes. 
        /// Each value v = grid[i][j] represents a tower of v cubes placed on top of cell (i, j).
        /// After placing these cubes, you have decided to glue any directly adjacent cubes to each other, 
        /// forming several irregular 3D shapes.
        /// Return the total surface area of the resulting shapes.
        /// Note: The bottom face of each shape counts toward its surface area.
        /// </summary>
        public _00892_SurfaceAreaOf3DShapes()
        {
            Console.WriteLine(SurfaceAreaOf3DShapes0(
            [
                [1, 2],
                [3, 4]
            ]));

            Console.WriteLine(SurfaceAreaOf3DShapes0(
            [
                [1, 1, 1],
                [1, 0, 1],
                [1, 1, 1]
            ]));

            Console.WriteLine(SurfaceAreaOf3DShapes0(
            [
                [2, 2, 2],
                [2, 1, 2],
                [2, 2, 2]
            ]));
        }

        public static int SurfaceAreaOf3DShapes0(int[][] a0) => RftSurfaceAreaOf3DShapes0(a0);

        private static int RftSurfaceAreaOf3DShapes0(int[][] grid)
        {
            int res = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    int height = grid[i][j];

                    if (height > 0)
                    {
                        int area = 2 + 4 * height;
                        area -= j > 0 ? 2 * Math.Min(height, grid[i][j - 1]) : 0;
                        area -= i > 0 ? 2 * Math.Min(height, grid[i - 1][j]) : 0;
                        res += area;
                    }

                }
            }

            return res;
        }
    }
}