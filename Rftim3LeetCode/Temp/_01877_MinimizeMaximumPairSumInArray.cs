namespace Rftim3LeetCode.Temp
{
    public class _01877_MinimizeMaximumPairSumInArray
    {
        /// <summary>
        /// The pair sum of a pair (a,b) is equal to a + b. The maximum pair sum is the largest pair sum in a list of pairs.
        /// 
        /// For example, if we have pairs(1,5), (2,3), and(4,4), the maximum pair sum would be max(1+5, 2+3, 4+4) = max(6, 5, 8) = 8.
        /// Given an array nums of even length n, pair up the elements of nums into n / 2 pairs such that:
        /// 
        /// Each element of nums is in exactly one pair, and
        /// The maximum pair sum is minimized.
        /// Return the minimized maximum pair sum after optimally pairing up the elements.
        /// </summary>
        public _01877_MinimizeMaximumPairSumInArray()
        {
            Console.WriteLine(MinPairSum0([3, 5, 2, 3]));
            Console.WriteLine(MinPairSum0([3, 5, 4, 2, 4, 6]));
            Console.WriteLine(MinPairSum0([4, 1, 5, 1, 2, 5, 1, 5, 5, 4]));
        }

        public static int MinPairSum0(int[] a0) => RftMinPairSum0(a0);

        private static int RftMinPairSum0(int[] nums)
        {
            int n = nums.Length / 2;
            Array.Sort(nums);

            int max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                max = Math.Max(max, nums[0 + i] + nums[^(i + 1)]);
            }

            return max;
        }
    }
}
