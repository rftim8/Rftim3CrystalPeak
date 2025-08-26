namespace Rftim3LeetCode.Temp
{
    public class _00744_FindSmallestLetterGreaterThanTarget
    {
        /// <summary>
        /// You are given an array of characters letters that is sorted in non-decreasing order, and a character target. 
        /// There are at least two different characters in letters.
        /// Return the smallest character in letters that is lexicographically greater than target.
        /// If such a character does not exist, return the first character in letters.
        /// </summary>
        public _00744_FindSmallestLetterGreaterThanTarget()
        {
            Console.WriteLine(NextGreatestLetter(['c', 'f', 'j'], 'a'));
            Console.WriteLine(NextGreatestLetter(['c', 'f', 'j'], 'c'));
            Console.WriteLine(NextGreatestLetter(['x', 'x', 'y', 'y'], 'z'));
        }

        private static char NextGreatestLetter(char[] letters, char target)
        {
            int n = letters.Length;

            for (int i = 0; i < n; i++)
            {
                if (letters[i] > target) return letters[i];
            }

            return letters[0];
        }
    }
}
