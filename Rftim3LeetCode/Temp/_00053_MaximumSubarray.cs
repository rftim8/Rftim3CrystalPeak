namespace Rftim3LeetCode.Temp
{
    public class _00053_MaximumSubarray
    {
        /// <summary>
        /// Given an integer array nums, find the subarray with the largest sum, and return its sum.
        /// </summary>
        public _00053_MaximumSubarray()
        {
            Console.WriteLine(MaximumSubarray0([-2, 1, -3, 4, -1, 2, 1, -5, 4]));
            Console.WriteLine(MaximumSubarray0([1]));
            Console.WriteLine(MaximumSubarray0([5, 4, -1, 7, 8]));
        }

        public static int MaximumSubarray0(int[] a0) => RftMaximumSubarray0(a0);

        private static int RftMaximumSubarray0(int[] nums)
        {
            int n = nums.Length;
            int max = int.MinValue;
            int r = 0;

            for (int i = 0; i < n; i++)
            {
                r += nums[i];

                if (max < r) max = r;
                if (r < 0) r = 0;
            }

            return max;
        }
    }
}
