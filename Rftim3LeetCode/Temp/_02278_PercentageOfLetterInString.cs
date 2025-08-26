namespace Rftim3LeetCode.Temp
{
    public class _02278_PercentageOfLetterInString
    {
        /// <summary>
        /// Given a string s and a character letter, return the percentage of characters in s that equal letter rounded down to the nearest whole percent.
        /// </summary>
        public _02278_PercentageOfLetterInString()
        {
            Console.WriteLine(PercentageLetter("foobar", 'o'));
            Console.WriteLine(PercentageLetter("jjjj", 'k'));
            Console.WriteLine(PercentageLetter("vmvvvvvzrvvpvdvvvvyfvdvvvvpkvvbvvkvvfkvvvkvbvvnvvomvzvvvdvvvkvvvvvvvvvlvcvilaqvvhoevvlmvhvkvtgwfvvzy", 'v'));
            Console.WriteLine(PercentageLetter("sgawtb", 's'));
        }

        private static int PercentageLetter(string s, char letter)
        {
            int c = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == letter) c++;
            }

            return c * 100 / s.Length;
        }

        private static int PercentageLetter0(string s, char letter)
        {
            int count = s.Count(ch => ch == letter);

            return count * 100 / s.Length;
        }
    }
}
