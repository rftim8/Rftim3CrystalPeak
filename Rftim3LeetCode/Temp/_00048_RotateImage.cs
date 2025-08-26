using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00048_RotateImage
    {
        /// <summary>
        /// You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
        /// You have to rotate the image in-place, which means you have to modify the input 2D matrix directly.
        /// DO NOT allocate another 2D matrix and do the rotation.
        /// </summary>
        public _00048_RotateImage()
        {
            int[][] x = RotateImage0([
                [1, 2, 3],
                [4, 5, 6],
                [7, 8, 9]
            ]);

            RftTerminal.RftReadResult<int>(x);
        }

        public static int[][] RotateImage0(int[][] a0) => RftRotateImage0(a0);

        private static int[][] RftRotateImage0(int[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    (matrix[j][i], matrix[i][j]) = (matrix[i][j], matrix[j][i]);
                }
                Array.Reverse(matrix[i]);
            }

            return matrix;
        }
    }
}
