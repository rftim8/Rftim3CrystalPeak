namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class TheGift
    {
        public TheGift()
        {
            int n = 3;
            int c = 100;
            List<int> budgets = new()
            {
                40,
                40,
                40
            };

            //int n = 3;
            //int c = 100;
            //List<int> budgets = new()
            //{
            //    100,
            //    1,
            //    60
            //};

            Solve(n, c, budgets);
        }

        private static void Solve(int n, int c, List<int> budgets)
        {
            budgets.Sort((a, b) => a.CompareTo(b));

            float mean = 0F;

            if (budgets.Sum() >= c)
            {
                for (int i = 0; i < budgets.Count; i++)
                {
                    mean = c / (n - i);
                    Console.WriteLine($"mean: {mean}");

                    if (budgets[i] < mean)
                    {
                        Console.WriteLine(budgets[i]);
                        c -= budgets[i];
                    }
                    else
                    {
                        Console.WriteLine(mean);
                        c -= (int)mean;
                    }
                }
            }
            else Console.WriteLine($"IMPOSSIBLE");
        }
    }
}
