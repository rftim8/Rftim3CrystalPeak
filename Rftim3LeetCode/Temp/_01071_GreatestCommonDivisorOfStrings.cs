namespace Rftim3LeetCode.Temp
{
    public class _01071_GreatestCommonDivisorOfStrings
    {
        /// <summary>
        /// For two strings s and t, we say "t divides s" if and only if s = t + ... + t (i.e., t is concatenated with itself one or more times).
        /// Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.
        /// </summary>
        public _01071_GreatestCommonDivisorOfStrings()
        {
            Console.WriteLine(GcdOfStrings("ABCABC", "ABC"));
            Console.WriteLine(GcdOfStrings("ABABAB", "ABAB"));
            Console.WriteLine(GcdOfStrings("LEET", "CODE"));
        }

        private static string GcdOfStrings(string str1, string str2)
        {
            if (!(str1 + str2).Equals(str2 + str1)) return "";

            int gcdLength = Gcd(str1.Length, str2.Length);

            return str1[..gcdLength];
        }

        private static int Gcd(int x, int y)
        {
            if (y == 0) return x;
            else return Gcd(y, x % y);
        }

        private static string GcdOfStrings0(string str1, string str2)
        {
            if (str1 + str2 != str2 + str1) return "";

            int m = str1.Length;
            int n = str2.Length;
            int temp = 0;

            for (int i = 1; i <= m && i <= n; i++)
            {
                if (m % i == 0 && n % i == 0) temp = i;
            }

            return str1[..temp];
        }
    }
}
