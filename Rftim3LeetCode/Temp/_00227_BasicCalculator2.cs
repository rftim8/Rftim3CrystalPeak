namespace Rftim3LeetCode.Temp
{
    public class _00227_BasicCalculator2
    {
        /// <summary>
        /// Given a string s which represents an expression, evaluate this expression and return its value. 
        /// The integer division should truncate toward zero.
        /// You may assume that the given expression is always valid.All intermediate results will be in the range of[-231, 231 - 1].
        /// Note: You are not allowed to use any built-in function which evaluates strings as mathematical expressions, such as eval().
        /// </summary>
        public _00227_BasicCalculator2()
        {
            Console.WriteLine(Calculate("3+2*2"));
            Console.WriteLine(Calculate("3/2 "));
            Console.WriteLine(Calculate("3+5 / 2 "));
        }

        private static int Calculate(string s)
        {
            if (s is null || !s.Any()) return 0;
            int len = s.Length;
            Stack<int> stack = new();
            int currentNumber = 0;
            char operation = '+';
            for (int i = 0; i < len; i++)
            {
                char currentChar = s[i];
                if (char.IsDigit(currentChar)) currentNumber = currentNumber * 10 + (currentChar - '0');

                if (!char.IsDigit(currentChar) && !char.IsWhiteSpace(currentChar) || i == len - 1)
                {
                    switch (operation)
                    {
                        case '-':
                            stack.Push(-currentNumber);
                            break;
                        case '+':
                            stack.Push(currentNumber);
                            break;
                        case '*':
                            stack.Push(stack.Pop() * currentNumber);
                            break;
                        case '/':
                            stack.Push(stack.Pop() / currentNumber);
                            break;
                        default:
                            break;
                    }
                    operation = currentChar;
                    currentNumber = 0;
                }
            }

            int result = 0;
            while (stack.Any())
            {
                result += stack.Pop();
            }

            return result;
        }

        private static int Calculate0(string s)
        {
            int len = s.Length;
            Stack<int> stk = new();
            int num = 0;
            char sign = '+';
            for (int i = 0; i < len; i++)
            {
                if (char.IsDigit(s[i])) num = num * 10 + (s[i] - '0');
                if (!char.IsDigit(s[i]) && s[i] != ' ' || i == len - 1)
                {
                    if (sign == '-') stk.Push(-num);
                    if (sign == '+') stk.Push(num);
                    if (sign == '*') stk.Push(stk.Pop() * num);
                    if (sign == '/') stk.Push(stk.Pop() / num);
                    sign = s[i];
                    num = 0;
                }
            }

            int ans = 0;
            while (stk.Count > 0)
            {
                ans += stk.Pop();
            }

            return ans;
        }
    }
}
