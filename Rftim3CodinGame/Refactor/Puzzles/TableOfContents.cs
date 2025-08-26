namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class TableOfContents
    {
        /// <summary>
        /// You are writing a book, and the table of contents is the only thing left to do. 
        /// Sadly, the necessary packages are not working well, so you will have to implement one yourself.
        /// 
        /// To generate the table of contents, your program will read N entries, describing a section with its level, title and page.
        /// - The level is given by the number of > at the start of the entry.
        /// - The title will not contain any space nor > characters.
        /// - The page is an integer, separated from the title by a space.
        /// Your program will then output the table of contents with the right format, N lines containing :
        /// - An indentation to reflect the level, 4 spaces per level.
        /// - The number of the section
        /// - Its title
        /// - A variable number of dots, for each line to be lengthofline long (including the page number)
        /// - The page number
        /// </summary>
        public TableOfContents()
        {

        }

        public static List<string> RftSolve(List<string> titles, int lengthofline)
        {
            List<string> r = [];

            Dictionary<int, int> kvp = [];
            int c = 1;
            int prev = 0;
            foreach (string item in titles)
            {
                int n = item.Where(o => o == '>').Count();
                if (!kvp.TryGetValue(n, out int value))
                {
                    kvp[n] = 1;
                    c = kvp[n];
                }
                else
                {
                    if (prev == n) c++;
                    else if (n < prev)
                    {
                        kvp[n] = ++value;
                        c = value;
                    }
                    else if (n > prev)
                    {
                        kvp[n] = 1;
                        c = kvp[n];
                    }
                }

                string t = string.Empty;
                for (int i = 0; i < n; i++)
                {
                    t += "    ";
                }

                t += $"{c} ";
                t += item.Split(' ')[0].Replace(">", "");
                t += string.Concat(Enumerable.Repeat('.', lengthofline - t.Length - item.Split(' ')[1].Length));
                t += item.Split(' ')[1];
                r.Add(t);

                prev = n;
            }

            return r;
        }
    }
}
