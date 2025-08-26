namespace Rftim3LeetCode.Temp
{
    public class _00790_DominoAndTrominoTiling
    {
        /// <summary>
        /// You have two types of tiles: a 2 x 1 domino shape and a tromino shape. 
        /// You may rotate these shapes.
        /// 
        /// Given an integer n, return the number of ways to tile an 2 x n board.
        /// Since the answer may be very large, return it modulo 109 + 7.
        /// 
        /// In a tiling, every square must be covered by a tile.
        /// Two tilings are different if and only if there are two 4-directionally adjacent cells 
        /// on the board such that exactly one of the tilings has both squares occupied by a tile.
        /// </summary>
        public _00790_DominoAndTrominoTiling()
        {
            Console.WriteLine(DominoAndTrominoTiling0(3));
            Console.WriteLine(DominoAndTrominoTiling0(1));
        }

        public static int DominoAndTrominoTiling0(int a0) => RftDominoAndTrominoTiling0(a0);

        public static int DominoAndTrominoTiling1(int a0) => RftDominoAndTrominoTiling1(a0);

        public static int DominoAndTrominoTiling2(int a0) => RftDominoAndTrominoTiling2(a0);

        public static int DominoAndTrominoTiling3(int a0) => RftDominoAndTrominoTiling3(a0);

        public static int DominoAndTrominoTiling4(int a0) => RftDominoAndTrominoTiling4(a0);

        public static int DominoAndTrominoTiling5(int a0) => RftDominoAndTrominoTiling5(a0);

        public static int DominoAndTrominoTiling6(int a0) => RftDominoAndTrominoTiling6(a0);

        // Bottom-Up DP
        private static int RftDominoAndTrominoTiling0(int n)
        {
            int MOD = 1_000_000_007;
            if (n <= 2) return n;

            long[] f = new long[n + 1];
            long[] p = new long[n + 1];

            f[1] = 1L;
            f[2] = 2L;
            p[2] = 1L;
            for (int k = 3; k < n + 1; ++k)
            {
                f[k] = (f[k - 1] + f[k - 2] + 2 * p[k - 1]) % MOD;
                p[k] = (p[k - 1] + f[k - 2]) % MOD;
            }

            return (int)f[n];
        }

        // Bottom-Up DP Space Optimized
        private static int RftDominoAndTrominoTiling1(int n)
        {
            int MOD = 1_000_000_007;
            if (n <= 2) return n;

            long fPrevious = 1L;
            long fCurrent = 2L;
            long pCurrent = 1L;
            for (int k = 3; k < n + 1; ++k)
            {
                long tmp = fCurrent;
                fCurrent = (fCurrent + fPrevious + 2 * pCurrent) % MOD;
                pCurrent = (pCurrent + fPrevious) % MOD;
                fPrevious = tmp;
            }

            return (int)fCurrent;
        }

        // Top-Down DP
        private static int RftDominoAndTrominoTiling2(int n) => (int)F(n);

        private static readonly int MOD = 1_000_000_007;
        private static readonly Dictionary<int, long> f_cache = [];
        private static readonly Dictionary<int, long> p_cache = [];

        private static long P(int n)
        {
            if (p_cache.TryGetValue(n, out long value)) return value;

            long val;
            if (n == 2) val = 1L;
            else val = (P(n - 1) + F(n - 2)) % MOD;

            p_cache.Add(n, val);

            return val;
        }

        private static long F(int n)
        {
            if (f_cache.TryGetValue(n, out long value)) return value;

            long val;
            if (n == 1) val = 1L;
            else if (n == 2) val = 2L;
            else val = (F(n - 1) + F(n - 2) + 2 * P(n - 1)) % MOD;

            f_cache.Add(n, val);

            return val;
        }

        // Matrix Exponentiation
        private static readonly long[][] SQ_MATRIX = [
            [1, 1, 2],
            [1, 0, 0],
            [0, 1, 1],
        ];
        private static readonly int SIZE = 3;

        private static int RftDominoAndTrominoTiling3(int n)
        {
            if (n <= 2) return n;

            return MatrixExpo(n - 2);
        }

        private static long[][] MatrixProduct(long[][] m1, long[][] m2)
        {
            long[][] ans = new long[SIZE][];
            for (int row = 0; row < SIZE; ++row)
            {
                ans[row] = new long[SIZE];
                for (int col = 0; col < SIZE; ++col)
                {
                    long curSum = 0;
                    for (int k = 0; k < SIZE; ++k)
                    {
                        curSum = (curSum + m1[row][k] * m2[k][col]) % MOD;
                    }
                    ans[row][col] = curSum;
                }
            }

            return ans;
        }

        private static int MatrixExpo(int n)
        {
            long[][] cur = SQ_MATRIX;
            for (int i = 1; i < n; ++i)
            {
                cur = MatrixProduct(cur, SQ_MATRIX);
            }

            return (int)((cur[0][0] * 2 + cur[0][1] * 1 + cur[0][2] * 1) % MOD);
        }

        // Matrix Exponentiation: Time Optimization, Space/Time Trade Off
        private static readonly Dictionary<int, long[][]> cache = [];

        private static int RftDominoAndTrominoTiling4(int n)
        {
            if (n <= 2) return n;

            long[] ans = MatrixExpo4(n - 2)[0];

            return (int)((ans[0] * 2 + ans[1] * 1 + ans[2] * 1) % MOD);
        }

        private static long[][] MatrixProduct4(long[][] m1, long[][] m2)
        {
            long[][] ans = new long[SIZE][];
            for (int row = 0; row < SIZE; ++row)
            {
                ans[row] = new long[SIZE];
                for (int col = 0; col < SIZE; ++col)
                {
                    long sum = 0L;
                    for (int k = 0; k < SIZE; ++k)
                    {
                        sum = (sum + m1[row][k] * m2[k][col]) % MOD;
                    }
                    ans[row][col] = sum;
                }
            }

            return ans;
        }

        private static long[][] MatrixExpo4(int n)
        {
            if (cache.TryGetValue(n, out long[][]? value)) return value;

            long[][] cur;
            if (n == 1) cur = SQ_MATRIX;
            else if (n % 2 == 1) cur = MatrixProduct4(MatrixExpo4(n - 1), SQ_MATRIX);
            else cur = MatrixProduct4(MatrixExpo4(n / 2), MatrixExpo4(n / 2));

            cache.Add(n, cur);

            return cur;
        }

        // Math Optimization Fibonacci Sequence
        private static int RftDominoAndTrominoTiling5(int n)
        {
            int MOD = 1_000_000_007;
            if (n <= 2) return n;

            long fCurrent = 5L;
            long fPrevious = 2;
            long fBeforePrevious = 1;
            for (int k = 4; k < n + 1; ++k)
            {
                long tmp = fPrevious;
                fPrevious = fCurrent;
                fCurrent = (2 * fCurrent + fBeforePrevious) % MOD;
                fBeforePrevious = tmp;
            }

            return (int)(fCurrent % MOD);
        }

        private static int RftDominoAndTrominoTiling6(int n)
        {
            if (n < 3) return n;

            int[] result = new int[n];
            result[0] = 1;
            result[1] = 2;
            result[2] = 5;

            for (int i = 3; i < n; i++)
            {
                result[i] = (int)(2 * result[i - 1] % (1e9 + 7)) + result[i - 3];
                result[i] = (int)(result[i] % (1e9 + 7));
            }

            return result[n - 1];
        }
    }
}
