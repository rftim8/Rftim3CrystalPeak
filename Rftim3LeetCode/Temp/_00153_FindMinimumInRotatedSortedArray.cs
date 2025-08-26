namespace Rftim3LeetCode.Temp
{
    public class _00153_FindMinimumInRotatedSortedArray
    {
        /// <summary>
        /// Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,2,4,5,6,7] might become:
        /// [4,5,6,7,0,1,2] if it was rotated 4 times.
        /// [0, 1, 2, 4, 5, 6, 7] if it was rotated 7 times.
        /// Notice that rotating an array[a[0], a[1], a[2], ..., a[n - 1]] 1 time results in the array[a[n - 1], a[0], a[1], a[2], ..., a[n - 2]].
        /// Given the sorted rotated array nums of unique elements, return the minimum element of this array.
        /// You must write an algorithm that runs in O(log n) time.
        /// </summary>
        public _00153_FindMinimumInRotatedSortedArray()
        {
            Console.WriteLine(FindMinimumInRotatedSortedArray0([3, 4, 5, 1, 2]));
            Console.WriteLine(FindMinimumInRotatedSortedArray0([4, 5, 6, 7, 0, 1, 2]));
            Console.WriteLine(FindMinimumInRotatedSortedArray0([11, 13, 15, 17]));
            Console.WriteLine(FindMinimumInRotatedSortedArray0([2, 3, 4, 5, 1]));
        }

        public static int FindMinimumInRotatedSortedArray0(int[] a0) => RftFindMinimumInRotatedSortedArray0(a0);

        public static int FindMinimumInRotatedSortedArray1(int[] a0) => RftFindMinimumInRotatedSortedArray1(a0);

        private static int RftFindMinimumInRotatedSortedArray0(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return nums[0];

            int l = 0;
            int r = n - 1;
            if (nums[r] > nums[0]) return nums[0];

            int mid = (l + r) / 2;

            while (l < r)
            {
                if (nums[mid] > nums[mid + 1]) return nums[mid + 1];
                if (nums[mid - 1] > nums[mid]) return nums[mid];

                if (nums[mid] > nums[0]) l = mid + 1;
                else r = mid - 1;

                mid = (l + r) / 2;
            }

            return nums[mid];
        }

        private static int RftFindMinimumInRotatedSortedArray1(int[] nums)
        {
            int l = 0;
            int r = nums.Length - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (nums[l] <= nums[r]) return nums[l];
                if (nums[mid] < nums[l]) r = mid;
                else l = mid + 1;
            }

            return l;
        }
    }
}