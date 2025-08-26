namespace Rftim3LeetCode.Temp
{
    public class _01991_FindTheMiddleIndexInArray
    {
        /// <summary>
        /// Given a 0-indexed integer array nums, find the leftmost middleIndex (i.e., the smallest amongst all the possible ones).
        /// A middleIndex is an index where nums[0] + nums[1] + ... + nums[middleIndex - 1] == nums[middleIndex + 1] + nums[middleIndex + 2] + ... + nums[nums.length - 1].
        /// If middleIndex == 0, the left side sum is considered to be 0.
        /// Similarly, if middleIndex == nums.length - 1, the right side sum is considered to be 0.
        /// Return the leftmost middleIndex that satisfies the condition, or -1 if there is no such index.
        /// </summary>
        public _01991_FindTheMiddleIndexInArray()
        {
            Console.WriteLine(FindTheMiddleIndexInArray0([2, 3, -1, 8, 4]));
            Console.WriteLine(FindTheMiddleIndexInArray0([1, -1, 4]));
            Console.WriteLine(FindTheMiddleIndexInArray0([2, 5]));
        }

        public static int FindTheMiddleIndexInArray0(int[] a0) => RftFindTheMiddleIndexInArray0(a0);

        private static int RftFindTheMiddleIndexInArray0(int[] nums)
        {
            int n = nums.Length, x = -1;

            for (int i = 0; i < n; i++)
            {
                int l = nums[..i].Sum(), r = nums[(i + 1)..].Sum();

                if (l == r) return i;
            }

            return x;
        }
    }
}