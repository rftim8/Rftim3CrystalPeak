namespace Rftim3LeetCode.Temp
{
    public class _00027_RemoveElement
    {
        /// <summary>
        /// Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The relative order of the elements may be changed.
        /// Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums.
        /// More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result.
        /// It does not matter what you leave beyond the first k elements.
        /// Return k after placing the final result in the first k slots of nums.
        /// Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
        /// </summary>
        public _00027_RemoveElement()
        {
            Console.WriteLine(RemoveElement0([3, 2, 2, 3], 3));
            Console.WriteLine(RemoveElement0([0, 1, 2, 2, 3, 0, 4, 2], 2));
        }

        public static int RemoveElement0(int[] a0, int a1) => RftRemoveElement0(a0, a1);

        private static int RftRemoveElement0(int[] nums, int val)
        {
            int c = nums.Length;
            int r = c;

            for (int i = 0; i < c; i++)
            {
                if (nums[i] == val)
                {
                    r--;
                    nums[i] = 101;
                }
            }

            Array.Sort(nums);

            return r;
        }
    }
}
