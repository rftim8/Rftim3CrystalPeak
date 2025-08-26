namespace Rftim3LeetCode.Temp
{
    public class _02586_CountTheNumberOfVowelStringsInRange
    {
        /// <summary>
        /// You are given a 0-indexed array of string words and two integers left and right.
        /// A string is called a vowel string if it starts with a vowel character and ends with a vowel character where vowel characters are 'a', 'e', 'i', 'o', and 'u'.
        /// Return the number of vowel strings words[i] where i belongs to the inclusive range[left, right].
        /// </summary>
        public _02586_CountTheNumberOfVowelStringsInRange()
        {
            Console.WriteLine(VowelStrings(["are", "amy", "u"], 0, 2));
            Console.WriteLine(VowelStrings(["hey", "aeo", "mu", "ooo", "artro"], 1, 4));
        }

        private static int VowelStrings(string[] words, int left, int right)
        {
            char[] v = ['a', 'e', 'i', 'o', 'u'];

            int c = 0;
            for (int i = left; i <= right; i++)
            {
                if (v.Contains(words[i][0]) && v.Contains(words[i][^1])) c++;
            }

            return c;
        }
    }
}
