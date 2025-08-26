using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02090_KRadiusSubarrayAverages
    {
        /// <summary>
        /// You are given a 0-indexed array nums of n integers, and an integer k.
        /// The k-radius average for a subarray of nums centered at some index i with the radius k is the average of all elements in nums between the indices i - k and i + k(inclusive). 
        /// If there are less than k elements before or after the index i, then the k-radius average is -1.
        /// Build and return an array avgs of length n where avgs[i] is the k-radius average for the subarray centered at index i.
        /// The average of x elements is the sum of the x elements divided by x, using integer division.
        /// The integer division truncates toward zero, which means losing its fractional part.
        /// For example, the average of four elements 2, 3, 1, and 5 is (2 + 3 + 1 + 5) / 4 = 11 / 4 = 2.75, which truncates to 2.
        /// </summary>
        public _02090_KRadiusSubarrayAverages()
        {
            int[] x0 = GetAverages([7, 4, 3, 9, 1, 8, 5, 2, 6], 3);
            int[] x1 = GetAverages([100000], 0);
            int[] x2 = GetAverages([8], 100000);

            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
            RftTerminal.RftReadResult(x2);
        }

        private static int[] GetAverages(int[] nums, int k)
        {
            int n = nums.Length;
            int d = k * 2 + 1;
            int[] x = new int[n];

            bool first = true;
            long c = 0;
            for (int i = 0; i < n; i++)
            {
                if (i < k || i + k >= n) x[i] = -1;
                else
                {
                    if (first)
                    {
                        int j = i - k, m = i + k + 1;
                        while (j < m)
                        {
                            c += nums[j];
                            j++;
                        }
                        x[i] = (int)(c / d);
                        first = false;
                    }
                    else
                    {
                        c += nums[i + k] - nums[i - k - 1];
                        x[i] = (int)(c / d);
                    }
                }
            }

            return x;
        }

        // TLE
        private static int[] GetAverages0(int[] nums, int k)
        {
            int n = nums.Length;
            int[] x = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (i < k || i + k >= n) x[i] = -1;
                else x[i] = nums[(i - k)..(i + k + 1)].Sum() / (k * 2 + 1);
            }

            return x;
        }
    }
}
