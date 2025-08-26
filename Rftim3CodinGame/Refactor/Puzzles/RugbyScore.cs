namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class RugbyScore
    {
        public RugbyScore()
        {
            int n = 12;

            Solve(n);
        }

        private static void Solve(int n)
        {
            int touchdown = 5;
            int kick = 2;
            int drop = 3;

            int tdCount = n / touchdown;
            int kickCount = tdCount;
            int dropCount = n / drop;

            for (int i = 0; i <= tdCount; i++)
            {
                for (int j = 0; j <= kickCount; j++)
                {
                    for (int k = 0; k <= dropCount; k++)
                    {
                        int tdValue = i * touchdown;
                        int kickValue = j * kick;
                        int dropValue = k * drop;

                        if (j <= i)
                        {
                            int score = tdValue + kickValue + dropValue;
                            if (score == n) Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }
    }
}
