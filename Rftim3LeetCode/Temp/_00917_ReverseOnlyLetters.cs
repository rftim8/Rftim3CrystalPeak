namespace Rftim3LeetCode.Temp
{
    public class _00917_ReverseOnlyLetters
    {
        /// <summary>
        /// Given a string s, reverse the string according to the following rules:
        /// All the characters that are not English letters remain in the same position.
        /// All the English letters(lowercase or uppercase) should be reversed.
        /// Return s after reversing it.
        /// </summary>
        public _00917_ReverseOnlyLetters()
        {
            Console.WriteLine(ReverseOnlyLetters("ab-cd"));
            Console.WriteLine(ReverseOnlyLetters("a-bC-dEf-ghIj"));
            Console.WriteLine(ReverseOnlyLetters("Test1ng-Leet=code-Q!"));
        }

        private static string ReverseOnlyLetters(string s)
        {
            int n = s.Length;
            char[] x = s.ToCharArray();

            int l = 0, r = n - 1;
            while (l < r)
            {
                bool lc = char.IsLetter(x[l]);
                bool rc = char.IsLetter(x[r]);

                if (!lc) l++;
                if (!rc) r--;

                if (lc && rc)
                {
                    (x[l], x[r]) = (x[r], x[l]);
                    l++;
                    r--;
                }
            }

            return string.Concat(x);
        }
    }
}
