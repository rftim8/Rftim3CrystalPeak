namespace Rftim3LeetCode.Temp
{
    public class _01575_CountAllPossibleRoutes
    {
        /// <summary>
        /// You are given an array of distinct positive integers locations where locations[i] represents the position of city i. 
        /// You are also given integers start, finish and fuel representing the starting city, ending city, and the initial amount of fuel you have, respectively.
        /// At each step, if you are at city i, you can pick any city j such that j != i and 0 <= j<locations.length and move to city j.
        /// Moving from city i to city j reduces the amount of fuel you have by |locations[i] - locations[j]|. Please notice that |x| denotes the absolute value of x.
        /// Notice that fuel cannot become negative at any point in time, and that you are allowed to visit any city more than once (including start and finish).
        /// Return the count of all possible routes from start to finish.
        /// Since the answer may be too large, return it modulo 109 + 7.
        /// </summary>
        public _01575_CountAllPossibleRoutes()
        {
            Console.WriteLine(CountRoutes([2, 3, 6, 8, 4], 1, 3, 5));
            Console.WriteLine(CountRoutes([4, 3, 1], 1, 0, 6));
            Console.WriteLine(CountRoutes([5, 2, 1], 0, 2, 3));
        }

        private static int CountRoutes(int[] locations, int start, int finish, int fuel)
        {
            int n = locations.Length;
            int[][] dp = new int[n][];

            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[fuel + 1];
            }

            Array.Fill(dp[finish], 1);
            for (int j = 0; j <= fuel; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (k == i) continue;
                        if (Math.Abs(locations[i] - locations[k]) <= j) dp[i][j] = (dp[i][j] + dp[k][j - Math.Abs(locations[i] - locations[k])]) % 1000000007;
                    }
                }
            }

            return dp[start][fuel];
        }

        private static int CountRoutes0(int[] locations, int start, int finish, int fuel)
        {
            int n = locations.Length;
            int[][] memo = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                memo[i] = new int[fuel + 1];
                Array.Fill(memo[i], -1);
            }

            return Solve(locations, start, finish, fuel, memo);
        }

        private static int Solve(int[] locations, int currCity, int finish, int remainingFuel, int[][] memo)
        {
            if (remainingFuel < 0) return 0;
            if (memo[currCity][remainingFuel] != -1) return memo[currCity][remainingFuel];

            int ans = currCity == finish ? 1 : 0;
            for (int nextCity = 0; nextCity < locations.Length; nextCity++)
            {
                if (nextCity != currCity) ans = (ans + Solve(locations, nextCity, finish, remainingFuel - Math.Abs(locations[currCity] - locations[nextCity]), memo)) % 1000000007;
            }

            return memo[currCity][remainingFuel] = ans;
        }
    }
}
