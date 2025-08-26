namespace Rftim3LeetCode.Temp
{
    public class _00074_SearchA2DMatrix
    {
        /// <summary>
        ///
        /// </summary>
        public _00074_SearchA2DMatrix()
        {
            Console.WriteLine(SearchA2DMatrix0(
                [
                    [1, 3, 5, 7],
                    [10, 11, 16, 20],
                    [23, 30, 34, 60]
                ],
                3));
        }

        public static bool SearchA2DMatrix0(int[][] a0, int a1) => RftSearchA2DMatrix0(a0, a1);

        private static bool RftSearchA2DMatrix0(int[][] matrix, int target)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;

            for (int i = 0; i < n; i++)
            {
                if (target >= matrix[i][0] && target <= matrix[i][^1])
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i][j] == target) return true;
                    }

                    return false;
                }
            }

            return false;
        }
    }
}