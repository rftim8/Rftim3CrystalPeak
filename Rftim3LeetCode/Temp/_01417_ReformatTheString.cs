using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01417_ReformatTheString
    {
        /// <summary>
        /// You are given an alphanumeric string s. (Alphanumeric string is a string consisting of lowercase English letters and digits).
        /// You have to find a permutation of the string where no letter is followed by another letter and no digit is followed by another digit.
        /// That is, no two adjacent characters have the same type.
        /// Return the reformatted string or return an empty string if it is impossible to reformat the string.
        /// </summary>
        public _01417_ReformatTheString()
        {
            Console.WriteLine(Reformat("a0b1c2"));
            Console.WriteLine(Reformat("a0b1c2a"));
            Console.WriteLine(Reformat("leetcode"));
            Console.WriteLine(Reformat("1229857369"));
            Console.WriteLine(Reformat("ec"));
            Console.WriteLine(Reformat("e"));
        }

        private static string Reformat(string s)
        {
            int n = s.Length;

            int a = 0, l = 0;
            List<char> a0 = [];
            List<char> l0 = [];
            for (int i = 0; i < n; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    l++;
                    l0.Add(s[i]);
                }
                else
                {
                    a++;
                    a0.Add(s[i]);
                }
            }

            if (Math.Abs(a - l) >= 2) return "";

            string r = "";
            if (a0.Count >= l0.Count)
            {
                for (int i = 0; i < a0.Count; i++)
                {
                    r += a0[i];
                    if (i < l0.Count) r += l0[i];
                }
            }
            else
            {
                for (int i = 0; i < l0.Count; i++)
                {
                    r += l0[i];
                    if (i < a0.Count) r += a0[i];
                }
            }

            return r;
        }

        private static string Reformat0(string s)
        {
            List<char> letters = [];
            List<char> digits = [];
            foreach (char c in s)
            {
                if (char.IsDigit(c)) digits.Add(c);
                else letters.Add(c);
            }

            if (Math.Abs(letters.Count - digits.Count) > 1) return "";

            StringBuilder sb = new();
            if (letters.Count < digits.Count) sb.Append(digits[^1]);

            for (int i = 0; i < Math.Min(letters.Count, digits.Count); i++)
            {
                sb.Append(letters[i]).Append(digits[i]);
            }

            if (letters.Count > digits.Count) sb.Append(letters[^1]);

            return sb.ToString();
        }
    }
}
