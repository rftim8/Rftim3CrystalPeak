namespace Rftim3LeetCode.Temp
{
    public class _00231_PowerOfTwo
    {
        /// <summary>
        /// Given an integer n, return true if it is a power of two. Otherwise, return false.
        /// An integer n is a power of two, if there exists an integer x such that n == 2x.
        /// </summary>
        public _00231_PowerOfTwo()
        {

        }

        public static bool PowerOfTwo0(int a0) => RftPowerOfTwo0(a0);

        public static bool PowerOfTwo1(int a0) => RftPowerOfTwo1(a0);

        private static bool RftPowerOfTwo0(int n)
        {
            if (n == 0 || n == int.MinValue) return false;
            if (n == 1) return true;

            char[] x = Convert.ToString(n, 2).ToCharArray();

            return x.Where(o => o == '1').Count() == 1;
        }

        private static bool RftPowerOfTwo1(int n)
        {
            return n > 0 && (n & n - 1) == 0;
        }
    }
}