namespace Rftim3LeetCode.Temp
{
    public class _00032_LongestValidParentheses
    {
        /// <summary>
        /// Given a string containing just the characters '(' and ')', return the length of the longest valid (well-formed) parentheses substring
        /// </summary>
        public _00032_LongestValidParentheses()
        {
            Console.WriteLine(LongestValidParentheses0("(()"));
            Console.WriteLine(LongestValidParentheses0(")()())"));
            Console.WriteLine(LongestValidParentheses0(""));
        }

        public static int LongestValidParentheses0(string a0) => RftLongestValidParentheses0(a0);

        private static int RftLongestValidParentheses0(string s)
        {
            int n = s.Length;
            if (n == 0) return 0;

            int[] r = new int[n];
            for (int i = 1; i < n; i++)
            {
                if (s[i] == ')')
                {
                    int l = i - 1 - r[i - 1];

                    if (l >= 0 && s[l] == '(')
                    {
                        r[i] = r[i - 1] + 2;
                        if (l - 1 > 0) r[i] += r[l - 1];
                    }
                }
            }

            return r.Max();
        }
    }
}
