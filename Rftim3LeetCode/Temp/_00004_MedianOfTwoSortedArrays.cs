namespace Rftim3LeetCode.Temp
{
    public class _00004_MedianOfTwoSortedArrays
    {
        /// <summary>
        /// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
        /// The overall run time complexity should be O(log (m+n)).
        /// </summary>
        public _00004_MedianOfTwoSortedArrays()
        {
            Console.WriteLine(MedianOfTwoSortedArrays0([1, 2], [3]));
            Console.WriteLine(MedianOfTwoSortedArrays0([1, 2], [3, 4]));
        }

        public static double MedianOfTwoSortedArrays0(int[] a0, int[] a1) => RftMedianOfTwoSortedArrays0(a0, a1);

        private static double RftMedianOfTwoSortedArrays0(int[] nums1, int[] nums2)
        {
            int l = nums1.Length + nums2.Length;
            int[] x = new int[l];
            //x = nums1.Concat(nums2).ToArray();
            nums1.CopyTo(x, 0);
            nums2.CopyTo(x, nums1.Length);
            Array.Sort(x);

            double c = l % 2 == 0 ? (double)(x[l / 2 - 1] + x[l / 2]) / 2 : x[l / 2];

            return c;
        }
    }
}
