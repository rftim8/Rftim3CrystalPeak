using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01685_SumOfAbsoluteDifferencesInASortedArray
    {
        /// <summary>
        /// You are given an integer array nums sorted in non-decreasing order.
        /// 
        /// Build and return an integer array result with the same length as nums such that result[i] is equal to the summation of absolute 
        /// differences between nums[i] and all the other elements in the array.
        /// 
        /// In other words, result[i] is equal to sum(|nums[i]-nums[j]|) where 0 <= j<nums.length and j != i (0-indexed).
        /// </summary>
        public _01685_SumOfAbsoluteDifferencesInASortedArray()
        {
            int[] x = GetSumAbsoluteDifferences0([2, 3, 5]);
            RftTerminal.RftReadResult(x);

            int[] x0 = GetSumAbsoluteDifferences0([1, 4, 6, 8, 10]);
            RftTerminal.RftReadResult(x0);
        }

        public static int[] GetSumAbsoluteDifferences0(int[] a0) => RftGetSumAbsoluteDifferences0(a0);

        public static int[] GetSumAbsoluteDifferences1(int[] a0) => RftGetSumAbsoluteDifferences1(a0);

        private static int[] RftGetSumAbsoluteDifferences0(int[] nums)
        {
            int n = nums.Length;
            int[] x = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (i > 0 && i < n - 1 && nums[i] == nums[i - 1]) x[i] = x[i - 1];
                else
                {
                    int c = 0;
                    int l = i - 1, r = i + 1;

                    while (l > -1)
                    {
                        c += Math.Abs(nums[i] - nums[l]);
                        l--;
                    }
                    while (r < n)
                    {
                        c += Math.Abs(nums[i] - nums[r]);
                        r++;
                    }
                    x[i] = c;
                }
            }

            return x;
        }

        private static int[] RftGetSumAbsoluteDifferences1(int[] nums)
        {
            int rightsum = 0, leftSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                leftSum += nums[i];
            }

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                leftSum -= nums[i];
                int right = rightsum - (nums.Length - i - 1) * nums[i];
                int left = i * nums[i] - leftSum;

                rightsum += nums[i];
                nums[i] = left + right;
            }

            return nums;
        }
    }
}
