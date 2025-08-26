using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02389_LongestSubsequenceWithLimitedSum
    {
        /// <summary>
        /// You are given an integer array nums of length n, and an integer array queries of length m.
        /// Return an array answer of length m where answer[i] is the maximum size of a subsequence that you can 
        /// take from nums such that the sum of its elements is less than or equal to queries[i].
        /// A subsequence is an array that can be derived from another array by deleting some or no elements without changing the order of the remaining elements.
        /// </summary>
        public _02389_LongestSubsequenceWithLimitedSum()
        {
            int[] x = AnswerQueries([4, 5, 2, 1], [3, 10, 21]);
            RftTerminal.RftReadResult(x);
            int[] x0 = AnswerQueries([2, 3, 4, 5], [1]);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] AnswerQueries(int[] nums, int[] queries)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int m = queries.Length;

            int[] result = new int[m];
            int sum = 0;
            for (int j = 0; j < n; j++)
            {
                sum += nums[j];
                for (int k = 0; k < m; k++)
                {
                    if (sum <= queries[k]) result[k] = j + 1;
                }
            }

            return result;
        }
    }
}
