using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01018_BinaryPrefixDivisibleBy5
    {
        /// <summary>
        /// You are given a binary array nums (0-indexed).
        /// We define xi as the number whose binary representation is the subarray nums[0..i] (from most-significant-bit to least-significant-bit).
        /// For example, if nums = [1,0,1], then x0 = 1, x1 = 2, and x2 = 5.
        /// Return an array of booleans answer where answer[i] is true if xi is divisible by 5.
        /// </summary>
        public _01018_BinaryPrefixDivisibleBy5()
        {
            IList<bool> x = PrefixesDivBy5([0, 1, 1]);
            IList<bool> x0 = PrefixesDivBy5([1, 1, 1]);
            IList<bool> x1 = PrefixesDivBy5([1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1]);
            IList<bool> x2 = PrefixesDivBy5([1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
            RftTerminal.RftReadResult(x2);
        }

        private static List<bool> PrefixesDivBy5(int[] nums)
        {
            int n = nums.Length;
            List<bool> x = [];

            int t0 = 1, t1 = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 1) t1 += t0 % 10;

                x.Add(t1 % 5 == 0);
                t0 += t0 * 2 % 10;
            }

            return x;
        }
    }
}
