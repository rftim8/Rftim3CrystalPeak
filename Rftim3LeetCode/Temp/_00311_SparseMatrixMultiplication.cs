using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00311_SparseMatrixMultiplication
    {
        /// <summary>
        /// Given two sparse matrices mat1 of size m x k and mat2 of size k x n, return the result of mat1 x mat2. 
        /// You may assume that multiplication is always possible.
        /// </summary>
        public _00311_SparseMatrixMultiplication()
        {
            int[][] a0 = SparseMatrixMultiplication0([[1, 0, 0], [-1, 0, 3]], [[7, 0, 0], [0, 0, 0], [0, 0, 1]]);
            RftTerminal.RftReadResult<int>(a0);

            int[][] a1 = SparseMatrixMultiplication0([[0]], [[0]]);
            RftTerminal.RftReadResult<int>(a1);
        }

        public static int[][] SparseMatrixMultiplication0(int[][] a0, int[][] a1) => RftSparseMatrixMultiplication0(a0, a1);

        public static int[][] SparseMatrixMultiplication1(int[][] a0, int[][] a1) => RftSparseMatrixMultiplication1(a0, a1);

        // Naive method
        private static int[][] RftSparseMatrixMultiplication0(int[][] mat1, int[][] mat2)
        {
            int n = mat1.Length, n0 = mat1[0].Length;
            int m0 = mat2[0].Length;

            int[][] res = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                res[i] = new int[m0];
                for (int j = 0; j < n0; ++j)
                {
                    if (mat1[i][j] != 0)
                    {
                        for (int k = 0; k < m0; ++k)
                        {
                            res[i][k] += mat1[i][j] * mat2[j][k];
                        }
                    }
                }
            }

            return res;
        }

        // Yale method
        private static int[][] RftSparseMatrixMultiplication1(int[][] mat1, int[][] mat2)
        {
            SparseMatrix A = new(mat1);
            SparseMatrix B = new(mat2, true);

            int[][] ans = new int[mat1.Length][];
            for (int i = 0; i < mat1.Length; i++)
            {
                ans[i] = new int[mat2[0].Length];
            }

            for (int row = 0; row < ans.Length; ++row)
            {
                for (int col = 0; col < ans[0].Length; ++col)
                {
                    int matrixOneRowStart = A.rowIndex[row];
                    int matrixOneRowEnd = A.rowIndex[row + 1];

                    int matrixTwoColStart = B.colIndex[col];
                    int matrixTwoColEnd = B.colIndex[col + 1];

                    while (matrixOneRowStart < matrixOneRowEnd && matrixTwoColStart < matrixTwoColEnd)
                    {
                        if (A.colIndex[matrixOneRowStart] < B.rowIndex[matrixTwoColStart]) matrixOneRowStart++;
                        else if (A.colIndex[matrixOneRowStart] > B.rowIndex[matrixTwoColStart]) matrixTwoColStart++;
                        else
                        {
                            ans[row][col] += A.values[matrixOneRowStart] * B.values[matrixTwoColStart];
                            matrixOneRowStart++;
                            matrixTwoColStart++;
                        }
                    }
                }
            }

            return ans;
        }

        private class SparseMatrix
        {
            public int cols = 0, rows = 0;
            public List<int> values = [];
            public List<int> colIndex = [];
            public List<int> rowIndex = [];

            public SparseMatrix(int[][] matrix)
            {
                rows = matrix.Length;
                cols = matrix[0].Length;
                rowIndex.Add(0);

                for (int row = 0; row < rows; ++row)
                {
                    for (int col = 0; col < cols; ++col)
                    {
                        if (matrix[row][col] != 0)
                        {
                            values.Add(matrix[row][col]);
                            colIndex.Add(col);
                        }
                    }
                    rowIndex.Add(values.Count);
                }
            }

            public SparseMatrix(int[][] matrix, bool colWise)
            {
                rows = matrix.Length;
                cols = matrix[0].Length;
                colIndex.Add(0);

                for (int col = 0; col < cols; ++col)
                {
                    for (int row = 0; row < rows; ++row)
                    {
                        if (matrix[row][col] != 0)
                        {
                            values.Add(matrix[row][col]);
                            rowIndex.Add(row);
                        }
                    }
                    colIndex.Add(values.Count);
                }
            }
        };
    }
}
