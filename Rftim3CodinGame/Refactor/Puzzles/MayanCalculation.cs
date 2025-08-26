namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class MayanCalculation
    {
        public MayanCalculation()
        {
            //int H = 4;
            //List<string> numerals = new()
            //{
            //    ".oo.o...oo..ooo.oooo....o...oo..ooo.oooo____o...oo..ooo.oooo____o...oo..ooo.oooo",
            //    "o..o................____________________________________________________________",
            //    ".oo.........................................____________________________________",
            //    "................................................................________________"
            //};
            //int S1 = 4;
            //List<string> num1Line = new()
            //{
            //    "o...",
            //    "....",
            //    "....",
            //    "...."
            //};
            //int S2 = 4;
            //List<string> num2Line = new()
            //{
            //    "o...",
            //    "....",
            //    "....",
            //    "...."
            //};
            //string operation = "+";

            int H = 4;
            List<string> numerals = new()
            {
                ".oo.o...oo..ooo.oooo....o...oo..ooo.oooo____o...oo..ooo.oooo____o...oo..ooo.oooo",
                "o..o................____________________________________________________________",
                ".oo.........................................____________________________________",
                "................................................................________________"
            };
            int S1 = 16;
            List<string> num1Line = new()
            {
                "o...",
                "....",
                "....",
                "....",
                "....",
                "____",
                "____",
                "....",
                "oo..",
                "____",
                "____",
                "____",
                "....",
                "____",
                "....",
                "...."
            };
            int S2 = 20;
            List<string> num2Line = new()
            {
                "oooo",
                "....",
                "....",
                "....",
                "ooo.",
                "____",
                "____",
                "____",
                "oo..",
                "____",
                "____",
                "....",
                "....",
                "____",
                "____",
                "....",
                "oo..",
                "____",
                "____",
                "...."
            };
            string operation = "*";

            Solve(H, numerals, S1, num1Line, S2, num2Line, operation);
        }

        private static void Solve(int h, List<string> numerals, int s1, List<string> num1Line, int s2, List<string> num2Line, string operation)
        {
            List<string> alpha = new();
            int alphaNr = numerals[0].Length / h;
            string nr = "";

            for (int i = 0; i < alphaNr; i++)
            {
                for (int j = 0; j < numerals.Count; j++)
                {
                    nr += numerals[j][..h];
                    numerals[j] = numerals[j][h..];
                }
                alpha.Add(nr);
                nr = "";
            }

            foreach (string item in alpha)
            {
                Console.WriteLine($"{alpha.IndexOf(item)}: {item}");
            }

            List<string> num1 = new();
            string num1nr = "";

            for (int i = 1; i <= s1; i++)
            {
                num1nr += num1Line[i - 1];

                if (i % h == 0)
                {
                    num1.Add(num1nr);
                    num1nr = "";
                }
            }
            num1.Reverse();
            int num1result = 0;
            for (int i = 0; i < num1.Count; i++)
            {
                foreach (string item in alpha)
                {
                    if (num1[i] == item) num1result += alpha.IndexOf(item) * (int)Math.Pow(20, i);
                }
            }
            Console.WriteLine($"num1result: {num1result}");

            List<string> num2 = new();
            string num2nr = "";

            for (int i = 1; i <= s2; i++)
            {
                num2nr += num2Line[i - 1];

                if (i % h == 0)
                {
                    num2.Add(num2nr);
                    num2nr = "";
                }
            }
            num2.Reverse();
            int num2result = 0;
            for (int i = 0; i < num2.Count; i++)
            {
                foreach (string item in alpha)
                {
                    if (num2[i] == item) num2result += alpha.IndexOf(item) * (int)Math.Pow(20, i);
                }
            }
            Console.WriteLine($"num2result: {num2result}");

            long resultOp = 0;

            switch (operation)
            {
                case "-":
                    resultOp = num1result - (long)num2result;
                    break;
                case "+":
                    resultOp = num1result + (long)num2result;
                    break;
                case "/":
                    resultOp = num1result / (long)num2result;
                    break;
                case "*":
                    resultOp = num1result * (long)num2result;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"resultOp: {resultOp}");

            List<string> results = new();

            string result = "";

            if (resultOp != 0)
            {
                while (resultOp > 0)
                {
                    result += resultOp % 20;
                    int location = (int)(resultOp % 20);
                    results.Add(alpha[location]);
                    resultOp /= 20;
                }
            }
            else results.Add(alpha[0]);

            results.Reverse();
            foreach (string item in results)
            {
                for (int i = 1; i <= item.Length; i++)
                {
                    Console.Write($"{item[i - 1]}");
                    if (i % h == 0) Console.WriteLine();
                }
            }

            Console.WriteLine($"result: {result}");
        }

    }
}
