namespace Rftim3LeetCode.Temp
{
    public class _02609_FindTheLongestBalancedSubstringOfABinaryString
    {
        /// <summary>
        /// You are given a binary string s consisting only of zeroes and ones.
        /// A substring of s is considered balanced if all zeroes are before ones and the number of zeroes is equal to the number of ones inside the substring.
        /// Notice that the empty substring is considered a balanced substring.
        /// Return the length of the longest balanced substring of s.
        /// A substring is a contiguous sequence of characters within a string.
        /// </summary>
        public _02609_FindTheLongestBalancedSubstringOfABinaryString()
        {
            Console.WriteLine(FindTheLongestBalancedSubstring("01000111"));
            Console.WriteLine(FindTheLongestBalancedSubstring("00111"));
            Console.WriteLine(FindTheLongestBalancedSubstring("111"));
        }

        private static int FindTheLongestBalancedSubstring(string s)
        {
            int result = 0;

            for (int i = 0, zeroes = 0, ones = 0; i < s.Length; ++i)
            {
                if (s[i] == '0')
                {
                    if (i > 0 && s[i - 1] == '1') zeroes = 0;

                    ones = 0;
                    zeroes += 1;
                }
                else result = Math.Max(result, 2 * Math.Min(ones += 1, zeroes));
            }

            return result;
        }

        private static int FindTheLongestBalancedSubstring0(string s)
        {
            int ans = 0;
            int i = 0;
            while (i < s.Length)
            {
                int zz = 0;
                int oo = 0;
                while (i < s.Length && s[i] == '0')
                {
                    zz++;
                    i++;
                }
                while (i < s.Length && s[i] == '1')
                {
                    oo++;
                    i++;
                }
                ans = Math.Max(ans, Math.Min(zz, oo));
            }

            return ans * 2;
        }
    }
}
