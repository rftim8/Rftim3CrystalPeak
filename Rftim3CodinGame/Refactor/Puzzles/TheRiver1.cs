namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class TheRiver1
    {
        public TheRiver1()
        {
            int n = 20000000;
            long r1 = 15485863;
            long r2 = 15215260;

            Solve(n, r1, r2);
        }

        private static void Solve(int n, long r1, long r2)
        {
            List<long> r1Seq = new();
            List<long> r2Seq = new();

            List<long> r1Chars = new();
            List<long> r2Chars = new();

            for (int j = 0; j < n; j++)
            {
                if (r1 >= r2)
                {
                    for (int i = 0; i < r2.ToString().Length; i++)
                    {
                        r2Chars.Add(long.Parse(r2.ToString()[i].ToString()));
                    }

                    long r2x = r2Chars.Aggregate((a, b) => a + b);
                    r2Seq.Add(r2);
                    r2 += r2x;
                    r2Chars = new List<long>();

                    for (int i = 0; i < r1Seq.Count; i++)
                    {
                        if (r2Seq.Contains(r1Seq[i]))
                        {
                            Console.WriteLine(r1Seq[i]);
                            j = n;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < r1.ToString().Length; i++)
                    {
                        r1Chars.Add(long.Parse(r1.ToString()[i].ToString()));
                    }

                    long r1x = r1Chars.Aggregate((a, b) => a + b);
                    r1Seq.Add(r1);
                    r1 += r1x;
                    r1Chars = new List<long>();

                    for (int i = 0; i < r2Seq.Count; i++)
                    {
                        if (r1Seq.Contains(r2Seq[i]))
                        {
                            Console.WriteLine(r2Seq[i]);
                            j = n;
                        }
                    }
                }
            }
        }
    }
}
