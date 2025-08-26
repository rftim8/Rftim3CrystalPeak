namespace Rftim3LeetCode.Temp
{
    public class _00567_PermutationInString
    {
        /// <summary>
        /// Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
        /// In other words, return true if one of s1's permutations is the substring of s2.
        /// </summary>
        public _00567_PermutationInString()
        {
            Console.WriteLine(CheckInclusion("ab", "eidbaooo"));
            Console.WriteLine(CheckInclusion("ab", "eidboaoo"));
        }

        private static bool CheckInclusion(string s1, string s2)
        {
            int n = s2.Length;
            int x = 0;
            int y = s1.Length;
            char[] z1 = s1.ToCharArray();
            Array.Sort(z1);

            for (int i = 0; i <= n - y; i++, x++)
            {
                char[] z = s2[x..(x + y)].ToCharArray();
                Array.Sort(z);
                if (z1.SequenceEqual(z)) return true;
            }

            return false;
        }
    }
}
