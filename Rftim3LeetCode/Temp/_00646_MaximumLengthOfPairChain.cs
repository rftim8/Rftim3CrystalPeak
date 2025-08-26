namespace Rftim3LeetCode.Temp
{
    public class _00646_MaximumLengthOfPairChain
    {
        /// <summary>
        /// You are given an array of n pairs pairs where pairs[i] = [lefti, righti] and lefti < righti.
        /// A pair p2 = [c, d] follows a pair p1 = [a, b] if b < c.
        /// A chain of pairs can be formed in this fashion.
        /// Return the length longest chain which can be formed.
        /// You do not need to use up all the given intervals.You can select pairs in any order.
        /// </summary>
        public _00646_MaximumLengthOfPairChain()
        {
            Console.WriteLine(FindLongestChain(
            [
                [1, 2],
                [2, 3],
                [3, 4]
            ]));

            Console.WriteLine(FindLongestChain(
            [
                [1, 2],
                [7, 8],
                [4, 5]
            ]));
        }

        // Greedy
        private static int FindLongestChain(int[][] pairs)
        {
            Array.Sort(pairs, (a, b) => a[1] - b[1]);
            int curr = int.MinValue;
            int ans = 0;

            foreach (int[] pair in pairs)
            {
                if (pair[0] > curr)
                {
                    ans++;
                    curr = pair[1];
                }
            }

            return ans;
        }

        // Recursive DP
        private static int FindLongestChain0(int[][] pairs)
        {
            int n = pairs.Length;
            Array.Sort(pairs, (a, b) => a[0] - b[0]);
            int[] memo = new int[n];

            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                ans = Math.Max(ans, LongestPairChain(i, pairs, n, memo));
            }

            return ans;
        }

        private static int LongestPairChain(int i, int[][] pairs, int n, int[] memo)
        {
            if (memo[i] != 0) return memo[i];

            memo[i] = 1;
            for (int j = i + 1; j < n; j++)
            {
                if (pairs[i][1] < pairs[j][0]) memo[i] = Math.Max(memo[i], 1 + LongestPairChain(j, pairs, n, memo));
            }

            return memo[i];
        }

        // Iterative DP
        private static int FindLongestChain1(int[][] pairs)
        {
            int n = pairs.Length;
            Array.Sort(pairs, (a, b) => a[0] - b[0]);
            int[] dp = new int[n];
            Array.Fill(dp, 1);
            int ans = 1;

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (pairs[i][1] < pairs[j][0]) dp[i] = Math.Max(dp[i], 1 + dp[j]);
                }
                ans = Math.Max(ans, dp[i]);
            }

            return ans;
        }
    }
}
