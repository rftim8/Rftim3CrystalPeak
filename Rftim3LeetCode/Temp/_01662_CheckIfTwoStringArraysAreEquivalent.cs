namespace Rftim3LeetCode.Temp
{
    public class _01662_CheckIfTwoStringArraysAreEquivalent
    {
        /// <summary>
        /// Given two string arrays word1 and word2, return true if the two arrays represent the same string, and false otherwise.
        /// A string is represented by an array if the array elements concatenated in order forms the string.
        /// </summary>
        public _01662_CheckIfTwoStringArraysAreEquivalent()
        {
            Console.WriteLine(ArrayStringsAreEqual(["ab", "c"], ["a", "bc"]));
            Console.WriteLine(ArrayStringsAreEqual(["a", "cb"], ["ab", "c"]));
            Console.WriteLine(ArrayStringsAreEqual(["abc", "d", "defg"], ["abcddefg"]));
        }

        private static bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            return string.Concat(word1) == string.Concat(word2);
        }
    }
}
