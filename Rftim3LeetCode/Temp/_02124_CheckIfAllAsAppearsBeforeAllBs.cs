namespace Rftim3LeetCode.Temp
{
    public class _02124_CheckIfAllAsAppearsBeforeAllBs
    {
        /// <summary>
        /// Given a string s consisting of only the characters 'a' and 'b', return true if every 'a' appears before every 'b' in the string. 
        /// Otherwise, return false.
        /// </summary>
        public _02124_CheckIfAllAsAppearsBeforeAllBs()
        {
            Console.WriteLine(CheckString("aaabbb"));
            Console.WriteLine(CheckString("abab"));
            Console.WriteLine(CheckString("bbb"));
        }

        private static bool CheckString(string s)
        {
            bool a = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    if (a) return false;
                }
                else a = true;
            }

            return true;
        }
    }
}
