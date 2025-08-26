namespace Rftim3LeetCode.Temp
{
    public class _00844_BackspaceStringCompare
    {
        /// <summary>
        /// Given two strings s and t, return true if they are equal when both are typed into empty text editors. '#' means a backspace character.
        /// Note that after backspacing an empty text, the text will continue empty.
        /// </summary>
        public _00844_BackspaceStringCompare()
        {
            Console.WriteLine(BackspaceCompare("ab#c", "ad#c"));
            Console.WriteLine(BackspaceCompare("ab##", "c#d#"));
            Console.WriteLine(BackspaceCompare("a#c", "b"));
            Console.WriteLine(BackspaceCompare("xywrrmp", "xywrrmu#p"));
        }

        private static bool BackspaceCompare(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;

            string x = "", y = "";
            int x0 = 0, y0 = 0;

            int i = n - 1, j = m - 1, k = i > j ? i : j;
            while (k >= 0)
            {
                if (i >= 0)
                {
                    if (s[i] != '#')
                    {
                        if (x0 > 0)
                        {
                            if (s[i] == ' ') x += s[i];
                            x0--;
                        }
                        else x += s[i];
                    }
                    else x0++;
                }

                if (j >= 0)
                {
                    if (t[j] != '#')
                    {
                        if (y0 > 0)
                        {
                            if (t[j] == ' ') y += t[j];
                            y0--;
                        }
                        else y += t[j];
                    }
                    else y0++;
                }

                i--;
                j--;
                k--;
            }
            if (x != y) return false;

            return true;
        }

        private static IEnumerable<char> YieldBackspaces(string s)
        {
            int consecutive = 0;
            foreach (char curChar in s.Reverse())
            {
                if (curChar != '#' && consecutive == 0) yield return curChar;
                else if (curChar == '#') consecutive++;
                else consecutive--;
            }
        }

        private static bool BackspaceCompare0(string s, string t)
        {
            return YieldBackspaces(s).SequenceEqual(YieldBackspaces(t));
        }
    }
}
