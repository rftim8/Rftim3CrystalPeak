using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00088_MergeSortedArray
    {
        /// <summary>
        /// You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
        /// Merge nums1 and nums2 into a single array sorted in non-decreasing order.
        /// The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
        /// </summary>
        public _00088_MergeSortedArray()
        {
            int[] a0 = Merge0([1, 2, 3, 0, 0, 0], 3, [2, 5, 6], 3);
            RftTerminal.RftReadResult(a0);

            int[] a1 = Merge0([1], 1, [], 0);
            RftTerminal.RftReadResult(a1);

            int[] a2 = Merge0([0], 0, [1], 1);
            RftTerminal.RftReadResult(a2);
        }

        public static int[] Merge0(int[] a0, int a1, int[] a2, int a3) => RftMerge0(a0, a1, a2, a3);

        private static int[] RftMerge0(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0; i < n; i++)
            {
                nums1[i + m] = nums2[i];
            }
            int[] x = [.. nums1.OrderBy(o => o)];
            Array.Copy(x, nums1, x.Length);

            return nums1;
        }
    }
}
