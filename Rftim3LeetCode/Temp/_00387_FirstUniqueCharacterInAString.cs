namespace Rftim3LeetCode.Temp
{
    public class _00387_FirstUniqueCharacterInAString
    {
        /// <summary>
        /// Given a string s, find the first non-repeating character in it and return its index. If it does not exist, return -1.
        /// </summary>
        public _00387_FirstUniqueCharacterInAString()
        {
            Console.WriteLine(FirstUniqChar0("leetcode"));
            Console.WriteLine(FirstUniqChar0("loveleetcode"));
            Console.WriteLine(FirstUniqChar0("aabb"));
        }

        public static int FirstUniqChar0(string a0) => RftFirstUniqChar0(a0);

        private static int RftFirstUniqChar0(string s)
        {
            if (s.Length == 1) return 0;

            Dictionary<char, int> kvp = [];
            for (int i = 97; i < 123; i++)
            {
                kvp.Add((char)i, int.MaxValue);
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (kvp.TryGetValue(s[i], out int value))
                {
                    if (value == int.MaxValue) kvp[s[i]] = i;
                    else kvp.Remove(s[i]);
                }
            }

            if (kvp.Count == 0) return -1;

            int x = kvp.Min(o => o.Value);

            return x == int.MaxValue ? -1 : x;
        }
    }
}
