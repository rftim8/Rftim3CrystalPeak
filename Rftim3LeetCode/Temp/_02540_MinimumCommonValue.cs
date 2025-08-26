namespace Rftim3LeetCode.Temp
{
    public class _02540_MinimumCommonValue
    {
        /// <summary>
        /// Given two integer arrays nums1 and nums2, sorted in non-decreasing order, return the minimum integer common to both arrays.
        /// If there is no common integer amongst nums1 and nums2, return -1.
        /// Note that an integer is said to be common to nums1 and nums2 if both arrays have at least one occurrence of that integer.
        /// </summary>
        public _02540_MinimumCommonValue()
        {
            Console.WriteLine(GetCommon([1, 2, 3], [2, 4]));
            Console.WriteLine(GetCommon([1, 2, 3, 6], [2, 3, 4, 5]));
        }

        private static int GetCommon(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (nums1[i] == nums2[j]) return nums1[i];
                    if (nums1[i] < nums2[j]) break;
                }
            }

            return -1;
        }
    }
}
