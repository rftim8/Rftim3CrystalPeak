namespace Rftim3LeetCode.Temp
{
    public class _02399_CheckDistancesBetweenSameLetters
    {
        /// <summary>
        /// You are given a 0-indexed string s consisting of only lowercase English letters, where each letter in s appears exactly twice. 
        /// You are also given a 0-indexed integer array distance of length 26.
        /// Each letter in the alphabet is numbered from 0 to 25 (i.e. 'a' -> 0, 'b' -> 1, 'c' -> 2, ... , 'z' -> 25).
        /// In a well-spaced string, the number of letters between the two occurrences of the ith letter is distance[i]. 
        /// If the ith letter does not appear in s, then distance[i] can be ignored.
        /// Return true if s is a well-spaced string, otherwise return false.
        /// </summary>
        public _02399_CheckDistancesBetweenSameLetters()
        {
            Console.WriteLine(CheckDistances("abaccb", [1, 3, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]));
            Console.WriteLine(CheckDistances("aa", [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]));
            Console.WriteLine(CheckDistances("abbccddeeffgghhiijjkkllmmnnooppqqrrssttuuvvwwxxyyzza", [49, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]));
        }

        private static bool CheckDistances(string s, int[] distance)
        {
            int[] lastIndex = new int[26];
            Array.Fill(lastIndex, -1);

            for (int i = 0; i < s.Length; i++)
            {
                if (lastIndex[s[i] - 'a'] == -1) lastIndex[s[i] - 'a'] = i;
                else if (i - lastIndex[s[i] - 'a'] - 1 != distance[s[i] - 'a']) return false;
            }

            return true;
        }
    }
}
