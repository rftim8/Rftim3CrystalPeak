namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class IfThenElse
    {
        public IfThenElse()
        {
            string[] ops = new string[] { "begin", "if", "else", "endif", "if", "else", "endif",
            "if", "else", "endif", "if", "else", "endif", "if", "else", "endif", "if", "else",
            "endif", "if", "else", "endif", "if", "else", "endif", "if", "else", "endif", "if",
            "else", "endif", "if", "else", "endif", "if", "else", "endif", "if", "else", "endif",
            "if", "else", "endif", "if", "else", "endif", "if", "else", "endif", "if", "else",
            "endif", "if", "else", "endif", "if", "else", "endif", "if", "else", "endif", "if",
            "else", "endif", "if", "else", "endif", "if", "else", "endif", "if", "else", "endif",
            "if", "else", "endif", "if", "else", "endif", "if", "else", "endif", "if", "else",
            "endif", "if", "else", "endif", "if", "else", "endif", "if", "else", "endif", "if",
            "else", "endif", "end" }; // 80

            //string[] ops = new string[] { "begin", "if", "if", "else", "if", "else", "endif", "endif",
            //    "if", "else", "endif", "if", "if", "else", "endif", "else", "if", "else", "if", "else",
            //    "endif", "endif", "endif", "else", "if", "else", "if", "else", "endif", "endif", "if",
            //    "else", "endif", "if", "else", "endif", "endif", "end"
            //}; // 42

            //string[] ops = new string[] { "begin", "if", "if", "else", "endif", "if",
            //        "else", "endif", "if", "else", "endif", "else", "if", "if", "else",
            //        "endif", "if", "else", "endif", "else", "endif", "endif", "end" }; // 13
            //string[] ops = new string[] { "begin", "if", "else", "endif", "if", "else", "endif", "end" }; // 4
            //string[] ops = new string[] { "begin", "if", "else", "if", "else", "endif", "endif", "end" }; // 3

            Solve(ops);
        }

        private static void Solve(string[] ops)
        {
            int n = ops.Length;
            string x = "";
            int combo = 2;

            for (int i = 0; i < n; i++)
            {
                if (i < n - 1) x += $"{ops[i]} ";
                else x += $"{ops[i]}";
            }

            x = x.Replace("  ", " ");

            while (x.Contains("begin"))
            {
                x = x.Replace(" if else endif ", $" {combo} ");
                x = x.Replace("  ", " ");
                if (x == "begin end") x = x.Replace("begin end", 1.ToString());

                int count = x.Split(' ').Length;
                string[] y = new string[count];

                for (int i = 0; i < count; i++)
                {
                    y[i] = x.Split(' ')[i];
                }

                for (int i = 0; i < count - 1; i++)
                {
                    int c = 0;
                    bool a1 = int.TryParse(y[i], out int a);
                    bool b1 = int.TryParse(y[i + 1], out int b);
                    bool c1 = false;
                    if (i < count - 2) c1 = int.TryParse(y[i + 2], out c);
                    if (a1)
                    {
                        x = x.Replace($" if {a} else endif ", $" {a + 1} ");
                        x = x.Replace($" if else {a} endif ", $" {a + 1} ");
                        x = x.Replace($"begin {a} end", $"{a}");
                    }
                    if (a1 && b1)
                    {
                        try
                        {
                            x = x.Replace($" {a} {b} ", $" {checked(a * b)} ");
                        }
                        catch (OverflowException)
                        {
                            long overflow = a * (long)b;
                            x = x.Replace($" {a} {b} ", $" {overflow} ");
                            x = x.Replace($"begin {overflow} end", $"{overflow}");
                        }
                        x = x.Replace($" if else {a} {b} endif ", $" {a * b} ");
                        x = x.Replace($" if {a} {b} else endif ", $" {a * b} ");
                    }
                    if (a1 && c1) x = x.Replace($" if {a} else {c} endif ", $" {a + c} ");
                }
            }

            Console.WriteLine(x);
        }
    }
}
