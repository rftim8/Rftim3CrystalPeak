namespace Rftim3LeetCode.Temp
{
    public class _01043_PartitionArrayForMaximumSum
    {
        /// <summary>
        /// Given an integer array arr, partition the array into (contiguous) subarrays of length at most k. 
        /// After partitioning, each subarray has their values changed to become the maximum value of that subarray.
        ///
        /// Return the largest sum of the given array after partitioning.
        /// Test cases are generated so that the answer fits in a 32-bit integer.
        /// </summary>
        public _01043_PartitionArrayForMaximumSum()
        {
            Console.WriteLine(PartitionArrayForMaximumSum0([1, 15, 7, 9, 2, 5, 10], 3));
            Console.WriteLine(PartitionArrayForMaximumSum0([1, 4, 1, 5, 7, 3, 6, 1, 9, 9, 3], 4));
            Console.WriteLine(PartitionArrayForMaximumSum0([1], 1));
        }

        public static int PartitionArrayForMaximumSum0(int[] a0, int a1) => RftPartitionArrayForMaximumSum0(a0, a1);

        public static int PartitionArrayForMaximumSum1(int[] a0, int a1) => RftPartitionArrayForMaximumSum1(a0, a1);

        public static int PartitionArrayForMaximumSum2(int[] a0, int a1) => RftPartitionArrayForMaximumSum2(a0, a1);

        public static int PartitionArrayForMaximumSum3(int[] a0, int a1) => RftPartitionArrayForMaximumSum3(a0, a1);

        // Top-Down DP
        private static int RftPartitionArrayForMaximumSum0(int[] arr, int k)
        {
            int[] dp = new int[arr.Length];
            Array.Fill(dp, -1);

            return MaxSum(arr, k, dp, 0);
        }

        private static int MaxSum(int[] arr, int k, int[] dp, int start)
        {
            int n = arr.Length;

            if (start >= n) return 0;
            if (dp[start] != -1) return dp[start];

            int currMax = 0, ans = 0;
            int end = Math.Min(n, start + k);
            for (int i = start; i < end; i++)
            {
                currMax = Math.Max(currMax, arr[i]);
                ans = Math.Max(ans, currMax * (i - start + 1) + MaxSum(arr, k, dp, i + 1));
            }

            return dp[start] = ans;
        }

        // Bottom-Up DP
        private static int RftPartitionArrayForMaximumSum1(int[] arr, int k)
        {
            int n = arr.Length;

            int[] dp = new int[n + 1];
            Array.Fill(dp, 0);

            for (int start = n - 1; start >= 0; start--)
            {
                int currMax = 0;
                int end = Math.Min(n, start + k);

                for (int i = start; i < end; i++)
                {
                    currMax = Math.Max(currMax, arr[i]);
                    dp[start] = Math.Max(dp[start], dp[i + 1] + currMax * (i - start + 1));
                }
            }

            return dp[0];
        }

        // Bottom-Up Optimised
        private static int RftPartitionArrayForMaximumSum2(int[] arr, int k)
        {
            int n = arr.Length;
            int m = k + 1;

            int[] dp = new int[m];
            Array.Fill(dp, 0);

            for (int start = n - 1; start >= 0; start--)
            {
                int currMax = 0;
                int end = Math.Min(n, start + k);

                for (int i = start; i < end; i++)
                {
                    currMax = Math.Max(currMax, arr[i]);
                    dp[start % m] = Math.Max(dp[start % m], dp[(i + 1) % m] + currMax * (i - start + 1));
                }
            }

            return dp[0];
        }

        private static int RftPartitionArrayForMaximumSum3(int[] arr, int k)
        {
            int n = arr.Length;
            int[] dp = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                int max = 0;
                for (int j = 1; j <= k && j <= i; j++)
                {
                    max = Math.Max(max, arr[i - j]);
                    dp[i] = Math.Max(dp[i], dp[i - j] + max * j);
                }
            }

            return dp[n];
        }
    }
}