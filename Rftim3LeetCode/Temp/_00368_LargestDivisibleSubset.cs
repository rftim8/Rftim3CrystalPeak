using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00368_LargestDivisibleSubset
    {
        /// <summary>
        /// Given a set of distinct positive integers nums, return the largest subset answer such that every pair 
        /// (answer[i], answer[j]) of elements in this subset satisfies:
        /// 
        /// answer[i] % answer[j] == 0, or
        /// answer[j] % answer[i] == 0
        /// If there are multiple solutions, return any of them.
        /// </summary>
        public _00368_LargestDivisibleSubset()
        {
            IList<int> a0 = LargestDivisibleSubset0([1, 2, 3]);
            RftTerminal.RftReadResult(a0); // [1,2]

            IList<int> a1 = LargestDivisibleSubset0([1, 2, 4, 8]);
            RftTerminal.RftReadResult(a1); // [1,2,4,8]
        }

        public static IList<int> LargestDivisibleSubset0(int[] a0) => RftLargestDivisibleSubset0(a0);

        public static IList<int> LargestDivisibleSubset1(int[] a0) => RftLargestDivisibleSubset1(a0);

        public static IList<int> LargestDivisibleSubset2(int[] a0) => RftLargestDivisibleSubset2(a0);

        public static IList<int> LargestDivisibleSubset3(int[] a0) => RftLargestDivisibleSubset3(a0);

        // DP
        private static List<int> RftLargestDivisibleSubset0(int[] nums)
        {
            int n = nums.Length;
            if (n == 0) return [];

            List<List<int>> EDS = [];
            for (int i = 0; i < nums.Length; i++)
            {
                EDS.Add([]);
            }

            Array.Sort(nums);

            for (int i = 0; i < n; ++i)
            {
                List<int> maxSubset = [];

                for (int k = 0; k < i; ++k)
                {
                    if (nums[i] % nums[k] == 0 && maxSubset.Count < EDS[k].Count) maxSubset = [.. EDS[k]];
                }

                EDS[i].AddRange(maxSubset);
                EDS[i].Add(nums[i]);
            }

            List<int> ret = [];
            for (int i = 0; i < n; ++i)
            {
                if (ret.Count < EDS[i].Count) ret = EDS[i];
            }

            return ret;
        }

        // DP Space Optimized
        private static List<int> RftLargestDivisibleSubset1(int[] nums)
        {
            int n = nums.Length;
            if (n == 0) return [];

            int[] dp = new int[n];

            Array.Sort(nums);

            int maxSubsetSize = -1, maxSubsetIndex = -1;

            for (int i = 0; i < n; ++i)
            {
                int subsetSize = 0;

                for (int k = 0; k < i; ++k)
                {
                    if (nums[i] % nums[k] == 0 && subsetSize < dp[k]) subsetSize = dp[k];
                }

                dp[i] = subsetSize + 1;

                if (maxSubsetSize < dp[i])
                {
                    maxSubsetSize = dp[i];
                    maxSubsetIndex = i;
                }
            }

            LinkedList<int> subset = [];
            int currSize = maxSubsetSize;
            int currTail = nums[maxSubsetIndex];
            for (int i = maxSubsetIndex; i >= 0; --i)
            {
                if (currSize == 0) break;

                if (currTail % nums[i] == 0 && currSize == dp[i])
                {
                    subset.AddFirst(nums[i]);
                    currTail = nums[i];
                    currSize -= 1;
                }
            }

            return [.. subset];
        }

        // Recursion With Memoization
        private static Dictionary<int, List<int>>? _eds;
        private static int[]? _nums;

        private static List<int> RftLargestDivisibleSubset2(int[] nums)
        {
            _eds = [];
            _nums = [];

            int n = nums.Length;
            if (n == 0) return [];

            Array.Sort(nums);
            _nums = nums;

            List<int> maxSubset = [];
            for (int i = 0; i < n; ++i)
            {
                List<int> subset = EDS(i);
                if (maxSubset.Count < subset.Count) maxSubset = subset;
            }

            return maxSubset;
        }

        private static List<int> EDS(int i)
        {
            if (_eds!.TryGetValue(i, out List<int>? value)) return value;

            List<int> maxSubset = [];
            for (int k = 0; k < i; ++k)
            {
                if (_nums![i] % _nums[k] == 0)
                {
                    List<int> subset = EDS(k);
                    if (maxSubset.Count < subset.Count) maxSubset = subset;
                }
            }

            List<int> newEntry = [];
            newEntry.AddRange(maxSubset);
            newEntry.Add(_nums![i]);

            _eds.Add(i, newEntry);

            return newEntry;
        }

        private static List<int> RftLargestDivisibleSubset3(int[] nums)
        {
            int size = nums.Length;

            int[] maxDiv = new int[size];
            int[] prev = new int[size];

            Array.Fill(prev, -1);
            Array.Fill(maxDiv, 1);

            Array.Sort(nums);

            int max = -1;
            int index = -1;

            for (int idx = 0; idx < size; idx++)
            {
                for (int j = idx - 1; j >= 0; j--)
                {
                    if (nums[idx] % nums[j] == 0 && maxDiv[j] + 1 > maxDiv[idx])
                    {
                        maxDiv[idx] = maxDiv[j] + 1;
                        prev[idx] = j;
                    }
                }

                if (maxDiv[idx] > max)
                {
                    max = maxDiv[idx];
                    index = idx;
                }
            }

            List<int> result = [];

            while (index != -1)
            {
                result.Insert(0, nums[index]);
                index = prev[index];
            }

            return result;
        }
    }
}
