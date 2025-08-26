namespace Rftim3LeetCode.Temp
{
    public class _00072_EditDistance
    {
        /// <summary>
        /// Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        /// You have the following three operations permitted on a word:
        /// Insert a character
        /// Delete a character
        /// Replace a character
        /// </summary>
        public _00072_EditDistance()
        {
            Console.WriteLine(MinDistance("horse", "ros"));
            Console.WriteLine(MinDistance("intention", "execution"));
        }

        private static int MinDistance(string word1, string word2)
        {
            int n = word1.Length;
            int m = word2.Length;
            if (string.IsNullOrEmpty(word1)) return m;
            else if (string.IsNullOrEmpty(word2)) return n;

            int[,] res = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
            {
                res[i, 0] = i;
            }

            for (int i = 1; i <= m; i++)
            {
                res[0, i] = i;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (word1[i - 1] == word2[j - 1]) res[i, j] = res[i - 1, j - 1];
                    else res[i, j] = Math.Min(res[i - 1, j - 1], Math.Min(res[i - 1, j], res[i, j - 1])) + 1;
                }
            }

            return res[n, m];
        }

        private static int MinDistance01(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;
            int[][] dp = new int[m + 1][];
            for (int w1 = 0; w1 <= m; w1++)
            {
                dp[w1] = new int[n + 1];
                dp[w1][n] = m - w1;
            }

            for (int w2 = 0; w2 < n; w2++)
            {
                dp[m][w2] = n - w2;
            }

            for (int w1 = m - 1; w1 >= 0; w1--)
            {
                for (int w2 = n - 1; w2 >= 0; w2--)
                {
                    if (word1[w1] == word2[w2])
                    {
                        dp[w1][w2] = dp[w1 + 1][w2 + 1];
                        continue;
                    }

                    dp[w1][w2] = Math.Min(dp[w1 + 1][w2 + 1], Math.Min(dp[w1][w2 + 1], dp[w1 + 1][w2])) + 1;
                }
            }

            return dp[0][0];
        }

        private static int MinDistance0(string word1, string word2)
        {
            int n = word1.Length;
            int m = word2.Length;

            int[,] dp = new int[n + 1, m + 1];

            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < m + 1; j++)
                {
                    if (i == 0 && j == 0) dp[i, j] = 0;
                    else if (i == 0) dp[i, j] = j;
                    else if (j == 0) dp[i, j] = i;
                    else
                    {
                        int word1Index = i - 1;
                        int word2Index = j - 1;

                        if (word1[word1Index] == word2[word2Index]) dp[i, j] = dp[i - 1, j - 1];
                        else dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i, j - 1], dp[i - 1, j])) + 1;
                    }
                }
            }

            return dp[n, m];
        }

        private static int MinDistance1(string word1, string word2)
        {
            int word1Length = word1.Length;
            int word2Length = word2.Length;

            if (word1Length == 0) return word2Length;
            if (word2Length == 0) return word1Length;

            int[,] dp = new int[word1Length + 1, word2Length + 1];

            for (int word1Index = 1; word1Index <= word1Length; word1Index++)
            {
                dp[word1Index, 0] = word1Index;
            }

            for (int word2Index = 1; word2Index <= word2Length; word2Index++)
            {
                dp[0, word2Index] = word2Index;
            }

            for (int word1Index = 1; word1Index <= word1Length; word1Index++)
            {
                for (int word2Index = 1; word2Index <= word2Length; word2Index++)
                {
                    if (word2[word2Index - 1] == word1[word1Index - 1]) dp[word1Index, word2Index] = dp[word1Index - 1, word2Index - 1];
                    else dp[word1Index, word2Index] = Math.Min(dp[word1Index - 1, word2Index], Math.Min(dp[word1Index, word2Index - 1], dp[word1Index - 1, word2Index - 1])) + 1;
                }
            }

            return dp[word1Length, word2Length];
        }

        private static int[,]? memo;

        private static int MinDistance2(string word1, string word2)
        {
            memo = new int[word1.Length + 1, word2.Length + 1];

            return MinDistanceRecur(word1, word2, word1.Length, word2.Length);
        }

        private static int MinDistanceRecur(string word1, string word2, int word1Index, int word2Index)
        {
            if (word1Index == 0) return word2Index;
            if (word2Index == 0) return word1Index;
            if (memo?[word1Index, word2Index] != null) return memo[word1Index, word2Index];

            int minEditDistance;
            if (word1[word1Index - 1] == word2[word2Index - 1]) minEditDistance = MinDistanceRecur(word1, word2, word1Index - 1, word2Index - 1);
            else
            {
                int insertOperation = MinDistanceRecur(word1, word2, word1Index, word2Index - 1);
                int deleteOperation = MinDistanceRecur(word1, word2, word1Index - 1, word2Index);
                int replaceOperation = MinDistanceRecur(word1, word2, word1Index - 1, word2Index - 1);
                minEditDistance = Math.Min(insertOperation, Math.Min(deleteOperation, replaceOperation)) + 1;
            }
            memo![word1Index, word2Index] = minEditDistance;

            return minEditDistance;
        }
    }
}
