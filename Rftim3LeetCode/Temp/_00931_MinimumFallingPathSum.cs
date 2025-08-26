namespace Rftim3LeetCode.Temp
{
    public class _00931_MinimumFallingPathSum
    {
        /// <summary>
        /// Given an n x n array of integers matrix, return the minimum sum of any falling path through matrix.
        /// A falling path starts at any element in the first row and chooses the element in the next row that is 
        /// either directly below or diagonally left/right.Specifically, the next element from position(row, col) 
        /// will be(row + 1, col - 1), (row + 1, col), or(row + 1, col + 1).
        /// </summary>
        public _00931_MinimumFallingPathSum()
        {
            Console.WriteLine(MinFallingPathSum(
            [
                [2,1,3],
                [6,5,4],
                [7,8,9]
            ]));

            Console.WriteLine(MinFallingPathSum(
            [
                [-19,57],
                [-40,-5]
            ]));

            Console.WriteLine(MinFallingPathSum(
            [
                [100, -42, -46, -41],
                [31,  97,  10,  -10],
                [-58, -51, 82,  89],
                [51,  81,  69,  -51]
            ]));
        }

        private static int MinFallingPathSum(int[][] matrix)
        {
            int n = matrix.Length;
            if (n == 1) return matrix[0][0];

            int x = int.MaxValue;
            int[] dx = [-1, 0, 1];
            int[,] results = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                results[0, i] = matrix[0][i];
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int crt = int.MaxValue;

                    for (int k = 0; k < 3; k++)
                    {
                        int newX = j + dx[k];

                        if (newX > -1 && newX < n) crt = Math.Min(crt, results[i - 1, newX] + matrix[i][j]);
                    }

                    results[i, j] = crt;
                }
            }

            for (int i = 0; i < results.GetLength(1); i++)
            {
                x = Math.Min(x, results[results.GetLength(0) - 1, i]);
            }

            return x;
        }

        private static int MinFallingPathSum0(int[][] matrix)
        {
            int n = matrix.Length;
            int[,] dp = new int[n, n];

            for (int i = 0; i < n; i++) dp[0, i] = matrix[0][i];

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int upLeft = j - 1 >= 0 ? dp[i - 1, j - 1] : int.MaxValue;
                    int up = dp[i - 1, j];
                    int upRight = j + 1 < n ? dp[i - 1, j + 1] : int.MaxValue;
                    dp[i, j] = (new int[] { upLeft, up, upRight }).Min() + matrix[i][j];
                }
            }

            return Enumerable.Range(0, n).Select(x => dp[n - 1, x]).Min();
        }
    }
}
