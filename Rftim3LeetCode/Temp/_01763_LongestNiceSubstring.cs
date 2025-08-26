namespace Rftim3LeetCode.Temp
{
    public class _01763_LongestNiceSubstring
    {
        /// <summary>
        /// A string s is nice if, for every letter of the alphabet that s contains, it appears both in uppercase and lowercase. 
        /// For example, "abABB" is nice because 'A' and 'a' appear, and 'B' and 'b' appear. 
        /// However, "abA" is not because 'b' appears, but 'B' does not.
        /// Given a string s, return the longest substring of s that is nice.
        /// If there are multiple, return the substring of the earliest occurrence.
        /// If there are none, return an empty string.
        /// </summary>
        public _01763_LongestNiceSubstring()
        {
            Console.WriteLine(LongestNiceSubstring("YazaAay"));
            Console.WriteLine(LongestNiceSubstring("Bb"));
            Console.WriteLine(LongestNiceSubstring("c"));
            Console.WriteLine(LongestNiceSubstring("cChH"));
            Console.WriteLine(LongestNiceSubstring("BebjJE"));
        }

        private static string LongestNiceSubstring(string s)
        {
            if (s == "") return s;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 97 && !s.Contains((char)(s[i] - 32)) || s[i] < 97 && !s.Contains((char)(s[i] + 32)))
                {
                    string front = LongestNiceSubstring(s[..i]);
                    string back = LongestNiceSubstring(i + 1 >= s.Length ? "" : s.Substring(i + 1, s.Length - i - 1));

                    return front.Length >= back.Length ? front : back;
                }
            }

            return s;
        }
    }
}
