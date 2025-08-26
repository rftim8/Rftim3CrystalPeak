namespace Rftim3LeetCode.Temp
{
    public class _02744_FindMaximumNumberOfStringPairs
    {
        /// <summary>
        /// You are given a 0-indexed array words consisting of distinct strings.
        /// The string words[i] can be paired with the string words[j] if:
        /// The string words[i] is equal to the reversed string of words[j].
        /// 0 <= i<j<words.length.
        /// Return the maximum number of pairs that can be formed from the array words.
        /// Note that each string can belong in at most one pair.
        /// </summary>
        public _02744_FindMaximumNumberOfStringPairs()
        {
            Console.WriteLine(MaximumNumberOfStringPairs(["cd", "ac", "dc", "ca", "zz"]));
            Console.WriteLine(MaximumNumberOfStringPairs(["ab", "ba", "cc"]));
            Console.WriteLine(MaximumNumberOfStringPairs(["aa", "ab"]));
        }

        private static int MaximumNumberOfStringPairs(string[] words)
        {
            int n = words.Length;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (words[i] == string.Concat(words[j].Reverse())) c++;
                }
            }

            return c;
        }

        private static int MaximumNumberOfStringPairs0(string[] words)
        {
            int n = words.Length;
            int count = 0;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    string rev = words[i];
                    char[] charArray = rev.ToCharArray();
                    Array.Reverse(charArray);
                    rev = new string(charArray);

                    if (rev == words[j]) count++;
                }
            }

            return count;
        }
    }
}
