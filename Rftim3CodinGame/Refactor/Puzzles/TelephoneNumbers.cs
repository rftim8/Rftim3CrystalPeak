namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class TelephoneNumbers
    {
        public TelephoneNumbers()
        {
            int n = 1;
            List<string> x = new()
            {
                "0467123456"
            };

            //int n = 5;
            //List<string> x = new()
            //{
            //    "0412578440",
            //    "0412199803",
            //    "0468892011",
            //    "112",
            //    "15"
            //};

            Solve(x, n);
        }

        private static void Solve(List<string> x, int n)
        {
            HashSet<string> prefix = new();
            int m = x.MaxBy(o => o.Length).Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (x[j].Length > i)
                    {
                        if (!prefix.Contains(x[j][..(i + 1)])) prefix.Add(x[j][..(i + 1)]);
                    }
                }
            }

            Console.WriteLine(prefix.Count);

            foreach (string item in prefix)
            {
                Console.WriteLine(item);
            }
        }
    }
}
