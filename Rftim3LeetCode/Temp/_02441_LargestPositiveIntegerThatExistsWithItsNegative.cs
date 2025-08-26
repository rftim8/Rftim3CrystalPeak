namespace Rftim3LeetCode.Temp
{
    public class _02441_LargestPositiveIntegerThatExistsWithItsNegative
    {
        /// <summary>
        /// Given an integer array nums that does not contain any zeros, find the largest positive integer k such that -k also exists in the array.
        /// Return the positive integer k.If there is no such integer, return -1.
        /// </summary>
        public _02441_LargestPositiveIntegerThatExistsWithItsNegative()
        {
            Console.WriteLine(FindMaxK([-1, 2, -3, 3]));
            Console.WriteLine(FindMaxK([-1, 10, 6, 7, -7, 1]));
            Console.WriteLine(FindMaxK([-10, 8, 6, 7, -2, -3]));
        }

        private static int FindMaxK(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);

            int r = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[i] < 0 && nums[j] > 0) if (nums[i] + nums[j] == 0) r = Math.Max(r, nums[j]);
                }
            }

            return r == int.MinValue ? -1 : r;
        }

        private static int FindMaxK0(int[] nums)
        {
            Dictionary<int, int> positiveNegativePair = [];
            int maxValue = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                int key = Math.Abs(nums[i]);
                if (positiveNegativePair.TryGetValue(key, out int value))
                {
                    if (value + nums[i] == 0) maxValue = Math.Max(maxValue, key);
                }
                else positiveNegativePair.Add(key, nums[i]);
            }

            return maxValue;
        }
    }
}
