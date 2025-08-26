namespace Rftim3LeetCode.Temp
{
    public class _00879_ProfitableSchemes
    {
        /// <summary>
        /// There is a group of n members, and a list of various crimes they could commit. The ith crime generates a profit[i] and requires group[i] members to participate in it.
        /// If a member participates in one crime, that member can't participate in another crime.
        /// Let's call a profitable scheme any subset of these crimes that generates at least minProfit profit,
        /// and the total number of members participating in that subset of crimes is at most n.
        /// Return the number of schemes that can be chosen.Since the answer may be very large, return it modulo 109 + 7.
        /// </summary>
        public _00879_ProfitableSchemes()
        {
            Console.WriteLine(ProfitableSchemes(5, 3, [2, 2], [2, 3]));
            Console.WriteLine(ProfitableSchemes(10, 5, [2, 3, 5], [6, 7, 8]));
        }

        private static int ProfitableSchemes(int n, int minProfit, int[] group, int[] profit)
        {
            int mod = 1000000007;
            int[,,] dp = new int[101, 101, 101];
            int m = group.Length;

            for (int count = 0; count <= n; count++)
            {
                dp[m, count, minProfit] = 1;
            }

            for (int index = m - 1; index >= 0; index--)
            {
                for (int count = 0; count <= n; count++)
                {
                    for (int profits = 0; profits <= minProfit; profits++)
                    {
                        dp[index, count, profits] = dp[index + 1, count, profits];
                        if (count + group[index] <= n)
                        {
                            dp[index, count, profits] = (dp[index, count, profits] + dp[index + 1, count + group[index], Math.Min(minProfit, profits + profit[index])]) % mod;
                        }
                    }
                }
            }

            return dp[0, 0, 0];
        }
    }
}
