namespace Rftim3LeetCode.Temp
{
    public class _00392_IsSubsequence
    {
        /// <summary>
        /// Given two strings s and t, return true if s is a subsequence of t, or false otherwise.
        /// A subsequence of a string is a new string that is formed from the original string by deleting some(can be none) of the 
        /// characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).
        /// </summary>
        public _00392_IsSubsequence()
        {
            Console.WriteLine(IsSubsequence0("abc", "ahbgdc"));
            Console.WriteLine(IsSubsequence0("axc", "ahbgdc"));
        }

        public static bool IsSubsequence0(string a0, string a1) => RftIsSubsequence0(a0, a1);

        private static bool RftIsSubsequence0(string s, string t)
        {
            if (s is null || t is null) return false;

            int i = 0, j = 0;

            while (i < s.Length)
            {
                while (j < t.Length && s[i] != t[j]) j++;

                if (j == t.Length) break;

                i++;
                j++;
            }

            return i == s.Length;
        }
    }
}
