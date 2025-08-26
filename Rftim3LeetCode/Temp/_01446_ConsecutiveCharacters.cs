namespace Rftim3LeetCode.Temp
{
    public class _01446_ConsecutiveCharacters
    {
        /// <summary>
        /// The power of the string is the maximum length of a non-empty substring that contains only one unique character.
        /// Given a string s, return the power of s.
        /// </summary>
        public _01446_ConsecutiveCharacters()
        {
            Console.WriteLine(MaxPower("leetcode"));
            Console.WriteLine(MaxPower("abbcccddddeeeeedcba"));
            Console.WriteLine(MaxPower("j"));
        }

        private static int MaxPower(string s)
        {
            int n = s.Length;
            if (n == 1) return 1;

            int r = 0, c = 1;
            for (int i = 1; i < n; i++)
            {
                if (s[i] == s[i - 1]) c++;
                else
                {
                    r = Math.Max(r, c);
                    c = 1;
                }
                if (i == n - 1) r = Math.Max(r, c);
            }

            return r;
        }

        private static int MaxPower0(string s)
        {
            int max = 1, help = 1;
            char[] c = s.ToCharArray();
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (c[i] == c[i + 1])
                {
                    help++;
                    if (help > max) max = help;
                }
                else help = 1;
            }

            return max;
        }
    }
}
