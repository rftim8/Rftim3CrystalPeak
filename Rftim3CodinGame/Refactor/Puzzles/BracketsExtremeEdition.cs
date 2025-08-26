namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class BracketsExtremeEdition
    {
        public BracketsExtremeEdition()
        {
            string expression = "{(})";

            Solve(expression);
        }

        private static void Solve(string expression)
        {
            int lCurly = 0;
            int rCurly = 0;
            int lBracket = 0;
            int rBracket = 0;
            int lParent = 0;
            int rParent = 0;
            bool result = true;

            for (int i = 0; i < expression.Length; i++)
            {
                string symbol = expression[i].ToString();
                string symbol1 = "";
                if (i < expression.Length - 1) symbol1 = expression[i + 1].ToString();

                switch (symbol)
                {
                    case "{": lCurly++; if (symbol1 == "]" || symbol1 == ")") result = false; break;
                    case "}": rCurly++; break;
                    case "[": lBracket++; if (symbol1 == "}" || symbol1 == ")") result = false; break;
                    case "]": rBracket++; break;
                    case "(": lParent++; if (symbol1 == "]" || symbol1 == "}") result = false; break;
                    case ")": rParent++; break;
                    default: break;
                }

                if (rCurly > lCurly || rBracket > lBracket || rParent > lParent) result = false;
            }

            if (rCurly != lCurly || rBracket != lBracket || rParent != lParent) result = false;
            Console.WriteLine(result.ToString().ToLower());
        }
    }
}
