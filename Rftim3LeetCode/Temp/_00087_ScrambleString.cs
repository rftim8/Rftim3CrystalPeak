namespace Rftim3LeetCode.Temp
{
    public class _00087_ScrambleString
    {
        /// <summary>
        /// We can scramble a string s to get a string t using the following algorithm:
        /// If the length of the string is 1, stop.
        /// If the length of the string is > 1, do the following:
        /// Split the string into two non-empty substrings at a random index, i.e., if the string is s, divide it to x and y where s = x + y.
        /// Randomly decide to swap the two substrings or to keep them in the same order.i.e., after this step, s may become s = x + y or s = y + x.
        /// Apply step 1 recursively on each of the two substrings x and y.
        /// Given two strings s1 and s2 of the same length, return true if s2 is a scrambled string of s1, otherwise, return false.
        /// </summary>
        public _00087_ScrambleString()
        {
            Console.WriteLine(IsScramble("great", "rgeat"));
            Console.WriteLine(IsScramble("abcde", "caebd"));
            Console.WriteLine(IsScramble("a", "a"));
        }

        private static bool IsScramble(string s1, string s2)
        {
            int n = s1.Length;
            int m = s2.Length;
            if (n != m) return false;

            char[] c1 = s1.ToCharArray();
            Array.Sort(c1);

            char[] c2 = s2.ToCharArray();
            Array.Sort(c2);

            for (int i = 0; i < n; i++)
            {
                if (c1[i] != c2[i]) return false;
            }

            bool[,,] r = new bool[n, n, n + 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (s1[i] == s2[j]) r[i, j, 1] = true;
                }
            }

            for (int i = 2; i <= n; i++)
            {
                for (int j = 0; j < n - i + 1; j++)
                {
                    for (int k = 0; k < n - i + 1; k++)
                    {
                        for (int l = 1; l < i; l++)
                        {
                            if (r[j, k, l] && r[j + l, k + l, i - l] ||
                                r[j, k + i - l, l] && r[j + l, k, i - l])
                                r[j, k, i] = true;
                        }
                    }
                }
            }

            return r[0, 0, n];
        }
    }
}
