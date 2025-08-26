using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02639_FindTheWidthOfColumnsOfAGrid
    {
        /// <summary>
        /// You are given a 0-indexed m x n integer matrix grid.
        /// The width of a column is the maximum length of its integers.
        /// For example, if grid = [[-10], [3], [12]], the width of the only column is 3 since -10 is of length 3.
        /// Return an integer array ans of size n where ans[i] is the width of the ith column.
        /// The length of an integer x with len digits is equal to len if x is non-negative, and len + 1 otherwise.
        /// </summary>
        public _02639_FindTheWidthOfColumnsOfAGrid()
        {
            int[] x = FindColumnWidth(
            [
                [1],
                [22],
                [333]
            ]);
            RftTerminal.RftReadResult(x);
            int[] x0 = FindColumnWidth(
            [
                [-15, 1, 3],
                [15, 7, 12],
                [5, 6, -2]
            ]);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] FindColumnWidth(int[][] grid)
        {
            int n = grid.Length;
            int c = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                c = Math.Min(c, grid[i].Length);
            }

            int[] t = new int[c];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    t[j] = Math.Max(t[j], grid[i][j].ToString().Length);
                }
            }

            return t;
        }
    }
}
