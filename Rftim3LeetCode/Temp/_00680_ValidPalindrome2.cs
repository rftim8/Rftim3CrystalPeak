namespace Rftim3LeetCode.Temp
{
    public class _00680_ValidPalindrome2
    {
        /// <summary>
        /// Given a string s, return true if the s can be palindrome after deleting at most one character from it.
        /// </summary>
        public _00680_ValidPalindrome2()
        {
            Console.WriteLine(ValidPalindrome("aba"));
            Console.WriteLine(ValidPalindrome("abca"));
            Console.WriteLine(ValidPalindrome("abcca"));
            Console.WriteLine(ValidPalindrome("abc"));
            Console.WriteLine(ValidPalindrome("aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga"));
            Console.WriteLine(ValidPalindrome("cbbcc"));
        }

        private static string a = "";

        private static bool ValidPalindrome(string s)
        {
            if (IsValid(s)) return true;

            string tl = a[1..];
            string tr = a[..^1];

            if (IsValid(tl)) return true;
            if (IsValid(tr)) return true;

            return false;
        }

        private static bool IsValid(string s)
        {
            int l = 0, r = s.Length - 1;

            while (l < r)
            {
                if (s[l] != s[r])
                {
                    a = s[l..(r + 1)];
                    return false;
                }

                l++;
                r--;
            }

            return true;
        }
    }
}
