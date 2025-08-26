using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01260_Shift2DGrid
    {
        /// <summary>
        /// Given a 2D grid of size m x n and an integer k. You need to shift the grid k times.
        /// In one shift operation:
        /// Element at grid[i][j] moves to grid[i][j + 1].
        /// Element at grid[i][n - 1] moves to grid[i + 1][0].
        /// Element at grid[m - 1][n - 1] moves to grid[0][0].
        /// Return the 2D grid after applying shift operation k times.
        /// </summary>
        public _01260_Shift2DGrid()
        {
            IList<IList<int>> x = ShiftGrid(
            [
                [1,2,3],
                [4,5,6],
                [7,8,9]
            ],
            1
            );

            IList<IList<int>> x0 = ShiftGrid(
            [
                [3,8,1,9],
                [19,7,2,5],
                [4,6,11,10],
                [12,0,21,13]
            ],
            4
            );

            IList<IList<int>> x1 = ShiftGrid(
            [
                [1,2,3],
                [4,5,6],
                [7,8,9]
            ],
            9
            );

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static List<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            List<int> x = [];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    x.Add(grid[i][j]);
                }
            }

            for (int i = 0; i < k; i++)
            {
                int t = x.Last();
                x.RemoveAt(x.Count - 1);
                x.Insert(0, t);
            }

            List<IList<int>> r = [];
            List<int> q = [];
            int l = 1;
            for (int i = 0; i < x.Count; i++, l++)
            {
                q.Add(x[i]);
                if (l % m == 0)
                {
                    r.Add(q);
                    q = [];
                }
            }

            return r;
        }
    }
}
