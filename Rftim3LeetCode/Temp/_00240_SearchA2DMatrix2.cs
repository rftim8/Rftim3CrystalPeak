namespace Rftim3LeetCode.Temp
{
    public class _00240_SearchA2DMatrix2
    {
        /// <summary>
        /// Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. 
        /// This matrix has the following properties:
        /// Integers in each row are sorted in ascending from left to right.
        /// Integers in each column are sorted in ascending from top to bottom.
        /// </summary>
        public _00240_SearchA2DMatrix2()
        {
            Console.WriteLine(SearchMatrix(new int[5][] {
                new int[] { 1,4,7,11,15 },
                new int[] { 2,5,8,12,19 },
                new int[] { 3,6,9,16,22 },
                new int[] { 10,13,14,17,24 },
                new int[] { 18,21,23,26,30 }
            }, 5));

            Console.WriteLine(SearchMatrix(new int[5][] {
                new int[] { 1,4,7,11,15 },
                new int[] { 2,5,8,12,19 },
                new int[] { 3,6,9,16,22 },
                new int[] { 10,13,14,17,24 },
                new int[] { 18,21,23,26,30 }
            }, 20));
        }

        private static bool SearchMatrix(int[][] matrix, int target)
        {
            int n = matrix.Length;

            for (int i = 0; i < n; i++)
            {
                int index = Array.BinarySearch(matrix[i], target);
                if (index > -1) return true;
            }

            return false;
        }

        private static bool SearchMatrix0(int[][] matrix, int target)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int i = 0, j = n - 1;

            while (i >= 0 && i < m && j >= 0 && j < n)
            {
                if (matrix[i][j] == target) return true;
                else if (matrix[i][j] > target) j--;
                else if (matrix[i][j] < target) i++;
            }

            return false;
        }
    }
}
