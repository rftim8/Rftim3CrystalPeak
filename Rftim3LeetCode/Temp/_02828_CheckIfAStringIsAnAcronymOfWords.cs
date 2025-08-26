namespace Rftim3LeetCode.Temp
{
    public class _02828_CheckIfAStringIsAnAcronymOfWords
    {
        /// <summary>
        /// Given an array of strings words and a string s, determine if s is an acronym of words.
        /// The string s is considered an acronym of words if it can be formed by concatenating the first character of each string in words in order.
        /// For example, "ab" can be formed from["apple", "banana"], but it can't be formed from ["bear", "aardvark"].
        /// Return true if s is an acronym of words, and false otherwise.
        /// </summary>
        public _02828_CheckIfAStringIsAnAcronymOfWords()
        {
            Console.WriteLine(IsAcronym(["alice", "bob", "charlie"], "abc"));
            Console.WriteLine(IsAcronym(["an", "apple"], "a"));
            Console.WriteLine(IsAcronym(["never", "gonna", "give", "up", "on", "you"], "ngguoy"));
        }

        private static bool IsAcronym(IList<string> words, string s)
        {
            string r = "";
            foreach (string item in words)
            {
                r += item[0];
            }

            return r == s;
        }
    }
}
