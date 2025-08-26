namespace Rftim3LeetCode.Temp
{
    public class _00164_MaximumGap
    {
        /// <summary>
        /// Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        /// You must write an algorithm that runs in linear time and uses linear extra space.
        /// </summary>
        public _00164_MaximumGap()
        {
            Console.WriteLine(MaximumGap0(new int[] { 3, 6, 9, 1 }));
        }

        private static int MaximumGap0(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            int c = 0;
            for (int i = 1; i < n; i++)
            {
                int x = nums[i] - nums[i - 1];
                if (x > c) c = x;
            }

            return c;
        }
    }
}
