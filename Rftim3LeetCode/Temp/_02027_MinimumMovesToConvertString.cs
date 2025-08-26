namespace Rftim3LeetCode.Temp
{
    public class _02027_MinimumMovesToConvertString
    {
        /// <summary>
        /// You are given a string s consisting of n characters which are either 'X' or 'O'.
        /// A move is defined as selecting three consecutive characters of s and converting them to 'O'. 
        /// Note that if a move is applied to the character 'O', it will stay the same.
        /// Return the minimum number of moves required so that all the characters of s are converted to 'O'.
        /// </summary>
        public _02027_MinimumMovesToConvertString()
        {
            Console.WriteLine(MinimumMoves("XXX"));
            Console.WriteLine(MinimumMoves("XXOX"));
            Console.WriteLine(MinimumMoves("OOOO"));
        }

        private static int MinimumMoves(string s)
        {
            int n = s.Length;
            char[] r = s.ToCharArray();

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                if (r[i] == 'O') continue;
                else
                {
                    r[i] = 'O';
                    if (i + 1 < n) r[i + 1] = 'O';
                    if (i + 2 < n) r[i + 2] = 'O';
                    c++;
                }
            }

            return c;
        }
    }
}
