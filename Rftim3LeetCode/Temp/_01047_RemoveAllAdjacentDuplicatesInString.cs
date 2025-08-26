using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01047_RemoveAllAdjacentDuplicatesInString
    {
        /// <summary>
        /// You are given a string s consisting of lowercase English letters. A duplicate removal consists of choosing two adjacent and equal letters and removing them.
        /// We repeatedly make duplicate removals on s until we no longer can.
        /// Return the final string after all such duplicate removals have been made.It can be proven that the answer is unique.
        /// </summary>
        public _01047_RemoveAllAdjacentDuplicatesInString()
        {
            Console.WriteLine(RemoveDuplicates("abbaca"));
            Console.WriteLine(RemoveDuplicates("azxxzy"));
            Console.WriteLine(RemoveDuplicates("aa"));
            Console.WriteLine(RemoveDuplicates("a"));
        }

        private static string RemoveDuplicates(string s)
        {
            int n = s.Length;
            if (n == 1) return s;

            int l = 1;
            while (l < s.Length)
            {
                if (s[l - 1] == s[l])
                {
                    s = s[..(l - 1)] + s[(l + 1)..];
                    l = 0;
                }

                l++;
            }

            return s;
        }

        private static string RemoveDuplicates0(string s)
        {
            StringBuilder stack = new();
            foreach (char ch in s)
            {
                int currLen = stack.Length;
                if (stack.Length > 0 && stack[currLen - 1] == ch) stack.Length--;
                else stack.Append(ch);
            }

            return stack.ToString();
        }
    }
}
