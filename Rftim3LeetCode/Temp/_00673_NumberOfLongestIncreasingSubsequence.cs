namespace Rftim3LeetCode.Temp
{
    public class _00673_NumberOfLongestIncreasingSubsequence
    {
        /// <summary>
        /// Given an integer array nums, return the number of longest increasing subsequences.
        /// Notice that the sequence has to be strictly increasing.
        /// </summary>
        public _00673_NumberOfLongestIncreasingSubsequence()
        {
            Console.WriteLine(FindNumberOfLIS([1, 3, 5, 4, 7]));
            Console.WriteLine(FindNumberOfLIS([2, 2, 2, 2, 2]));
        }

        private static int FindNumberOfLIS(int[] nums)
        {
            int n = nums.Length;
            int[] x = Enumerable.Repeat(1, n).ToArray();
            int[] y = Enumerable.Repeat(1, n).ToArray();

            (int len, int c) = (1, 0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] >= nums[i]) continue;

                    int z = x[j] + 1;

                    if (x[i] < z)
                    {
                        x[i] = z;
                        y[i] = y[j];
                    }
                    else if (x[i] == z) y[i] += y[j];
                }

                len = Math.Max(len, x[i]);
            }

            for (int i = 0; i < n; i++)
            {
                if (x[i] == len) c += y[i];
            }

            return c;
        }

        private static int FindNumberOfLIS0(int[] nums)
        {
            int n = nums.Length;
            int[] dp = new int[n];
            int[] count = new int[n];

            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                count[i] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (dp[j] + 1 > dp[i])
                        {
                            dp[i] = dp[j] + 1;
                            count[i] = count[j];
                        }
                        else if (dp[j] + 1 == dp[i]) count[i] += count[j];
                    }
                }
            }

            int max = dp.Max();
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                if (dp[i] == max) res += count[i];
            }

            return res;
        }

        private static int FindNumberOfLIS1(int[] nums)
        {
            int n = nums.Length;
            if (n == 0) return 0;
            if (n == 1) return 1;

            int max = 1;
            int res = 1;
            (int, int)[] dp = new (int, int)[n];
            dp[0] = (1, 1);

            for (int i = 1; i < n; i++)
            {
                dp[i] = (1, 1);

                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        (int, int) prev = dp[j];
                        int length = prev.Item1;
                        int newLength = length + 1;
                        int count = prev.Item2;

                        if (newLength > dp[i].Item1) dp[i] = (newLength, count);
                        else if (newLength == dp[i].Item1) dp[i] = (newLength, dp[i].Item2 + count);
                    }
                }

                if (dp[i].Item1 > max)
                {
                    max = dp[i].Item1;
                    res = dp[i].Item2;
                }
                else if (dp[i].Item1 == max) res += dp[i].Item2;
            }

            return res;
        }
    }
}
