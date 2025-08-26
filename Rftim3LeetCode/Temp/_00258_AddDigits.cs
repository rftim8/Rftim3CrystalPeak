namespace Rftim3LeetCode.Temp
{
    public class _00258_AddDigits
    {
        /// <summary>
        /// Given an integer num, repeatedly add all its digits until the result has only one digit, and return it.
        /// </summary>
        public _00258_AddDigits()
        {
            Console.WriteLine(AddDigits0(38));
            Console.WriteLine(AddDigits0(0));
        }

        public static int AddDigits0(int a0) => RftAddDigits0(a0);

        public static int AddDigits1(int a0) => RftAddDigits1(a0);

        private static int RftAddDigits0(int num)
        {
            while (num.ToString().Length > 1)
            {
                int c = 0;
                while (num > 0)
                {
                    c += num % 10;
                    num /= 10;
                }
                num = c;
            }

            return num;
        }

        private static int RftAddDigits1(int num)
        {
            while (num > 9)
            {
                int a = num % 10;
                int b = (num - a) / 10;
                num = a + b;
            }

            return num;
        }
    }
}
