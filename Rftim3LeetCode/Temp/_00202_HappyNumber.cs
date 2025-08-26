namespace Rftim3LeetCode.Temp
{
    public class _00202_HappyNumber
    {
        /// <summary>
        /// Write an algorithm to determine if a number n is happy.
        /// A happy number is a number defined by the following process:
        /// Starting with any positive integer, replace the number by the sum of the squares of its digits.
        /// Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        /// Those numbers for which this process ends in 1 are happy.
        /// Return true if n is a happy number, and false if not.
        /// </summary>
        public _00202_HappyNumber()
        {
            Console.WriteLine(IsHappy0(19));
            Console.WriteLine(IsHappy0(2));
        }

        public static bool IsHappy0(int a0) => RftIsHappy0(a0);

        private static bool RftIsHappy0(int n)
        {
            HashSet<int> x = [];

            while (!x.Contains(n) && n != 1)
            {
                x.Add(n);

                int c = 0;
                while (n > 0)
                {
                    int d = n % 10;
                    n /= 10;
                    c += d * d;
                }
                n = c;
            }

            return n == 1;
        }
    }
}
