namespace Rftim3LeetCode.Temp
{
    public class _00005_LongestPalindromicSubstring
    {
        /// <summary>
        /// Given a string s, return the longest palindromic substring in s.
        /// </summary>
        public _00005_LongestPalindromicSubstring()
        {
            Console.WriteLine(LongestPalindromicSubstring0("babad"));
            Console.WriteLine(LongestPalindromicSubstring0("cbbd"));
        }

        public static string LongestPalindromicSubstring0(string a0) => RftLongestPalindromicSubstring0(a0);

        public static string LongestPalindromicSubstring1(string a0) => RftLongestPalindromicSubstring1(a0);

        private static string RftLongestPalindromicSubstring0(string s)
        {
            int n = s.Length;
            if (n == 1) return s;

            int x = 0, l = 0, r = 0;

            for (int i = 0; i < n; i++)
            {
                for (int diff = 1; i - diff + 1 >= 0 && i + diff < n; diff++)
                {
                    if (s[i - diff + 1] != s[i + diff]) break;
                    else if (x < diff * 2)
                    {
                        x = diff * 2;
                        l = i - diff + 1;
                        r = i + diff;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int diff = 1; i - diff >= 0 && i + diff < n; diff++)
                {
                    if (s[i - diff] != s[i + diff]) break;
                    else if (x < diff * 2 + 1)
                    {
                        x = diff * 2 + 1;
                        l = i - diff;
                        r = i + diff;
                    }
                }
            }

            return s.Substring(l, r - l + 1);
        }

        private static string RftLongestPalindromicSubstring1(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";

            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int length = Math.Max(len1, len2);

                if (length > end - start)
                {
                    start = i - (length - 1) / 2;
                    end = i + length / 2;
                }
            }

            return s.Substring(start, end - start + 1);
        }

        private static int ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }
    }
}
