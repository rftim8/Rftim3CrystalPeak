using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00338_CountingBits
    {
        /// <summary>
        /// Given an integer n, return an array ans of length n + 1 such that for each i (0 <= i <= n), ans[i] is the number of 1's in the binary representation of i.
        /// </summary>
        public _00338_CountingBits()
        {
            int[] a0 = CountBits0(2);
            RftTerminal.RftReadResult(a0);

            int[] a1 = CountBits0(5);
            RftTerminal.RftReadResult(a1);
        }

        public static int[] CountBits0(int a0) => RftCountBits0(a0);

        public static int[] CountBits1(int a0) => RftCountBits1(a0);

        private static int[] RftCountBits0(int n)
        {
            int[] result = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                result[i] = result[i & i - 1] + 1;
            }

            return result;
        }

        private static int[] RftCountBits1(int n)
        {
            int[] x = new int[n + 1];

            for (int i = 0; i <= n; i++)
            {
                x[i] = Convert.ToString(i, 2).Where(o => o == '1').Count();
            }

            return x;
        }
    }
}
