using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01636_SortArrayByIncreasingFrequency
    {
        /// <summary>
        /// Given an array of integers nums, sort the array in increasing order based on the frequency of the values.
        /// If multiple values have the same frequency, sort them in decreasing order.
        /// Return the sorted array.
        /// </summary>
        public _01636_SortArrayByIncreasingFrequency()
        {
            int[] x = FrequencySort([1, 1, 2, 2, 2, 3]);
            int[] x0 = FrequencySort([2, 3, 1, 3, 2]);
            int[] x1 = FrequencySort([-1, 1, -6, 4, 5, -6, 1, 4, 1]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] FrequencySort(int[] nums)
        {
            int n = nums.Length;
            Dictionary<int, int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (r.TryGetValue(nums[i], out int value)) r[nums[i]] = ++value;
                else r[nums[i]] = 1;
            }

            r = r.OrderBy(o => o.Value).ThenByDescending(o => o.Key).ToDictionary(o => o.Key, o => o.Value);

            int[] x = new int[n];
            int j = 0;
            foreach (KeyValuePair<int, int> item in r)
            {
                for (int i = 0; i < item.Value; i++, j++)
                {
                    x[j] = item.Key;
                }
            }

            return x;
        }

        private static int[] FrequencySort0(int[] nums)
        {
            return nums
                .GroupBy(num => num)
                .OrderBy(group => group.Count())
                .ThenByDescending(group => group.Key)
                .SelectMany(group => group)
                .ToArray();
        }

        private static int[] FrequencySort1(int[] nums)
        {
            Dictionary<int, int> freqMap = [];

            foreach (int num in nums)
            {
                if (!freqMap.TryAdd(num, 1)) freqMap[num]++;
            }

            Array.Sort(nums, (a, b) =>
            {
                int diff = freqMap[a] - freqMap[b];

                if (diff == 0) return b - a;

                return diff;
            });

            return nums;
        }
    }
}
