using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01961_CheckIfStringIsAPrefixOfArray
    {
        /// <summary>
        /// Given a string s and an array of strings words, determine whether s is a prefix string of words.
        /// A string s is a prefix string of words if s can be made by concatenating the first k strings in words for some positive k no larger than words.length.
        /// Return true if s is a prefix string of words, or false otherwise.
        /// </summary>
        public _01961_CheckIfStringIsAPrefixOfArray()
        {
            Console.WriteLine(IsPrefixString("iloveleetcode", ["i", "love", "leetcode", "apples"]));
            Console.WriteLine(IsPrefixString("iloveleetcode", ["apples", "i", "love", "leetcode"]));
        }

        private static bool IsPrefixString(string s, string[] words)
        {
            int l = 0;
            string t = "";
            foreach (string item in words)
            {
                int m = item.Length;
                l += m;
                t += item;

                if (l == s.Length && t == s) return true;
            }

            return false;
        }

        private static bool IsPrefixString0(string s, string[] words)
        {
            StringBuilder sb = new();

            foreach (string word in words)
            {
                sb.Append(word);
                if (sb.ToString() == s) return true;
                if (!s.Contains(sb.ToString())) return false;
            }

            return false;
        }
    }
}
