using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02433_FindTheOriginalArrayOfPrefixXor
    {
        /// <summary>
        /// You are given an integer array pref of size n. 
        /// Find and return the array arr of size n that satisfies:
        /// 
        /// pref[i] = arr[0] ^ arr[1] ^ ... ^ arr[i].
        /// Note that ^ denotes the bitwise-xor operation.
        /// 
        /// It can be proven that the answer is unique.
        /// </summary>
        public _02433_FindTheOriginalArrayOfPrefixXor()
        {
            int[] x = FindArray0([5, 2, 0, 3, 1]);
            RftTerminal.RftReadResult(x);

            int[] x0 = FindArray0([13]);
            RftTerminal.RftReadResult(x0);
        }

        public static int[] FindArray0(int[] a0) => RftFindArray0(a0);

        public static int[] FindArray1(int[] a0) => RftFindArray1(a0);

        private static int[] RftFindArray0(int[] pref)
        {
            int n = pref.Length;
            int[] r = new int[n];
            r[0] = pref[0];

            int c = r[0];
            for (int i = 1; i < n; i++)
            {
                r[i] = c ^ pref[i];
                c ^= r[i];
            }

            return r;
        }

        private static int[] RftFindArray1(int[] pref)
        {
            int[] res = new int[pref.Length];
            res[0] = pref[0];

            for (int i = 1; i < pref.Length; i++)
            {
                res[i] = pref[i - 1] ^ pref[i];
            }

            return res;
        }
    }
}
