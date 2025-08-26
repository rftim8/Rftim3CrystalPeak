using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00131_PalindromePartitioning
    {
        /// <summary>
        /// Given a string s, partition s such that every substring of the partition is a palindrome.
        /// Return all possible palindrome partitioning of s.
        /// </summary>
        public _00131_PalindromePartitioning()
        {
            IList<IList<string>> x = Partition("aab");
            RftTerminal.RftReadResult(x);
            IList<IList<string>> x0 = Partition("a");
            RftTerminal.RftReadResult(x0);
        }

        private static List<IList<string>>? r;
        private static List<IList<string>> Partition(string s)
        {
            r = [];
            Backtrack(s, []);

            return r;
        }

        private static void Backtrack(string s, List<string> l)
        {
            if (string.IsNullOrEmpty(s))
            {
                r?.Add(new List<string>(l));

                return;
            }

            for (int i = 1; i <= s.Length; i++)
            {
                string c = s[..i];
                if (!IsPalindrome(c)) continue;

                l.Add(c);
                Backtrack(s[i..], l);
                l.RemoveAt(l.Count - 1);
            }
        }

        private static bool IsPalindrome(string s)
        {
            int l = 0, r = s.Length - 1;

            while (l < r)
            {
                if (s[l++] != s[r--]) return false;
            }

            return true;
        }
    }
}
