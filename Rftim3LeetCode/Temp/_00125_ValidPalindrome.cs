namespace Rftim3LeetCode.Temp
{
    public class _00125_ValidPalindrome
    {
        /// <summary>
        /// A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, 
        /// it reads the same forward and backward. Alphanumeric characters include letters and numbers.
        /// Given a string s, return true if it is a palindrome, or false otherwise.
        /// </summary>
        public _00125_ValidPalindrome()
        {
            Console.WriteLine(IsPalindrome0("A man, a plan, a canal: Panama"));
            Console.WriteLine(IsPalindrome0("race a car"));
            Console.WriteLine(IsPalindrome0(" "));
        }

        public static bool IsPalindrome0(string a0) => RftIsPalindrome0(a0);

        private static bool RftIsPalindrome0(string s)
        {
            int n = s.Length;

            string x = "";

            for (int i = 0; i < n; i++)
            {
                if (char.IsLetter(s[i]) || char.IsNumber(s[i])) x += s[i].ToString().ToLower();
            }

            for (int i = 0; i < x.Length / 2; i++)
            {
                if (x[i] != x[x.Length - i - 1]) return false;
            }

            return true;
        }
    }
}
