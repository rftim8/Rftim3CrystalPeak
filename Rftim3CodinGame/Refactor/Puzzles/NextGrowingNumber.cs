namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class NextGrowingNumber
    {
        public NextGrowingNumber()
        {
            long n = 11123159995399999;

            Solve(n);
        }

        private static void Solve(long n)
        {
            n++;
            long count = n.ToString().Length;
            long cc = 0;
            bool flag = true;

            for (int i = 0; i < count; i++)
            {
                long subs = long.Parse(n.ToString()[i].ToString());
                if (subs >= cc && flag) cc = subs;
                else
                {
                    flag = false;
                    n = long.Parse(n.ToString()[..i] + cc + n.ToString()[(i + 1)..]);
                }
            }
            Console.WriteLine(n);
        }
    }
}
