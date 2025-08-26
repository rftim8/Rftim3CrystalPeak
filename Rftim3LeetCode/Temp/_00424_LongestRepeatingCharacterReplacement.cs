namespace Rftim3LeetCode.Temp
{
    public class _00424_LongestRepeatingCharacterReplacement
    {
        /// <summary>
        /// You are given a string s and an integer k. You can choose any character of the string and change it to any other uppercase English character. 
        /// You can perform this operation at most k times.
        /// Return the length of the longest substring containing the same letter you can get after performing the above operations.
        /// </summary>
        public _00424_LongestRepeatingCharacterReplacement()
        {
            Console.WriteLine(CharacterReplacement("ABAB", 2));
            Console.WriteLine(CharacterReplacement("AABABBA", 1));
            Console.WriteLine(CharacterReplacement("ABBB", 2));
            Console.WriteLine(CharacterReplacement("BAAAB", 2));
        }

        private static int CharacterReplacement(string s, int k)
        {
            int n = s.Length;
            int[] chars = new int[26];
            int c = 0;
            int l = 0, max = 0;

            for (int r = 0; r < n; r++)
            {
                int crt = s[r] - 'A';
                chars[crt]++;

                max = Math.Max(max, chars[crt]);

                bool valid = r + 1 - l - max <= k;
                if (!valid)
                {
                    int slideRight = s[l] - 'A';
                    chars[slideRight]--;
                    l++;
                }

                c = r + 1 - l;
            }

            return c;
        }
    }
}
