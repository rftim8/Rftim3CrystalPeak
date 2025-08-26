namespace Rftim3LeetCode.Temp
{
    public class _00215_KthLargestElementInAnArray
    {
        /// <summary>
        /// Given an integer array nums and an integer k, return the kth largest element in the array.
        /// Note that it is the kth largest element in the sorted order, not the kth distinct element.
        /// You must solve it in O(n) time complexity.
        /// </summary>
        public _00215_KthLargestElementInAnArray()
        {
            Console.WriteLine(KthLargestElementInAnArray0([3, 2, 1, 5, 6, 4], 2));
            Console.WriteLine(KthLargestElementInAnArray0([3, 2, 3, 1, 2, 4, 5, 5, 6], 4));
        }

        public static int KthLargestElementInAnArray0(int[] a0, int a1) => RftKthLargestElementInAnArray0(a0, a1);

        private static int RftKthLargestElementInAnArray0(int[] nums, int k)
        {
            Array.Sort(nums);
            int c = nums[^k];

            return c;
        }
    }
}