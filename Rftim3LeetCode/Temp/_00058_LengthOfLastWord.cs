namespace Rftim3LeetCode.Temp
{
    public class _00058_LengthOfLastWord
    {
        /// <summary>
        /// Given a string s consisting of words and spaces, return the length of the last word in the string.
        /// A word is a maximal
        /// substring
        /// consisting of non-space characters only.
        /// </summary>
        public _00058_LengthOfLastWord()
        {
            Console.WriteLine(LengthOfLastWord0("Hello World"));
            Console.WriteLine(LengthOfLastWord0("   fly me   to   the moon  "));
            Console.WriteLine(LengthOfLastWord0("luffy is still joyboy"));
        }

        public static int LengthOfLastWord0(string a0) => RftLengthOfLastWord0(a0);

        private static int RftLengthOfLastWord0(string s)
        {
            int n = s.Length;

            int c = 0;
            bool start = false;
            for (int i = n - 1; i >= 0; i--)
            {
                if (s[i] != ' ')
                {
                    start = true;
                    c++;
                }
                else if (start || i == 0) return c;
            }

            return c;
        }
    }
}
