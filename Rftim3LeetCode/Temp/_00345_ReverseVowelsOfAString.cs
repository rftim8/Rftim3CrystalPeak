using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00345_ReverseVowelsOfAString
    {
        /// <summary>
        /// Given a string s, reverse only all the vowels in the string and return it.
        /// The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.
        /// </summary>
        public _00345_ReverseVowelsOfAString()
        {
            Console.WriteLine(ReverseVowels0("hello"));
            Console.WriteLine(ReverseVowels0("leetcode"));
        }

        public static string ReverseVowels0(string a0) => RftReverseVowels0(a0);

        public static string ReverseVowels1(string a0) => RftReverseVowels1(a0);

        private static string RftReverseVowels0(string s)
        {
            int n = s.Length;
            HashSet<char> v = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

            int l = 0, r = n - 1;

            bool fl = false;
            bool fr = false;

            while (l < r)
            {
                if (!v.Contains(s[l])) l++;
                else fl = true;

                if (!v.Contains(s[r])) r--;
                else fr = true;

                if (fl && fr)
                {
                    char cl = s[l];
                    char rl = s[r];

                    s = s[..l] + rl + s[(l + 1)..r] + cl + s[(r + 1)..];

                    fl = false;
                    fr = false;
                    l++;
                    r--;
                }
            }

            return s;
        }

        private static string RftReverseVowels1(string s)
        {
            List<int> vowelIndexes = [];
            HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

            for (int i = 0; i < s.Length; i++)
            {
                if (vowels.Contains(s[i])) vowelIndexes.Add(i);
            }

            StringBuilder sb = new(s);

            for (int i = 0; i < vowelIndexes.Count / 2; i++)
            {
                (sb[vowelIndexes[vowelIndexes.Count - 1 - i]], sb[vowelIndexes[i]]) = (sb[vowelIndexes[i]], sb[vowelIndexes[vowelIndexes.Count - 1 - i]]);
            }

            return sb.ToString();
        }
    }
}
