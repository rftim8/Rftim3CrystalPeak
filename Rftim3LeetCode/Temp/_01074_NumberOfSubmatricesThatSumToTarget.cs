namespace Rftim3LeetCode.Temp
{
    public class _01074_NumberOfSubmatricesThatSumToTarget
    {
        /// <summary>
        /// Given a matrix and a target, return the number of non-empty submatrices that sum to target.
        /// 
        /// A submatrix x1, y1, x2, y2 is the set of all cells matrix[x][y] with x1 <= x <= x2 and y1 <= y <= y2.
        /// 
        /// Two submatrices(x1, y1, x2, y2) and(x1', y1', x2', y2') are different if they have some coordinate that is different: 
        /// for example, if x1 != x1'.
        /// </summary>
        public _01074_NumberOfSubmatricesThatSumToTarget()
        {
            Console.WriteLine(NumberOfSubmatricesThatSumToTarget0(
                [[0, 1, 0], [1, 1, 1], [0, 1, 0]],
                0
                ));

            Console.WriteLine(NumberOfSubmatricesThatSumToTarget0(
                [[1, -1], [-1, 1]],
                0
                ));

            Console.WriteLine(NumberOfSubmatricesThatSumToTarget0(
                [[904]],
                0
                ));
        }

        public static int NumberOfSubmatricesThatSumToTarget0(int[][] a0, int a1) => RftNumberOfSubmatricesThatSumToTarget0(a0, a1);

        public static int NumberOfSubmatricesThatSumToTarget1(int[][] a0, int a1) => RftNumberOfSubmatricesThatSumToTarget1(a0, a1);

        // Horizontal 1D prefix sum
        private static int RftNumberOfSubmatricesThatSumToTarget0(int[][] matrix, int target)
        {
            int r = matrix.Length, c = matrix[0].Length;

            int[][] ps = new int[r + 1][];
            for (int i = 0; i < r + 1; i++)
            {
                ps[i] = new int[c + 1];
            }

            for (int i = 1; i < r + 1; ++i)
            {
                for (int j = 1; j < c + 1; ++j)
                {
                    ps[i][j] = ps[i - 1][j] + ps[i][j - 1] - ps[i - 1][j - 1] + matrix[i - 1][j - 1];
                }
            }

            int count = 0, currSum;
            Dictionary<int, int> h = [];
            for (int r1 = 1; r1 < r + 1; ++r1)
            {
                for (int r2 = r1; r2 < r + 1; ++r2)
                {
                    h.Clear();
                    h.Add(0, 1);
                    for (int col = 1; col < c + 1; ++col)
                    {
                        currSum = ps[r2][col] - ps[r1 - 1][col];
                        count += h.GetValueOrDefault(currSum - target, 0);

                        if (h.TryGetValue(currSum, out int value)) h[currSum] = ++value;
                        else h[currSum] = 1;
                    }
                }
            }

            return count;
        }

        // Vertical 1D prefix sum
        private static int RftNumberOfSubmatricesThatSumToTarget1(int[][] matrix, int target)
        {
            int r = matrix.Length, c = matrix[0].Length;

            int[][] ps = new int[r + 1][];
            for (int i = 0; i < r + 1; i++)
            {
                ps[i] = new int[c + 1];
            }

            for (int i = 1; i < r + 1; ++i)
            {
                for (int j = 1; j < c + 1; ++j)
                {
                    ps[i][j] = ps[i - 1][j] + ps[i][j - 1] - ps[i - 1][j - 1] + matrix[i - 1][j - 1];
                }
            }

            int count = 0, currSum;
            Dictionary<int, int> h = [];
            for (int c1 = 1; c1 < c + 1; ++c1)
            {
                for (int c2 = c1; c2 < c + 1; ++c2)
                {
                    h.Clear();
                    h.Add(0, 1);
                    for (int row = 1; row < r + 1; ++row)
                    {
                        currSum = ps[row][c2] - ps[row][c1 - 1];
                        count += h.GetValueOrDefault(currSum - target, 0);

                        if (h.TryGetValue(currSum, out int value)) h[currSum] = ++value;
                        else h[currSum] = 1;
                    }
                }
            }

            return count;
        }
    }
}
