using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00867_TransposeMatrix
    {
        /// <summary>
        /// Given a 2D integer array matrix, return the transpose of matrix.
        /// The transpose of a matrix is the matrix flipped over its main diagonal, switching the matrix's row and column indices.
        /// </summary>
        public _00867_TransposeMatrix()
        {
            int[][] x = Transpose([
                [1,2,3],
                [4,5,6],
                [7,8,9]
            ]);

            int[][] x0 = Transpose([
                [1,2,3],
                [4,5,6]
            ]);

            RftTerminal.RftReadResult<int>(x);
            RftTerminal.RftReadResult<int>(x0);
        }

        private static int[][] Transpose(int[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;

            int[][] r = new int[m][];

            for (int i = 0; i < m; i++)
            {
                r[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    r[i][j] = matrix[j][i];
                }
            }

            return r;
        }
    }
}
