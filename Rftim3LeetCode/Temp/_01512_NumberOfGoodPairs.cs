namespace Rftim3LeetCode.Temp
{
    public class _01512_NumberOfGoodPairs
    {
        /// <summary>
        /// Given an array of integers nums, return the number of good pairs.
        /// A pair(i, j) is called good if nums[i] == nums[j] and i<j.
        /// </summary>
        public _01512_NumberOfGoodPairs()
        {
            Console.WriteLine(NumIdenticalPairs([1, 2, 3, 1, 1, 3]));
            Console.WriteLine(NumIdenticalPairs([1, 1, 1, 1]));
            Console.WriteLine(NumIdenticalPairs([1, 2, 3]));
        }

        private static int NumIdenticalPairs(int[] nums)
        {
            int n = nums.Length;
            Dictionary<int, int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (r.TryGetValue(nums[i], out int value)) r[nums[i]] = ++value;
                else r[nums[i]] = 1;
            }

            int c = 0;
            foreach (KeyValuePair<int, int> item in r)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    c += i;
                }
            }

            return c;
        }

        private static int NumIdenticalPairs0(int[] nums)
        {
            int n = nums.Length;
            int counter = 0;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[i] == nums[j]) counter++;
                }
            }

            return counter;
        }
    }
}
