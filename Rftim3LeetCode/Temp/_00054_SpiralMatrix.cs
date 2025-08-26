using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00054_SpiralMatrix
    {
        /// <summary>
        /// Given an m x n matrix, return all elements of the matrix in spiral order.
        /// </summary>
        public _00054_SpiralMatrix()
        {
            IList<int> x = SpiralMatrix0([
                [1, 2, 3],
                [4, 5, 6],
                [7, 8, 9]
            ]);
            RftTerminal.RftReadResult(x);

            IList<int> x1 = SpiralMatrix0([
                [1, 2, 3, 4],
                [5, 6, 7, 8],
                [9, 10, 11, 12]
            ]);

            RftTerminal.RftReadResult(x1);
        }

        public static List<int> SpiralMatrix0(int[][] a0) => RftSpiralMatrix0(a0);

        private static List<int> RftSpiralMatrix0(int[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;
            List<int> x = [];
            int y = 0;
            int i = 0, j = 0;

            while (x.Count < n * m)
            {
                x.Add(matrix[i][j]);

                if (j < m - y - 1 && i == y) j++;
                else if (j == m - y - 1 && i < n - y - 1) i++;
                else if (j > y && i == n - y - 1) j--;
                else if (j == y)
                {
                    i--;
                    if (i == y + 1) y++;
                }
            }

            return x;
        }

        private static List<int> RftSpiralMatrix1(int[][] matrix)
        {
            var result = new List<int>();
            int m = matrix.Length;
            int n = matrix[0].Length;
            int top = 0;
            int bottom = m - 1;
            int left = 0;
            int right = n - 1;
            while (top <= bottom && left <= right)
            {
                for (int j = left; j <= right; j++)
                {
                    result.Add(matrix[top][j]);
                }
                top++;
                if (top <= bottom && left <= right)
                {
                    for (int i = top; i <= bottom; i++)
                    {
                        result.Add(matrix[i][right]);
                    }
                }
                right--;
                if (top <= bottom && left <= right)
                {
                    for (int j = right; j >= left; j--)
                    {
                        result.Add(matrix[bottom][j]);
                    }
                }
                bottom--;
                if (top <= bottom && left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        result.Add(matrix[i][left]);
                    }
                }
                left++;

            }
            return result;
        }
    }
}
