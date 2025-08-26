namespace Rftim3LeetCode.Temp
{
    public class _02325_DecodeTheMessage
    {
        /// <summary>
        /// You are given the strings key and message, which represent a cipher key and a secret message, respectively. 
        /// The steps to decode message are as follows:
        /// Use the first appearance of all 26 lowercase English letters in key as the order of the substitution table.
        /// Align the substitution table with the regular English alphabet.
        /// Each letter in message is then substituted using the table.
        /// Spaces ' ' are transformed to themselves.
        /// For example, given key = "happy boy"(actual key would have at least one instance of each letter in the alphabet), 
        /// we have the partial substitution table of ('h' -> 'a', 'a' -> 'b', 'p' -> 'c', 'y' -> 'd', 'b' -> 'e', 'o' -> 'f').
        /// Return the decoded message.
        /// </summary>
        public _02325_DecodeTheMessage()
        {
            Console.WriteLine(DecodeMessage("the quick brown fox jumps over the lazy dog", "vkbs bs t suepuv"));
            Console.WriteLine(DecodeMessage("eljuxhpwnyrdgtqkviszcfmabo", "zwx hnfx lqantp mnoeius ycgk vcnjrdb"));
        }

        private static string DecodeMessage(string key, string message)
        {
            Dictionary<char, char> r = [];

            int n = key.Length;
            char j = 'a';
            for (int i = 0; i < n; i++)
            {
                if (key[i] != ' ')
                {
                    if (!r.ContainsKey(key[i]))
                    {
                        r[key[i]] = j;
                        j++;
                    }
                }
            }

            string t = "";
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ' ') t += ' ';
                else t += r[message[i]];
            }

            return t;
        }
    }
}
