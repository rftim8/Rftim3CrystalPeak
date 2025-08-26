using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00186_ReverseWordsInAStringII
    {
        /// <summary>
        /// Given a character array s, reverse the order of the words.
        /// 
        /// A word is defined as a sequence of non-space characters.
        /// The words in s will be separated by a single space.
        /// 
        /// Your code must solve the problem in-place, i.e.without allocating extra space.
        /// </summary>
        public _00186_ReverseWordsInAStringII()
        {
            char[] a0 = ReverseWordsInAStringII0(['t', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e']);
            RftTerminal.RftReadResult(a0);

            char[] a1 = ReverseWordsInAStringII0(['a']);
            RftTerminal.RftReadResult(a1);
        }

        public static char[] ReverseWordsInAStringII0(char[] a0) => RftReverseWordsInAStringII0(a0);

        public static char[] ReverseWordsInAStringII1(char[] a0) => RftReverseWordsInAStringII1(a0);

        private static char[] RftReverseWordsInAStringII0(char[] s)
        {
            Reverse(s, 0, s.Length - 1);

            return ReverseEachWord(s);
        }

        private static void Reverse(char[] s, int left, int right)
        {
            while (left < right)
            {
                char tmp = s[left];
                s[left++] = s[right];
                s[right--] = tmp;
            }
        }

        private static char[] ReverseEachWord(char[] s)
        {
            int n = s.Length;
            int start = 0, end = 0;

            while (start < n)
            {
                while (end < n && s[end] != ' ') ++end;

                Reverse(s, start, end - 1);

                start = end + 1;
                ++end;
            }

            return s;
        }

        private static char[] RftReverseWordsInAStringII1(char[] s)
        {
            int lft = 0, start, end;
            int rgt;
            for (rgt = 0; rgt <= s.Length; rgt++)
            {
                if (rgt == s.Length || s[rgt] == ' ')
                {
                    end = rgt - 1;
                    start = lft;
                    lft = rgt + 1;
                    while (start < end)
                    {
                        char tmp = s[start];
                        s[start++] = s[end];
                        s[end--] = tmp;
                    }
                }
            }
            int l = 0, r = s.Length - 1;
            while (l < r)
            {
                char c = s[l];
                s[l++] = s[r];
                s[r--] = c;
            }

            return s;
        }
    }
}
