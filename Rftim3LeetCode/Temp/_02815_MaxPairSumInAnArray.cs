namespace Rftim3LeetCode.Temp
{
    public class _02815_MaxPairSumInAnArray
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums. 
        /// You have to find the maximum sum of a pair of numbers from nums such that the maximum digit in both numbers are equal.
        /// Return the maximum sum or -1 if no such pair exists.
        /// </summary>
        public _02815_MaxPairSumInAnArray()
        {
            Console.WriteLine(MaxSum([51, 71, 17, 24, 42]));
            Console.WriteLine(MaxSum([1, 2, 3, 4]));
        }

        private static int MaxSum(int[] nums)
        {
            int n = nums.Length;
            int c = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    char l = nums[i].ToString().Max();
                    char r = nums[j].ToString().Max();

                    if (l == r) c = Math.Max(c, nums[i] + nums[j]);
                }
            }

            return c;
        }

        private static int MaxSum0(int[] nums)
        {
            int n = nums.Length;
            int[] maxDigit = new int[n];

            for (int i = 0; i < n; i++)
            {
                int cur = nums[i];
                int max = -1;
                while (cur > 0)
                {
                    max = Math.Max(max, cur % 10);
                    cur /= 10;
                }
                maxDigit[i] = max;
            }

            int res = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (maxDigit[i] == maxDigit[j]) res = Math.Max(res, nums[i] + nums[j]);
                }
            }

            return res;
        }
    }
}
