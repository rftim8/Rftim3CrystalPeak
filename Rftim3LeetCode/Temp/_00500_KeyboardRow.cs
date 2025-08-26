using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00500_KeyboardRow
    {
        /// <summary>
        /// Given an array of strings words, return the words that can be typed using letters of the alphabet on only one row of American keyboard like the image below.
        /// In the American keyboard:
        /// the first row consists of the characters "qwertyuiop",
        /// the second row consists of the characters "asdfghjkl", and
        /// the third row consists of the characters "zxcvbnm".
        /// </summary>
        public _00500_KeyboardRow()
        {
            string[] x = FindWords0(["Hello", "Alaska", "Dad", "Peace"]);
            RftTerminal.RftReadResult(x);

            string[] x0 = FindWords0(["omk"]);
            RftTerminal.RftReadResult(x0);

            string[] x1 = FindWords0(["adsdf", "sfd"]);
            RftTerminal.RftReadResult(x1);
        }

        public static string[] FindWords0(string[] a0) => RftFindWords0(a0);

        private static string[] RftFindWords0(string[] words)
        {
            int n = words.Length;
            string[] keyboard = ["qwertyuiop", "asdfghjkl", "zxcvbnm"];
            List<string> r = [];

            for (int i = 0; i < n; i++)
            {
                string t = words[i];
                string s = t.ToLower();
                int c, m = s.Length;

                if (m == 1) r.Add(t);

                if (keyboard[0].Contains(s[0])) c = 0;
                else if (keyboard[1].Contains(s[0])) c = 1;
                else c = 2;

                for (int j = 1; j < m; j++)
                {
                    if (!keyboard[c].Contains(s[j])) break;
                    if (j == m - 1) r.Add(t);
                }
            }

            return [.. r];
        }
    }
}
