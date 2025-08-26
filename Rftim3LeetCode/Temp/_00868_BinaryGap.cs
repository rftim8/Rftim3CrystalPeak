namespace Rftim3LeetCode.Temp
{
    public class _00868_BinaryGap
    {
        /// <summary>
        /// Given a positive integer n, find and return the longest distance between any two adjacent 1's in the binary representation of n. 
        /// If there are no two adjacent 1's, return 0.
        /// Two 1's are adjacent if there are only 0's separating them(possibly no 0's). 
        /// The distance between two 1's is the absolute difference between their bit positions.
        /// For example, the two 1's in "1001" have a distance of 3.
        /// </summary>
        public _00868_BinaryGap()
        {
            Console.WriteLine(BinaryGap(22));
            Console.WriteLine(BinaryGap(8));
            Console.WriteLine(BinaryGap(5));
        }

        private static int BinaryGap(int n)
        {
            string x = Convert.ToString(n, 2);
            int m = x.Length;
            int[] r = new int[m];

            int c = 0;
            for (int i = 0; i < m; i++)
            {
                if (x[i] == '1')
                {
                    r[i] = c;
                    c = 1;
                }
                else c++;
            }

            return r.Max();
        }

        private static int BinaryGap0(int n)
        {
            int max = 0;
            int cur = 0;

            while (n != 0)
            {
                if ((n & 1) == 1) break;
                n >>= 1;
            }
            n >>= 1;

            while (n != 0)
            {
                if ((n & 1) == 1)
                {
                    max = Math.Max(max, cur + 1);
                    cur = 0;
                }
                else cur++;

                n >>= 1;
            }

            return max;
        }
    }
}
