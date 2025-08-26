namespace Rftim3LeetCode.Temp
{
    public class _00983_MinimumCostForTickets
    {
        /// <summary>
        /// You have planned some train traveling one year in advance. 
        /// The days of the year in which you will travel are given as an integer array days. 
        /// Each day is an integer from 1 to 365.
        /// 
        /// Train tickets are sold in three different ways:
        /// 
        /// a 1-day pass is sold for costs[0] dollars,
        /// a 7-day pass is sold for costs[1] dollars, and
        /// a 30-day pass is sold for costs[2] dollars.
        /// The passes allow that many days of consecutive travel.
        /// 
        /// For example, if we get a 7-day pass on day 2, then we can travel for 7 days: 2, 3, 4, 5, 6, 7, and 8.
        /// Return the minimum number of dollars you need to travel every day in the given list of days.
        /// </summary>
        public _00983_MinimumCostForTickets()
        {
            Console.WriteLine(MinimumCostForTickets0([1, 4, 6, 7, 8, 20], [2, 7, 15]));
            Console.WriteLine(MinimumCostForTickets0([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31], [2, 7, 15]));
        }

        public static int MinimumCostForTickets0(int[] a0, int[] a1) => RftMinimumCostForTickets0(a0, a1);

        public static int MinimumCostForTickets1(int[] a0, int[] a1) => RftMinimumCostForTickets1(a0, a1);

        public static int MinimumCostForTickets2(int[] a0, int[] a1) => RftMinimumCostForTickets2(a0, a1);

        // Top-Down DP
        private static HashSet<int>? isTravelNeeded;

        private static int RftMinimumCostForTickets0(int[] days, int[] costs)
        {
            isTravelNeeded = [];

            int lastDay = days[^1];
            int[] dp = new int[lastDay + 1];
            Array.Fill(dp, -1);

            foreach (int day in days)
            {
                isTravelNeeded.Add(day);
            }

            return Solve(dp, days, costs, 1);
        }

        private static int Solve(int[] dp, int[] days, int[] costs, int currDay)
        {
            if (currDay > days[^1]) return 0;

            if (!isTravelNeeded!.Contains(currDay)) return Solve(dp, days, costs, currDay + 1);

            if (dp[currDay] != -1) return dp[currDay];

            int oneDay = costs[0] + Solve(dp, days, costs, currDay + 1);
            int sevenDay = costs[1] + Solve(dp, days, costs, currDay + 7);
            int thirtyDay = costs[2] + Solve(dp, days, costs, currDay + 30);

            return dp[currDay] = Math.Min(oneDay, Math.Min(sevenDay, thirtyDay));
        }

        // Bottom-Up DP
        private static int RftMinimumCostForTickets1(int[] days, int[] costs)
        {
            int lastDay = days[^1];
            int[] dp = new int[lastDay + 1];
            Array.Fill(dp, 0);

            int i = 0;
            for (int day = 1; day <= lastDay; day++)
            {
                if (day < days[i]) dp[day] = dp[day - 1];
                else
                {
                    i++;
                    dp[day] = Math.Min(dp[day - 1] + costs[0],
                        Math.Min(dp[Math.Max(0, day - 7)] + costs[1],
                        dp[Math.Max(0, day - 30)] + costs[2]));
                }
            }

            return dp[lastDay];
        }

        private static int RftMinimumCostForTickets2(int[] days, int[] costs)
        {
            HashSet<int> set = new(days);
            int max = days[^1];
            int[] x = new int[max + 1];

            for (int i = 1; i <= max; i++)
            {
                if (!set.Contains(i))
                {
                    x[i] = x[i - 1];
                    continue;
                }

                x[i] = Math.Min(costs[0] + x[i - 1], costs[1] + x[Math.Max(i - 7, 0)]);
                x[i] = Math.Min(x[i], costs[2] + x[Math.Max(i - 30, 0)]);
            }

            return x[max];
        }
    }
}
