namespace Rftim3LeetCode.Temp
{
    public class _02465_NumberOfDistinctAverages
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums of even length.
        /// As long as nums is not empty, you must repetitively:
        /// Find the minimum number in nums and remove it.
        /// Find the maximum number in nums and remove it.
        /// Calculate the average of the two removed numbers.
        /// The average of two numbers a and b is (a + b) / 2.
        /// For example, the average of 2 and 3 is (2 + 3) / 2 = 2.5.
        /// Return the number of distinct averages calculated using the above process.
        /// Note that when there is a tie for a minimum or maximum number, any can be removed.
        /// </summary>
        public _02465_NumberOfDistinctAverages()
        {
            Console.WriteLine(DistinctAverages([4, 1, 4, 0, 3, 5]));
            Console.WriteLine(DistinctAverages([1, 100]));
            Console.WriteLine(DistinctAverages([9, 5, 7, 8, 7, 9, 8, 2, 0, 7]));
        }

        private static int DistinctAverages(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);

            int l = 0, r = n - 1;
            HashSet<float> c = [];
            while (l < r)
            {
                c.Add((nums[l] + nums[r]) / 2f);

                l++;
                r--;
            }

            return c.Count;
        }
    }
}
