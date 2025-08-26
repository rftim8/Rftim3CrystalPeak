namespace Rftim3LeetCode.Temp
{
    public class _00009_PalindromeNumber
    {
        /// <summary>
        /// Given an integer x, return true if x is a palindrome, and false otherwise.
        /// </summary>
        public _00009_PalindromeNumber()
        {
            Console.WriteLine(PalindromeNumber0(121));
            Console.WriteLine(PalindromeNumber0(-121));
            Console.WriteLine(PalindromeNumber0(10));
        }

        public static bool PalindromeNumber0(int a0) => RftPalindromeNumber0(a0);

        public static bool PalindromeNumber1(int a0) => RftPalindromeNumber1(a0);

        private static bool RftPalindromeNumber0(int x)
        {
            string y = x.ToString();
            for (int i = 0; i < y.Length / 2; i++)
            {
                if (y[i] != y[y.Length - i - 1]) return false;
            }

            return true;
        }

        private static bool RftPalindromeNumber1(int x)
        {
            if (x < 0 || x % 10 == 0 && x != 0) return false;

            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            return x == revertedNumber || x == revertedNumber / 10;
        }
    }
}
