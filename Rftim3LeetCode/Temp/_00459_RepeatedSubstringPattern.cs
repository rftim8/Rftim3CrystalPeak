using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00459_RepeatedSubstringPattern
    {
        /// <summary>
        /// Given a string s, check if it can be constructed by taking a substring of it and appending multiple copies of the substring together.
        /// </summary>

        public _00459_RepeatedSubstringPattern()
        {
            Console.WriteLine(RepeatedSubstringPattern0("abab"));
            Console.WriteLine(RepeatedSubstringPattern0("aba"));
            Console.WriteLine(RepeatedSubstringPattern0("abcabcabcabc"));
        }

        public static bool RepeatedSubstringPattern0(string a0) => RftRepeatedSubstringPattern0(a0);

        public static bool RepeatedSubstringPattern1(string a0) => RftRepeatedSubstringPattern1(a0);

        public static bool RepeatedSubstringPattern2(string a0) => RftRepeatedSubstringPattern2(a0);

        private static bool RftRepeatedSubstringPattern0(string s)
        {
            int n = s.Length;

            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    int m = n / i;
                    if (s == string.Concat(Enumerable.Repeat(s[..i], m))) return true;
                }
            }

            return false;
        }

        private static bool RftRepeatedSubstringPattern1(string s)
        {
            string t = s + s;

            return t[1..^1].Contains(s);
        }

        private static bool RftRepeatedSubstringPattern2(string s)
        {
            int n = s.Length;
            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    StringBuilder pattern = new();
                    for (int j = 0; j < n / i; j++)
                    {
                        pattern.Append(s[..i]);
                    }
                    if (s.Equals(pattern.ToString())) return true;
                }
            }

            return false;
        }
    }
}
