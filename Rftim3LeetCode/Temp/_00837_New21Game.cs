namespace Rftim3LeetCode.Temp
{
    public class _00837_New21Game
    {
        /// <summary>
        /// Alice plays the following game, loosely based on the card game "21".
        /// Alice starts with 0 points and draws numbers while she has less than k points.
        /// During each draw, she gains an integer number of points randomly from the range[1, maxPts], where maxPts is an integer. 
        /// Each draw is independent and the outcomes have equal probabilities.
        /// Alice stops drawing numbers when she gets k or more points.
        /// Return the probability that Alice has n or fewer points.
        /// Answers within 10-5 of the actual answer are considered accepted.
        /// </summary>
        public _00837_New21Game()
        {
            Console.WriteLine(New21Game(10, 1, 10));
            Console.WriteLine(New21Game(6, 1, 10));
            Console.WriteLine(New21Game(21, 17, 10));
        }

        private static double New21Game(int n, int k, int maxPts)
        {
            double[] dp = new double[n + 1];
            dp[0] = 1;
            double s = k > 0 ? 1 : 0;

            for (int i = 1; i <= n; i++)
            {
                dp[i] = s / maxPts;
                if (i < k) s += dp[i];
                if (i - maxPts >= 0 && i - maxPts < k) s -= dp[i - maxPts];
            }

            double ans = 0;
            for (int i = k; i <= n; i++)
            {
                ans += dp[i];
            }

            return ans;
        }

        private static double New21Game0(int n, int k, int maxPts)
        {
            double[] dp = new double[n + 1];
            dp[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= maxPts; j++)
                {
                    if (i - j >= 0 && i - j < k) dp[i] += dp[i - j] / maxPts;
                }
            }
            double ans = 0;
            for (int i = k; i <= n; i++)
            {
                ans += dp[i];
            }

            return ans;
        }
    }
}
