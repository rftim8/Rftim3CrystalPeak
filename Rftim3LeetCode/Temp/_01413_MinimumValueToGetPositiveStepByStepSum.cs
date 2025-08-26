namespace Rftim3LeetCode.Temp
{
    public class _01413_MinimumValueToGetPositiveStepByStepSum
    {
        /// <summary>
        /// Given an array of integers nums, you start with an initial positive value startValue.
        /// In each iteration, you calculate the step by step sum of startValue plus elements in nums(from left to right).
        /// Return the minimum positive value of startValue such that the step by step sum is never less than 1.
        /// </summary>
        public _01413_MinimumValueToGetPositiveStepByStepSum()
        {
            Console.WriteLine(MinStartValue([-3, 2, -3, 4, 2]));
            Console.WriteLine(MinStartValue([1, 2]));
            Console.WriteLine(MinStartValue([1, -2, -3]));
            Console.WriteLine(MinStartValue([-22, -29, -21, 0, -4, -26, 10, -11, -14, -11]));
        }

        private static int MinStartValue(int[] nums)
        {
            int i = 1;
            while (true)
            {
                int c = i;
                HashSet<int> r = [];
                for (int j = 0; j < nums.Length; j++)
                {
                    c += nums[j];
                    r.Add(c);
                    if (c < 1) break;
                }
                if (r.Min() >= 1) return i;

                i++;
            }
        }

        private static int MinStartValue0(int[] nums)
        {
            int r = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = nums[i] + nums[i - 1];
                r = Math.Min(r, nums[i]);
            }

            if (r >= 0) return 1;

            return -1 * r + 1;
        }
    }
}
