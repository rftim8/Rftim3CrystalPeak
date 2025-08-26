namespace Rftim3LeetCode.Temp
{
    public class _00304_RangeSumQuery2DImmutable
    {
        /// <summary>
        /// Given a 2D matrix matrix, handle multiple queries of the following type:
        /// Calculate the sum of the elements of matrix inside the rectangle defined by its upper left corner(row1, col1) and lower right corner(row2, col2).
        /// Implement the NumMatrix class:
        /// NumMatrix(int[][] matrix) Initializes the object with the integer matrix matrix.
        /// int sumRegion(int row1, int col1, int row2, int col2) Returns the sum of the elements of matrix inside the rectangle 
        /// defined by its upper left corner(row1, col1) and lower right corner(row2, col2).
        /// You must design an algorithm where sumRegion works on O(1) time complexity.
        /// </summary>
        public _00304_RangeSumQuery2DImmutable()
        {
            NumMatrix obj = new(new int[][]
            {
                new int[] { 3,0,1,4,2 },
                new int[] { 5,6,3,2,1 },
                new int[] { 1,2,0,1,5 },
                new int[] { 4,1,0,1,7 },
                new int[] { 1,0,3,0,5 }
            });
            int param_1 = obj.SumRegion(2, 1, 4, 3);
            Console.WriteLine(param_1);
            int param_2 = obj.SumRegion(1, 1, 2, 2);
            Console.WriteLine(param_2);
            int param_3 = obj.SumRegion(1, 2, 2, 4);
            Console.WriteLine(param_3);
        }

        private class NumMatrix
        {
            public int[][] matrix;

            public NumMatrix(int[][] matrix)
            {
                this.matrix = matrix;
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                int c = 0;
                for (int i = row1; i <= row2; i++)
                {
                    for (int j = col1; j <= col2; j++)
                    {
                        c += matrix[i][j];
                    }
                }

                return c;
            }
        }
    }
}
