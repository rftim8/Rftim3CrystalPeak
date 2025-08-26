using System.Numerics;

namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class HappyNumbers
    {
        public HappyNumbers()
        {
            int x = 23;

            Solve(x);
        }

        private static void Solve(BigInteger n)
        {
            BigInteger nInit = n;
            List<BigInteger> n1 = new();
            long sumY = 0;
            byte flag = 0;

            while (flag == 0)
            {
                if (n != 1)
                {
                    BigInteger n2 = SumY(n, sumY);
                    n = n2;

                    if (!n1.Contains(n2)) n1.Add(n2);
                    else flag = 2;
                }
                else flag = 1;
            }

            if (flag == 1) Console.WriteLine(nInit + " :)");
            else if (flag == 2) Console.WriteLine(nInit + " :(");
        }

        public static long SumY(BigInteger x, double sumY)
        {
            for (int i = 0; i < x.ToString().Length; i++)
            {
                string y = x.ToString()[i].ToString();
                sumY += Math.Pow(long.Parse(y), 2);
            }

            return (long)sumY;
        }
    }
}
