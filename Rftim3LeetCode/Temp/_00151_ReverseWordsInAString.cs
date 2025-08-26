namespace Rftim3LeetCode.Temp
{
    public class _00151_ReverseWordsInAString
    {
        /// <summary>
        /// Given an input string s, reverse the order of the words.
        /// A word is defined as a sequence of non-space characters.The words in s will be separated by at least one space.
        /// Return a string of the words in reverse order concatenated by a single space.
        /// Note that s may contain leading or trailing spaces or multiple spaces between two words.
        /// The returned string should only have a single space separating the words.
        /// Do not include any extra spaces.
        /// </summary>
        public _00151_ReverseWordsInAString()
        {
            Console.WriteLine(ReverseWords("the sky is blue"));
            Console.WriteLine(ReverseWords("  hello world  "));
            Console.WriteLine(ReverseWords("a good   example"));
        }

        private static string ReverseWords(string s)
        {
            s = string.Join(' ', s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            int i = 0, j = s.Length - 1;

            char[] c = [.. s];
            while (i < j)
            {
                c[i] = s[j];
                c[j--] = s[i++];
            }

            i = 0;
            j = 0;

            while (i < s.Length)
            {
                while (j < c.Length && c[j] != ' ')
                {
                    j++;
                }

                int k = j - 1;

                while (i < k)
                {
                    char t = c[i];
                    c[i++] = c[k];
                    c[k--] = t;
                }

                i = j + 1;
                j = i;
            }

            return new string(c);
        }
    }
}
