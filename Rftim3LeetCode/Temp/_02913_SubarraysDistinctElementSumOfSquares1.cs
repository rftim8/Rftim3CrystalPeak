namespace Rftim3LeetCode.Temp
{
    public class _02913_SubarraysDistinctElementSumOfSquares1
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums.
        /// 
        /// The distinct count of a subarray of nums is defined as:
        /// 
        /// Let nums[i..j] be a subarray of nums consisting of all the indices from i to j such that 0 <= i <= j<nums.length.
        /// Then the number of distinct values in nums[i..j] is called the distinct count of nums[i..j].
        /// Return the sum of the squares of distinct counts of all subarrays of nums.
        /// 
        /// A subarray is a contiguous non-empty sequence of elements within an array.
        /// </summary>
        public _02913_SubarraysDistinctElementSumOfSquares1()
        {
            Console.WriteLine(SumCounts0([1, 2, 1]));
            Console.WriteLine(SumCounts0([1, 1]));
        }

        public static int SumCounts0(IList<int> a0) => RftSumCounts0(a0);

        public static int SumCounts1(IList<int> a0) => RftSumCounts1(a0);

        private static int RftSumCounts0(IList<int> nums)
        {
            int n = nums.Count;
            int r = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= n - i; j++)
                {
                    HashSet<int> t = [];
                    for (int k = j; k < j + i; k++)
                    {
                        t.Add(nums[k]);
                    }
                    r += t.Count * t.Count;
                }
            }

            return r;
        }

        private static int RftSumCounts1(IList<int> nums)
        {
            int ans = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                HashSet<int> set = [];
                for (int j = i; j < nums.Count; j++)
                {
                    if (!set.Contains(nums[j])) set.Add(nums[j]);

                    ans += set.Count * set.Count;
                }
            }

            return ans;
        }
    }
}
