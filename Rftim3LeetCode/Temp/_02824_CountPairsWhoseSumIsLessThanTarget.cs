namespace Rftim3LeetCode.Temp
{
    public class _02824_CountPairsWhoseSumIsLessThanTarget
    {
        /// <summary>
        /// Given a 0-indexed integer array nums of length n and an integer target, return the number of pairs (i, j) 
        /// where 0 <= i < j < n and nums[i] + nums[j] < target.
        /// </summary>
        public _02824_CountPairsWhoseSumIsLessThanTarget()
        {
            Console.WriteLine(CountPairs([-1, 1, 2, 3, 1], 2));
            Console.WriteLine(CountPairs([-6, 2, 5, -2, -7, -1, 3], -2));
        }

        private static int CountPairs(IList<int> nums, int target)
        {
            int n = nums.Count;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[i] + nums[j] < target) c++;
                }
            }

            return c;
        }
    }
}
