namespace Rftim3LeetCode.Temp
{
    public class _00896_MonotonicArray
    {
        /// <summary>
        /// An array is monotonic if it is either monotone increasing or monotone decreasing.
        /// An array nums is monotone increasing if for all i <= j, nums[i] <= nums[j]. 
        /// An array nums is monotone decreasing if for all i <= j, nums[i] >= nums[j].
        /// Given an integer array nums, return true if the given array is monotonic, or false otherwise.
        /// </summary>
        public _00896_MonotonicArray()
        {
            Console.WriteLine(IsMonotonic([1, 2, 2, 3]));
            Console.WriteLine(IsMonotonic([6, 5, 4, 4]));
            Console.WriteLine(IsMonotonic([1, 3, 2]));
        }

        private static bool IsMonotonic(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return true;

            bool m = nums[0] <= nums[^1];

            for (int i = 1; i < n; i++)
            {
                if (nums[i] < nums[i - 1] && m) return false;

                if (nums[i] > nums[i - 1] && !m) return false;
            }

            return true;
        }
    }
}
