namespace Rftim3LeetCode.Temp
{
    public class _00521_LongestUncommonSubsequence1
    {
        /// <summary>
        /// Given two strings a and b, return the length of the longest uncommon subsequence between a and b. 
        /// If the longest uncommon subsequence does not exist, return -1.
        /// An uncommon subsequence between two strings is a string that is a subsequence of one but not the other.
        /// A subsequence of a string s is a string that can be obtained after deleting any number of characters from s.
        /// For example, "abc" is a subsequence of "aebdc" because you can delete the underlined characters in "aebdc" to get "abc". 
        /// Other subsequences of "aebdc" include "aebdc", "aeb", and "" (empty string).
        /// </summary>
        public _00521_LongestUncommonSubsequence1()
        {
            Console.WriteLine(FindLUSlength0("aba", "cdc"));
            Console.WriteLine(FindLUSlength0("aaa", "bbb"));
            Console.WriteLine(FindLUSlength0("aaa", "aaa"));
        }

        public static int FindLUSlength0(string a0, string a1) => RftFindLUSlength0(a0, a1);

        private static int RftFindLUSlength0(string a, string b)
        {
            if (a.Equals(b)) return -1;

            return Math.Max(a.Length, b.Length);
        }
    }
}
