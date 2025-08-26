using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00824_GoatLatin
    {
        /// <summary>
        /// You are given a string sentence that consist of words separated by spaces. 
        /// Each word consists of lowercase and uppercase letters only.
        /// We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.) The rules of Goat Latin are as follows:
        /// If a word begins with a vowel('a', 'e', 'i', 'o', or 'u'), append "ma" to the end of the word.
        /// For example, the word "apple" becomes "applema".
        /// If a word begins with a consonant (i.e., not a vowel), remove the first letter and append it to the end, then add "ma".
        /// For example, the word "goat" becomes "oatgma".
        /// Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
        /// For example, the first word gets "a" added to the end, the second word gets "aa" added to the end, and so on.
        /// Return the final sentence representing the conversion from sentence to Goat Latin.
        /// </summary>
        public _00824_GoatLatin()
        {
            Console.WriteLine(ToGoatLatin("I speak Goat Latin"));
            Console.WriteLine(ToGoatLatin("The quick brown fox jumped over the lazy dog"));
        }

        private static string ToGoatLatin(string sentence)
        {
            List<string> x = [.. sentence.Split(' ')];
            char[] v = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

            StringBuilder sb = new();
            int i = 1;
            foreach (string item in x)
            {
                string a = string.Concat(Enumerable.Repeat('a', i));
                if (v.Contains(item[0])) sb.Append($"{item}ma{a} ");
                else sb.Append($"{item[1..]}{item[0]}ma{a} ");
                i++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
