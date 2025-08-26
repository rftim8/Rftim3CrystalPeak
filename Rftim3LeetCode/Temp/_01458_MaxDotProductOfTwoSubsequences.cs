namespace Rftim3LeetCode.Temp
{
    public class _01458_MaxDotProductOfTwoSubsequences
    {
        /// <summary>
        /// Given two arrays nums1 and nums2.
        /// Return the maximum dot product between non-empty subsequences of nums1 and nums2 with the same length.
        /// A subsequence of a array is a new array which is formed from the original array by deleting some(can be none) 
        /// of the characters without disturbing the relative positions of the remaining characters. 
        /// (ie, [2,3,5] is a subsequence of[1, 2, 3, 4, 5] while [1,5,3] is not).
        /// </summary>
        public _01458_MaxDotProductOfTwoSubsequences()
        {
            Console.WriteLine(
                MaxDotProduct(
                    [2, 1, -2, 5],
                    [3, 0, -6]
                )
            );
            Console.WriteLine(
                MaxDotProduct(
                    [3, -2],
                    [2, -6, 7]
                )
            );
            Console.WriteLine(
                MaxDotProduct(
                    [-1, -1],
                    [1, 1]
                )
            );
        }

        // Bottom-Up DP
        private static int MaxDotProduct(int[] nums1, int[] nums2)
        {
            int firstMax = int.MinValue;
            int secondMax = int.MinValue;
            int firstMin = int.MaxValue;
            int secondMin = int.MaxValue;

            foreach (int num in nums1)
            {
                firstMax = Math.Max(firstMax, num);
                firstMin = Math.Min(firstMin, num);
            }

            foreach (int num in nums2)
            {
                secondMax = Math.Max(secondMax, num);
                secondMin = Math.Min(secondMin, num);
            }

            if (firstMax < 0 && secondMin > 0) return firstMax * secondMin;

            if (firstMin > 0 && secondMax < 0) return firstMin * secondMax;

            int[][] dp = new int[nums1.Length + 1][];

            for (int i = 0; i < nums1.Length + 1; i++)
            {
                dp[i] = new int[nums2.Length + 1];
            }

            for (int i = nums1.Length - 1; i >= 0; i--)
            {
                for (int j = nums2.Length - 1; j >= 0; j--)
                {
                    int use = nums1[i] * nums2[j] + dp[i + 1][j + 1];
                    dp[i][j] = Math.Max(use, Math.Max(dp[i + 1][j], dp[i][j + 1]));
                }
            }

            return dp[0][0];
        }

        // Bottom-Up DP space optimized
        private static int MaxDotProduct0(int[] nums1, int[] nums2)
        {
            int firstMax = int.MinValue;
            int secondMax = int.MinValue;
            int firstMin = int.MaxValue;
            int secondMin = int.MaxValue;

            foreach (int num in nums1)
            {
                firstMax = Math.Max(firstMax, num);
                firstMin = Math.Min(firstMin, num);
            }

            foreach (int num in nums2)
            {
                secondMax = Math.Max(secondMax, num);
                secondMin = Math.Min(secondMin, num);
            }

            if (firstMax < 0 && secondMin > 0) return firstMax * secondMin;

            if (firstMin > 0 && secondMax < 0) return firstMin * secondMax;

            int m = nums2.Length + 1;
            int[] dp = new int[m];
            int[] prevDp = new int[m];

            for (int i = nums1.Length - 1; i >= 0; i--)
            {
                dp = new int[m];
                for (int j = nums2.Length - 1; j >= 0; j--)
                {
                    int use = nums1[i] * nums2[j] + prevDp[j + 1];
                    dp[j] = Math.Max(use, Math.Max(prevDp[j], dp[j + 1]));
                }

                prevDp = dp;
            }

            return dp[0];
        }

        // Top-Down DP
        private static int[][]? memo;

        private static int MaxDotProduct1(int[] nums1, int[] nums2)
        {
            int firstMax = int.MinValue;
            int secondMax = int.MinValue;
            int firstMin = int.MaxValue;
            int secondMin = int.MaxValue;

            foreach (int num in nums1)
            {
                firstMax = Math.Max(firstMax, num);
                firstMin = Math.Min(firstMin, num);
            }

            foreach (int num in nums2)
            {
                secondMax = Math.Max(secondMax, num);
                secondMin = Math.Min(secondMin, num);
            }

            if (firstMax < 0 && secondMin > 0) return firstMax * secondMin;

            if (firstMin > 0 && secondMax < 0) return firstMin * secondMax;

            memo = new int[nums1.Length][];
            for (int i = 0; i < nums1.Length; i++)
            {
                memo[i] = new int[nums2.Length];
            }

            return Dp(0, 0, nums1, nums2);
        }

        private static int Dp(int i, int j, int[] nums1, int[] nums2)
        {
            if (i == nums1.Length || j == nums2.Length) return 0;

            if (memo![i][j] != 0) return memo[i][j];

            int use = nums1[i] * nums2[j] + Dp(i + 1, j + 1, nums1, nums2);
            memo[i][j] = Math.Max(use, Math.Max(Dp(i + 1, j, nums1, nums2), Dp(i, j + 1, nums1, nums2)));

            return memo[i][j];
        }
    }
}
