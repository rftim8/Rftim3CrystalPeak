using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00073_SetMatrixZeroes
    {
        /// <summary>
        /// Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.
        /// You must do it in place.
        /// </summary>
        public _00073_SetMatrixZeroes()
        {
            SetZeroes(
            [
                [1, 1, 1],
                [1, 0, 1],
                [1, 1, 1]
            ]);
            SetZeroes(
            [
                [0, 1, 2, 0],
                [3, 4, 5, 2],
                [1, 3, 1, 5]
            ]);
        }

        private static void SetZeroes(int[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;

            bool[] r = new bool[m];
            for (int i = 0; i < n; i++)
            {
                if (matrix[i].Contains(0))
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i][j] == 0) r[j] = true;
                        matrix[i][j] = 0;
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                if (r[i])
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[j][i] = 0;
                    }
                }
            }

            RftTerminal.RftReadResult<int>(matrix);
        }
    }
}
