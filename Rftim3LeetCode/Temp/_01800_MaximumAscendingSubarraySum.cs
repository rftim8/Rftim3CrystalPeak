namespace Rftim3LeetCode.Temp
{
    public class _01800_MaximumAscendingSubarraySum
    {
        /// <summary>
        /// Given an array of positive integers nums, return the maximum possible sum of an ascending subarray in nums.
        /// A subarray is defined as a contiguous sequence of numbers in an array.
        /// A subarray[numsl, numsl + 1, ..., numsr - 1, numsr] is ascending if for all i where l <= i<r, numsi<numsi+1. 
        /// Note that a subarray of size 1 is ascending.
        /// </summary>
        public _01800_MaximumAscendingSubarraySum()
        {
            Console.WriteLine(MaxAscendingSum([10, 20, 30, 5, 10, 50]));
            Console.WriteLine(MaxAscendingSum([10, 20, 30, 40, 50]));
            Console.WriteLine(MaxAscendingSum([12, 17, 15, 13, 10, 11, 12]));
        }

        private static int MaxAscendingSum(int[] nums)
        {
            int n = nums.Length;

            int c = nums[0], r = c;
            for (int i = 1; i < n; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    c += nums[i];
                    if (i == n - 1) r = Math.Max(r, c);
                }
                else
                {
                    r = Math.Max(r, c);
                    c = nums[i];
                }
            }

            return r;
        }
    }
}
