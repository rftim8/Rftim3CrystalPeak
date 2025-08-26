namespace Rftim3LeetCode.Temp
{
    public class _00994_RottingOranges
    {
        /// <summary>
        /// You are given an m x n grid where each cell can have one of three values:
        /// 0 representing an empty cell,
        /// 1 representing a fresh orange, or
        /// 2 representing a rotten orange.
        /// Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.
        /// Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.
        /// </summary>
        public _00994_RottingOranges()
        {
            Console.WriteLine(OrangesRotting([
                [2,1,1],
                [1,1,0],
                [0,1,1]
            ]));

            Console.WriteLine(OrangesRotting([
                [2,1,1],
                [0,1,1],
                [1,0,1]
            ]));

            Console.WriteLine(OrangesRotting([
                [0,2]
            ]));

            Console.WriteLine(OrangesRotting([
                [1,2]
            ]));
            Console.WriteLine(OrangesRotting([
                [0,2,2]
            ]));
        }

        private static int OrangesRotting(int[][] grid)
        {
            if (grid is null || grid.Length == 0) return 0;

            int n = grid.Length;
            int m = grid[0].Length;
            int z = 0;
            int t = 0;

            int[] dr = [0, 1, 0, -1];
            int[] dc = [-1, 0, 1, 0];

            Queue<(int, int)> q = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i][j] == 1) t++;
                    if (grid[i][j] == 2) q.Enqueue((i, j));
                }
            }

            if (t == 0) return 0;

            while (q.Count > 0)
            {
                z++;
                int s = q.Count;
                for (int i = 0; i < s; i++)
                {
                    (int, int) c = q.Dequeue();

                    for (int j = 0; j < 4; j++)
                    {
                        int nr = c.Item1 + dr[j];
                        int nc = c.Item2 + dc[j];
                        if (nr > -1 && nr < n && nc > -1 && nc < m && grid[nr][nc] == 1)
                        {
                            grid[nr][nc] = 2;
                            q.Enqueue((nr, nc));
                            t--;
                        }
                    }
                }
            }

            return t == 0 ? z - 1 : -1;
        }
    }
}
