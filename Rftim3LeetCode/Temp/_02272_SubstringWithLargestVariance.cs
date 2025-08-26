namespace Rftim3LeetCode.Temp
{
    public class _02272_SubstringWithLargestVariance
    {
        /// <summary>
        /// The variance of a string is defined as the largest difference between the number of occurrences of any 2 characters present in the string. 
        /// Note the two characters may or may not be the same.
        /// Given a string s consisting of lowercase English letters only, return the largest variance possible among all substrings of s.
        /// A substring is a contiguous sequence of characters within a string.
        /// </summary>
        public _02272_SubstringWithLargestVariance()
        {
            Console.WriteLine(LargestVariance("aababbb"));
            Console.WriteLine(LargestVariance("abcde"));
        }

        // Kadanes algorithm
        private static int LargestVariance(string s)
        {
            int[] counter = new int[26];
            foreach (char ch in s.ToCharArray())
            {
                counter[ch - 'a']++;
            }
            int globalMax = 0;

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (i == j || counter[i] == 0 || counter[j] == 0) continue;

                    char major = (char)('a' + i);
                    char minor = (char)('a' + j);
                    int majorCount = 0;
                    int minorCount = 0;

                    int restMinor = counter[j];

                    foreach (char ch in s.ToCharArray())
                    {
                        if (ch == major) majorCount++;
                        if (ch == minor)
                        {
                            minorCount++;
                            restMinor--;
                        }

                        if (minorCount > 0) globalMax = Math.Max(globalMax, majorCount - minorCount);

                        if (majorCount < minorCount && restMinor > 0)
                        {
                            majorCount = 0;
                            minorCount = 0;
                        }
                    }
                }
            }

            return globalMax;
        }
    }
}
