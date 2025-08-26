namespace Rftim3LeetCode.Temp
{
    public class _01220_CountVowelsPermutation
    {
        /// <summary>
        /// Given an integer n, your task is to count how many strings of length n can be formed under the following rules:
        /// 
        /// Each character is a lower case vowel('a', 'e', 'i', 'o', 'u')
        /// Each vowel 'a' may only be followed by an 'e'.
        /// Each vowel 'e' may only be followed by an 'a' or an 'i'.
        /// Each vowel 'i' may not be followed by another 'i'.
        /// Each vowel 'o' may only be followed by an 'i' or a 'u'.
        /// Each vowel 'u' may only be followed by an 'a'.
        /// Since the answer may be too large, return it modulo 10^9 + 7.
        /// </summary>
        public _01220_CountVowelsPermutation()
        {
            Console.WriteLine(CountVowelPermutation0(1));
            Console.WriteLine(CountVowelPermutation0(2));
        }

        public static int CountVowelPermutation0(int a0) => RftCountVowelPermutation0(a0);

        public static int CountVowelPermutation1(int a0) => RftCountVowelPermutation1(a0);

        private static int RftCountVowelPermutation0(int n)
        {
            long mod = 1_000_000_007;
            long[] count = [1, 1, 1, 1, 1];

            for (int i = 2; i <= n; i++)
            {
                long[] countTemp =
                [
                    count[1],
                    (count[0] + count[2]) % mod,
                    (count[0] + count[1] + count[3] + count[4]) % mod,
                    (count[2] + count[4]) % mod,
                    count[0],
                ];
                count = countTemp;
            }

            return (int)(count.Sum() % mod);
        }

        private static readonly ulong _mod = 1000000007;

        private static int RftCountVowelPermutation1(int n)
        {
            ulong a = 1, e = 1, i = 1, o = 1, u = 1;

            for (int iter = 1; iter < n; iter++)
            {
                ulong nextA = e + i + u, nextE = a + i, nextI = e + o, nextO = i, nextU = i + o;
                a = nextA % _mod;
                e = nextE % _mod;
                i = nextI % _mod;
                o = nextO % _mod;
                u = nextU % _mod;
            }

            return (int)((a + e + i + o + u) % _mod);
        }
    }
}
