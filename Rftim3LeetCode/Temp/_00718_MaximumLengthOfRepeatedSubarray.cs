namespace Rftim3LeetCode.Temp
{
    public class _00718_MaximumLengthOfRepeatedSubarray
    {
        /// <summary>
        /// Given two integer arrays nums1 and nums2, return the maximum length of a subarray that appears in both arrays.
        /// </summary>
        public _00718_MaximumLengthOfRepeatedSubarray()
        {
            Console.WriteLine(MaximumLengthOfRepeatedSubarray0([1, 2, 3, 2, 1], [3, 2, 1, 4, 7]));
            Console.WriteLine(MaximumLengthOfRepeatedSubarray0([0, 0, 0, 0, 0], [0, 0, 0, 0, 0]));
        }

        public static int MaximumLengthOfRepeatedSubarray0(int[] a0, int[] a1) => RftMaximumLengthOfRepeatedSubarray0(a0, a1);

        public static int MaximumLengthOfRepeatedSubarray1(int[] a0, int[] a1) => RftMaximumLengthOfRepeatedSubarray1(a0, a1);

        // DP
        private static int RftMaximumLengthOfRepeatedSubarray0(int[] nums1, int[] nums2)
        {
            int ans = 0;
            int[][] memo = new int[nums1.Length + 1][];
            for (int i = 0; i < nums1.Length + 1; i++)
            {
                memo[i] = new int[nums2.Length + 1];
            }

            for (int i = nums1.Length - 1; i >= 0; --i)
            {
                for (int j = nums2.Length - 1; j >= 0; --j)
                {
                    if (nums1[i] == nums2[j])
                    {
                        memo[i][j] = memo[i + 1][j + 1] + 1;

                        if (ans < memo[i][j]) ans = memo[i][j];
                    }
                }
            }

            return ans;
        }

        private static int RftMaximumLengthOfRepeatedSubarray1(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            int[] prev = new int[n + 1], curr = new int[n + 1];
            int max = 0;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (nums1[i - 1] == nums2[j - 1])
                    {
                        curr[j] = 1 + prev[j - 1];
                        max = Math.Max(max, curr[j]);
                    }
                    else curr[j] = 0;
                }

                prev = [.. curr];
            }

            return max;
        }
    }
}
