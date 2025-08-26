using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02373_LargestLocalValuesInAMatrix
    {
        /// <summary>
        /// You are given an n x n integer matrix grid.
        /// Generate an integer matrix maxLocal of size(n - 2) x(n - 2) such that:
        /// maxLocal[i][j] is equal to the largest value of the 3 x 3 matrix in grid centered around row i + 1 and column j + 1.
        /// In other words, we want to find the largest value in every contiguous 3 x 3 matrix in grid.
        /// Return the generated matrix.
        /// </summary>
        public _02373_LargestLocalValuesInAMatrix()
        {
            int[][] x = LargestLocal(
            [
                [9,9,8,1],
                [5,6,2,6],
                [8,2,6,4],
                [6,2,2,2]
            ]);
            RftTerminal.RftReadResult<int>(x);
            int[][] x0 = LargestLocal(
            [
                [1,1,1,1,1],
                [1,1,1,1,1],
                [1,1,2,1,1],
                [1,1,1,1,1],
                [1,1,1,1,1]
            ]);
            RftTerminal.RftReadResult<int>(x0);
        }

        private static int[][] LargestLocal(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            int[][] res = new int[n - 2][];

            for (int i = 0; i < n - 2; i++)
            {
                res[i] = new int[m - 2];

                for (int j = 0; j < m - 2; j++)
                {
                    res[i][j] = int.MinValue;

                    for (int k = i; k < i + 3; k++)
                    {
                        for (int l = j; l < j + 3; l++)
                        {
                            res[i][j] = Math.Max(res[i][j], grid[k][l]);
                        }
                    }
                }
            }

            return res;
        }

        private static int[][] LargestLocal0(int[][] grid) =>
            Enumerable
                .Range(0, grid.Length - 2)
                .Select(i =>
                     Enumerable
                        .Range(0, grid[0].Length - 2)
                        .Select(j =>
                            grid[i..(i + 3)].Max(row => row[j..(j + 3)].Max())
                        )
                        .ToArray()
                )
                .ToArray();
    }
}
