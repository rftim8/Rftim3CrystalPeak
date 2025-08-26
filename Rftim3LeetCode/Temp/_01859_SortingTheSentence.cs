using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01859_SortingTheSentence
    {
        /// <summary>
        /// A sentence is a list of words that are separated by a single space with no leading or trailing spaces. 
        /// Each word consists of lowercase and uppercase English letters.
        /// A sentence can be shuffled by appending the 1-indexed word position to each word then rearranging the words in the sentence.
        /// For example, the sentence "This is a sentence" can be shuffled as "sentence4 a3 is2 This1" or "is2 sentence4 This1 a3".
        /// Given a shuffled sentence s containing no more than 9 words, reconstruct and return the original sentence.
        /// </summary>
        public _01859_SortingTheSentence()
        {
            Console.WriteLine(SortSentence("is2 sentence4 This1 a3"));
            Console.WriteLine(SortSentence("Myself2 Me1 I4 and3"));
        }

        private static string SortSentence(string s)
        {
            List<string> r = [.. s.Split(' ')];

            string[] x = new string[r.Count];

            for (int i = 0; i < r.Count; i++)
            {
                int c = 0;
                for (int j = r[i].Length - 1; j > -1; j--)
                {
                    if (char.IsDigit(r[i][j])) c++;
                    else break;
                }

                x[int.Parse(r[i][^c..]) - 1] = r[i].Replace(r[i][^c..], "");
            }

            return string.Join(' ', x);
        }

        private static string SortSentence0(string s)
        {
            string[] arr = new string[9];
            StringBuilder curr = new("", s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= '1' && s[i] <= '9')
                {
                    arr[s[i] - '1'] = curr.ToString();
                    curr.Clear();
                    i++;
                }
                else curr.Append(s[i]);
            }

            StringBuilder res = new(arr[0], s.Length);
            for (int i = 1; i < arr.Length && arr[i] != null; i++)
            {
                res.Append(" " + arr[i]);
            }

            return res.ToString();
        }
    }
}
