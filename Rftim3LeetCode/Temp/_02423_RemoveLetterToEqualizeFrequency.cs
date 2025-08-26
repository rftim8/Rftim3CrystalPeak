namespace Rftim3LeetCode.Temp
{
    public class _02423_RemoveLetterToEqualizeFrequency
    {
        /// <summary>
        /// You are given a 0-indexed string word, consisting of lowercase English letters. 
        /// You need to select one index and remove the letter at that index from word so that the frequency of every letter present in word is equal.
        /// Return true if it is possible to remove one letter so that the frequency of all letters in word are equal, and false otherwise.
        /// Note:
        /// The frequency of a letter x is the number of times it occurs in the string.
        /// You must remove exactly one letter and cannot chose to do nothing.
        /// </summary>
        public _02423_RemoveLetterToEqualizeFrequency()
        {
            Console.WriteLine(EqualFrequency("abcc"));
            Console.WriteLine(EqualFrequency("aazz"));
            Console.WriteLine(EqualFrequency("abbcc"));
        }

        private static bool EqualFrequency(string word)
        {
            int n = word.Length;

            for (int i = 0; i < n; i++)
            {
                int[] r = new int[26];

                for (int j = 0; j < n; j++)
                {
                    if (i != j) r[word[j] - 97]++;
                }

                HashSet<int> x = r.Where(o => o != 0).ToHashSet();
                if (x.Count == 1) return true;
            }

            return false;
        }
    }
}
