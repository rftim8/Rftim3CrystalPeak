namespace Rftim3LeetCode.Temp
{
    public class _01254_NumberOfClosedIslands
    {
        /// <summary>
        /// Given a 2D grid consists of 0s (land) and 1s (water).  
        /// An island is a maximal 4-directionally connected group of 0s and a closed island is an island totally (all left, top, right, bottom) surrounded by 1s.
        /// Return the number of closed islands.
        /// </summary>
        public _01254_NumberOfClosedIslands()
        {
            Console.WriteLine(ClosedIsland([
                [1,1,1,1,1,1,1,0],
                [1,0,0,0,0,1,1,0],
                [1,0,1,0,1,1,1,0],
                [1,0,0,0,0,1,0,1],
                [1,1,1,1,1,1,1,0]
            ]));

            Console.WriteLine(ClosedIsland([
                [0,0,1,0,0],
                [0,1,0,1,0],
                [0,1,1,1,0]
            ]));

            Console.WriteLine(ClosedIsland([
                [0,0,0,1,0],
                [0,0,1,0,1],
                [0,0,0,1,1]
            ]));

            Console.WriteLine(ClosedIsland([
                [1,1,1,1,1,1,1],
                [1,0,0,0,0,0,1],
                [1,0,1,1,1,0,1],
                [1,0,1,0,1,0,1],
                [1,0,1,1,1,0,1],
                [1,0,0,0,0,0,1],
                [1,1,1,1,1,1,1]
            ]));

            Console.WriteLine(ClosedIsland([
                [0,0,1,1,0,1,0,0,1,0],
                [1,1,0,1,1,0,1,1,1,0],
                [1,0,1,1,1,0,0,1,1,0],
                [0,1,1,0,0,0,0,1,0,1],
                [0,0,0,0,0,0,1,1,1,0],
                [0,1,0,1,0,1,0,1,1,1],
                [1,0,1,0,1,1,0,0,0,1],
                [1,1,1,1,1,1,0,0,0,0],
                [1,1,1,0,0,1,0,1,0,1],
                [1,1,1,0,1,1,0,1,1,0]
            ]));
        }

        private static int ClosedIsland(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            int c = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i][j] == 0 && Dfs(grid, i, j))
                    {
                        c++;
                    }
                }
            }

            return c;
        }

        private static bool Dfs(int[][] grid, int i, int j)
        {
            if (i < 0 || j < 0 || i >= grid.Length || j >= grid[i].Length) return false;

            if (grid[i][j] == 1 || grid[i][j] == 2) return true;

            grid[i][j] = 2;

            return Dfs(grid, i + 1, j)
                & Dfs(grid, i - 1, j)
                & Dfs(grid, i, j + 1)
                & Dfs(grid, i, j - 1);
        }

        private static int ClosedIsland0(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            int c = 0;

            Stack<(int, int)> st = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        st.Push((i, j));
                        c++;
                    }

                    while (st.Count > 0)
                    {
                        (int y, int x) = st.Pop();

                        if (y < 0 || x < 0 || y >= n || x >= m)
                        {
                            c--;
                            st.Clear();
                            continue;
                        }
                        if (grid[y][x] != 1) continue;

                        else grid[y][x] = 2;

                        st.Push((y - 1, x));
                        st.Push((y + 1, x));
                        st.Push((y, x - 1));
                        st.Push((y, x + 1));
                    }
                }
            }

            return c;
        }
    }
}
