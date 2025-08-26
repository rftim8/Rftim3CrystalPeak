namespace Rftim3LeetCode.Temp
{
    public class _01897_RedistributeCharactersToMakeAllStringsEqual
    {
        /// <summary>
        /// You are given an array of strings words (0-indexed).
        /// In one operation, pick two distinct indices i and j, where words[i] is a non-empty string, and move any character from words[i] to any position in words[j].
        /// Return true if you can make every string in words equal using any number of operations, and false otherwise.
        /// </summary>
        public _01897_RedistributeCharactersToMakeAllStringsEqual()
        {
            Console.WriteLine(MakeEqual(["abc", "aabc", "bc"]));
            Console.WriteLine(MakeEqual(["ab", "a"]));
        }

        private static bool MakeEqual(string[] words)
        {
            int n = words.Length;
            Dictionary<char, int> r = [];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (r.TryGetValue(words[i][j], out int value)) r[words[i][j]] = ++value;
                    else r[words[i][j]] = 1;
                }
            }

            foreach (KeyValuePair<char, int> item in r)
            {
                if (item.Value % words.Length != 0) return false;
            }

            return true;
        }
    }
}
