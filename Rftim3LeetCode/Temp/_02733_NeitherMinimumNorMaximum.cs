namespace Rftim3LeetCode.Temp
{
    public class _02733_NeitherMinimumNorMaximum
    {
        /// <summary>
        /// Given an integer array nums containing distinct positive integers, 
        /// find and return any number from the array that is neither the minimum nor the maximum value in the array, or -1 if there is no such number.
        /// Return the selected integer.
        /// </summary>
        public _02733_NeitherMinimumNorMaximum()
        {
            Console.WriteLine(FindNonMinOrMax([3, 2, 1, 4]));
            Console.WriteLine(FindNonMinOrMax([1, 2]));
            Console.WriteLine(FindNonMinOrMax([2, 1, 3]));
        }

        private static int FindNonMinOrMax(int[] nums)
        {
            int min = nums.Min();
            int max = nums.Max();

            int c = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != min && nums[i] != max) c = Math.Min(c, nums[i]);
            }

            return c == int.MaxValue ? -1 : c;
        }

        private static int FindNonMinOrMax0(int[] nums)
        {
            Array.Sort(nums);
            int min = nums[0];
            int max = nums[^1];

            foreach (int num in nums)
            {
                if (num != min && num != max) return num;
            }

            return -1;
        }
    }
}
