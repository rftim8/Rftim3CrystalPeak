using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01021_RemoveOutermostParentheses
    {
        /// <summary>
        /// A valid parentheses string is either empty "", "(" + A + ")", or A + B, where A and B are valid parentheses strings, and + represents string concatenation.
        /// For example, "", "()", "(())()", and "(()(()))" are all valid parentheses strings.
        /// A valid parentheses string s is primitive if it is nonempty, and there does not exist a way to split it into s = A + B, with A and B nonempty valid parentheses strings.
        /// Given a valid parentheses string s, consider its primitive decomposition: s = P1 + P2 + ... + Pk, where Pi are primitive valid parentheses strings.
        /// Return s after removing the outermost parentheses of every primitive string in the primitive decomposition of s.
        /// </summary>
        public _01021_RemoveOutermostParentheses()
        {
            Console.WriteLine(RemoveOuterParentheses("(()())(())"));
            Console.WriteLine(RemoveOuterParentheses("(()())(())(()(()))"));
            Console.WriteLine(RemoveOuterParentheses("()()"));
        }

        private static string RemoveOuterParentheses(string s)
        {
            StringBuilder sb = new();
            int i = 0;

            foreach (char c in s.ToCharArray())
            {
                i += c == '(' ? 1 : -1;

                if (c == '(' && i > 1 || c == ')' && i > 0) sb.Append(c);
            }

            return sb.ToString();
        }

        private string RemoveOuterParentheses0(string s)
        {
            StringBuilder sb = new(s.Length);

            for (int i = 0; i < s.Length;)
            {
                int start = i;
                int end = i;
                int sum = 0;
                do
                {
                    if (s[end++] == ')') sum--;
                    else sum++;
                }
                while (sum != 0);

                sb.Append(s.AsSpan(start + 1, end - start - 2));
                i = end;
            }

            return sb.ToString();
        }
    }
}
