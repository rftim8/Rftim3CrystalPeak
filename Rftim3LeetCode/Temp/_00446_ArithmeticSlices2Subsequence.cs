namespace Rftim3LeetCode.Temp
{
    public class _00446_ArithmeticSlices2Subsequence
    {
        /// <summary>
        /// Given an integer array nums, return the number of all the arithmetic subsequences of nums.
        /// 
        /// A sequence of numbers is called arithmetic if it consists of at least three elements and if the difference between any two 
        /// consecutive elements is the same.
        /// 
        /// For example, [1, 3, 5, 7, 9], [7, 7, 7, 7], and[3, -1, -5, -9] are arithmetic sequences.
        /// For example, [1, 1, 2, 5, 7] is not an arithmetic sequence.
        /// A subsequence of an array is a sequence that can be formed by removing some elements (possibly none) of the array.
        /// 
        /// For example, [2,5,10] is a subsequence of[1, 2, 1, 2, 4, 1, 5, 10].
        /// The test cases are generated so that the answer fits in 32-bit integer.
        /// </summary>
        public _00446_ArithmeticSlices2Subsequence()
        {
            Console.WriteLine(NumberOfArithmeticSlices0([2, 4, 6, 8, 10]));
            Console.WriteLine(NumberOfArithmeticSlices0([7, 7, 7, 7, 7]));
        }

        public static int NumberOfArithmeticSlices0(int[] a0) => RftNumberOfArithmeticSlices0(a0);

        public static int NumberOfArithmeticSlices1(int[] a0) => RftNumberOfArithmeticSlices1(a0);

        private static int RftNumberOfArithmeticSlices0(int[] nums)
        {
            int total = 0, n = nums.Length;
            Dictionary<long, int>[] map = new Dictionary<long, int>[n];

            for (int i = 0; i < n; i++) map[i] = [];

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    long diff = nums[i] - (long)nums[j];
                    map[j].TryAdd(diff, 0);
                    map[i].TryAdd(diff, 0);
                    map[i][diff] += map[j][diff] + 1;
                    total += map[j][diff];
                }
            }

            return total;
        }

        private static int RftNumberOfArithmeticSlices1(int[] nums)
        {
            if (nums.Length < 3) return 0;

            int total = 0;
            Dictionary<int, int>[] memo = new Dictionary<int, int>[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                memo[i] = [];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    long diffl = nums[i] - (long)nums[j];

                    if (int.MaxValue <= diffl || diffl <= int.MinValue) continue;

                    int diff = (int)diffl;
                    memo[i].TryGetValue(diff, out int counti);
                    memo[j].TryGetValue(diff, out int countj);
                    memo[i][diff] = counti + countj + 1;
                    total += countj;
                }
            }

            return total;
        }
    }
}
