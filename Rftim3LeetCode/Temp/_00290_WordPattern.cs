namespace Rftim3LeetCode.Temp
{
    public class _00290_WordPattern
    {
        /// <summary>
        /// Given a pattern and a string s, find if s follows the same pattern.
        /// Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.
        /// </summary>
        public _00290_WordPattern()
        {
            Console.WriteLine(WordPattern0("abba", "dog cat cat dog"));
            Console.WriteLine(WordPattern0("abba", "dog cat cat fish"));
            Console.WriteLine(WordPattern0("aaaa", "dog cat cat dog"));
        }

        public static bool WordPattern0(string a0, string a1) => RftWordPattern0(a0, a1);

        private static bool RftWordPattern0(string pattern, string s)
        {
            int n = pattern.Length;
            List<string> y = [.. s.Split(' ')];
            int m = y.Count;
            if (n != m) return false;

            Dictionary<char, string> x = [];

            for (int i = 0; i < n; i++)
            {
                if (!x.TryGetValue(pattern[i], out string? value))
                {
                    foreach (KeyValuePair<char, string> item in x)
                    {
                        if (item.Value == y[i]) return false;
                    }
                    x.Add(pattern[i], y[i]);
                }
                else if (value != y[i]) return false;
            }

            return true;
        }
    }
}
