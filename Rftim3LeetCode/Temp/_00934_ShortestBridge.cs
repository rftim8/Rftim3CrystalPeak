namespace Rftim3LeetCode.Temp
{
    public class _00934_ShortestBridge
    {
        /// <summary>
        /// You are given an n x n binary matrix grid where 1 represents land and 0 represents water.
        /// An island is a 4-directionally connected group of 1's not connected to any other 1's.There are exactly two islands in grid.
        /// You may change 0's to 1's to connect the two islands to form one island.
        /// Return the smallest number of 0's you must flip to connect the two islands.
        /// </summary>
        public _00934_ShortestBridge()
        {
            Console.WriteLine(ShortestBridge([
                [0,1],
                [1,0]
            ]));

            Console.WriteLine(ShortestBridge([
                [0,1,0],
                [0,0,0],
                [0,0,1]
            ]));

            Console.WriteLine(ShortestBridge([
                [1,1,1,1,1],
                [1,0,0,0,1],
                [1,0,1,0,1],
                [1,0,0,0,1],
                [1,1,1,1,1]
            ]));
        }

        private static int ShortestBridge(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            int r = int.MaxValue;

            Stack<(int, int)> x = new();
            List<IList<(int, int)>> a = [];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1) x.Push((i, j));
                    List<(int, int)> z = [];

                    while (x.Count != 0)
                    {
                        (int, int) y = x.Pop();

                        if (y.Item1 < 0 || y.Item2 < 0 || y.Item1 >= n || y.Item2 >= m) continue;
                        if (grid[y.Item1][y.Item2] != 1 || grid[y.Item1][y.Item2] == 2) continue;

                        grid[y.Item1][y.Item2] = 2;
                        z.Add((y.Item1, y.Item2));

                        x.Push((y.Item1 + 1, y.Item2));
                        x.Push((y.Item1 - 1, y.Item2));
                        x.Push((y.Item1, y.Item2 + 1));
                        x.Push((y.Item1, y.Item2 - 1));
                    }

                    if (z.Count != 0) a.Add(z);
                }
            }

            foreach ((int, int) item in a[0])
            {
                foreach ((int, int) item1 in a[1])
                {
                    int d = Math.Abs(item.Item1 - item1.Item1) + Math.Abs(item.Item2 - item1.Item2) - 1;
                    r = Math.Min(d, r);
                }
            }

            return r;
        }
    }
}
