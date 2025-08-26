namespace Rftim3LeetCode.Temp
{
    public class _02578_SplitWithMinimumSum
    {
        /// <summary>
        /// Given a positive integer num, split it into two non-negative integers num1 and num2 such that:
        /// The concatenation of num1 and num2 is a permutation of num.
        /// In other words, the sum of the number of occurrences of each digit in num1 and num2 is equal to the number of occurrences of that digit in num.
        /// num1 and num2 can contain leading zeros.
        /// Return the minimum possible sum of num1 and num2.
        /// Notes:
        /// It is guaranteed that num does not contain any leading zeros.
        /// The order of occurrence of the digits in num1 and num2 may differ from the order of occurrence of num.
        /// </summary>
        public _02578_SplitWithMinimumSum()
        {
            Console.WriteLine(SplitNum(4325));
            Console.WriteLine(SplitNum(687));
        }

        private static int SplitNum(int num)
        {
            IEnumerable<int> digits = string.Concat(num.ToString().OrderBy(o => o)).Select(o => o - '0');

            int s1 = 0;
            int s2 = 0;

            foreach (int digit in digits)
            {
                if (s1 <= s2) s1 = s1 * 10 + digit;
                else s2 = s2 * 10 + digit;
            }

            return s1 + s2;
        }

        private static int SplitNum0(int num)
        {
            int[] digits = new int[10];

            while (num != 0)
            {
                digits[num % 10]++;
                num /= 10;
            }

            int[] n = new int[2];

            for (int i = 0, j = 0; i < digits.Length; i++)
            {
                while (digits[i]-- > 0)
                {
                    n[j % 2] = n[j % 2] * 10 + i;
                    j++;
                }
            }

            return n[0] + n[1];
        }
    }
}
