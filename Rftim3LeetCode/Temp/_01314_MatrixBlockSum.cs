using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01314_MatrixBlockSum
    {
        /// <summary>
        /// Given a m x n matrix mat and an integer k, return a matrix answer where each answer[i][j] is the sum of all elements mat[r][c] for:
        /// i - k <= r <= i + k,
        /// j - k <= c <= j + k, and
        /// (r, c) is a valid position in the matrix.
        /// </summary>
        public _01314_MatrixBlockSum()
        {
            int[][] x = MatrixBlockSum(
                [
                    [1,2,3],
                    [4,5,6],
                    [7,8,9]
                ],
                1
            );

            int[][] x0 = MatrixBlockSum(
                [
                    [67,64,78],
                    [99,98,38],
                    [82,46,46],
                    [6,52,55],
                    [55,99,45]
                ],
                3
            );

            RftTerminal.RftReadResult<int>(x);
            RftTerminal.RftReadResult<int>(x0);
        }

        private static int[][] MatrixBlockSum(int[][] mat, int k)
        {
            int n = mat.Length, m = mat[0].Length;

            int[,] sum = new int[n + 1, m + 1];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    sum[i, j] = sum[i - 1, j] + sum[i, j - 1] - sum[i - 1, j - 1] + mat[i - 1][j - 1];
                }
            }

            int[][] x = new int[n][];
            for (int i = 0; i < n; i++)
            {
                x[i] = new int[m];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int r1 = Math.Max(i - k, 0), c1 = Math.Max(j - k, 0);
                    int r2 = Math.Min(i + k + 1, n), c2 = Math.Min(j + k + 1, m);
                    x[i][j] = sum[r2, c2] - sum[r1, c2] - sum[r2, c1] + sum[r1, c1];
                }
            }

            return x;
        }
    }
}
