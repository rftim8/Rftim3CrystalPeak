namespace Rftim3LeetCode.Temp
{
    public class _00463_IslandPerimeter
    {
        /// <summary>
        /// You are given row x col grid representing a map where grid[i][j] = 1 represents land and grid[i][j] = 0 represents water.
        /// Grid cells are connected horizontally/vertically(not diagonally). 
        /// The grid is completely surrounded by water, and there is exactly one island(i.e., one or more connected land cells).
        /// The island doesn't have "lakes", meaning the water inside isn't connected to the water around the island.One cell is a square with side length 1. 
        /// The grid is rectangular, width and height don't exceed 100. 
        /// Determine the perimeter of the island.
        /// </summary>
        public _00463_IslandPerimeter()
        {
            Console.WriteLine(IslandPerimeter0([
                [0, 1, 0, 0],
                [1, 1, 1, 0],
                [0, 1, 0, 0],
                [1, 1, 0, 0]
                ]));
            Console.WriteLine(IslandPerimeter0([[1]]));
            Console.WriteLine(IslandPerimeter0([[1, 0]]));
        }

        public static int IslandPerimeter0(int[][] a0) => RftIslandPerimeter0(a0);

        public static int IslandPerimeter1(int[][] a0) => RftIslandPerimeter1(a0);

        private static int RftIslandPerimeter0(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            int old = 1;
            Stack<(int y, int x)> st = new();
            int r = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        st.Push((i, j));
                        i = n;
                        break;
                    }
                }
            }

            while (st.Count > 0)
            {
                (int y, int x) = st.Pop();

                if (y < 0 || x < 0 || y >= n || x >= m) continue;
                if (grid[y][x] != old || grid[y][x] == 2) continue;

                grid[y][x] = 2;

                if (y == 0) r++;
                else if (grid[y - 1][x] == 0) r++;

                if (y == n - 1) r++;
                else if (grid[y + 1][x] == 0) r++;

                if (x == 0) r++;
                else if (grid[y][x - 1] == 0) r++;

                if (x == m - 1) r++;
                else if (grid[y][x + 1] == 0) r++;

                st.Push((y - 1, x));
                st.Push((y + 1, x));
                st.Push((y, x - 1));
                st.Push((y, x + 1));
            }

            return r;
        }

        private static int RftIslandPerimeter1(int[][] grid)
        {

            int rows = grid.Length;
            int cols = grid[0].Length;

            int perimeter = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row][col] == 1)
                    {
                        perimeter += 4;

                        if (row > 0 && grid[row - 1][col] == 1) perimeter -= 2;
                        if (col > 0 && grid[row][col - 1] == 1) perimeter -= 2;
                    }
                }
            }

            return perimeter;
        }
    }
}
