namespace Rftim3LeetCode.Temp
{
    public class _00383_RansomNote
    {
        /// <summary>
        /// Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.
        /// Each letter in magazine can only be used once in ransomNote.
        /// </summary>
        public _00383_RansomNote()
        {
            Console.WriteLine(CanConstruct0("a", "b"));
            Console.WriteLine(CanConstruct0("aa", "ab"));
            Console.WriteLine(CanConstruct0("aa", "aab"));
        }

        public static bool CanConstruct0(string a0, string a1) => RftCanConstruct0(a0, a1);

        private static bool RftCanConstruct0(string ransomNote, string magazine)
        {
            Dictionary<char, int> x = [];
            Dictionary<char, int> y = [];

            for (int i = 97; i < 123; i++)
            {
                x.Add((char)i, 0);
                y.Add((char)i, 0);
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                x[ransomNote[i]] += 1;
            }

            for (int i = 0; i < magazine.Length; i++)
            {
                y[magazine[i]] += 1;
            }

            foreach (KeyValuePair<char, int> item in x)
            {
                if (item.Value > y[item.Key]) return false;
            }

            return true;
        }
    }
}
