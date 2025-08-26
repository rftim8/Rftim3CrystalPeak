namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class SumOfSpiralsDiagonals
    {
        public SumOfSpiralsDiagonals()
        {
            int n = 1453;

            Solve(n);
        }

        private static void Solve(int n)
        {
            long sum = 0;
            int nr = n * n;
            int steps = n - 1;
            int step = 0;
            int corners = 0;

            for (int i = 1; i <= nr; i++)
            {
                if (step == steps) step = 0;

                if (step == 0)
                {
                    sum += i;
                    corners++;
                }

                if (corners == 5)
                {
                    steps -= 2;
                    corners = 1;
                }

                step++;
            }

            Console.WriteLine($"{sum}");
        }
    }
}
