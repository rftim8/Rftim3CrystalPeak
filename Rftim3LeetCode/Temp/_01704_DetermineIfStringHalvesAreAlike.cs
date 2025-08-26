namespace Rftim3LeetCode.Temp
{
    public class _01704_DetermineIfStringHalvesAreAlike
    {
        /// <summary>
        /// You are given a string s of even length. Split this string into two halves of equal lengths, and let a be the first half and b be the second half.
        /// Two strings are alike if they have the same number of vowels('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'). 
        /// Notice that s contains uppercase and lowercase letters.
        /// Return true if a and b are alike.Otherwise, return false.
        /// </summary>
        public _01704_DetermineIfStringHalvesAreAlike()
        {
            Console.WriteLine(HalvesAreAlike("book"));
            Console.WriteLine(HalvesAreAlike("textbook"));
        }

        private static bool HalvesAreAlike(string s)
        {
            int n = s.Length / 2;
            char[] v = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

            int l = 0;
            for (int i = 0; i < n; i++)
            {
                if (v.Contains(s[i])) l++;
            }

            int r = 0;
            for (int i = n; i < s.Length; i++)
            {
                if (v.Contains(s[i])) r++;
            }

            return l == r;
        }

        private static bool HalvesAreAlike0(string s)
        {
            int n = s.Length;
            int count = 0;

            for (int i = 0; i < n / 2; i++)
            {
                count += s[i] switch
                {
                    'a' => 1,
                    'e' => 1,
                    'i' => 1,
                    'o' => 1,
                    'u' => 1,
                    'A' => 1,
                    'E' => 1,
                    'I' => 1,
                    'O' => 1,
                    'U' => 1,
                    _ => 0
                };
            }

            for (int i = n / 2; i < n; i++)
            {
                count -= s[i] switch
                {
                    'a' => 1,
                    'e' => 1,
                    'i' => 1,
                    'o' => 1,
                    'u' => 1,
                    'A' => 1,
                    'E' => 1,
                    'I' => 1,
                    'O' => 1,
                    'U' => 1,
                    _ => 0
                };
            }

            return count == 0;
        }
    }
}
