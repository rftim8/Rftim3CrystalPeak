namespace Rftim3LeetCode.Temp
{
    public class _00221_MaximalSquare
    {
        /// <summary>
        /// Given an m x n binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.
        /// </summary>
        public _00221_MaximalSquare()
        {
            Console.WriteLine(MaximalSquare(new char[][]
            {
                new char[] { '1','0','1','0','0' },
                new char[] { '1','0','1','1','1' },
                new char[] { '1','1','1','1','1' },
                new char[] { '1','0','0','1','0' }
            }));
        }

        private static int MaximalSquare(char[][] matrix)
        {
            int n = matrix.Length, m = n > 0 ? matrix[0].Length : 0;
            int x = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        int len = 1;
                        bool flag = true;
                        while (len + i < n && len + j < m && flag)
                        {
                            for (int k = j; k <= len + j; k++)
                            {
                                if (matrix[i + len][k] == '0')
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            for (int k = i; k <= len + i; k++)
                            {
                                if (matrix[k][j + len] == '0')
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag) len++;
                        }
                        if (x < len) x = len;
                    }
                }
            }

            return x * x;
        }

        private static int MaximalSquare2(char[][] matrix)
        {
            int[,] dp = new int[matrix.Length + 1, matrix[0].Length + 1];
            int max = 0;
            for (int i = 1; i <= matrix.Length; i++)
            {
                for (int j = 1; j <= matrix[0].Length; j++)
                {
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        dp[i, j] = Math.Min(dp[i, j - 1], Math.Min(dp[i - 1, j], dp[i - 1, j - 1])) + 1;
                        max = Math.Max(max, dp[i, j]);
                    }
                }
            }

            return max * max;
        }

        private static int MaximalSquare0(char[][] matrix)
        {
            int rows = matrix.Length, cols = rows > 0 ? matrix[0].Length : 0;
            int[][] dp = new int[rows + 1][];
            for (int i = 0; i < rows + 1; i++)
            {
                dp[i] = new int[cols + 1];
            }
            int maxsqlen = 0;

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        dp[i][j] = Math.Min(Math.Min(dp[i][j - 1], dp[i - 1][j]), dp[i - 1][j - 1]) + 1;
                        maxsqlen = Math.Max(maxsqlen, dp[i][j]);
                    }
                }
            }
            return maxsqlen * maxsqlen;
        }

        private static int MaximalSquare1(char[][] matrix)
        {
            int rows = matrix.Length, cols = rows > 0 ? matrix[0].Length : 0;
            int[] dp = new int[cols + 1];
            int maxsqlen = 0, prev = 0;
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    int temp = dp[j];
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        dp[j] = Math.Min(Math.Min(dp[j - 1], prev), dp[j]) + 1;
                        maxsqlen = Math.Max(maxsqlen, dp[j]);
                    }
                    else dp[j] = 0;

                    prev = temp;
                }
            }
            return maxsqlen * maxsqlen;
        }
    }
}
