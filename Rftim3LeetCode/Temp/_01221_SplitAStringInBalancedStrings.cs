namespace Rftim3LeetCode.Temp
{
    public class _01221_SplitAStringInBalancedStrings
    {
        /// <summary>
        /// Balanced strings are those that have an equal quantity of 'L' and 'R' characters.
        /// Given a balanced string s, split it into some number of substrings such that:
        /// Each substring is balanced.
        /// Return the maximum number of balanced strings you can obtain.
        /// </summary>
        public _01221_SplitAStringInBalancedStrings()
        {
            Console.WriteLine(BalancedStringSplit("RLRRLLRLRL"));
            Console.WriteLine(BalancedStringSplit("RLRRRLLRLL"));
            Console.WriteLine(BalancedStringSplit("LLLLRRRR"));
        }

        private static int BalancedStringSplit(string s)
        {
            int n = s.Length;

            Dictionary<char, int> r = new()
            {
                ['L'] = 0,
                ['R'] = 0
            };

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                r[s[i]]++;

                if (r['L'] == r['R']) c++;
            }

            return c;
        }
    }
}
