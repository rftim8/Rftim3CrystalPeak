namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class RectanglePartition
    {
        public RectanglePartition()
        {
            int[] x = new int[] { 0, 3, 5 };
            int[] y = new int[] { 0, 2, 5, 10 };

            Solve(x, y);
        }

        private static void Solve(int[] x, int[] y)
        {
            int result = 0;

            if (x.Length >= y.Length)
            {
                for (int k = 0; k < x.Length; k++)
                {
                    for (int l = 0; l < k; l++)
                    {
                        for (int m = 0; m < y.Length; m++)
                        {
                            for (int n = 0; n < m; n++)
                            {
                                if (x[k] - x[l] == y[m] - y[n]) result++;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int k = 0; k < y.Length; k++)
                {
                    for (int l = 0; l < k; l++)
                    {
                        for (int m = 0; m < x.Length; m++)
                        {
                            for (int n = 0; n < m; n++)
                            {
                                if (y[k] - y[l] == x[m] - x[n]) result++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
