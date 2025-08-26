namespace Rftim3LeetCode.Temp
{
    public class _00205_IsomorphicStrings
    {
        /// <summary>
        /// Given two strings s and t, determine if they are isomorphic.
        /// Two strings s and t are isomorphic if the characters in s can be replaced to get t.
        /// All occurrences of a character must be replaced with another character while preserving the order of characters.
        /// No two characters may map to the same character, but a character may map to itself.
        /// </summary>
        public _00205_IsomorphicStrings()
        {
            Console.WriteLine(IsIsomorphic0("egg", "add"));
            Console.WriteLine(IsIsomorphic0("foo", "bar"));
            Console.WriteLine(IsIsomorphic0("paper", "title"));
        }

        public static bool IsIsomorphic0(string a0, string a1) => RftIsIsomorphic0(a0, a1);

        private static bool RftIsIsomorphic0(string s, string t)
        {
            int n = s.Length;

            Dictionary<char, char> map = [];
            List<char> x = [];

            for (int i = 0; i < n; i++)
            {
                if (!map.TryGetValue(s[i], out char value))
                {
                    if (x.Contains(t[i])) return false;
                    x.Add(t[i]);
                    map.Add(s[i], t[i]);
                }
                else
                {
                    if (value != t[i]) return false;
                }
            }

            return true;
        }
    }
}
