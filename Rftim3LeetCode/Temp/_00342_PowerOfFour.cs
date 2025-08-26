namespace Rftim3LeetCode.Temp
{
    public class _00342_PowerOfFour
    {
        /// <summary>
        /// Given an integer n, return true if it is a power of four. 
        /// Otherwise, return false.
        /// 
        /// An integer n is a power of four, if there exists an integer x such that n == 4x.
        /// </summary>
        public _00342_PowerOfFour()
        {

        }

        public static bool PowerOfFour0(int a0) => RftPowerOfFour0(a0);

        private static bool RftPowerOfFour0(int n)
        {
            return Math.Log10(n) / Math.Log10(4) % 1 == 0;
        }
    }
}