namespace Rftim3LeetCode.Temp
{
    public class _01967_NumberOfStringsThatAppearAsSubstringsInWord
    {
        /// <summary>
        /// Given an array of strings patterns and a string word, return the number of strings in patterns that exist as a substring in word.
        /// A substring is a contiguous sequence of characters within a string.
        /// </summary>
        public _01967_NumberOfStringsThatAppearAsSubstringsInWord()
        {
            Console.WriteLine(NumOfStrings(["a", "abc", "bc", "d"], "abc"));
            Console.WriteLine(NumOfStrings(["a", "b", "c"], "aaaaabbbbb"));
            Console.WriteLine(NumOfStrings(["a", "a", "a"], "ab"));
        }

        private static int NumOfStrings(string[] patterns, string word)
        {
            int c = 0;
            foreach (string item in patterns)
            {
                if (word.Contains(item)) c++;
            }

            return c;
        }
    }
}
