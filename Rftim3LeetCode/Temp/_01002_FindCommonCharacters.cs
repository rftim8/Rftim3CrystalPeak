using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01002_FindCommonCharacters
    {
        /// <summary>
        /// Given a string array words, return an array of all characters that show up in all strings within the words (including duplicates). 
        /// You may return the answer in any order.
        /// </summary>
        public _01002_FindCommonCharacters()
        {
            IList<string> x = CommonChars(["bella", "label", "roller"]);
            IList<string> x0 = CommonChars(["cool", "lock", "cook"]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static IList<string> CommonChars(string[] words)
        {
            int[,] chars = new int[words.Length, 26];
            List<string> result = [];

            for (int i = 0; i < words.Length; i++)
            {
                foreach (char item in words[i])
                {
                    chars[i, item - 'a']++;
                }
            }

            for (int i = 0; i < 26; i++)
            {
                int min = int.MaxValue;

                for (int j = 0; j < words.Length; j++)
                {
                    if (chars[j, i] < min) min = chars[j, i];
                }

                if (min > 0)
                {
                    for (int j = 0; j < min; j++)
                    {
                        result.Add(((char)(i + 'a')).ToString());
                    }
                }
            }

            return result;
        }

        private static IList<string> CommonChars0(string[] words)
        {
            List<string> result = [];
            string firstWord = words[0];

            foreach (char c in firstWord)
            {
                bool match = false;

                for (int i = 1; i < words.Length; i++)
                {
                    match = words[i].Contains(c);
                    if (!match) break;
                }

                if (match)
                {
                    result.Add(c.ToString());
                    for (int i = 1; i < words.Length; i++)
                    {
                        int index = words[i].IndexOf(c);
                        if (index > -1) words[i] = words[i].Remove(index, 1);
                    }
                }
            }

            return result;
        }
    }
}
