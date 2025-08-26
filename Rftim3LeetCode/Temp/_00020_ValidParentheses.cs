namespace Rftim3LeetCode.Temp
{
    public class _00020_ValidParentheses
    {
        /// <summary>
        /// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        /// An input string is valid if:
        /// Open brackets must be closed by the same type of brackets.
        /// Open brackets must be closed in the correct order.
        /// Every close bracket has a corresponding open bracket of the same type.
        /// </summary>
        public _00020_ValidParentheses()
        {
            Console.WriteLine(ValidParentheses0("()"));
            Console.WriteLine(ValidParentheses0("()[]{}"));
            Console.WriteLine(ValidParentheses0("(]"));
            Console.WriteLine(ValidParentheses0("((([])))"));
            Console.WriteLine(ValidParentheses0("({{([()(])}})"));
        }

        public static bool ValidParentheses0(string a0) => RftValidParentheses0(a0);

        private static bool RftValidParentheses0(string s)
        {
            Stack<char> stack = new();
            Dictionary<char, char> dict = new()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
            };

            foreach (char c in s)
            {
                if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count > 0 && dict[stack.Peek()] != c || stack.Count == 0) return false;

                    stack.Pop();
                }
                else stack.Push(c);
            }

            return stack.Count == 0;
        }
    }
}
