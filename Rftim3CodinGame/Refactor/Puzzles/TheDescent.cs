namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class TheDescent
    {
        public TheDescent()
        {
            int[] h = new int[] { 9, 8, 7, 3, 6, 5, 2, 4 };

            Solve(h);
        }

        private static void Solve(int[] h)
        {
            int max = 0;
            int imax = 0;

            for (int i = 0; i < 8; i++)
            {
                if (h[i] > max)
                {
                    max = h[i];
                    imax = i;
                }
            }

            Console.WriteLine(imax);
        }
    }
}
