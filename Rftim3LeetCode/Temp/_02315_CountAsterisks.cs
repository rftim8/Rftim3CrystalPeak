namespace Rftim3LeetCode.Temp
{
    public class _02315_CountAsterisks
    {
        /// <summary>
        /// You are given a string s, where every two consecutive vertical bars '|' are grouped into a pair. 
        /// In other words, the 1st and 2nd '|' make a pair, the 3rd and 4th '|' make a pair, and so forth.
        /// Return the number of '*' in s, excluding the '*' between each pair of '|'.
        /// Note that each '|' will belong to exactly one pair.
        /// </summary>
        public _02315_CountAsterisks()
        {
            Console.WriteLine(CountAsterisks("l|*e*et|c**o|*de|"));
            Console.WriteLine(CountAsterisks("iamprogrammer"));
            Console.WriteLine(CountAsterisks("yo|uar|e**|b|e***au|tifu|l"));
        }

        private static int CountAsterisks(string s)
        {
            int n = s.Length;
            int c = 0;

            bool b = true;
            for (int i = 0; i < n; i++)
            {
                if (s[i] != '|')
                {
                    if (b) if (s[i] == '*') c++;
                }
                else
                {
                    if (b) b = false;
                    else b = true;
                }
            }

            return c;
        }
    }
}
