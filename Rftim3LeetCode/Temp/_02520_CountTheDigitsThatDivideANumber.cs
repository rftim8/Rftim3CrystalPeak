namespace Rftim3LeetCode.Temp
{
    public class _02520_CountTheDigitsThatDivideANumber
    {
        /// <summary>
        /// Given an integer num, return the number of digits in num that divide num.
        /// An integer val divides nums if nums % val == 0.
        /// </summary>
        public _02520_CountTheDigitsThatDivideANumber()
        {
            Console.WriteLine(CountDigits(7));
            Console.WriteLine(CountDigits(121));
            Console.WriteLine(CountDigits(1248));
        }

        private static int CountDigits(int num)
        {
            int c = 0;
            int t = num;

            while (t > 0)
            {
                if (num % (t % 10) == 0) c++;
                t /= 10;
            }

            return c;
        }
    }
}
