namespace Rftim3LeetCode.Temp
{
    public class _01880_CheckIfWordEqualsSummationOfTwoWords
    {
        /// <summary>
        /// The letter value of a letter is its position in the alphabet starting from 0 (i.e. 'a' -> 0, 'b' -> 1, 'c' -> 2, etc.).
        /// The numerical value of some string of lowercase English letters s is the concatenation of the letter values of each letter in s, which is then converted into an integer.
        /// For example, if s = "acb", we concatenate each letter's letter value, resulting in "021". 
        /// After converting it, we get 21.
        /// You are given three strings firstWord, secondWord, and targetWord, each consisting of lowercase English letters 'a' through 'j' inclusive.
        /// Return true if the summation of the numerical values of firstWord and secondWord equals the numerical value of targetWord, or false otherwise.
        /// </summary>
        public _01880_CheckIfWordEqualsSummationOfTwoWords()
        {
            Console.WriteLine(IsSumEqual("acb", "cba", "cdb"));
            Console.WriteLine(IsSumEqual("aaa", "a", "aab"));
            Console.WriteLine(IsSumEqual("aaa", "a", "aaaa"));
        }

        private static bool IsSumEqual(string firstWord, string secondWord, string targetWord)
        {
            string a = "", b = "", c = "";

            for (int i = 0; i < firstWord.Length; i++)
            {
                a += firstWord[i] - 97;
            }
            for (int i = 0; i < secondWord.Length; i++)
            {
                b += secondWord[i] - 97;
            }
            for (int i = 0; i < targetWord.Length; i++)
            {
                c += targetWord[i] - 97;
            }

            return int.Parse(a) + int.Parse(b) == int.Parse(c);
        }
    }
}
