namespace Rftim3LeetCode.Temp
{
    public class _01027_LongestArithmeticSubsequence
    {
        /// <summary>
        /// Given an array nums of integers, return the length of the longest arithmetic subsequence in nums.
        /// Note that:
        /// A subsequence is an array that can be derived from another array by deleting some or no elements without changing the order of the remaining elements.
        /// A sequence seq is arithmetic if seq[i + 1] - seq[i] are all the same value(for 0 <= i<seq.length - 1).
        /// </summary>
        public _01027_LongestArithmeticSubsequence()
        {
            Console.WriteLine(LongestArithSeqLength(new int[] { 3, 6, 9, 12 }));
            Console.WriteLine(LongestArithSeqLength(new int[] { 9, 4, 7, 2, 10 }));
            Console.WriteLine(LongestArithSeqLength(new int[] { 20, 1, 15, 3, 10, 5, 8 }));
        }

        private static int LongestArithSeqLength(int[] nums)
        {
            int maxLength = 0;
            Dictionary<int, int>[] dp = new Dictionary<int, int>[nums.Length];

            for (int right = 0; right < nums.Length; ++right)
            {
                dp[right] = new Dictionary<int, int>();
                for (int left = 0; left < right; ++left)
                {
                    int diff = nums[left] - nums[right];

                    if (!dp[right].ContainsKey(diff)) dp[right].Add(diff, (dp[left].ContainsKey(diff) ? dp[left][diff] : 1) + 1);
                    else dp[right][diff] = (dp[left].ContainsKey(diff) ? dp[left][diff] : 1) + 1;

                    maxLength = Math.Max(maxLength, dp[right][diff]);
                }
            }

            return maxLength;
        }

        private static int LongestArithSeqLength0(int[] nums)
        {
            int[,] dp = new int[nums.Length, 10000];
            int answer = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int diff = nums[i] - nums[j] + 500;
                    dp[i, diff] = dp[j, diff] + 1;
                    answer = Math.Max(answer, dp[i, diff]);
                }
            }

            return answer + 1;
        }
    }
}
