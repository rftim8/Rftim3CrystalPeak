using System.Globalization;
using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _02129_CapitalizeTheTitle
    {
        /// <summary>
        /// You are given a string title consisting of one or more words separated by a single space, where each word consists of English letters.
        /// Capitalize the string by changing the capitalization of each word such that:
        /// If the length of the word is 1 or 2 letters, change all letters to lowercase.
        /// Otherwise, change the first letter to uppercase and the remaining letters to lowercase.
        /// Return the capitalized title.
        /// </summary>
        public _02129_CapitalizeTheTitle()
        {
            Console.WriteLine(CapitalizeTitle("capiTalIze tHe titLe"));
            Console.WriteLine(CapitalizeTitle("First leTTeR of EACH Word"));
            Console.WriteLine(CapitalizeTitle("i lOve leetcode"));
        }

        private static string CapitalizeTitle(string title)
        {
            title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
            List<string> r = [.. title.Split(' ')];

            StringBuilder sb = new();
            foreach (string item in r)
            {
                if (item.Length < 3) sb.Append($"{item.ToLower()} ");
                else
                {
                    sb.Append($"{item} ");
                }
            }

            return string.Concat(sb.ToString().SkipLast(1));
        }
    }
}
