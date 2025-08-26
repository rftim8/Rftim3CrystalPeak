namespace Rftim3LeetCode.Temp
{
    public class _02404_MostFrequentEvenElement
    {
        /// <summary>
        /// Given an integer array nums, return the most frequent even element.
        /// If there is a tie, return the smallest one.If there is no such element, return -1.
        /// </summary>
        public _02404_MostFrequentEvenElement()
        {
            Console.WriteLine(MostFrequentEven([0, 1, 2, 2, 4, 4, 1]));
            Console.WriteLine(MostFrequentEven([4, 4, 4, 9, 2, 4]));
            Console.WriteLine(MostFrequentEven([29, 47, 21, 41, 13, 37, 25, 7]));
        }

        private static int MostFrequentEven(int[] nums)
        {
            int n = nums.Length;

            Dictionary<int, int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    if (r.TryGetValue(nums[i], out int value)) r[nums[i]] = ++value;
                    else r[nums[i]] = 1;
                }
            }

            return r.Count > 0 ? r.OrderBy(o => o.Value).ThenBy(o => o.Key).MaxBy(o => o.Value).Key : -1;
        }
    }
}
