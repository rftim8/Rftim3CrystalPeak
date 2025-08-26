namespace Rftim3LeetCode.Temp
{
    public class _02357_MakeArrayZeroBySubtractingEqualAmounts
    {
        /// <summary>
        /// You are given a non-negative integer array nums. 
        /// In one operation, you must:
        /// Choose a positive integer x such that x is less than or equal to the smallest non-zero element in nums.
        /// Subtract x from every positive element in nums.
        /// Return the minimum number of operations to make every element in nums equal to 0.
        /// </summary>
        public _02357_MakeArrayZeroBySubtractingEqualAmounts()
        {
            Console.WriteLine(MinimumOperations([1, 5, 0, 3, 5]));
            Console.WriteLine(MinimumOperations([0]));
        }

        private static int MinimumOperations(int[] nums)
        {
            int n = nums.Length;

            int c = 0;
            while (nums.Max() != 0)
            {
                int t = nums.Where(o => o != 0).Min();
                for (int i = 0; i < n; i++)
                {
                    if (nums[i] > 0) nums[i] -= t;
                }
                c++;
            }

            return c;
        }

        private static int MinimumOperations0(int[] nums)
        {
            int cnt = 0, min = 0;

            while (min != int.MaxValue)
            {
                int currentMin = int.MaxValue;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                    {
                        nums[i] -= min;
                        if (nums[i] > 0) currentMin = Math.Min(nums[i], currentMin);
                    }
                    continue;
                }
                cnt++;
                min = currentMin;
            }

            return cnt - 1;
        }
    }
}
