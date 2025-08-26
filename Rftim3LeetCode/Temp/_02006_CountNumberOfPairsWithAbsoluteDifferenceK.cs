namespace Rftim3LeetCode.Temp
{
    public class _02006_CountNumberOfPairsWithAbsoluteDifferenceK
    {
        /// <summary>
        /// Given an integer array nums and an integer k, return the number of pairs (i, j) where i < j such that |nums[i] - nums[j]| == k.
        /// The value of |x| is defined as:
        /// x if x >= 0.
        /// -x if x< 0.
        /// </summary>
        public _02006_CountNumberOfPairsWithAbsoluteDifferenceK()
        {
            Console.WriteLine(CountKDifference([1, 2, 2, 1], 1));
            Console.WriteLine(CountKDifference([1, 3], 3));
            Console.WriteLine(CountKDifference([3, 2, 1, 5, 4], 2));
        }

        private static int CountKDifference(int[] nums, int k)
        {
            int n = nums.Length;

            int r = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (Math.Abs(nums[i] - nums[j]) == k) r++;
                }
            }

            return r;
        }
    }
}
