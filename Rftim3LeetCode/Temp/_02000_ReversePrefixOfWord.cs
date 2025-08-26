namespace Rftim3LeetCode.Temp
{
    public class _02000_ReversePrefixOfWord
    {
        /// <summary>
        /// Given a 0-indexed string word and a character ch, reverse the segment of word that starts at index 0 and ends at the index of the first occurrence of ch (inclusive). 
        /// If the character ch does not exist in word, do nothing.        /// 
        /// For example, if word = "abcdefd" and ch = "d", then you should reverse the segment that starts at 0 and ends at 3 (inclusive). 
        /// The resulting string will be "dcbaefd".
        /// Return the resulting string.
        /// </summary>
        public _02000_ReversePrefixOfWord()
        {
            Console.WriteLine(ReversePrefix("abcdefd", 'd'));
            Console.WriteLine(ReversePrefix("xyxzxe", 'z'));
            Console.WriteLine(ReversePrefix("abcd", 'z'));
        }

        private static string ReversePrefix(string word, char ch)
        {
            int n = word.IndexOf(ch);

            return n == -1 ? word : $"{string.Concat(word[..(n + 1)].Reverse())}{word[(n + 1)..]}";
        }
    }
}
