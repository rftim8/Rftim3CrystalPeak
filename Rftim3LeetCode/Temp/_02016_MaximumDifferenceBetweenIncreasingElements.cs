namespace Rftim3LeetCode.Temp
{
    public class _02016_MaximumDifferenceBetweenIncreasingElements
    {
        /// <summary>
        /// Given a 0-indexed integer array nums of size n, find the maximum difference between nums[i] and nums[j] (i.e., nums[j] - nums[i]), such that 0 <= i < j < n and nums[i] < nums[j].
        /// Return the maximum difference.If no such i and j exists, return -1.
        /// </summary>
        public _02016_MaximumDifferenceBetweenIncreasingElements()
        {
            Console.WriteLine(MaximumDifference([7, 1, 5, 4]));
            Console.WriteLine(MaximumDifference([9, 4, 3, 2]));
            Console.WriteLine(MaximumDifference([1, 5, 2, 10]));
        }

        private static int MaximumDifference(int[] nums)
        {
            int n = nums.Length;

            int r = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[i] < nums[j]) r = Math.Max(r, nums[j] - nums[i]);
                }
            }

            return r;
        }
    }
}
