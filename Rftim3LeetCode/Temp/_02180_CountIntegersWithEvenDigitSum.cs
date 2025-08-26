namespace Rftim3LeetCode.Temp
{
    public class _02180_CountIntegersWithEvenDigitSum
    {
        /// <summary>
        /// Given a positive integer num, return the number of positive integers less than or equal to num whose digit sums are even.
        /// The digit sum of a positive integer is the sum of all its digits.
        /// </summary>
        public _02180_CountIntegersWithEvenDigitSum()
        {
            Console.WriteLine(CountEven(4));
            Console.WriteLine(CountEven(30));
        }

        private static int CountEven(int num)
        {
            int r = 0;

            for (int i = 1; i <= num; i++)
            {
                int j = i;
                int t = 0;
                while (j > 0)
                {
                    t += j % 10;
                    j /= 10;
                }
                if (t % 2 == 0) r++;
            }

            return r;
        }
    }
}
