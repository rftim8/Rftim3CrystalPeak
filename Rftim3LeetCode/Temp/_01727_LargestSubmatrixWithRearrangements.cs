namespace Rftim3LeetCode.Temp
{
    public class _01727_LargestSubmatrixWithRearrangements
    {
        /// <summary>
        /// You are given a binary matrix matrix of size m x n, and you are allowed to rearrange the columns of the matrix in any order.
        /// 
        /// Return the area of the largest submatrix within matrix where every element of the submatrix is 1 after reordering the columns optimally.
        /// </summary>
        public _01727_LargestSubmatrixWithRearrangements()
        {
            Console.WriteLine(LargestSubmatrix0([[0, 0, 1], [1, 1, 1], [1, 0, 1]]));
            Console.WriteLine(LargestSubmatrix0([[1, 0, 1, 0, 1]]));
            Console.WriteLine(LargestSubmatrix0([[1, 1, 0], [1, 0, 1]]));
        }

        public static int LargestSubmatrix0(int[][] a0) => RftLargestSubmatrix0(a0);

        public static int LargestSubmatrix1(int[][] a0) => RftLargestSubmatrix0(a0);

        public static int LargestSubmatrix2(int[][] a0) => RftLargestSubmatrix0(a0);

        private static int RftLargestSubmatrix0(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int ans = 0;

            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row][col] != 0 && row > 0) matrix[row][col] += matrix[row - 1][col];
                }

                int[] currRow = (int[])matrix[row].Clone();
                Array.Sort(currRow);
                for (int i = 0; i < n; i++)
                {
                    ans = Math.Max(ans, currRow[i] * (n - i));
                }
            }

            return ans;
        }

        private static int RftLargestSubmatrix1(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[] prevRow = new int[n];
            int ans = 0;

            for (int row = 0; row < m; row++)
            {
                int[] currRow = (int[])matrix[row].Clone();
                for (int col = 0; col < n; col++)
                {
                    if (currRow[col] != 0) currRow[col] += prevRow[col];
                }

                int[] sortedRow = (int[])currRow.Clone();
                Array.Sort(sortedRow);
                for (int i = 0; i < n; i++)
                {
                    ans = Math.Max(ans, sortedRow[i] * (n - i));
                }

                prevRow = currRow;
            }

            return ans;
        }

        private static int RftLargestSubmatrix2(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            List<(int, int)> prevHeights = [];
            int ans = 0;

            for (int row = 0; row < m; row++)
            {
                List<(int, int)> heights = [];
                bool[] seen = new bool[n];

                foreach ((int, int) pair in prevHeights)
                {
                    int height = pair.Item1;
                    int col = pair.Item2;
                    if (matrix[row][col] == 1)
                    {
                        heights.Add((height + 1, col));
                        seen[col] = true;
                    }
                }

                for (int col = 0; col < n; col++)
                {
                    if (seen[col] == false && matrix[row][col] == 1) heights.Add((1, col));
                }

                for (int i = 0; i < heights.Count; i++)
                {
                    ans = Math.Max(ans, heights[i].Item1 * (i + 1));
                }

                prevHeights = heights;
            }

            return ans;
        }
    }
}
