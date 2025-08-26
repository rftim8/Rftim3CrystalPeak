namespace Rftim3LeetCode.Temp
{
    public class _01455_CheckIfAWordOccursAsAPrefixOfAnyWordInASentence
    {
        /// <summary>
        /// Given a sentence that consists of some words separated by a single space, and a searchWord, check if searchWord is a prefix of any word in sentence.
        /// Return the index of the word in sentence(1-indexed) where searchWord is a prefix of this word.
        /// If searchWord is a prefix of more than one word, return the index of the first word (minimum index). 
        /// If there is no such word return -1.
        /// A prefix of a string s is any leading contiguous substring of s.
        /// </summary>
        public _01455_CheckIfAWordOccursAsAPrefixOfAnyWordInASentence()
        {
            Console.WriteLine(IsPrefixOfWord("i love eating burger", "burg"));
            Console.WriteLine(IsPrefixOfWord("this problem is an easy problem", "pro"));
            Console.WriteLine(IsPrefixOfWord("i am tired", "you"));
        }

        private static int IsPrefixOfWord(string sentence, string searchWord)
        {
            int c = -1;
            List<string> r = [.. sentence.Split(' ')];

            for (int i = 0; i < r.Count; i++)
            {
                if (r[i].StartsWith(searchWord)) return i + 1;
            }

            return c;
        }
    }
}
