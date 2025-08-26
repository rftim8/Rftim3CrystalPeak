namespace Rftim3LeetCode.Temp
{
    public class _00367_ValidPerfectSquare
    {
        /// <summary>
        /// Given a positive integer num, return true if num is a perfect square or false otherwise.
        /// A perfect square is an integer that is the square of an integer.In other words, it is the product of some integer with itself.
        /// You must not use any built-in library function, such as sqrt.
        /// </summary>
        public _00367_ValidPerfectSquare()
        {
            Console.WriteLine(IsPerfectSquare0(16));
            Console.WriteLine(IsPerfectSquare0(14));
        }

        public static bool IsPerfectSquare0(int a0) => RftIsPerfectSquare0(a0);

        private static bool RftIsPerfectSquare0(int num)
        {
            if (num == 1) return true;

            long l = 0, r = num;
            long mid = (l + r) / 2;

            while (l < r)
            {
                if (mid * mid < num) l = mid + 1;
                else if (mid * mid > num) r = mid;
                else return true;

                mid = (l + r) / 2;
            }

            return false;
        }
    }
}
