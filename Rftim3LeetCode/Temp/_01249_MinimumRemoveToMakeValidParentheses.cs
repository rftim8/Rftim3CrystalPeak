using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01249_MinimumRemoveToMakeValidParentheses
    {
        /// <summary>
        /// Given a string s of '(' , ')' and lowercase English characters.
        /// Your task is to remove the minimum number of parentheses( '(' or ')', in any positions) so that the resulting parentheses string is valid and return any valid string.
        /// Formally, a parentheses string is valid if and only if:
        /// It is the empty string, contains only lowercase characters, or
        /// It can be written as AB(A concatenated with B), where A and B are valid strings, or
        /// It can be written as (A), where A is a valid string.
        /// </summary>
        public _01249_MinimumRemoveToMakeValidParentheses()
        {
            Console.WriteLine(MinRemoveToMakeValid("lee(t(c)o)de)"));
            Console.WriteLine(MinRemoveToMakeValid("a)b(c)d"));
            Console.WriteLine(MinRemoveToMakeValid("))(("));
        }

        private static string MinRemoveToMakeValid(string s)
        {
            int n = s.Length;
            Stack<(char c, int p)> stack = new();
            char[] a = [.. s];

            for (int i = 0; i < n; i++)
            {
                if (s[i] == ')' && stack.Count > 0 && stack.Peek().c == '(') stack.Pop();
                else if (s[i] == '(' || s[i] == ')') stack.Push((s[i], i));
            }

            while (stack.Count != 0)
            {
                a[stack.Peek().p] = ' ';
                stack.Pop();
            }

            return new string(a).Replace(" ", "");
        }

        private static string MinRemoveToMakeValid0(string s)
        {
            Stack<(int index, char symbol)> stack = new();

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                        stack.Push(new(i, s[i]));
                        break;

                    case ')':
                        if (stack.Count != 0 && stack.Peek().symbol == '(')
                        {
                            stack.Pop();
                        }
                        else stack.Push(new(i, s[i]));
                        break;

                    default:
                        break;
                }
            }

            List<(int index, char symbol)> list = [.. stack];

            StringBuilder sb = new(s);
            foreach ((int index, _) in list)
            {
                sb.Remove(index, 1);
            }

            return sb.ToString();
        }
    }
}