namespace Rftim3LeetCode.Temp
{
    public class _00808_SoupServings
    {
        /// <summary>
        /// There are two types of soup: type A and type B. 
        /// Initially, we have n ml of each type of soup. 
        /// There are four kinds of operations:
        /// Serve 100 ml of soup A and 0 ml of soup B,
        /// Serve 75 ml of soup A and 25 ml of soup B,
        /// Serve 50 ml of soup A and 50 ml of soup B, and
        /// Serve 25 ml of soup A and 75 ml of soup B.
        /// When we serve some soup, we give it to someone, and we no longer have it. 
        /// Each turn, we will choose from the four operations with an equal probability 0.25. 
        /// If the remaining volume of soup is not enough to complete the operation, we will serve as much as possible.
        /// We stop once we no longer have some quantity of both types of soup.
        /// Note that we do not have an operation where all 100 ml's of soup B are used first.
        /// Return the probability that soup A will be empty first, plus half the probability that A and B become empty at the same time. 
        /// Answers within 10-5 of the actual answer will be accepted.
        /// </summary>

        // Bottom-Up DP
        private static double SoupServings(int n)
        {
            int m = (int)Math.Ceiling(n / 25.0);
            Dictionary<int, Dictionary<int, double>> dp = new()
            {
                { 0, new() }
            };
            dp[0].Add(0, 0.5);

            for (int k = 1; k <= m; k++)
            {
                if (!dp.ContainsKey(k)) dp.Add(k, []);
                dp[0].TryAdd(k, 1.0);
                dp[k].Add(0, 0.0);
                for (int j = 1; j <= k; j++)
                {
                    if (!dp[j].ContainsKey(k)) dp[j].Add(k, CalculateDP(j, k, dp));
                    if (!dp[k].ContainsKey(j)) dp[k].Add(j, CalculateDP(k, j, dp));
                }
                if (dp[k][k] > 1 - 1e-5) return 1;
            }

            return dp[m][m];
        }

        private static double CalculateDP(int i, int j, Dictionary<int, Dictionary<int, double>> dp)
        {
            return (dp[Math.Max(0, i - 4)][j]
                    + dp[Math.Max(0, i - 3)][j - 1]
                    + dp[Math.Max(0, i - 2)][Math.Max(0, j - 2)]
                    + dp[i - 1][Math.Max(0, j - 3)]) / 4;
        }

        // Top-Down DP Memoization
        private static double SoupServings1(int n)
        {
            int m = (int)Math.Ceiling(n / 25.0);
            Dictionary<int, Dictionary<int, double>> dp = [];

            for (int k = 1; k <= m; k++)
            {
                if (CalculateDP1(k, k, dp) > 1 - 1e-5) return 1.0;
            }

            return CalculateDP1(m, m, dp);
        }

        private static double CalculateDP1(int i, int j, Dictionary<int, Dictionary<int, double>> dp)
        {
            if (i <= 0 && j <= 0) return 0.5;
            if (i <= 0) return 1.0;
            if (j <= 0) return 0.0;
            if (dp.TryGetValue(i, out Dictionary<int, double>? value) && value.TryGetValue(j, out double value1)) return value1;

            double result = (CalculateDP1(i - 4, j, dp)
                + CalculateDP1(i - 3, j - 1, dp)
                + CalculateDP1(i - 2, j - 2, dp)
                + CalculateDP1(i - 1, j - 3, dp)) / 4.0;

            if (!dp.TryGetValue(i, out Dictionary<int, double>? value0)) dp.Add(i, new() { { j, result } });
            else
                value0.Add(j, result);

            return result;
        }

        // DFS
        private static double SoupServings2(int n)
        {
            if (n > 4800) return 1;

            return SoupServe2(n, n, []);
        }

        private static double SoupServe2(int a, int b, Dictionary<string, double> memo)
        {
            if (a <= 0 && b <= 0) return .5;
            if (b <= 0) return 0;
            if (a <= 0) return 1.0;

            string current_str = $"{a} {b}";
            if (memo.TryGetValue(current_str, out double value)) return value;

            double prob = 0;
            prob += SoupServe2(a - 100, b, memo);
            prob += SoupServe2(a - 75, b - 25, memo);
            prob += SoupServe2(a - 50, b - 50, memo);
            prob += SoupServe2(a - 25, b - 75, memo);
            memo[current_str] = prob / 4;

            return prob / 4;
        }
    }
}
