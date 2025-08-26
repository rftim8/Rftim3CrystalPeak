namespace Rftim3LeetCode.Temp
{
    public class _00069_SqrtX
    {
        /// <summary>
        /// Given a non-negative integer x, return the square root of x rounded down to the nearest integer. 
        /// The returned integer should be non-negative as well.
        /// You must not use any built-in exponent function or operator.
        /// For example, do not use pow(x, 0.5) in c++ or x ** 0.5 in python.
        /// </summary>
        public _00069_SqrtX()
        {
            Console.WriteLine(MySqrt0(4));
            Console.WriteLine(MySqrt0(8));
        }

        public static int MySqrt0(int a0) => RftMySqrt0(a0);

        public static int MySqrt1(int a0) => RftMySqrt1(a0);

        public static int MySqrt2(int a0) => RftMySqrt2(a0);

        private static int RftMySqrt0(int x)
        {
            if (x == 0 || x == 1) return x;

            double l = 1;
            double r = Math.Floor(x / 2d);

            while (l <= r)
            {
                double mid = Math.Floor(l + (r - l) / 2);
                double l1 = mid * mid;
                double r1 = (mid + 1) * (mid + 1);

                if (l1 == x || l1 < x && r1 > x) return (int)mid;
                if (l1 < x) l = mid + 1;
                else if (l1 > x) r = mid - 1;
            }

            return -1;
        }

        private static int RftMySqrt1(int x)
        {
            return (int)Math.Floor(Math.Sqrt(x));
        }

        private static int RftMySqrt2(int x)
        {
            if (x < 2) return x;

            int l = 2;
            int r = x / 2;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                long num = (long)mid * mid;

                if (num == x) return mid;
                else if (num > x) r = mid - 1;
                else l = mid + 1;
            }

            return r;
        }
    }
}
