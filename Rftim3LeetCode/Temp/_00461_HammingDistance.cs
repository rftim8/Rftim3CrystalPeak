namespace Rftim3LeetCode.Temp
{
    public class _00461_HammingDistance
    {
        /// <summary>
        /// The Hamming distance between two integers is the number of positions at which the corresponding bits are different.
        /// Given two integers x and y, return the Hamming distance between them.
        /// </summary>
        public _00461_HammingDistance()
        {
            Console.WriteLine(HammingDistance0(1, 4));
            Console.WriteLine(HammingDistance0(3, 1));
        }

        public static int HammingDistance0(int a0, int a1) => RftHammingDistance0(a0, a1);

        public static int HammingDistance1(int a0, int a1) => RftHammingDistance1(a0, a1);

        public static int HammingDistance2(int a0, int a1) => RftHammingDistance2(a0, a1);

        private static int RftHammingDistance0(int x, int y)
        {
            int r = 0;
            if (x == 0 && y == 0) return 0;

            string x0 = Convert.ToString(x, 2);
            string y0 = Convert.ToString(y, 2);

            int padX0 = (int)Math.Ceiling((double)x0.Length / 4) * 4;
            int padY0 = (int)Math.Ceiling((double)y0.Length / 4) * 4;

            x0 = x0.PadLeft(Math.Max(padX0, padY0), '0');
            y0 = y0.PadLeft(Math.Max(padX0, padY0), '0');

            for (int i = 0; i < x0.Length; i++)
            {
                if (x0[i] != y0[i]) r++;
            }

            return r;
        }

        private static int RftHammingDistance1(int x, int y)
        {
            int dist = 0;
            while (x != 0 || y != 0)
            {
                dist += (x & 1) == (y & 1) ? 0 : 1;
                x >>= 1;
                y >>= 1;
            }

            return dist;
        }

        private static int RftHammingDistance2(int x, int y)
        {
            int xorResult = x ^ y;
            int distance = 0;

            while (xorResult > 0)
            {
                distance += xorResult & 1;
                xorResult >>= 1;
            }

            return distance;
        }
    }
}
