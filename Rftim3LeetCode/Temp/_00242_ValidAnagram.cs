namespace Rftim3LeetCode.Temp
{
    public class _00242_ValidAnagram
    {
        /// <summary>
        /// Given two strings s and t, return true if t is an anagram of s, and false otherwise.
        /// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
        /// </summary>
        public _00242_ValidAnagram()
        {
            Console.WriteLine(IsAnagram0("anagram", "nagaram"));
            Console.WriteLine(IsAnagram0("rat", "cat"));
        }

        public static bool IsAnagram0(string a0, string a1) => RftIsAnagram0(a0, a1);

        private static bool RftIsAnagram0(string s, string t)
        {
            Dictionary<char, int> x = [];
            Dictionary<char, int> y = [];

            for (int i = 97; i < 123; i++)
            {
                x.Add((char)i, 0);
                y.Add((char)i, 0);
            }

            for (int i = 0; i < s.Length; i++)
            {
                x[s[i]] += 1;
            }

            for (int i = 0; i < t.Length; i++)
            {
                y[t[i]] += 1;
            }

            foreach (KeyValuePair<char, int> item in x)
            {
                if (item.Value != y[item.Key]) return false;
            }

            return true;
        }
    }
}
