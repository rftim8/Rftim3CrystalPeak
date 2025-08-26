namespace Rftim3LeetCode.Temp
{
    public class _02351_FirstLetterToAppearTwice
    {
        /// <summary>
        /// Given a string s consisting of lowercase English letters, return the first letter to appear twice.
        /// Note:
        /// A letter a appears twice before another letter b if the second occurrence of a is before the second occurrence of b.
        /// s will contain at least one letter that appears twice.
        /// </summary>
        public _02351_FirstLetterToAppearTwice()
        {
            Console.WriteLine(RepeatedCharacter("abccbaacz"));
            Console.WriteLine(RepeatedCharacter("abcdd"));
        }

        private static char RepeatedCharacter(string s)
        {
            int n = s.Length;
            Dictionary<char, int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (r.TryGetValue(s[i], out int value))
                {
                    r[s[i]] = ++value;
                    if (value == 2) return s[i];
                }
                else r[s[i]] = 1;
            }

            return ' ';
        }
    }
}
