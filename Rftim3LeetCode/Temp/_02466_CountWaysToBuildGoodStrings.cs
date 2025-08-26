namespace Rftim3LeetCode.Temp
{
    public class _02466_CountWaysToBuildGoodStrings
    {
        /// <summary>
        /// Given the integers zero, one, low, and high, we can construct a string by starting with an empty string, and then at each step perform either of the following:
        /// Append the character '0' zero times.
        /// Append the character '1' one times.
        /// This can be performed any number of times.
        /// A good string is a string constructed by the above process having a length between low and high (inclusive).
        /// Return the number of different good strings that can be constructed satisfying these properties. Since the answer can be large, return it modulo 109 + 7.
        /// </summary>
        public _02466_CountWaysToBuildGoodStrings()
        {
            Console.WriteLine(CountGoodStrings(3, 3, 1, 1));
            Console.WriteLine(CountGoodStrings(2, 3, 1, 2));
        }

        private static int CountGoodStrings(int low, int high, int zero, int one)
        {
            int[] x = new int[high + 1];
            x[0] = 1;
            int mod = 1_000_000_007;

            for (int end = 1; end <= high; ++end)
            {
                if (end >= zero) x[end] += x[end - zero];
                if (end >= one) x[end] += x[end - one];
                x[end] %= mod;
            }

            int y = 0;
            for (int i = low; i <= high; ++i)
            {
                y += x[i];
                y %= mod;
            }

            return y;
        }

        private static int CountGoodStrings0(int low, int high, int zero, int one)
        {
            int[] x = new int[high + 1];
            x[0] = 1;
            int mod = (int)(1e9 + 7), y = 0;

            for (int i = 1; i <= high; ++i)
            {
                if (i - zero >= 0) x[i] += x[i - zero];
                if (i - one >= 0) x[i] += x[i - one];

                x[i] %= mod;

                if (i < low) continue;

                y += x[i];
                y %= mod;
            }

            return y;
        }
    }
}
