using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01816_TruncateSentence
    {
        /// <summary>
        /// A sentence is a list of words that are separated by a single space with no leading or trailing spaces. 
        /// Each of the words consists of only uppercase and lowercase English letters (no punctuation).
        /// For example, "Hello World", "HELLO", and "hello world hello world" are all sentences.
        /// You are given a sentence s​​​​​​ and an integer k​​​​​​.You want to truncate s​​​​​​ such that it contains only the first k​​​​​​ words.
        /// Return s​​​​​​ after truncating it.
        /// </summary>
        public _01816_TruncateSentence()
        {
            Console.WriteLine(TruncateSentence("Hello how are you Contestant", 4));
            Console.WriteLine(TruncateSentence("What is the solution to this problem", 4));
            Console.WriteLine(TruncateSentence("chopper is not a tanuki", 5));
        }

        private static string TruncateSentence(string s, int k)
        {
            List<string> r = s.Split(' ').Where(o => o != " ").ToList();

            StringBuilder sb = new();
            for (int i = 0; i < k; i++)
            {
                sb.Append($"{r[i]} ");
            }

            return sb.ToString().Trim();
        }

        private static string TruncateSentence0(string s, int k)
        {
            return string.Join(" ", s.Split().Take(k));
        }
    }
}
