namespace Rftim3LeetCode.Temp
{
    public class _01925_CountSquareSumTriples
    {
        /// <summary>
        /// A square triple (a,b,c) is a triple where a, b, and c are integers and a2 + b2 = c2.
        /// Given an integer n, return the number of square triples such that 1 <= a, b, c <= n.
        /// </summary>
        public _01925_CountSquareSumTriples()
        {
            Console.WriteLine(CountTriples(5));
            Console.WriteLine(CountTriples(10));
        }

        private static int CountTriples0(int n)
        {
            int c = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 1; k <= n; k++)
                    {
                        if (i * i + j * j == k * k) c++;
                    }
                }
            }

            return c;
        }

        private static int CountTriples(int n)
        {
            int r = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    double c = Math.Sqrt(i * i + j * j);
                    if ((int)c == c && c <= n) r += 2;
                }
            }

            return r;
        }
    }
}
