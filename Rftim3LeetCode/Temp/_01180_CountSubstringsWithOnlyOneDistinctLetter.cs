namespace Rftim3LeetCode.Temp
{
    public class _01180_CountSubstringsWithOnlyOneDistinctLetter
    {
        /// <summary>
        /// Given a string s, return the number of substrings that have only one distinct letter.
        /// </summary>
        public _01180_CountSubstringsWithOnlyOneDistinctLetter()
        {
            Console.WriteLine(CountSubstringsWithOnlyOneDistinctLetter0("aaaba")); // 8
            Console.WriteLine(CountSubstringsWithOnlyOneDistinctLetter0("aaaaaaaaaa")); // 55
        }

        public static int CountSubstringsWithOnlyOneDistinctLetter0(string a0) => RftCountSubstringsWithOnlyOneDistinctLetter0(a0);

        public static int CountSubstringsWithOnlyOneDistinctLetter1(string a0) => RftCountSubstringsWithOnlyOneDistinctLetter1(a0);

        private static int RftCountSubstringsWithOnlyOneDistinctLetter0(string s)
        {
            int res = 0, n = s.Length;

            char c = s[0];
            int left = 0;
            for (int i = 1; i < n; i++)
            {
                if (s[i] != c)
                {
                    res += Factorial(i - left);
                    c = s[i];
                    left = i;
                }
            }
            res += Factorial(n - left);

            return res;
        }

        private static int Factorial(int n)
        {
            int res = 0;

            for (int j = 1; j <= n; j++)
            {
                res += j;
            }

            return res;
        }

        private static int RftCountSubstringsWithOnlyOneDistinctLetter1(string s)
        {
            int total = 1, count = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1]) count++;
                else count = 1;

                total += count;
            }

            return total;
        }
    }
}
