namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class WaysToMakeChange
    {
        public WaysToMakeChange()
        {
            //int n = 9;
            //int n = 100;
            int n = 10;

            //int s = 3;
            //int s = 5;
            int s = 2;

            //int[] vi = new int[] { 5, 6, 10 };
            //int[] vi = new int[] { 1, 5, 10, 20, 50 };
            int[] vi = new int[] { 1, 5 };

            Solve(n, s, vi);
        }

        private static void Solve(int n, int s, int[] vi)
        {
            int[] combo = new int[n + 1];

            combo[0] = 1;

            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < combo.Length; j++)
                {
                    if (vi[i] <= j) combo[j] += combo[j - vi[i]];
                }
            }

            Console.WriteLine(combo[n]);
        }
    }
}
