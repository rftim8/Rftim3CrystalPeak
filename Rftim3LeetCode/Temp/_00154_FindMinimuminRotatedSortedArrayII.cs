namespace Rftim3LeetCode.Temp
{
    public class _00154_FindMinimumInRotatedSortedArrayII
    {
        /// <summary>
        /// Suppose an array of length n sorted in ascending order is rotated between 1 and n times. 
        /// For example, the array nums = [0,1,4,4,5,6,7] might become:
        /// [4,5,6,7,0,1,4] if it was rotated 4 times.
        /// [0, 1, 4, 4, 5, 6, 7] if it was rotated 7 times.
        /// Notice that rotating an array[a[0], a[1], a[2], ..., a[n - 1]] 1 time results in the array[a[n - 1], a[0], a[1], a[2], ..., a[n - 2]].
        /// Given the sorted rotated array nums that may contain duplicates, return the minimum element of this array.
        /// You must decrease the overall operation steps as much as possible.
        /// </summary>
        public _00154_FindMinimumInRotatedSortedArrayII()
        {
            Console.WriteLine(RftFindMinimumInRotatedSortedArrayII0([1, 3, 5]));
            Console.WriteLine(RftFindMinimumInRotatedSortedArrayII0([2, 2, 2, 0, 1]));
        }

        public static int FindMinimumInRotatedSortedArrayII0(int[] a0) => RftFindMinimumInRotatedSortedArrayII0(a0);

        private static int RftFindMinimumInRotatedSortedArrayII0(int[] nums)
        {
            if (nums[^1] > nums[0]) return nums[0];

            int min = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (min > nums[i]) return nums[i];
            }

            return min;
        }
    }
}