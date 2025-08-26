namespace Rftim3LeetCode.Temp
{
    public class _01855_MaximumDistanceBetweenAPairOfValues
    {
        /// <summary>
        /// You are given two non-increasing 0-indexed integer arrays nums1​​​​​​ and nums2​​​​​​.
        /// A pair of indices(i, j), where 0 <= i<nums1.length and 0 <= j<nums2.length, is valid if both i <= j and nums1[i] <= nums2[j].
        /// The distance of the pair is j - i​​​​.
        /// Return the maximum distance of any valid pair (i, j). If there are no valid pairs, return 0.
        /// An array arr is non-increasing if arr[i - 1] >= arr[i] for every 1 <= i<arr.length.
        /// </summary>
        public _01855_MaximumDistanceBetweenAPairOfValues()
        {
            Console.WriteLine(MaximumDistanceBetweenAPairOfValues0([55, 30, 5, 4, 2], [100, 20, 10, 10, 5]));
            Console.WriteLine(MaximumDistanceBetweenAPairOfValues0([2, 2, 2], [10, 10, 1]));
            Console.WriteLine(MaximumDistanceBetweenAPairOfValues0([30, 29, 19, 5], [25, 25, 25, 25, 25]));
        }

        public static int MaximumDistanceBetweenAPairOfValues0(int[] a0, int[] a1) => RftMaximumDistanceBetweenAPairOfValues0(a0, a1);

        private static int RftMaximumDistanceBetweenAPairOfValues0(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;
            int x = 0, l = 0, r = 0;

            while (l < n && r < m)
            {
                if (nums1[l] > nums2[r]) l++;
                else
                {
                    x = Math.Max(x, r - l);
                    r++;
                }
            }

            return x;
        }
    }
}