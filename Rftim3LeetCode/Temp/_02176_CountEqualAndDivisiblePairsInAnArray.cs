namespace Rftim3LeetCode.Temp
{
    public class _02176_CountEqualAndDivisiblePairsInAnArray
    {
        /// <summary>
        /// Given a 0-indexed integer array nums of length n and an integer k, 
        /// return the number of pairs (i, j) where 0 <= i < j < n, 
        /// such that nums[i] == nums[j] and (i * j) is divisible by k.
        /// </summary>
        public _02176_CountEqualAndDivisiblePairsInAnArray()
        {
            Console.WriteLine(CountEqualAndDivisiblePairsInAnArray0([3, 1, 2, 2, 2, 1, 3], 2));
            Console.WriteLine(CountEqualAndDivisiblePairsInAnArray0([1, 2, 3, 4], 1));
        }

        public static int CountEqualAndDivisiblePairsInAnArray0(int[] a0, int a1) => RftCountEqualAndDivisiblePairsInAnArray0(a0, a1);

        private static int RftCountEqualAndDivisiblePairsInAnArray0(int[] nums, int k)
        {
            int n = nums.Length;

            int r = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        if (i * j % k == 0) r++;
                    }
                }
            }

            return r;
        }
    }
}