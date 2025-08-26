namespace Rftim3LeetCode.Temp
{
    public class _02319_CheckIfMatrixIsXMatrix
    {
        /// <summary>
        /// A square matrix is said to be an X-Matrix if both of the following conditions hold:
        /// All the elements in the diagonals of the matrix are non-zero.
        /// All other elements are 0.
        /// Given a 2D integer array grid of size n x n representing a square matrix, return true if grid is an X-Matrix.
        /// Otherwise, return false.
        /// </summary>
        public _02319_CheckIfMatrixIsXMatrix()
        {
            Console.WriteLine(CheckXMatrix(
            [
                [2,0,0,1],
                [0,3,1,0],
                [0,5,2,0],
                [4,0,0,2]
            ]));
            Console.WriteLine(CheckXMatrix(
            [
                [5,7,0],
                [0,3,1],
                [0,5,0]
            ]));
        }

        private static bool CheckXMatrix(int[][] grid)
        {
            int n = grid.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || i + j == n - 1)
                    {
                        if (grid[i][j] == 0) return false;
                    }
                    else
                    {
                        if (grid[i][j] != 0) return false;
                    }
                }
            }

            return true;
        }
    }
}
