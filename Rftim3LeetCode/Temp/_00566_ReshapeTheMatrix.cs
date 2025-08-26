using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00566_ReshapeTheMatrix
    {
        /// <summary>
        /// In MATLAB, there is a handy function called reshape which can reshape an m x n matrix into a new one with a different size r x c keeping its original data.
        /// You are given an m x n matrix mat and two integers r and c representing the number of rows and the number of columns of the wanted reshaped matrix.
        /// The reshaped matrix should be filled with all the elements of the original matrix in the same row-traversing order as they were.
        /// If the reshape operation with given parameters is possible and legal, output the new reshaped matrix; Otherwise, output the original matrix.
        /// </summary>
        public _00566_ReshapeTheMatrix()
        {
            int[][] x = MatrixReshape([[1, 2], [3, 4]], 1, 4);
            int[][] x0 = MatrixReshape([[1, 2], [3, 4]], 4, 1);
            int[][] x1 = MatrixReshape([[1, 2], [3, 4]], 2, 4);
            int[][] x2 = MatrixReshape([[1, 2]], 1, 1);
            int[][] x3 = MatrixReshape([[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]], 2, 5);

            RftTerminal.RftReadResult<int>(x);
            RftTerminal.RftReadResult<int>(x0);
            RftTerminal.RftReadResult<int>(x1);
            RftTerminal.RftReadResult<int>(x2);
            RftTerminal.RftReadResult<int>(x3);
        }

        private static int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            if (r == 0 || c == 0) return mat;
            int n0 = mat.Length;
            int n1 = mat[0].Length;
            int o = r * c;
            if (n0 * n1 != o) return mat;

            int[][] x = new int[r][];
            int m = r * c > n0 * n1 ? c / r : c;
            int[] y = new int[m];

            int k = 0, z = 0;

            for (int i = 0; i < n0; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (z == r) return x;

                    y[k] = mat[i][j];
                    k++;

                    if (k == m)
                    {
                        x[z] = y;
                        z++;
                        k = 0;
                        y = new int[m];
                    }
                }
            }

            return x;
        }
    }
}
