namespace Rftim3LeetCode.Temp
{
    public class _01498_NumberOfSubsequencesThatSatisfyTheGivenSumCondition
    {
        /// <summary>
        /// You are given an array of integers nums and an integer target.
        /// Return the number of non-empty subsequences of nums such that the sum of the minimum and maximum element on it is less or equal to target.
        /// Since the answer may be too large, return it modulo 109 + 7.
        /// </summary>
        public _01498_NumberOfSubsequencesThatSatisfyTheGivenSumCondition()
        {
            Console.WriteLine(NumSubseq([3, 5, 6, 7], 9));
            Console.WriteLine(NumSubseq([3, 3, 6, 8], 10));
            Console.WriteLine(NumSubseq([2, 3, 3, 4, 6, 7], 12));
        }

        private static int NumSubseq(int[] nums, int target)
        {
            int n = nums.Length;
            int mod = 1_000_000_007;
            Array.Sort(nums);

            int[] power = new int[n];
            power[0] = 1;
            for (int i = 1; i < n; ++i)
            {
                power[i] = power[i - 1] * 2 % mod;
            }

            int x = 0;
            int l = 0, r = n - 1;

            while (l <= r)
            {
                if (nums[l] + nums[r] <= target)
                {
                    x += power[r - l];
                    x %= mod;
                    l++;
                }
                else r--;
            }

            return x;
        }
    }
}
