namespace Rftim3LeetCode.Temp
{
    public class _00953_VerifyingAnAlienDictionary
    {
        /// <summary>
        /// In an alien language, surprisingly, they also use English lowercase letters, but possibly in a different order.
        /// The order of the alphabet is some permutation of lowercase letters.
        /// Given a sequence of words written in the alien language, and the order of the alphabet, 
        /// return true if and only if the given words are sorted lexicographically in this alien language.
        /// </summary>
        public _00953_VerifyingAnAlienDictionary()
        {
            Console.WriteLine(IsAlienSorted(["hello", "leetcode"], "hlabcdefgijkmnopqrstuvwxyz"));
            Console.WriteLine(IsAlienSorted(["word", "world", "row"], "worldabcefghijkmnpqstuvxyz"));
            Console.WriteLine(IsAlienSorted(["apple", "app"], "abcdefghijklmnopqrstuvwxyz"));
        }

        private static bool IsAlienSorted(string[] words, string order)
        {
            int n = words.Length;
            int m = order.Length;
            int[] orderMap = new int[26];

            for (int i = 0; i < m; i++)
            {
                orderMap[order[i] - 'a'] = i;
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (j >= words[i + 1].Length) return false;

                    if (words[i][j] != words[i + 1][j])
                    {
                        int l = words[i][j] - 'a';
                        int r = words[i + 1][j] - 'a';

                        if (orderMap[l] > orderMap[r]) return false;
                        else break;
                    }
                }
            }

            return true;
        }
    }
}
