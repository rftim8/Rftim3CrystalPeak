namespace Rftim3LeetCode.Temp
{
    public class _00766_ToeplitzMatrix
    {
        /// <summary>
        /// Given an m x n matrix, return true if the matrix is Toeplitz. 
        /// Otherwise, return false.
        /// A matrix is Toeplitz if every diagonal from top-left to bottom-right has the same elements.
        /// </summary>
        public _00766_ToeplitzMatrix()
        {
            Console.WriteLine(IsToeplitzMatrix(
            [
                [1,2,3,4],
                [5,1,2,3],
                [9,5,1,2]
            ]));

            Console.WriteLine(IsToeplitzMatrix(
            [
                [1,2],
                [2,2]
            ]));
        }

        private static bool IsToeplitzMatrix(int[][] matrix)
        {
            for (int r = 0; r < matrix.Length; ++r)
            {
                for (int c = 0; c < matrix[0].Length; ++c)
                {
                    if (r > 0 && c > 0 && matrix[r - 1][c - 1] != matrix[r][c]) return false;
                }
            }

            return true;
        }
    }
}
