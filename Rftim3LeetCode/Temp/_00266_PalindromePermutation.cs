namespace Rftim3LeetCode.Temp
{
    public class _00266_PalindromePermutation
    {
        /// <summary>
        /// Given a string s, return true if a permutation of the string could form a palindrome and false otherwise.
        /// </summary>
        public _00266_PalindromePermutation()
        {
            Console.WriteLine(PalindromePermutation0("code"));
            Console.WriteLine(PalindromePermutation0("aab"));
            Console.WriteLine(PalindromePermutation0("carerac"));
        }

        public static bool PalindromePermutation0(string a0) => RftPalindromePermutation0(a0);

        public static bool PalindromePermutation1(string a0) => RftPalindromePermutation1(a0);

        private static bool RftPalindromePermutation0(string s)
        {
            int n = s.Length;

            Dictionary<char, int> kvp = [];
            for (int i = 0; i < n; i++)
            {
                if (kvp.TryGetValue(s[i], out int value))
                {
                    if (value == 1) kvp.Remove(s[i]);
                    else kvp[s[i]] = 1;
                }
                else kvp[s[i]] = 1;
            }

            return kvp.Count < 2;
        }

        private static bool RftPalindromePermutation1(string s)
        {
            HashSet<char> hashSet = [];
            foreach (char letter in s)
            {
                if (!hashSet.Remove(letter)) hashSet.Add(letter);
            }

            return hashSet.Count <= 1;
        }
    }
}
