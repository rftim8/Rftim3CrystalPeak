using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00344_ReverseString
    {
        /// <summary>
        /// Write a function that reverses a string. The input string is given as an array of characters s.
        /// You must do this by modifying the input array in-place with O(1) extra memory.
        /// </summary>
        public _00344_ReverseString()
        {
            char[] x = ReverseString0(['h', 'e', 'l', 'l', 'o']);
            RftTerminal.RftReadResult(x);

            char[] x0 = ReverseString0(['H', 'a', 'n', 'n', 'a', 'h']);
            RftTerminal.RftReadResult(x0);
        }

        public static char[] ReverseString0(char[] a0) => RftReverseString0(a0);

        public static char[] ReverseString1(char[] a0) => RftReverseString1(a0);

        private static char[] RftReverseString0(char[] s)
        {
            void Rec(int l, int r)
            {
                if (l > r) return;
                (s[l], s[r]) = (s[r], s[l]);

                Rec(l + 1, r - 1);
            }
            Rec(0, s.Length - 1);

            return s;
        }

        private static char[] RftReverseString1(char[] s)
        {
            int n = s.Length;

            for (int i = 0; i < n; i++, n--)
            {
                (s[n - 1], s[i]) = (s[i], s[n - 1]);
            }

            return s;
        }
    }
}
