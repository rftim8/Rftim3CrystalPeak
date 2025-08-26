namespace Rftim3LeetCode.Temp
{
    public class _01716_CalculateMoneyInLeetcodeBank
    {
        /// <summary>
        /// Hercy wants to save money for his first car. He puts money in the Leetcode bank every day.
        /// He starts by putting in $1 on Monday, the first day.Every day from Tuesday to Sunday, he will put in $1 more than the day before.
        /// On every subsequent Monday, he will put in $1 more than the previous Monday.
        /// Given n, return the total amount of money he will have in the Leetcode bank at the end of the nth day.
        /// </summary>
        public _01716_CalculateMoneyInLeetcodeBank()
        {
            Console.WriteLine(TotalMoney(4));
            Console.WriteLine(TotalMoney(10));
            Console.WriteLine(TotalMoney(20));
        }

        private static int TotalMoney(int n)
        {
            int t = 0, i = t, r = 0;
            for (int j = 0; j < n; j++, i++)
            {
                if (j % 7 == 0)
                {
                    t++;
                    i = t;
                }

                r += i;
            }

            return r;
        }
    }
}
