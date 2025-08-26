namespace Rftim3LeetCode.Temp
{
    public class _00935_KnightDialer
    {
        /// <summary>
        /// The chess knight has a unique movement, it may move two squares vertically and one square horizontally, 
        /// or two squares horizontally and one square vertically (with both forming the shape of an L). 
        /// The possible movements of chess knight are shown in this diagaram:
        /// 
        /// A chess knight can move as indicated in the chess diagram below:
        /// 
        /// We have a chess knight and a phone pad as shown below, the knight can only stand on a numeric cell(i.e.blue cell).
        /// 
        /// Given an integer n, return how many distinct phone numbers of length n we can dial.
        /// 
        /// You are allowed to place the knight on any numeric cell initially and then you should perform n - 1 jumps to dial a number of length n.
        /// All jumps should be valid knight jumps.
        /// 
        /// As the answer may be very large, return the answer modulo 109 + 7.
        /// </summary>
        public _00935_KnightDialer()
        {
            Console.WriteLine(KnightDialer0(1));
            Console.WriteLine(KnightDialer0(2));
            Console.WriteLine(KnightDialer0(3131));
        }

        private static int[][]? memo;
        private static int _n;
        private static readonly int MOD = (int)1e9 + 7;
        private static readonly int[][] jumps =
            [
                [4, 6],
                [6, 8],
                [7, 9],
                [4, 8],
                [3, 9, 0],
                [],
                [1, 7, 0],
                [2, 6],
                [1, 3],
                [2, 4]
            ];

        public static int KnightDialer0(int a0) => RftKnightDialer0(a0);

        public static int KnightDialer1(int a0) => RftKnightDialer1(a0);

        public static int KnightDialer2(int a0) => RftKnightDialer2(a0);

        public static int KnightDialer3(int a0) => RftKnightDialer3(a0);

        public static int KnightDialer4(int a0) => RftKnightDialer4(a0);

        private static int Dp(int remain, int square)
        {
            if (remain == 0) return 1;

            if (memo![remain][square] != 0) return memo[remain][square];

            int ans = 0;
            foreach (int nextSquare in jumps[square])
            {
                ans = (ans + Dp(remain - 1, nextSquare)) % MOD;
            }

            memo[remain][square] = ans;
            return ans;
        }

        // Top-Down DP
        private static int RftKnightDialer0(int n)
        {
            _n = n;
            memo = new int[n + 1][];
            for (int i = 0; i < n + 1; i++)
            {
                memo[i] = new int[10];
            }
            int ans = 0;
            for (int square = 0; square < 10; square++)
            {
                ans = (ans + Dp(n - 1, square)) % MOD;
            }

            return ans;

        }

        // Bottom-Up DP
        private static int RftKnightDialer1(int n)
        {
            int[][] jumps =
                [
                    [4, 6],
                    [6, 8],
                    [7, 9],
                    [4, 8],
                    [3, 9, 0],
                    [],
                    [1, 7, 0],
                    [2, 6],
                    [1, 3],
                    [2, 4]
                ];

            int MOD = (int)1e9 + 7;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[10];
            }

            for (int square = 0; square < 10; square++)
            {
                dp[0][square] = 1;
            }

            for (int remain = 1; remain < n; remain++)
            {
                for (int square = 0; square < 10; square++)
                {
                    int x = 0;
                    foreach (int nextSquare in jumps[square])
                    {
                        x = (x + dp[remain - 1][nextSquare]) % MOD;
                    }

                    dp[remain][square] = x;
                }
            }

            int ans = 0;
            for (int square = 0; square < 10; square++)
            {
                ans = (ans + dp[n - 1][square]) % MOD;
            }

            return ans;
        }

        // Space-Optimized
        private static int RftKnightDialer2(int n)
        {
            int[][] jumps =
                [
                    [4, 6],
                    [6, 8],
                    [7, 9],
                    [4, 8],
                    [3, 9, 0],
                    [],
                    [1, 7, 0],
                    [2, 6],
                    [1, 3],
                    [2, 4]
                ];

            int MOD = (int)1e9 + 7;
            _ = new int[10];
            int[] prevDp = new int[10];
            Array.Fill(prevDp, 1);

            for (int remain = 1; remain < n; remain++)
            {
                int[] dp = new int[10];
                for (int square = 0; square < 10; square++)
                {
                    int x = 0;
                    foreach (int nextSquare in jumps[square])
                    {
                        x = (x + prevDp[nextSquare]) % MOD;
                    }

                    dp[square] = x;
                }

                prevDp = dp;
            }

            int ans = 0;
            for (int square = 0; square < 10; square++)
            {
                ans = (ans + prevDp[square]) % MOD;
            }

            return ans;
        }

        // Efficient iteration on states
        private static int RftKnightDialer3(int n)
        {
            if (n == 1) return 10;

            int A = 4;
            int B = 2;
            int C = 2;
            int D = 1;
            int MOD = (int)1e9 + 7;

            for (int i = 0; i < n - 1; i++)
            {
                int tempA = A;
                int tempB = B;
                int tempC = C;
                int tempD = D;

                A = (2 * tempB % MOD + 2 * tempC % MOD) % MOD;
                B = tempA;
                C = (tempA + 2 * tempD % MOD) % MOD;
                D = tempC;
            }

            int ans = (A + B) % MOD;
            ans = (ans + C) % MOD;

            return (ans + D) % MOD;
        }

        // Linear Algebra
        private static int RftKnightDialer4(int n)
        {
            if (n == 1) return 10;

            long[][] A =
                [
                    [0, 0, 0, 0, 1, 0, 1, 0, 0, 0],
                    [0, 0, 0, 0, 0, 0, 1, 0, 1, 0],
                    [0, 0, 0, 0, 0, 0, 0, 1, 0, 1],
                    [0, 0, 0, 0, 1, 0, 0, 0, 1, 0],
                    [1, 0, 0, 1, 0, 0, 0, 0, 0, 1],
                    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                    [1, 1, 0, 0, 0, 0, 0, 1, 0, 0],
                    [0, 0, 1, 0, 0, 0, 1, 0, 0, 0],
                    [0, 1, 0, 1, 0, 0, 0, 0, 0, 0],
                    [0, 0, 1, 0, 1, 0, 0, 0, 0, 0]
                ];

            long[][] v =
                [
                    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
                ];

            n--;
            while (n > 0)
            {
                if ((n & 1) != 0) v = multiply(v, A);

                A = multiply(A, A);
                n >>= 1;
            }

            int ans = 0;
            foreach (long num in v[0])
            {
                ans = (int)((ans + num) % MOD);
            }

            return ans;

            static long[][] multiply(long[][] A, long[][] B)
            {
                long[][] result = new long[A.Length][];
                for (int i = 0; i < A.Length; i++)
                {
                    result[i] = new long[B[0].Length];
                }

                for (int i = 0; i < A.Length; i++)
                {
                    for (int j = 0; j < B[0].Length; j++)
                    {
                        for (int k = 0; k < B.Length; k++)
                        {
                            result[i][j] = (result[i][j] + A[i][k] * B[k][j]) % MOD;
                        }
                    }
                }

                return result;
            }
        }
    }
}
