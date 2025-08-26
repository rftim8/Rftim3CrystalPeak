namespace Rftim3LeetCode.Temp
{
    public class _02923_FindChampion1
    {
        /// <summary>
        /// There are n teams numbered from 0 to n - 1 in a tournament.
        /// 
        /// Given a 0-indexed 2D boolean matrix grid of size n * n.For all i, j that 0 <= i, j <= n - 1 and i != j team i is stronger 
        /// than team j if grid[i][j] == 1, otherwise, team j is stronger than team i.
        /// 
        /// Team a will be the champion of the tournament if there is no team b that is stronger than team a.
        /// 
        /// Return the team that will be the champion of the tournament.
        /// </summary>
        public _02923_FindChampion1()
        {
            Console.WriteLine(FindChampion0([[0, 1], [0, 0]]));
            Console.WriteLine(FindChampion0([[0, 0, 1], [1, 0, 1], [0, 0, 0]]));
            Console.WriteLine(FindChampion0([
                [0, 0, 0, 0],
                [1, 0, 0, 0],
                [1, 1, 0, 0],
                [1, 1, 1, 0]
                ]));
        }

        public static int FindChampion0(int[][] a0) => RftFindChampion0(a0);

        public static int FindChampion1(int[][] a0) => RftFindChampion1(a0);

        private static int RftFindChampion0(int[][] grid)
        {
            int n = grid.Length;
            int[] r = new int[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        if (grid[i][j] == 1) r[i]++;
                        if (r[i] == n - 1) return i;
                    }
                }
            }

            return -1;
        }

        private static int RftFindChampion1(int[][] grid)
        {
            int N = grid.Length;
            int r;
            for (r = 0; r < N; r++)
            {
                int c;
                for (c = 0; c < N; c++)
                {
                    if (r == c) continue;
                    if (grid[r][c] != 1) break;
                }

                if (c == N) break;
            }

            return r;
        }
    }
}
