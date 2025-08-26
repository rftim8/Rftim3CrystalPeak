namespace Rftim3LeetCode.Temp
{
    public class _03005_CountElementsWithMaximumFrequency
    {
        /// <summary>
        /// You are given an array nums consisting of positive integers.
        /// 
        /// Return the total frequencies of elements in nums such that those elements all have the maximum frequency.
        /// 
        /// The frequency of an element is the number of occurrences of that element in the array.
        /// </summary>
        public _03005_CountElementsWithMaximumFrequency()
        {
            Console.WriteLine(CountElementsWithMaximumFrequency0([1, 2, 2, 3, 1, 4]));
            Console.WriteLine(CountElementsWithMaximumFrequency0([1, 2, 3, 4, 5]));
        }

        public static int CountElementsWithMaximumFrequency0(int[] a0) => RftCountElementsWithMaximumFrequency0(a0);

        private static int RftCountElementsWithMaximumFrequency0(int[] nums)
        {
            int n = nums.Length;

            int c = 0;
            Dictionary<int, int> kvp = [];
            for (int i = 0; i < n; i++)
            {
                if (kvp.TryGetValue(nums[i], out int value)) kvp[nums[i]] = ++value;
                else kvp[nums[i]] = 1;

                if (kvp[nums[i]] > c) c = kvp[nums[i]];
            }

            return kvp.Where(o => o.Value == c).Count() * c;
        }
    }
}
