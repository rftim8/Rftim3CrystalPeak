namespace Rftim3LeetCode.Temp
{
    public class _00918_MaximumSumCircularSubarray
    {
        /// <summary>
        /// Given a circular integer array nums of length n, return the maximum possible sum of a non-empty subarray of nums.
        /// A circular array means the end of the array connects to the beginning of the array.Formally, the next element of nums[i] is nums[(i + 1) % n] 
        /// and the previous element of nums[i] is nums[(i - 1 + n) % n].
        /// A subarray may only include each element of the fixed buffer nums at most once.Formally, for a subarray nums[i], nums[i + 1], ..., nums[j], 
        /// there does not exist i <= k1, k2 <= j with k1 % n == k2 % n.
        /// </summary>
        public _00918_MaximumSumCircularSubarray()
        {
            Console.WriteLine(MaxSubarraySumCircular([1, -2, 3, -2]));
            Console.WriteLine(MaxSubarraySumCircular([5, -3, 5]));
            Console.WriteLine(MaxSubarraySumCircular([-3, -2, -3]));
        }

        private static int MaxSubarraySumCircular(int[] nums)
        {
            int crtMax = 0, crtMin = 0, sum = 0, maxSum = nums[0], minSum = nums[0];

            foreach (int item in nums)
            {
                crtMax = Math.Max(crtMax, 0) + item;
                maxSum = Math.Max(maxSum, crtMax);
                crtMin = Math.Min(crtMin, 0) + item;
                minSum = Math.Min(minSum, crtMin);
                sum += item;
            }

            return sum == minSum ? maxSum : Math.Max(maxSum, sum - minSum);
        }
    }
}
