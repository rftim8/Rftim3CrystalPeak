namespace Rftim3LeetCode.Temp
{
    public class _02760_LongestEvenOddSubarrayWithThreshold
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums and an integer threshold.
        /// Find the length of the longest subarray of nums starting at index l and ending at index r(0 <= l <= r<nums.length) that satisfies the following conditions:
        /// nums[l] % 2 == 0
        /// For all indices i in the range[l, r - 1], nums[i] % 2 != nums[i + 1] % 2
        /// For all indices i in the range[l, r], nums[i] <= threshold
        /// Return an integer denoting the length of the longest such subarray.
        /// Note: A subarray is a contiguous non-empty sequence of elements within an array.
        /// </summary>
        public _02760_LongestEvenOddSubarrayWithThreshold()
        {
            Console.WriteLine(LongestAlternatingSubarray([3, 2, 5, 4], 5));
            Console.WriteLine(LongestAlternatingSubarray([1, 2], 2));
            Console.WriteLine(LongestAlternatingSubarray([2, 3, 4, 5], 4));
        }

        private static int LongestAlternatingSubarray(int[] nums, int threshold)
        {
            int n = nums.Length;

            int r = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] % 2 == 0 && nums[i] <= threshold)
                {
                    int c = 1;
                    for (int j = i; j < n - 1; j++)
                    {
                        if (nums[j] % 2 != nums[j + 1] % 2 && nums[j + 1] <= threshold) c++;
                        else break;
                    }
                    r = Math.Max(r, c);
                }
            }

            return r;
        }
    }
}
