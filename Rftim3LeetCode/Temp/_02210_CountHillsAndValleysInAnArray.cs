namespace Rftim3LeetCode.Temp
{
    public class _02210_CountHillsAndValleysInAnArray
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums. An index i is part of a hill in nums if the closest non-equal neighbors of i are smaller than nums[i]. 
        /// Similarly, an index i is part of a valley in nums if the closest non-equal neighbors of i are larger than nums[i].
        /// Adjacent indices i and j are part of the same hill or valley if nums[i] == nums[j].
        /// Note that for an index to be part of a hill or valley, it must have a non-equal neighbor on both the left and right of the index.
        /// Return the number of hills and valleys in nums.
        /// </summary>
        public _02210_CountHillsAndValleysInAnArray()
        {
            Console.WriteLine(CountHillValley([2, 4, 1, 1, 6, 5]));
            Console.WriteLine(CountHillValley([6, 6, 5, 5, 4, 1]));
        }

        private static int CountHillValley(int[] nums)
        {
            int result = 0;
            int previous = nums[0];

            for (int i = 1; i < nums.Length - 1; i++)
            {
                int current = nums[i], next = nums[i + 1];

                bool isHill = current < previous && current < next;
                bool isValley = current > previous && current > next;

                if (isHill || isValley)
                {
                    result++;
                    previous = current;
                }
            }

            return result;
        }
    }
}
