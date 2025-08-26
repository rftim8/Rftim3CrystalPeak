namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class StockExchangeLosses
    {
        public StockExchangeLosses()
        {
            const int n = 6;
            int[] values = new int[]
            {
                3,2,4,2,1,5
            };

            Solve(n, values);
        }

        private static void Solve(int n, int[] values)
        {
            List<int> drops = new();
            int last = 0;

            for (int i = 0; i < n; i++)
            {
                if (values[i] > last) last = values[i];
                else if (values[i] < last) drops.Add(last - values[i]);
            }

            for (int i = 0; i < drops.Count; i++)
            {
                Console.WriteLine($"drop {i}: {drops[i]}");
            }

            Console.WriteLine();
            Console.WriteLine(drops.Count == 0 ? 0 : -drops.Max());
        }
    }
}
