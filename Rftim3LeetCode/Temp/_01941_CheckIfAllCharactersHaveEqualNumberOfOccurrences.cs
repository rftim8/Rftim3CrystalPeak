namespace Rftim3LeetCode.Temp
{
    public class _01941_CheckIfAllCharactersHaveEqualNumberOfOccurrences
    {
        /// <summary>
        /// Given a string s, return true if s is a good string, or false otherwise.
        /// A string s is good if all the characters that appear in s have the same number of occurrences(i.e., the same frequency).
        /// </summary>
        public _01941_CheckIfAllCharactersHaveEqualNumberOfOccurrences()
        {
            Console.WriteLine(AreOccurrencesEqual("abacbc"));
            Console.WriteLine(AreOccurrencesEqual("aaabb"));
        }

        private static bool AreOccurrencesEqual(string s)
        {
            int n = s.Length;
            Dictionary<char, int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (r.TryGetValue(s[i], out int value)) r[s[i]] = ++value;
                else r[s[i]] = 1;
            }

            return r.DistinctBy(o => o.Value).Count() == 1;
        }

        private static bool AreOccurrencesEqual0(string s)
        {
            int[] count = new int[26];
            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int val = ++count[s[i] - 'a'];
                if (val > max) max = val;
            }
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > 0 && count[i] != max) return false;
            }

            return true;
        }
    }
}
