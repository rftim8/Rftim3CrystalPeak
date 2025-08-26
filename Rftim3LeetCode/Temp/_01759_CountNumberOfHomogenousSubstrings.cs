namespace Rftim3LeetCode.Temp
{
    public class _01759_CountNumberOfHomogenousSubstrings
    {
        /// <summary>
        /// Given a string s, return the number of homogenous substrings of s. Since the answer may be too large, return it modulo 109 + 7.
        /// 
        /// A string is homogenous if all the characters of the string are the same.
        /// 
        /// A substring is a contiguous sequence of characters within a string.
        /// </summary>
        public _01759_CountNumberOfHomogenousSubstrings()
        {
            Console.WriteLine(CountHomogenous0("abbcccaa"));
            Console.WriteLine(CountHomogenous0("xy"));
            Console.WriteLine(CountHomogenous0("zzzzz"));
        }

        public static int CountHomogenous0(string a0) => RftCountHomogenous0(a0);

        private static int RftCountHomogenous0(string s)
        {
            int n = s.Length;
            if (n == 1) return 1;

            long mod0 = 1000000007;

            long r = 0;
            char a = s[0];
            int c = 1;
            for (int i = 1; i < n; i++)
            {
                if (s[i] == a) c++;
                else
                {
                    long x = 0;
                    for (int j = c; j > 0; j--)
                    {
                        x += j;
                    }
                    r += x;

                    a = s[i];
                    c = 1;
                }

                if (i == n - 1)
                {
                    long x = 0;
                    for (int j = c; j > 0; j--)
                    {
                        x += j;
                    }
                    r += x;
                }
            }

            return (int)(r % mod0);
        }
    }
}
