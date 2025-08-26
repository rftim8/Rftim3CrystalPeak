namespace Rftim3LeetCode.Temp
{
    public class _01035_UncrossedLines
    {
        /// <summary>
        /// You are given two integer arrays nums1 and nums2. We write the integers of nums1 and nums2 (in the order they are given) on two separate horizontal lines.
        /// We may draw connecting lines: a straight line connecting two numbers nums1[i] and nums2[j] such that:
        /// nums1[i] == nums2[j], and
        /// the line we draw does not intersect any other connecting(non-horizontal) line.
        /// Note that a connecting line cannot intersect even at the endpoints(i.e., each number can only belong to one connecting line).
        /// Return the maximum number of connecting lines we can draw in this way.
        /// </summary>
        public _01035_UncrossedLines()
        {
            Console.WriteLine(MaxUncrossedLines([1, 4, 2], [1, 2, 4]));
            Console.WriteLine(MaxUncrossedLines([2, 5, 1, 2, 5], [10, 5, 2, 1, 5, 2]));
            Console.WriteLine(MaxUncrossedLines([1, 2, 7, 1, 7, 5], [1, 9, 2, 5, 1]));
        }

        private static int MaxUncrossedLines(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;

            int[,] x = new int[n + 1, m + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (nums1[i - 1] == nums2[j - 1]) x[i, j] = 1 + x[i - 1, j - 1];
                    else x[i, j] = Math.Max(x[i, j - 1], x[i - 1, j]);
                }
            }

            return x[n, m];
        }

        private static int MaxUncrossedLines0(int[] nums1, int[] nums2)
        {
            int n1 = nums1.Length;
            int n2 = nums2.Length;

            int[] dp = new int[n2 + 1];
            int[] dpPrev = new int[n2 + 1];

            for (int i = 1; i <= n1; i++)
            {
                for (int j = 1; j <= n2; j++)
                {
                    if (nums1[i - 1] == nums2[j - 1])
                    {
                        dp[j] = 1 + dpPrev[j - 1];
                    }
                    else
                    {
                        dp[j] = Math.Max(dp[j - 1], dpPrev[j]);
                    }
                }
                dpPrev = (int[])dp.Clone();
            }

            return dp[n2];
        }

        private static int Solve(int i, int j, int[] nums1, int[] nums2, int[][] memo)
        {
            if (i <= 0 || j <= 0) return 0;

            if (memo[i][j] != -1) return memo[i][j];

            if (nums1[i - 1] == nums2[j - 1]) memo[i][j] = 1 + Solve(i - 1, j - 1, nums1, nums2, memo);
            else memo[i][j] = Math.Max(Solve(i, j - 1, nums1, nums2, memo), Solve(i - 1, j, nums1, nums2, memo));

            return memo[i][j];
        }

        private static int MaxUncrossedLines1(int[] nums1, int[] nums2)
        {
            int n1 = nums1.Length;
            int n2 = nums2.Length;

            int[][] memo = new int[n1 + 1][];
            for (int i = 0; i < n1 + 1; i++)
            {
                memo[i] = new int[n2 + 1];
            }

            foreach (int[] row in memo)
            {
                Array.Fill(row, -1);
            }

            return Solve(n1, n2, nums1, nums2, memo);
        }
    }
}
