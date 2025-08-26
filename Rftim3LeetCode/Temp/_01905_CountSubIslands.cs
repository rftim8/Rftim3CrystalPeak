namespace Rftim3LeetCode.Temp
{
    public class _01905_CountSubIslands
    {
        /// <summary>
        /// You are given two m x n binary matrices grid1 and grid2 containing only 0's (representing water) and 1's (representing land). 
        /// An island is a group of 1's connected 4-directionally (horizontal or vertical). Any cells outside of the grid are considered water cells.
        /// An island in grid2 is considered a sub-island if there is an island in grid1 that contains all the cells that make up this island in grid2.
        /// Return the number of islands in grid2 that are considered sub-islands.
        /// </summary>
        public _01905_CountSubIslands()
        {
            Console.WriteLine(CountSubIslands([
                [1,1,1,0,0],
                [0,1,1,1,1],
                [0,0,0,0,0],
                [1,0,0,0,0],
                [1,1,0,1,1]
            ],
            [
                [1,1,1,0,0],
                [0,0,1,1,1],
                [0,1,0,0,0],
                [1,0,1,1,0],
                [0,1,0,1,0]
            ]));

            Console.WriteLine(CountSubIslands([
                [1,0,1,0,1],
                [1,1,1,1,1],
                [0,0,0,0,0],
                [1,1,1,1,1],
                [1,0,1,0,1]
            ],
            [
                [0,0,0,0,0],
                [1,1,1,1,1],
                [0,1,0,1,0],
                [0,1,0,1,0],
                [1,0,0,0,1]
            ]));
        }

        private static int CountSubIslands(int[][] grid1, int[][] grid2)
        {
            HashSet<(int, int)> r1 = [];
            HashSet<HashSet<(int, int)>> r2 = Map(grid2);

            int c = 0;

            foreach (HashSet<(int, int)> item in Map(grid1))
            {
                r1.UnionWith(item);
            }

            foreach (HashSet<(int, int)> item in r2)
            {
                c++;
                foreach ((int, int) item1 in item)
                {
                    if (!r1.Contains(item1))
                    {
                        c--;
                        break;
                    }
                }
            }

            return c;
        }

        private static HashSet<HashSet<(int, int)>> Map(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;

            HashSet<HashSet<(int, int)>> r = [];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i][j] == 1) r.Add(Dfs(grid, i, j, n, m));
                }
            }

            return r;
        }

        private static HashSet<(int, int)> Dfs(int[][] grid, int i, int j, int n, int m)
        {
            HashSet<(int, int)> s = [];
            Stack<(int, int)> x = new();

            if (grid[i][j] == 1) x.Push((i, j));

            while (x.Count != 0)
            {
                (int, int) y = x.Pop();

                if (y.Item1 < 0 || y.Item2 < 0 || y.Item1 >= n || y.Item2 >= m) continue;
                if (grid[y.Item1][y.Item2] != 1 || grid[y.Item1][y.Item2] == 2) continue;

                grid[y.Item1][y.Item2] = 2;
                s.Add(y);

                x.Push((y.Item1 + 1, y.Item2));
                x.Push((y.Item1 - 1, y.Item2));
                x.Push((y.Item1, y.Item2 + 1));
                x.Push((y.Item1, y.Item2 - 1));
            }

            return s;
        }
    }
}
