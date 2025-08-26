namespace Rftim3LeetCode.Temp
{
    public class _02656_MaximumSumWithExactlyKElements
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums and an integer k. 
        /// Your task is to perform the following operation exactly k times in order to maximize your score:
        /// Select an element m from nums.
        /// Remove the selected element m from the array.
        /// Add a new element with a value of m + 1 to the array.
        /// Increase your score by m.
        /// Return the maximum score you can achieve after performing the operation exactly k times.
        /// </summary>
        public _02656_MaximumSumWithExactlyKElements()
        {
            Console.WriteLine(MaximizeSum([1, 2, 3, 4, 5], 3));
            Console.WriteLine(MaximizeSum([5, 5, 5], 2));
        }

        private static int MaximizeSum(int[] nums, int k)
        {
            int n = nums.Max();

            int c = 0;
            for (int i = 0; i < k; i++)
            {
                c += n + i;
            }

            return c;
        }
    }
}
