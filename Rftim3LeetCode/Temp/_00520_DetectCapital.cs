namespace Rftim3LeetCode.Temp
{
    public class _00520_DetectCapital
    {
        /// <summary>
        /// We define the usage of capitals in a word to be right when one of the following cases holds:
        /// All letters in this word are capitals, like "USA".
        /// All letters in this word are not capitals, like "leetcode".
        /// Only the first letter in this word is capital, like "Google".
        /// Given a string word, return true if the usage of capitals in it is right.
        /// </summary>
        public _00520_DetectCapital()
        {
            Console.WriteLine(DetectCapitalUse0("USA"));
            Console.WriteLine(DetectCapitalUse0("FlaG"));
        }

        public static bool DetectCapitalUse0(string a0) => RftDetectCapitalUse0(a0);

        public static bool DetectCapitalUse1(string a0) => RftDetectCapitalUse1(a0);

        private static bool RftDetectCapitalUse0(string word)
        {
            int n = word.Length;
            if (n == 1) return true;

            int l = 0, u = 0;
            for (int i = 1; i < n; i++)
            {
                if (char.IsLower(word[i])) l++;
                if (char.IsUpper(word[i])) u++;

                if (l > 0 && u > 0) return false;
            }

            if (char.IsLower(word[0]) && u > 0) return false;

            return true;
        }

        private static bool RftDetectCapitalUse1(string word)
        {
            return word.ToUpper().Equals(word) || word.ToLower().Equals(word) || (char.ToUpper(word[0]) + word[1..].ToLower()).Equals(word);
        }
    }
}
