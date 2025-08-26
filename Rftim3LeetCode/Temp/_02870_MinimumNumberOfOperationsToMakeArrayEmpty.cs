namespace Rftim3LeetCode.Temp
{
    public class _02870_MinimumNumberOfOperationsToMakeArrayEmpty
    {
        /// <summary>
        /// You are given a 0-indexed array nums consisting of positive integers.
        /// 
        /// There are two types of operations that you can apply on the array any number of times:
        /// 
        /// Choose two elements with equal values and delete them from the array.
        /// Choose three elements with equal values and delete them from the array.
        /// Return the minimum number of operations required to make the array empty, or -1 if it is not possible.
        /// </summary>
        public _02870_MinimumNumberOfOperationsToMakeArrayEmpty()
        {
            Console.WriteLine(MinOperations0([2, 3, 3, 2, 2, 4, 2, 3, 4]));
            Console.WriteLine(MinOperations0([2, 1, 2, 2, 3, 3]));
        }

        public static int MinOperations0(int[] a0) => RftMinOperations0(a0);

        public static int MinOperations1(int[] a0) => RftMinOperations1(a0);

        private static int RftMinOperations0(int[] nums)
        {
            int n = nums.Length;
            int r = 0;

            Dictionary<int, int> kvp = [];
            for (int i = 0; i < n; i++)
            {
                if (!kvp.TryGetValue(nums[i], out int value)) kvp.Add(nums[i], 1);
                else kvp[nums[i]] = ++value;
            }

            foreach (KeyValuePair<int, int> item in kvp)
            {
                if (item.Value == 1) return -1;
                else
                {
                    int t = item.Value % 3;
                    int t0 = item.Value / 3;

                    if (t == 0) r += t0;
                    else if (t == 1) r += t0 - 1 + 2;
                    else if (t == 2) r += t0 + 1;
                }
            }

            return r;
        }

        private static int RftMinOperations1(int[] nums)
        {
            Dictionary<int, int> count = [];
            int N = nums.Length;
            int res = 0;

            for (int i = 0; i < N; i++)
            {
                count.TryGetValue(nums[i], out int cnt);
                count[nums[i]] = cnt + 1;
            }

            foreach (KeyValuePair<int, int> kv in count)
            {
                if (kv.Value == 1) return -1;

                int d = kv.Value / 3;
                int rem = kv.Value % 3;
                res += d + (rem != 0 ? 1 : 0);
            }

            return res;
        }
    }
}
