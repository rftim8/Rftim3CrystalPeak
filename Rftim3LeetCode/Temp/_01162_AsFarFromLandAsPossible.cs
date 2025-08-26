namespace Rftim3LeetCode.Temp
{
    public class _01162_AsFarFromLandAsPossible
    {
        /// <summary>
        /// Given an n x n grid containing only values 0 and 1, where 0 represents water and 1 represents land, 
        /// find a water cell such that its distance to the nearest land cell is maximized, and return the distance. 
        /// If no land or water exists in the grid, return -1.
        /// The distance used in this problem is the Manhattan distance: the distance between two cells(x0, y0) and(x1, y1) is |x0 - x1| + |y0 - y1|.
        /// </summary>
        public _01162_AsFarFromLandAsPossible()
        {
            Console.WriteLine(AsFarFromLandAsPossible0(
                [
                    [1, 0, 1],
                    [0, 0, 0],
                    [1, 0, 1]
                ]
            ));
        }

        public static int AsFarFromLandAsPossible0(int[][] a0) => RftAsFarFromLandAsPossible0(a0);

        private static int RftAsFarFromLandAsPossible0(int[][] grid)
        {
            int a = 0;
            int b = 0;
            Queue<(int, int)> q = new();
            int d = -1;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 0) b++;
                    if (grid[i][j] == 1)
                    {
                        a++;
                        q.Enqueue((i, j));
                    }
                }
            }
            if (a == 0 || b == 0) return -1;

            while (q.Count != 0)
            {
                int c = q.Count;
                while (c > 0)
                {
                    (int i, int j) = q.Dequeue();
                    grid[i][j] = 1;
                    c--;
                    if (i + 1 < grid.Length && grid[i + 1][j] == 0)
                    {
                        q.Enqueue((i + 1, j));
                        grid[i + 1][j] = 1;
                    }
                    if (i - 1 >= 0 && grid[i - 1][j] == 0)
                    {
                        q.Enqueue((i - 1, j));
                        grid[i - 1][j] = 1;
                    }
                    if (j + 1 < grid[0].Length && grid[i][j + 1] == 0)
                    {
                        q.Enqueue((i, j + 1));
                        grid[i][j + 1] = 1;
                    }
                    if (j - 1 >= 0 && grid[i][j - 1] == 0)
                    {
                        q.Enqueue((i, j - 1));
                        grid[i][j - 1] = 1;
                    }
                }
                d++;
            }

            return d;
        }

        // Greedy
        private static int MaxDistance(int[][] grid)
        {
            if (grid.Length == 0) return -1;
            if (grid.Length == 1) return 0;

            HashSet<int> y = [];
            int w = grid[0].Length;
            int h = grid.Length;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    int z = 101;
                    for (int k = 0; k < h; k++)
                    {
                        for (int l = 0; l < w; l++)
                        {
                            if (grid[i][j] == 0 && grid[k][l] == 1)
                            {
                                int x = CalculateDistance(j, i, l, k);
                                if (x < z) z = x;
                            }
                        }
                    }
                    if (z != 101) y.Add(z);
                }
            }

            return y.Count > 0 ? y.Max() : -1;
        }

        // Manhattan distance
        private static int CalculateDistance(int x0, int y0, int x1, int y1) => Math.Abs(x0 - x1) + Math.Abs(y0 - y1);
    }
}