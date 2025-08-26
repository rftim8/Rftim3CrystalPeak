namespace Rftim3LeetCode.Temp
{
    public class _01844_ReplaceAllDigitsWithCharacters
    {
        /// <summary>
        /// You are given a 0-indexed string s that has lowercase English letters in its even indices and digits in its odd indices.
        /// There is a function shift(c, x), where c is a character and x is a digit, that returns the xth character after c.
        /// For example, shift('a', 5) = 'f' and shift('x', 0) = 'x'.
        /// For every odd index i, you want to replace the digit s[i] with shift(s[i - 1], s[i]).
        /// Return s after replacing all digits.It is guaranteed that shift(s[i - 1], s[i]) will never exceed 'z'.
        /// </summary>
        public _01844_ReplaceAllDigitsWithCharacters()
        {
            Console.WriteLine(ReplaceDigits("a1c1e1"));
            Console.WriteLine(ReplaceDigits("a1b2c3d4e"));
        }

        private static string ReplaceDigits(string s)
        {
            int n = s.Length;
            char[] r = s.ToCharArray();

            for (int i = 1; i < n; i++)
            {
                if (i % 2 != 0) r[i] = (char)(r[i - 1] + int.Parse(r[i].ToString()));
            }

            return string.Concat(r);
        }
    }
}
