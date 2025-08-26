namespace Rftim3LeetCode.Temp
{
    public class _02506_CountPairsOfSimilarStrings
    {
        /// <summary>
        /// You are given a 0-indexed string array words.
        /// Two strings are similar if they consist of the same characters.
        /// For example, "abca" and "cba" are similar since both consist of characters 'a', 'b', and 'c'.
        /// However, "abacba" and "bcfd" are not similar since they do not consist of the same characters.
        /// Return the number of pairs (i, j) such that 0 <= i<j <= word.length - 1 and the two strings words[i] and words[j] are similar.
        /// </summary>
        public _02506_CountPairsOfSimilarStrings()
        {
            Console.WriteLine(SimilarPairs(["aba", "aabb", "abcd", "bac", "aabc"]));
            Console.WriteLine(SimilarPairs(["aabb", "ab", "ba"]));
            Console.WriteLine(SimilarPairs(["nba", "cba", "dba"]));
        }

        private static int SimilarPairs(string[] words)
        {
            int n = words.Length;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (words[i].Distinct().OrderBy(o => o).ToList().SequenceEqual([.. words[j].Distinct().OrderBy(o => o)])) c++;
                }
            }

            return c;
        }

        private static int SimilarPairs0(string[] words)
        {
            int n = words.Length;
            string[] sArr = new string[n];

            for (int i = 0; i < n; i++)
            {
                HashSet<char> set = [.. words[i]];

                char[] cArr = [.. set];
                Array.Sort(cArr);
                sArr[i] = new string(cArr);
            }
            int count = 0;

            for (int i = 0; i < sArr.Length; i++)
            {
                for (int j = i + 1; j < sArr.Length; j++)
                {
                    if (sArr[i].Equals(sArr[j])) count++;
                }
            }

            return count;

        }
    }
}
