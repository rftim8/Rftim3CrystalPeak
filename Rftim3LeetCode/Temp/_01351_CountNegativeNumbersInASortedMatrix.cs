namespace Rftim3LeetCode.Temp
{
    public class _01351_CountNegativeNumbersInASortedMatrix
    {
        /// <summary>
        /// Given a m x n matrix grid which is sorted in non-increasing order both row-wise and column-wise,
        /// return the number of negative numbers in grid.
        /// </summary>
        public _01351_CountNegativeNumbersInASortedMatrix()
        {
            Console.WriteLine(CountNegativeNumbersInASortedMatrix0([
                [4, 3, 2, -1],
                [3, 2, 1, -1],
                [1, 1, -1, -2],
                [-1, -1, -2, -3]
            ]));

            Console.WriteLine(CountNegativeNumbersInASortedMatrix0([
                [3, 2],
                [1, 0]
            ]));
        }

        public static int CountNegativeNumbersInASortedMatrix0(int[][] a0) => RftCountNegativeNumbersInASortedMatrix0(a0);

        private static int RftCountNegativeNumbersInASortedMatrix0(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                int l = 0, r = m - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    if (grid[i][mid] < 0) r = mid - 1;
                    else l = mid + 1;
                }
                c += m - l;
            }

            return c;
        }
    }
}