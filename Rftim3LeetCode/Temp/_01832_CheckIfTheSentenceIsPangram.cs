namespace Rftim3LeetCode.Temp
{
    public class _01832_CheckIfTheSentenceIsPangram
    {
        /// <summary>
        /// A pangram is a sentence where every letter of the English alphabet appears at least once.
        /// Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
        /// </summary>
        public _01832_CheckIfTheSentenceIsPangram()
        {
            Console.WriteLine(CheckIfPangram("thequickbrownfoxjumpsoverthelazydog"));
            Console.WriteLine(CheckIfPangram("leetcode"));
        }

        private static bool CheckIfPangram(string sentence)
        {
            return sentence.ToHashSet().Count == 26;
        }

        private static bool CheckIfPangram0(string sentence)
        {
            HashSet<char> hashSet = new(sentence);
            for (int i = 97; i <= 122; i++)
            {
                if (!hashSet.Contains((char)i)) return false;
            }

            return true;
        }
    }
}
