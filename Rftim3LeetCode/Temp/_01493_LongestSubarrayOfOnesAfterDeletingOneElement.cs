namespace Rftim3LeetCode.Temp
{
    public class _01493_LongestSubarrayOfOnesAfterDeletingOneElement
    {
        /// <summary>
        /// Given a binary array nums, you should delete one element from it.
        /// Return the size of the longest non-empty subarray containing only 1's in the resulting array. 
        /// Return 0 if there is no such subarray.
        /// </summary>
        public _01493_LongestSubarrayOfOnesAfterDeletingOneElement()
        {
            Console.WriteLine(LongestSubarray([1, 1, 0, 1]));
            Console.WriteLine(LongestSubarray([0, 1, 1, 1, 0, 1, 1, 0, 1]));
            Console.WriteLine(LongestSubarray([1, 1, 1]));
            Console.WriteLine(LongestSubarray([0, 1, 0]));
        }

        private static int LongestSubarray(int[] nums)
        {
            int n = nums.Length;

            int c = 0, r = 0, s = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 0)
                {
                    int j = i > 0 ? i - 1 : i;
                    while (nums[j] != 0)
                    {
                        c++;
                        j--;
                        if (j == -1) break;
                    }
                    j = i < n - 1 ? i + 1 : i;
                    while (nums[j] != 0)
                    {
                        c++;
                        j++;
                        if (j == n) break;
                    }
                    s++;
                    i = i != n - 1 ? j - 1 : j;

                    if (c > r) r = c;
                    c = 0;
                }
            }
            if (s == 0) r = n - 1;

            return r;
        }

        private static int LongestSubarray0(int[] nums)
        {
            int j = 0, i = 0, maxCount = 0, delete = 0;
            while (j < nums.Length)
            {
                if (nums[j] == 0) delete++;

                if (delete > 1)
                {
                    if (nums[i] == 0) delete--;
                    i++;
                }
                if (delete <= 1) maxCount = Math.Max(maxCount, j - i + 1);

                j++;
            }

            return maxCount - 1;
        }
    }
}
