namespace Rftim3LeetCode.Temp
{
    public class _02697_LexicographicallySmallestPalindrome
    {
        /// <summary>
        /// You are given a string s consisting of lowercase English letters, and you are allowed to perform operations on it. 
        /// In one operation, you can replace a character in s with another lowercase English letter.
        /// Your task is to make s a palindrome with the minimum number of operations possible.
        /// If there are multiple palindromes that can be made using the minimum number of operations, make the lexicographically smallest one.
        /// A string a is lexicographically smaller than a string b (of the same length) if in the first position where a and b differ, 
        /// string a has a letter that appears earlier in the alphabet than the corresponding letter in b.
        /// Return the resulting palindrome string.
        /// </summary>
        public _02697_LexicographicallySmallestPalindrome()
        {
            Console.WriteLine(MakeSmallestPalindrome("egcfe"));
            Console.WriteLine(MakeSmallestPalindrome("abcd"));
            Console.WriteLine(MakeSmallestPalindrome("seven"));
        }

        private static string MakeSmallestPalindrome(string s)
        {
            int l = 0, r = s.Length - 1;
            char[] x = s.ToCharArray();

            while (l < r)
            {
                if (x[l] > x[r]) x[l] = x[r];
                else x[r] = x[l];

                l++;
                r--;
            }

            return string.Concat(x);
        }
    }
}
