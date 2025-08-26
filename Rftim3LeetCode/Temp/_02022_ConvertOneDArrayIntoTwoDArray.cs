using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02022_ConvertOneDArrayIntoTwoDArray
    {
        /// <summary>
        /// You are given a 0-indexed 1-dimensional (1D) integer array original, and two integers, m and n. 
        /// You are tasked with creating a 2-dimensional (2D) array with  m rows and n columns using all the elements from original.
        /// The elements from indices 0 to n - 1 (inclusive) of original should form the first row of the constructed 2D array,
        /// the elements from indices n to 2 * n - 1 (inclusive) should form the second row of the constructed 2D array, and so on.
        /// Return an m x n 2D array constructed according to the above procedure, or an empty 2D array if it is impossible.
        /// </summary>
        public _02022_ConvertOneDArrayIntoTwoDArray()
        {
            int[][] x = Construct2DArray([1, 2, 3, 4], 2, 2);
            RftTerminal.RftReadResult<int>(x);

            int[][] x0 = Construct2DArray([1, 2, 3], 1, 3);
            RftTerminal.RftReadResult<int>(x0);

            int[][] x1 = Construct2DArray([1, 2], 1, 1);
            RftTerminal.RftReadResult<int>(x1);
        }

        private static int[][] Construct2DArray(int[] original, int m, int n)
        {
            int o = original.Length;
            int t = m * n;
            if (t != o) return [];

            int[][] r = new int[m][];
            for (int k = 0; k < m; k++)
            {
                r[k] = new int[n];
            }

            int i = 0, j = 0;
            for (int k = 1; k <= o; k++)
            {
                r[i][j] = original[k - 1];
                if (k % n == 0)
                {
                    i++;
                    j = -1;
                }
                j++;
            }

            return r;
        }
    }
}
