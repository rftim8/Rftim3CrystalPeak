namespace Rftim3LeetCode.Temp
{
    public class _01572_MatrixDiagonalSum
    {
        /// <summary>
        /// Given a square matrix mat, return the sum of the matrix diagonals.
        /// Only include the sum of all the elements on the primary diagonal and all the elements on the secondary diagonal that are not part of the primary diagonal.
        /// </summary>
        public _01572_MatrixDiagonalSum()
        {
            Console.WriteLine(DiagonalSum([
                [1,2,3],
                [4,5,6],
                [7,8,9]
            ]));

            Console.WriteLine(DiagonalSum([
                [1,1,1,1],
                [1,1,1,1],
                [1,1,1,1],
                [1,1,1,1]
            ]));

            Console.WriteLine(DiagonalSum([
                [5]
            ]));
        }

        private static int DiagonalSum(int[][] mat)
        {
            int n = mat.Length;

            int x = 0;
            for (int i = 0; i < n; i++)
            {
                x += mat[i][i];
                if (i != n - i - 1) x += mat[i][n - i - 1];
            }

            return x;
        }
    }
}
