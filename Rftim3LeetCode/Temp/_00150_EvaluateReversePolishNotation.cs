namespace Rftim3LeetCode.Temp
{
    public class _00150_EvaluateReversePolishNotation
    {
        /// <summary>
        /// You are given an array of strings tokens that represents an arithmetic expression in a Reverse Polish Notation.
        /// Evaluate the expression.Return an integer that represents the value of the expression.
        /// Note that:
        /// The valid operators are '+', '-', '*', and '/'.
        /// Each operand may be an integer or another expression.
        /// The division between two integers always truncates toward zero.
        /// There will not be any division by zero.
        /// The input represents a valid arithmetic expression in a reverse polish notation.
        /// The answer and all the intermediate calculations can be represented in a 32-bit integer.
        /// </summary>
        public _00150_EvaluateReversePolishNotation()
        {
            Console.WriteLine(EvalRPN(["2", "1", "+", "3", "*"]));
            Console.WriteLine(EvalRPN(["4", "13", "5", "/", "+"]));
            Console.WriteLine(EvalRPN(["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"]));
        }

        private static int EvalRPN(string[] tokens)
        {
            Stack<int> s = new();

            foreach (string item in tokens)
            {
                if (item != "+" && item != "-" && item != "*" && item != "/") s.Push(Convert.ToInt32(item));
                else
                {
                    int l = s.Pop();
                    int r = s.Pop();

                    switch (item)
                    {
                        case "+":
                            s.Push(r + l);
                            break;
                        case "-":
                            s.Push(r - l);
                            break;
                        case "*":
                            s.Push(r * l);
                            break;
                        case "/":
                            s.Push(r / l);
                            break;
                        default:
                            break;
                    }
                }
            }

            return s.Pop();
        }
    }
}
