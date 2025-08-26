namespace Rftim3LeetCode.Temp
{
    public class _02605_FormSmallestNumberFromTwoDigitArrays
    {
        /// <summary>
        /// Given two arrays of unique digits nums1 and nums2, return the smallest number that contains at least one digit from each array.
        /// </summary>
        public _02605_FormSmallestNumberFromTwoDigitArrays()
        {
            Console.WriteLine(MinNumber([4, 1, 3], [5, 7]));
            Console.WriteLine(MinNumber([3, 5, 2, 6], [3, 1, 7]));
        }

        private static int MinNumber(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;

            Array.Sort(nums1);
            Array.Sort(nums2);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (nums1[i] == nums2[j]) return nums1[i];
                }
            }

            return nums1[0] < nums2[0] ? int.Parse($"{nums1[0]}{nums2[0]}") : int.Parse($"{nums2[0]}{nums1[0]}");
        }
    }
}
