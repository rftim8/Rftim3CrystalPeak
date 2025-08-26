namespace Rftim3LeetCode.Temp
{
    public class _01456_MaximumNumberOfVowelsInASubstringOfGivenLength
    {
        /// <summary>
        /// Given a string s and an integer k, return the maximum number of vowel letters in any substring of s with length k.
        /// Vowel letters in English are 'a', 'e', 'i', 'o', and 'u'.
        /// </summary>
        public _01456_MaximumNumberOfVowelsInASubstringOfGivenLength()
        {
            Console.WriteLine(MaxVowels("abciiidef", 3));
            Console.WriteLine(MaxVowels("aeiou", 2));
            Console.WriteLine(MaxVowels("leetcode", 3));
        }

        private static int MaxVowels(string s, int k)
        {
            List<char> vowels = ['a', 'e', 'i', 'o', 'u'];

            int count = 0;
            for (int i = 0; i < k; i++)
            {
                count += vowels.Contains(s[i]) ? 1 : 0;
            }

            int answer = count;
            for (int i = k; i < s.Length; i++)
            {
                count += vowels.Contains(s[i]) ? 1 : 0;
                count -= vowels.Contains(s[i - k]) ? 1 : 0;
                answer = Math.Max(answer, count);
                if (answer == k) return k;
            }

            return answer;
        }
    }
}
