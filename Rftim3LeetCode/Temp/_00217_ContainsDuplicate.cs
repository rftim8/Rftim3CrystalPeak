namespace Rftim3LeetCode.Temp
{
    public class _00217_ContainsDuplicate
    {
        /// <summary>
        /// Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
        /// </summary>
        public _00217_ContainsDuplicate()
        {
            Console.WriteLine(ContainsDuplicate0([1, 2, 3, 1]));
            Console.WriteLine(ContainsDuplicate0([1, 2, 3, 4]));
            Console.WriteLine(ContainsDuplicate0([1, 1, 1, 3, 3, 4, 3, 2, 4, 2]));
        }

        public static bool ContainsDuplicate0(int[] a0) => RftContainsDuplicate0(a0);

        private static bool RftContainsDuplicate0(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);

            for (int i = 0; i < n - 1; i++)
            {
                if (nums[i] == nums[i + 1]) return true;
            }

            return false;
        }
    }
}
