namespace Rftim3LeetCode.Temp
{
    public class _02616_MinimizeTheMaximumDifferenceOfPairs
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums and an integer p. 
        /// Find p pairs of indices of nums such that the maximum difference amongst all the pairs is minimized. 
        /// Also, ensure no index appears more than once amongst the p pairs.
        /// Note that for a pair of elements at the index i and j, the difference of this pair is |nums[i] - nums[j]|, where |x| represents the absolute value of x.
        /// Return the minimum maximum difference among all p pairs. 
        /// We define the maximum of an empty set to be zero.
        /// </summary>
        public _02616_MinimizeTheMaximumDifferenceOfPairs()
        {
            Console.WriteLine(MinimizeMax([10, 1, 2, 7, 1, 3], 2));
            Console.WriteLine(MinimizeMax([4, 2, 1, 2], 1));
        }

        // Greedy + BS
        private static int MinimizeMax(int[] nums, int p)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int left = 0, right = nums[n - 1] - nums[0];

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (CountValidPairs(nums, mid) >= p) right = mid;
                else left = mid + 1;
            }

            return left;
        }

        private static int CountValidPairs(int[] nums, int threshold)
        {
            int index = 0, count = 0;

            while (index < nums.Length - 1)
            {
                if (nums[index + 1] - nums[index] <= threshold)
                {
                    count++;
                    index++;
                }
                index++;
            }

            return count;
        }
    }
}
