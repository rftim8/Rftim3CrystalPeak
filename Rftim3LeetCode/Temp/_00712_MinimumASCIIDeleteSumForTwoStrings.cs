namespace Rftim3LeetCode.Temp
{
    public class _00712_MinimumASCIIDeleteSumForTwoStrings
    {
        /// <summary>
        /// Given two strings s1 and s2, return the lowest ASCII sum of deleted characters to make two strings equal.
        /// </summary>

        // Recursion
        private static int MinimumDeleteSum(string s1, string s2)
        {
            return ComputeCost(s1, s2, s1.Length - 1, s2.Length - 1);
        }

        private static int ComputeCost(string s1, string s2, int i, int j)
        {
            if (i < 0)
            {
                int deleteCost = 0;
                for (int pointer = 0; pointer <= j; pointer++)
                {
                    deleteCost += s2[pointer];
                }

                return deleteCost;
            }

            if (j < 0)
            {
                int deleteCost = 0;
                for (int pointer = 0; pointer <= i; pointer++)
                {
                    deleteCost += s1[pointer];
                }

                return deleteCost;
            }

            if (s1[i] == s2[j]) return ComputeCost(s1, s2, i - 1, j - 1);
            else
            {
                return Math.Min(
                    s1[i] + ComputeCost(s1, s2, i - 1, j),
                    Math.Min(
                        s2[j] + ComputeCost(s1, s2, i, j - 1),
                        s1[i] + s2[j] + ComputeCost(s1, s2, i - 1, j - 1)
                    )
                );
            }
        }

        // Top-Down DP
        private static Dictionary<(int, int), int>? savedResult;

        private static int MinimumDeleteSum0(string s1, string s2)
        {
            savedResult = [];
            return ComputeCost0(s1, s2, s1.Length - 1, s2.Length - 1);
        }

        private static int ComputeCost0(string s1, string s2, int i, int j)
        {
            if (i < 0 && j < 0) return 0;

            (int, int) key = new(i, j);
            if (savedResult!.TryGetValue(key, out int value)) return value;

            if (i < 0)
            {
                savedResult.Add(key, s2[j] + ComputeCost0(s1, s2, i, j - 1));

                return savedResult[key];
            }
            if (j < 0)
            {
                savedResult.Add(key, s1[i] + ComputeCost0(s1, s2, i - 1, j));

                return savedResult[key];
            }

            if (s1[i] == s2[j]) savedResult.Add(key, ComputeCost0(s1, s2, i - 1, j - 1));
            else
            {
                savedResult.Add(key, Math.Min(
                    s1[i] + ComputeCost0(s1, s2, i - 1, j),
                    s2[j] + ComputeCost0(s1, s2, i, j - 1)
                ));
            }

            return savedResult[key];
        }

        // Top-Down Optimized
        private static int MinimumDeleteSum00(string s1, string s2)
        {
            int m = s1.Length;
            int[] s1_ascii_sum = new int[m];
            s1_ascii_sum[0] = s1[0];
            for (int i = 1; i < m; i++)
            {
                s1_ascii_sum[i] = s1[i] + s1_ascii_sum[i - 1];
            }

            int n = s2.Length;
            int[] s2_ascii_sum = new int[n];
            s2_ascii_sum[0] = s2[0];
            for (int i = 1; i < n; i++)
            {
                s2_ascii_sum[i] = s2[i] + s2_ascii_sum[i - 1];
            }

            int[][] savedResult = new int[m][];
            for (int i = 0; i < m; i++)
            {
                savedResult[i] = new int[n];
                Array.Fill(savedResult[i], -1);
            }

            return ComputeCost00(s1, s2, m - 1, n - 1, savedResult, s1_ascii_sum, s2_ascii_sum);
        }

        private static int ComputeCost00(string s1, string s2, int i, int j, int[][] savedResult, int[] s1_ascii_sum, int[] s2_ascii_sum)
        {
            if (i < 0 && j < 0) return 0;
            if (i < 0) return s2_ascii_sum[j];
            if (j < 0) return s1_ascii_sum[i];
            if (savedResult[i][j] != -1) return savedResult[i][j];

            if (s1[i] == s2[j])
            {
                savedResult[i][j] = ComputeCost00(s1, s2, i - 1, j - 1, savedResult, s1_ascii_sum, s2_ascii_sum);

                return savedResult[i][j];
            }
            else
            {
                savedResult[i][j] = Math.Min(
                    s1[i] + ComputeCost00(s1, s2, i - 1, j, savedResult, s1_ascii_sum, s2_ascii_sum),
                    s2[j] + ComputeCost00(s1, s2, i, j - 1, savedResult, s1_ascii_sum, s2_ascii_sum)
                );

                return savedResult[i][j];
            }
        }

        // Bottom-Up DP
        private static int MinimumDeleteSum1(string s1, string s2)
        {
            int m = s1.Length, n = s2.Length;
            int[][] computeCost = new int[m + 1][];

            for (int i = 0; i < m + 1; i++)
            {
                computeCost[i] = new int[n + 1];
            }
            for (int i = 1; i <= m; i++)
            {
                computeCost[i][0] = computeCost[i - 1][0] + s1[i - 1];
            }
            for (int j = 1; j <= n; j++)
            {
                computeCost[0][j] = computeCost[0][j - 1] + s2[j - 1];
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s1[i - 1] == s2[j - 1]) computeCost[i][j] = computeCost[i - 1][j - 1];
                    else
                    {
                        computeCost[i][j] = Math.Min(
                            s1[i - 1] + computeCost[i - 1][j],
                            s2[j - 1] + computeCost[i][j - 1]
                        );
                    }
                }
            }

            return computeCost[m][n];
        }

        // Bottom-Up DP Space Optimized
        public int MinimumDeleteSum2(string s1, string s2)
        {
            if (s1.Length < s2.Length) return MinimumDeleteSum2(s2, s1);

            int m = s1.Length, n = s2.Length;
            int[] currRow = new int[n + 1];
            for (int j = 1; j <= n; j++)
            {
                currRow[j] = currRow[j - 1] + s2[j - 1];
            }
            for (int i = 1; i <= m; i++)
            {
                int diag = currRow[0];
                currRow[0] += s1[i - 1];

                for (int j = 1; j <= n; j++)
                {
                    int answer;

                    if (s1[i - 1] == s2[j - 1]) answer = diag;
                    else
                    {
                        answer = Math.Min(
                            s1[i - 1] + currRow[j],
                            s2[j - 1] + currRow[j - 1]
                        );
                    }

                    diag = currRow[j];
                    currRow[j] = answer;
                }
            }

            return currRow[n];
        }
    }
}
