namespace Rftim3LeetCode.Temp
{
    public class _02839_CheckIfStringsCanBeMadeEqualWithOperations1
    {
        /// <summary>
        /// You are given two strings s1 and s2, both of length 4, consisting of lowercase English letters.
        /// You can apply the following operation on any of the two strings any number of times:
        /// Choose any two indices i and j such that j - i = 2, then swap the two characters at those indices in the string.
        /// Return true if you can make the strings s1 and s2 equal, and false otherwise.
        /// </summary>
        public _02839_CheckIfStringsCanBeMadeEqualWithOperations1()
        {
            Console.WriteLine(CanBeEqual("abcd", "cdab"));
            Console.WriteLine(CanBeEqual("abcd", "dacb"));
        }

        private static bool CanBeEqual(string s1, string s2)
        {
            if (s1 == s2) return true;
            char[] r = s2.ToCharArray();

            if (s1 == $"{r[2]}{r[1]}{r[0]}{r[3]}" ||
                s1 == $"{r[0]}{r[3]}{r[2]}{r[1]}" ||
                s1 == $"{r[2]}{r[3]}{r[0]}{r[1]}")
                return true;
            else return false;
        }
    }
}
