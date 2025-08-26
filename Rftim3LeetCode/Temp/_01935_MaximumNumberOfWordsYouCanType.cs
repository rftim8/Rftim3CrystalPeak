namespace Rftim3LeetCode.Temp
{
    public class _01935_MaximumNumberOfWordsYouCanType
    {
        /// <summary>
        /// There is a malfunctioning keyboard where some letter keys do not work. All other keys on the keyboard work properly.
        /// Given a string text of words separated by a single space(no leading or trailing spaces) and a string brokenLetters 
        /// of all distinct letter keys that are broken, return the number of words in text you can fully type using this keyboard.
        /// </summary>
        public _01935_MaximumNumberOfWordsYouCanType()
        {
            Console.WriteLine(CanBeTypedWords("hello world", "ad"));
            Console.WriteLine(CanBeTypedWords("leet code", "lt"));
            Console.WriteLine(CanBeTypedWords("leet code", "e"));
        }

        private static int CanBeTypedWords(string text, string brokenLetters)
        {
            List<string> r = [.. text.Split(' ')];

            for (int i = 0; i < brokenLetters.Length; i++)
            {
                for (int j = 0; j < r.Count; j++)
                {
                    if (r[j].Contains(brokenLetters[i]))
                    {
                        r.Remove(r[j]);
                        j--;
                    }
                }
            }

            return r.Count;
        }
    }
}
