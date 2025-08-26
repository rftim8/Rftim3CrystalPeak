namespace Rftim3LeetCode.Temp
{
    public class _00704_BinarySearch
    {
        /// <summary>
        /// Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. 
        /// If target exists, then return its index. Otherwise, return -1.
        /// You must write an algorithm with O(log n) runtime complexity.
        /// </summary>
        public _00704_BinarySearch()
        {
            Console.WriteLine(Search([-1, 0, 3, 5, 9, 12], 9));
            Console.WriteLine(BinarySearch0([-1, 0, 3, 5, 9, 12], 9));
        }

        private static int Search(int[] nums, int target)
        {
            int r = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target) return i;
            }

            return r;
        }

        private static int BinarySearch0(int[] nums, int target)
        {
            int i = 0;
            int j = nums.Length - 1;
            while (i <= j)
            {
                int mid = (j - i) / 2 + i;
                if (nums[mid] == target) return mid;
                else if (nums[mid] > target) j = mid - 1;
                else i = mid + 1;
            }

            return -1;
        }
    }
}
