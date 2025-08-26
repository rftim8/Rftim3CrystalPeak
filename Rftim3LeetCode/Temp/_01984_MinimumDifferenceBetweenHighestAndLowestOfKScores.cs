namespace Rftim3LeetCode.Temp
{
    public class _01984_MinimumDifferenceBetweenHighestAndLowestOfKScores
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums, where nums[i] represents the score of the ith student. 
        /// You are also given an integer k.
        /// Pick the scores of any k students from the array so that the difference between the highest and the lowest of the k scores is minimized.
        /// Return the minimum possible difference.
        /// </summary>
        public _01984_MinimumDifferenceBetweenHighestAndLowestOfKScores()
        {
            Console.WriteLine(MinimumDifference([90], 1));
            Console.WriteLine(MinimumDifference([9, 4, 1, 7], 2));
        }

        private static int MinimumDifference(int[] nums, int k)
        {
            int n = nums.Length;
            if (n < k) return 0;

            Array.Sort(nums);
            int l = 0, r = 0, min = int.MaxValue;

            while (r < n)
            {
                if (r - l + 1 == k)
                {
                    min = Math.Min(min, nums[r] - nums[l]);
                    l++;
                }

                r++;
            }

            return min;
        }

        private static int MinimumDifference0(int[] nums, int k)
        {
            if (k == 1) return 0;
            Array.Sort(nums);
            int result = int.MaxValue;
            for (int i = 0; i < nums.Length - k + 1; i++)
            {
                int temp = nums[i + k - 1] - nums[i];
                if (temp < result) result = temp;
            }

            return result;
        }
    }
}
