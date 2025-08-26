namespace Rftim3LeetCode.Temp
{
    public class _01416_RestoreTheArray
    {
        /// <summary>
        /// A program was supposed to print an array of integers. 
        /// The program forgot to print whitespaces and the array is printed as a string of digits s and 
        /// all we know is that all integers in the array were in the range [1, k] and there are no leading zeros in the array.
        /// Given the string s and the integer k, return the number of the possible arrays that can be printed 
        /// as s using the mentioned program.Since the answer may be very large, return it modulo 109 + 7.
        /// </summary>
        public _01416_RestoreTheArray()
        {
            Console.WriteLine(NumberOfArrays("1000", 10000));
            Console.WriteLine(NumberOfArrays("1000", 10));
            Console.WriteLine(NumberOfArrays("1317", 2000));
        }

        private static int NumberOfArrays(string s, int k)
        {
            int n = s.Length;
            int mod = 1_000_000_007;

            int[] dp = new int[n + 1];
            dp[0] = 1;

            for (int start = 0; start < n; ++start)
            {
                if (s[start] == '0') continue;

                for (int end = start; end < n; ++end)
                {
                    string crt = s[start..(end + 1)];
                    if (long.Parse(crt) > k) break;
                    dp[end + 1] = (dp[end + 1] + dp[start]) % mod;
                }
            }

            return dp[n];
        }

        private static int NumberOfArrays0(string s, int k)
        {
            int m = s.Length;
            int[] dp = new int[m + 1];

            return Dfs(dp, 0, s, k);
        }

        private static int Dfs(int[] dp, int start, string s, int k)
        {
            int mod = 1_000_000_007;
            int n = s.Length;
            if (dp[start] != 0) return dp[start];
            if (start == n) return 1;
            if (s[start] == '0') return 0;

            int count = 0;
            for (int end = start; end < n; ++end)
            {
                string crt = s[start..(end + 1)];
                if (long.Parse(crt) > k) break;
                count = (count + Dfs(dp, end + 1, s, k)) % mod;
            }

            dp[start] = count;

            return count;
        }

        private static int NumberOfArrays1(string s, int k)
        {
            int m = s.Length;
            int n = k.ToString().Length;
            int mod = 1_000_000_007;

            int[] dp = new int[n + 1];

            dp[0] = 1;

            for (int start = 0; start < m; ++start)
            {
                if (s[start] == '0')
                {
                    dp[start % (n + 1)] = 0;
                    continue;
                }

                for (int end = start; end < m; ++end)
                {
                    string currNumber = s[start..(end + 1)];

                    if (long.Parse(currNumber) > k) break;

                    dp[(end + 1) % (n + 1)] = (dp[(end + 1) % (n + 1)] + dp[start % (n + 1)]) % mod;
                }

                dp[start % (n + 1)] = 0;
            }

            return dp[m % (n + 1)];
        }
    }
}
