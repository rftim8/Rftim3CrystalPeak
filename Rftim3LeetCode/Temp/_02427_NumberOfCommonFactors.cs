namespace Rftim3LeetCode.Temp
{
    public class _02427_NumberOfCommonFactors
    {
        /// <summary>
        /// Given two positive integers a and b, return the number of common factors of a and b.
        /// An integer x is a common factor of a and b if x divides both a and b.
        /// </summary>
        public _02427_NumberOfCommonFactors()
        {
            Console.WriteLine(CommonFactors(12, 6));
            Console.WriteLine(CommonFactors(25, 30));
        }

        private static int CommonFactors(int a, int b)
        {
            int t = a > b ? a : b;

            int c = 0;
            for (int i = 1; i <= t; i++)
            {
                if (a % i == 0 && b % i == 0) c++;
            }

            return c;
        }
    }
}
