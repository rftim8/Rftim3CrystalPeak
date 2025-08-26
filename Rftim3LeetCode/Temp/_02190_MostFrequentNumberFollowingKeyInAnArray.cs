namespace Rftim3LeetCode.Temp
{
    public class _02190_MostFrequentNumberFollowingKeyInAnArray
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums. You are also given an integer key, which is present in nums.
        /// For every unique integer target in nums, count the number of times target immediately follows an occurrence of key in nums.
        /// In other words, count the number of indices i such that:
        /// 0 <= i <= nums.length - 2,
        /// nums[i] == key and,
        /// nums[i + 1] == target.
        /// Return the target with the maximum count.The test cases will be generated such that the target with maximum count is unique.
        /// </summary>
        public _02190_MostFrequentNumberFollowingKeyInAnArray()
        {
            Console.WriteLine(MostFrequent([1, 100, 200, 1, 100], 1));
            Console.WriteLine(MostFrequent([2, 2, 2, 2, 3], 2));
        }

        private static int MostFrequent(int[] nums, int key)
        {
            int n = nums.Length;
            Dictionary<int, int> r = [];

            for (int i = 0; i < n - 1; i++)
            {
                if (nums[i] == key)
                {
                    if (r.ContainsKey(nums[i + 1])) r[nums[i + 1]]++;
                    else r[nums[i + 1]] = 1;
                }
            }

            return r.MaxBy(o => o.Value).Key;
        }
    }
}
