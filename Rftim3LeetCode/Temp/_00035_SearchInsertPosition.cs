namespace Rftim3LeetCode.Temp
{
    public class _00035_SearchInsertPosition
    {
        /// <summary>
        /// Given a sorted array of distinct integers and a target value, return the index if the target is found. 
        /// If not, return the index where it would be if it were inserted in order.
        /// You must write an algorithm with O(log n) runtime complexity.
        /// </summary>
        public _00035_SearchInsertPosition()
        {
            Console.WriteLine(SearchInsertPosition0([1, 3, 5, 6], 5));
            Console.WriteLine(SearchInsertPosition0([1, 3, 5, 6], 2));
            Console.WriteLine(SearchInsertPosition0([1, 3, 5, 6], 7));
            Console.WriteLine(SearchInsertPosition0([1, 3], 2));
        }

        public static int SearchInsertPosition0(int[] a0, int a1) => RftSearchInsertPosition0(a0, a1);

        private static int RftSearchInsertPosition0(int[] nums, int target)
        {
            if (nums is null || nums.Length == 0) return -1;
            if (target < nums[0]) return 0;

            int left = 0, right = nums.Length - 1;
            int mid = 0;

            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (nums[mid] == target) return mid;
                else if (nums[mid] < target) left = mid + 1;
                else right = mid - 1;
            }

            if (nums[mid] < target) return mid + 1;
            else return mid;
        }
    }
}
