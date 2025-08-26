using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00316_RemoveDuplicateLetters
    {
        /// <summary>
        /// Given a string s, remove duplicate letters so that every letter appears once and only once. 
        /// You must make sure your result is the smallest in lexicographical order among all possible results.
        /// </summary>
        public _00316_RemoveDuplicateLetters()
        {
            Console.WriteLine(RemoveDuplicateLetters("bcabc"));
            Console.WriteLine(RemoveDuplicateLetters("cbacdcbc"));
            Console.WriteLine(RemoveDuplicateLetters("bddbccd"));
        }

        private static string RemoveDuplicateLetters(string s)
        {
            int[] c = new int[26];
            int[] v = new int[26];

            int n = s.Length;

            for (int i = 0; i < n; i++)
            {
                c[s[i] - 'a']++;
            }

            string r = "";

            for (int i = 0; i < n; i++)
            {
                c[s[i] - 'a']--;

                if (v[s[i] - 'a'] == 0)
                {
                    int m = r.Length;

                    while (m > 0 && r[m - 1] > s[i] && c[r[m - 1] - 'a'] > 0)
                    {
                        v[r[m - 1] - 'a'] = 0;
                        r = r[..(m - 1)];
                        m--;

                    }

                    r += s[i];
                    v[s[i] - 'a'] = 1;
                }
            }

            return r;
        }

        public static string RemoveDuplicateLetters0(string s)
        {
            int[] counts = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                counts[s[i] - 'a']++;
            }

            int index = 0;
            for (int i = 0; i < s.Length; i++)
            {
                counts[s[i] - 'a']--;

                if (s[i] < s[index]) index = i;
                if (counts[s[i] - 'a'] == 0) break;
            }

            if (s.Length == 0) return string.Empty;

            string rest = s[(index + 1)..];
            rest = rest.Replace(s[index].ToString(), string.Empty);

            return s[index] + RemoveDuplicateLetters0(rest);
        }

        private static string RemoveDuplicateLetters1(string s)
        {
            int[] lastIndex = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                lastIndex[s[i] - 'a'] = i;
            }

            bool[] seen = new bool[26];
            Stack<int> st = new();

            for (int i = 0; i < s.Length; i++)
            {
                int curr = s[i] - 'a';
                if (seen[curr]) continue;
                while (st.Any() && st.Peek() > curr && i < lastIndex[st.Peek()])
                {
                    seen[st.Pop()] = false;
                }
                st.Push(curr);
                seen[curr] = true;
            }

            StringBuilder sb = new();
            while (st.Any())
            {
                sb.Append((char)(st.Pop() + 'a'));
            }

            return string.Concat(sb.ToString().Reverse());
        }
    }
}
