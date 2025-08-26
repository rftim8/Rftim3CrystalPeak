namespace Rftim3LeetCode.Temp
{
    public class _00647_PalindromicSubstrings
    {
        /// <summary>
        /// Given a string s, return the number of palindromic substrings in it.
        /// 
        /// A string is a palindrome when it reads the same backward as forward.
        /// 
        /// A substring is a contiguous sequence of characters within the string.
        /// </summary>
        public _00647_PalindromicSubstrings()
        {
            Console.WriteLine(PalindromicSubstrings0("abc"));
            Console.WriteLine(PalindromicSubstrings0("aaa"));
            Console.WriteLine(PalindromicSubstrings0("aba"));
        }

        public static int PalindromicSubstrings0(string a0) => RftPalindromicSubstrings0(a0);

        public static int PalindromicSubstrings1(string a0) => RftPalindromicSubstrings1(a0);

        private static int RftPalindromicSubstrings0(string s)
        {
            int res = 0;
            int n = s.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    string t = s[i..(j + 1)];
                    int m = t.Length / 2;

                    bool f = true;
                    for (int k = 0; k < m; k++)
                    {
                        if (t[k] != t[t.Length - k - 1])
                        {
                            f = false;
                            break;
                        }
                    }
                    if (f) res++;
                }
            }

            return res;
        }

        private static int RftPalindromicSubstrings1(string s)
        {
            int count = 0, n = s.Length;
            for (int i = 0; i < n; i++)
            {
                int l = i;
                int r = i;
                while (l >= 0 && r < n && s[l] == s[r])
                {
                    count++;
                    l--;
                    r++;
                }
                l = i; r = i + 1;
                while (l >= 0 && r < n && s[l] == s[r])
                {
                    count++;
                    l--;
                    r++;
                }
            }

            return count;
        }
    }
}
