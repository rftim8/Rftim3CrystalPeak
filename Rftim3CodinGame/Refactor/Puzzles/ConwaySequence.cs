namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class ConwaySequence
    {
        public ConwaySequence()
        {
            int r = 1;
            int l = 6;

            Solve(r, l);
        }

        private static void Solve(int r, int l)
        {
            string s = $"{r}";
            string s0 = "";

            for (int i = 0; i < l - 1; i++)
            {
                List<string> n = s.Split(" ").ToList();
                string s1 = n[0];
                int c = 0;
                for (int j = 0; j < n.Count; j++)
                {
                    if (n[j] == s1) c++;
                    else
                    {
                        s0 += $"{c} {s1} ";
                        s1 = n[j];
                        c = 1;
                    }
                    if (j == n.Count - 1) s0 += $"{c} {s1} ";
                }
                s = s0.TrimEnd();
                s0 = "";
            }

            Console.WriteLine(s.TrimEnd());
        }
    }
}
