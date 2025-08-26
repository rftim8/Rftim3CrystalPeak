namespace Rftim3LeetCode.Temp
{
    public class _00220_ContainsDuplicateIII
    {
        /// <summary>
        /// You are given an integer array nums and two integers indexDiff and valueDiff.
        /// 
        /// Find a pair of indices(i, j) such that:
        /// 
        /// i != j,
        /// abs(i - j) <= indexDiff.
        /// abs(nums[i] - nums[j]) <= valueDiff, and
        /// Return true if such pair exists or false otherwise.
        /// </summary>
        public _00220_ContainsDuplicateIII()
        {
            Console.WriteLine(ContainsDuplicateIII0([1, 2, 3, 1], 3, 0));
            Console.WriteLine(ContainsDuplicateIII0([1, 5, 9, 1, 5, 9], 2, 3));
        }

        public static bool ContainsDuplicateIII0(int[] a0, int a1, int a2) => RftContainsDuplicateIII0(a0, a1, a2);

        public static bool ContainsDuplicateIII1(int[] a0, int a1, int a2) => RftContainsDuplicateIII1(a0, a1, a2);

        private static bool RftContainsDuplicateIII0(int[] nums, int indexDiff, int valueDiff)
        {
            if (valueDiff < 0) return false;

            Dictionary<long, long> d = [];
            long w = (long)valueDiff + 1;
            for (int i = 0; i < nums.Length; ++i)
            {
                long m = GetID(nums[i], w);
                if (d.ContainsKey(m)) return true;
                if (d.ContainsKey(m - 1) && Math.Abs(nums[i] - d[m - 1]) < w) return true;
                if (d.ContainsKey(m + 1) && Math.Abs(nums[i] - d[m + 1]) < w) return true;

                d.Add(m, nums[i]);
                if (i >= indexDiff) d.Remove(GetID(nums[i - indexDiff], w));
            }

            return false;
        }

        private static long GetID(long x, long w) => x < 0 ? (x + 1) / w - 1 : x / w;

        private static bool RftContainsDuplicateIII1(int[] nums, int indexDiff, int valueDiff)
        {
            Dictionary<int, List<int>> valuesByOriginalIndex = [];
            for (int i = 0; i < nums.Length; i++)
            {
                if (valuesByOriginalIndex.TryGetValue(nums[i], out List<int>? value))
                {
                    value.Add(i);
                    continue;
                }

                valuesByOriginalIndex.Add(nums[i], []);
                valuesByOriginalIndex[nums[i]].Add(i);
            }

            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (Math.Abs(nums[i] - nums[j]) <= valueDiff)
                    {
                        foreach (int val1 in valuesByOriginalIndex[nums[i]])
                        {
                            foreach (int val2 in valuesByOriginalIndex[nums[j]])
                            {
                                if (val1 != val2 && Math.Abs(val1 - val2) <= indexDiff) return true;
                            }
                        }
                    }
                    else break;
                }


                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (Math.Abs(nums[i] - nums[j]) <= valueDiff)
                    {
                        foreach (int val1 in valuesByOriginalIndex[nums[i]])
                        {

                            foreach (int val2 in valuesByOriginalIndex[nums[j]])
                            {
                                if (val1 != val2 && Math.Abs(val1 - val2) <= indexDiff) return true;
                            }
                        }
                    }
                    else break;
                }
            }

            return false;
        }
    }
}
