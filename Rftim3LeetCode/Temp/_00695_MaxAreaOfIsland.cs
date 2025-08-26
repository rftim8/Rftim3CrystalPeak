namespace Rftim3LeetCode.Temp
{
    public class _00695_MaxAreaOfIsland
    {
        /// <summary>
        /// You are given an m x n binary matrix grid. An island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) 
        /// You may assume all four edges of the grid are surrounded by water.
        /// The area of an island is the number of cells with a value 1 in the island.
        /// Return the maximum area of an island in grid.If there is no island, return 0.
        /// </summary>
        public _00695_MaxAreaOfIsland()
        {

            Console.WriteLine(MaxAreaOfIsland([
                [0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0],
                [0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0],
                [0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0]
            ]));
        }

        private static int MaxAreaOfIsland(int[][] grid)
        {
            int n = 2;
            int r = grid.Length;
            int c = grid[0].Length;

            HashSet<int> islands = [];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        int t = 0;
                        int old = 1;

                        Stack<(int y, int x)> st = new();
                        st.Push((i, j));

                        while (st.Count > 0)
                        {
                            (int y, int x) = st.Pop();

                            if (y < 0 || x < 0 || y >= r || x >= c) continue;
                            if (grid[y][x] != old || grid[y][x] == n) continue;

                            grid[y][x] = n;
                            t++;

                            st.Push((y - 1, x));
                            st.Push((y + 1, x));
                            st.Push((y, x - 1));
                            st.Push((y, x + 1));
                        }

                        islands.Add(t);
                        n++;
                    }
                }
            }

            return islands.Count == 0 ? 0 : islands.Max();
        }
    }
}
