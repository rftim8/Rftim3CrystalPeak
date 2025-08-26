namespace Rftim3LeetCode.Temp
{
    public class _00441_ArrangingCoins
    {
        /// <summary>
        /// You have n coins and you want to build a staircase with these coins. 
        /// The staircase consists of k rows where the ith row has exactly i coins. 
        /// The last row of the staircase may be incomplete.
        /// Given the integer n, return the number of complete rows of the staircase you will build.
        /// </summary>
        public _00441_ArrangingCoins()
        {
            Console.WriteLine(ArrangeCoins0(5));
            Console.WriteLine(ArrangeCoins0(8));
        }

        public static int ArrangeCoins0(int a0) => RftArrangeCoins0(a0);

        public static int ArrangeCoins1(int a0) => RftArrangeCoins1(a0);

        private static int RftArrangeCoins0(int n)
        {
            if (n == 1) return 1;

            long i = 1, j = 2;
            int c = 1;

            while (i < n)
            {
                i += j;
                j++;

                if (i == n) return c + 1;
                if (i > n) return c;

                c++;
            }

            return -1;
        }

        private static int RftArrangeCoins1(int n)
        {
            long left = 0;
            long right = n;

            while (left <= right)
            {
                long mid = left + (right - left) / 2;
                long coinsUsed = mid * (mid + 1) / 2;

                if (coinsUsed == n) return (int)mid;
                if (n < coinsUsed) right = mid - 1;
                else left = mid + 1;
            }

            return (int)right;
        }
    }
}
