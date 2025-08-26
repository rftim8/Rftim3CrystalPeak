namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class EntryCode
    {
        public EntryCode()
        {
            int x = 2;
            int n = 3;

            //int x = 3;
            //int n = 2;

            //int x = 10;
            //int n = 2;

            //int x = 2;
            //int n = 8;

            //int x = 9;
            //int n = 3;
            List<string> list = new();

            Solve(x, n, list);
        }

        private static void Solve(int x, int n, List<string> list)
        {
            string r = "";

            for (int i = 0; i < n - 1; i++)
            {
                r += "0";
            }

            Console.WriteLine(r + Rec(r, x, "", list));
        }

        public static string Rec(string r, int x, string s, List<string> list)
        {
            for (int i = 0; i < x; i++)
            {
                string t = r + i.ToString();
                Console.WriteLine($"t: {t}");

                if (!list.Contains(t))
                {
                    list.Add(t);
                    s = i.ToString() + Rec(t[1..], x, s, list);
                }
            }

            foreach (string item in list)
            {
                Console.WriteLine($"i: {item}");
            }

            Console.WriteLine(s);
            Console.WriteLine();

            return s;
        }
    }
}
