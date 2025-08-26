namespace Rftim3LeetCode.Temp
{
    public class _00081_SearchinRotatedSortedArrayII
    {
        /// <summary>
        /// There is an integer array nums sorted in non-decreasing order (not necessarily with distinct values).
        /// Before being passed to your function, nums is rotated at an unknown pivot index 
        /// <para>
        /// k(0 <= k<nums.length) such that the resulting array is [nums[k], nums[k + 1], ..., nums[n - 1], nums[0], nums[1], ..., nums[k - 1]] (0-indexed). 
        /// </para>
        /// For example, [0, 1, 2, 4, 4, 4, 5, 6, 6, 7] might be rotated at pivot index 5 and become[4, 5, 6, 6, 7, 0, 1, 2, 4, 4].
        /// Given the array nums after the rotation and an integer target, return true if target is in nums, or false if it is not in nums.
        /// You must decrease the overall operation steps as much as possible.
        /// </summary>
        public _00081_SearchinRotatedSortedArrayII()
        {

        }

        public static bool SearchinRotatedSortedArrayII0(int[] a0, int a1) => RftSearchinRotatedSortedArrayII0(a0, a1);

        private static bool RftSearchinRotatedSortedArrayII0(int[] nums, int target)
        {
            int n = nums.Length;
            if (n == 0) return false;
            int end = n - 1;
            int start = 0;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                if (nums[mid] == target) return true;

                if (!IsBinarySearchHelpful(nums, start, nums[mid]))
                {
                    start++;
                    continue;
                }

                bool pivotArray = ExistsInFirst(nums, start, nums[mid]);
                bool targetArray = ExistsInFirst(nums, start, target);

                if (pivotArray ^ targetArray)
                {
                    if (pivotArray) start = mid + 1;
                    else end = mid - 1;
                }
                else
                {
                    if (nums[mid] < target) start = mid + 1;
                    else end = mid - 1;
                }
            }

            return false;
        }


        private static bool IsBinarySearchHelpful(int[] arr, int start, int element) => arr[start] != element;

        private static bool ExistsInFirst(int[] arr, int start, int element) => arr[start] <= element;

        // BS0
        private static bool Search0(int[] nums, int target)
        {
            int len = nums.Length;

            int st = 0;
            int end = len - 1;

            return Search0(nums, target, st, end);
        }

        private static bool Search0(int[] nums, int target, int st, int end)
        {
            if (st > end) return false;

            int mid = (end - st) / 2 + st;
            if (nums[mid] == target) return true;
            if (nums[mid] < nums[end])
            {
                if (target > nums[mid] && target <= nums[end]) return Search0(nums, target, mid + 1, end);

                return Search0(nums, target, st, mid - 1);
            }
            else if (nums[mid] > nums[st])
            {
                if (target >= nums[st] && target < nums[mid]) return Search0(nums, target, st, mid - 1);

                return Search0(nums, target, mid + 1, end);
            }

            if (Search0(nums, target, mid + 1, end)) return true;
            return Search0(nums, target, st, mid - 1);
        }
    }
}
