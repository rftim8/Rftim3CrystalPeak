namespace Rftim3LeetCode.Temp
{
    public class _01624_LargestSubstringBetweenTwoEqualCharacters
    {
        /// <summary>
        /// Given a string s, return the length of the longest substring between two equal characters, excluding the two characters.
        /// If there is no such substring return -1.
        /// A substring is a contiguous sequence of characters within a string.
        /// </summary>
        public _01624_LargestSubstringBetweenTwoEqualCharacters()
        {
            Console.WriteLine(MaxLengthBetweenEqualCharacters("aa"));
            Console.WriteLine(MaxLengthBetweenEqualCharacters("abca"));
            Console.WriteLine(MaxLengthBetweenEqualCharacters("cbzxy"));
        }

        private static int MaxLengthBetweenEqualCharacters(string s)
        {
            int n = s.Length;

            int r = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1; j > i; j--)
                {
                    if (s[i] == s[j])
                    {
                        r = Math.Max(r, j - i - 1);
                        break;
                    }
                }
            }

            return r;
        }

        private static int MaxLengthBetweenEqualCharacters0(string s)
        {
            int maxDistance = -1;
            Dictionary<char, int> charPositions = [];

            for (int i = 0; i < s.Length; i++)
            {
                if (!charPositions.TryGetValue(s[i], out int value)) charPositions.Add(s[i], i);
                else maxDistance = Math.Max(maxDistance, i - value - 1);
            }

            return maxDistance;
        }
    }
}
