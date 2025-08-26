namespace Rftim3LeetCode.Temp
{
    public class _02917_FindTheKOrOfAnArray
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums, and an integer k.
        /// 
        /// The K-or of nums is a non-negative integer that satisfies the following:
        /// 
        /// The ith bit is set in the K-or if and only if there are at least k elements of nums in which bit i is set.
        /// Return the K-or of nums.
        /// 
        /// Note that a bit i is set in x if (2i AND x) == 2i, where AND is the bitwise AND operator.
        /// </summary>
        public _02917_FindTheKOrOfAnArray()
        {
            Console.WriteLine(FindKOr0([7, 12, 9, 8, 9, 15], 4));
            Console.WriteLine(FindKOr0([2, 12, 1, 11, 4, 5], 6));
            Console.WriteLine(FindKOr0([10, 8, 5, 9, 11, 6, 8], 1));
        }

        public static int FindKOr0(int[] a0, int a1) => RftFindKOr0(a0, a1);

        public static int FindKOr1(int[] a0, int a1) => RftFindKOr1(a0, a1);

        private static int RftFindKOr0(int[] nums, int k)
        {
            int n = nums.Length;
            int r = 0;

            Dictionary<int, int> kvp = [];
            for (int i = 0; i < n; i++)
            {
                int t = nums[i];

                int c = 0;
                while (t != 0)
                {
                    if (t % 2 == 1)
                    {
                        if (kvp.TryGetValue(c, out int value)) kvp[c] = ++value;
                        else kvp[c] = 1;
                    }
                    t /= 2;

                    c++;
                }
            }

            foreach (KeyValuePair<int, int> item in kvp)
            {
                if (item.Value >= k) r += (int)Math.Pow(2, item.Key);
            }

            return r;
        }

        private static int RftFindKOr1(int[] nums, int k)
        {
            int[] bits = new int[32];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int position = 0; position < 32; position++)
                {
                    bits[position] += (nums[i] & 1 << position) >> position;
                }
            }

            int result = 0;
            for (int i = 0; i < 32; i++)
            {
                if (bits[i] >= k) result |= 1 << i;
            }

            return result;
        }
    }
}
