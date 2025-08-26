namespace Rftim3LeetCode.Temp
{
    public class _01592_RearrangeSpacesBetweenWords
    {
        /// <summary>
        /// You are given a string text of words that are placed among some number of spaces. 
        /// Each word consists of one or more lowercase English letters and are separated by at least one space. 
        /// It's guaranteed that text contains at least one word.
        /// Rearrange the spaces so that there is an equal number of spaces between every pair of adjacent words and that number is maximized.
        /// If you cannot redistribute all the spaces equally, place the extra spaces at the end, meaning the returned string should be the same length as text.
        /// Return the string after rearranging the spaces.
        /// </summary>
        public _01592_RearrangeSpacesBetweenWords()
        {
            Console.WriteLine(ReorderSpaces("  this   is  a sentence "));
            Console.WriteLine(ReorderSpaces(" practice   makes   perfect"));
            Console.WriteLine(ReorderSpaces("a b   c d"));
        }

        private static string ReorderSpaces(string text)
        {
            int n = text.Length;
            int m = text.Select(o => o).Where(o => o == ' ').Count();
            if (m == 0) return text;
            List<string> r = text.Split(' ').Where(o => !string.IsNullOrEmpty(o)).ToList();
            if (r.Count == 1) return r[0] + string.Concat(Enumerable.Repeat(' ', m));

            int x = m / (r.Count - 1);
            Console.WriteLine($"{x} {m}");

            string t = "";

            for (int i = 0; i < r.Count; i++)
            {
                t += r[i];
                if (i == r.Count - 1) t += string.Concat(Enumerable.Repeat(' ', m));
                else t += string.Concat(Enumerable.Repeat(' ', x));

                m -= x;
            }

            return t;
        }
    }
}
