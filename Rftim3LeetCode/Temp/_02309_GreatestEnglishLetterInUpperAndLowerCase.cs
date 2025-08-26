namespace Rftim3LeetCode.Temp
{
    public class _02309_GreatestEnglishLetterInUpperAndLowerCase
    {
        /// <summary>
        /// Given a string of English letters s, return the greatest English letter which occurs as both a lowercase and uppercase letter in s. 
        /// The returned letter should be in uppercase. If no such letter exists, return an empty string.
        /// An English letter b is greater than another letter a if b appears after a in the English alphabet.
        /// </summary>
        public _02309_GreatestEnglishLetterInUpperAndLowerCase()
        {
            Console.WriteLine(GreatestLetter("lEeTcOdE"));
            Console.WriteLine(GreatestLetter("arRAzFif"));
            Console.WriteLine(GreatestLetter("AbCdEfGhIjK"));
        }

        private static string GreatestLetter(string s)
        {
            Dictionary<char, int> r = [];
            List<int> x = [];

            for (int i = 0; i < s.Length; i++)
            {
                if (!r.ContainsKey(s[i]))
                {
                    r[s[i]] = 1;
                    if (char.IsUpper(s[i]) && r.ContainsKey((char)(s[i] + 32))) x.Add(s[i]);
                    if (char.IsLower(s[i]) && r.ContainsKey((char)(s[i] - 32))) x.Add(s[i] - 32);
                }
            }

            return x.Count > 0 ? string.Concat((char)x.Max()) : "";
        }
    }
}
