namespace Rftim3LeetCode.Temp
{
    public class _00026_RemoveDuplicatesFromSortedArray
    {
        /// <summary>
        /// Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. 
        /// The relative order of the elements should be kept the same.
        /// Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums.
        /// More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result.
        /// It does not matter what you leave beyond the first k elements.
        /// Return k after placing the final result in the first k slots of nums.
        /// Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
        /// </summary>
        public _00026_RemoveDuplicatesFromSortedArray()
        {
            Console.WriteLine(RemoveDuplicates0([1, 1, 2]));
            Console.WriteLine(RemoveDuplicates0([0, 0, 1, 1, 1, 2, 2, 3, 3, 4]));
        }

        public static int RemoveDuplicates0(int[] a0) => RftRemoveDuplicates0(a0);

        private static int RftRemoveDuplicates0(int[] nums)
        {
            short n = (short)nums.Length;
            short c = n;

            for (short i = 0; i < n; i++)
            {
                for (short j = 0; j < n; j++)
                {
                    if (i != j && nums[j] != short.MaxValue)
                    {
                        if (nums[i] == nums[j])
                        {
                            nums[i] = short.MaxValue;
                            c--;
                        }
                    }
                }
            }

            Array.Sort(nums);

            return c;
        }
    }
}
