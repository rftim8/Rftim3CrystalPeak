namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class VanEcksSequence
    {
        public VanEcksSequence()
        {
            int a1 = 0;
            int n = 10;

            Solve(a1, n);
        }

        private static void Solve(int a1, int n)
        {
            Dictionary<int, int> w = new();

            for (int i = 0; i < n - 1; i++)
            {
                if (!w.ContainsKey(a1))
                {
                    w.Add(a1, i);
                    a1 = 0;
                    Console.WriteLine($"A1: {a1}; w[A1]: {w[a1]}");
                    Console.WriteLine();
                }
                else if (w.ContainsKey(a1))
                {
                    int x = w[a1];
                    w[a1] = i;
                    a1 = i - x;
                    Console.WriteLine($"A1: {a1}; w[A1]: {x}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine(a1);
        }
    }
}
