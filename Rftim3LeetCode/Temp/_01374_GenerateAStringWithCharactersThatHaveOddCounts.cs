namespace Rftim3LeetCode.Temp
{
    public class _01374_GenerateAStringWithCharactersThatHaveOddCounts
    {
        /// <summary>
        /// Given an integer n, return a string with n characters such that each character in such string occurs an odd number of times.
        /// The returned string must contain only lowercase English letters.If there are multiples valid strings, return any of them.
        /// </summary>
        public _01374_GenerateAStringWithCharactersThatHaveOddCounts()
        {
            Console.WriteLine(GenerateTheString(4));
            Console.WriteLine(GenerateTheString(2));
            Console.WriteLine(GenerateTheString(7));
        }

        private static string GenerateTheString(int n)
        {
            if (n == 1) return "a";
            return n % 2 == 0 ? $"a{string.Concat(Enumerable.Repeat("b", n - 1))}" : $"ab{string.Concat(Enumerable.Repeat("c", n - 2))}";
        }

        private static string GenerateTheString0(int n)
        {
            char[] carr = new char[n];
            int left = 0;

            if (n % 2 == 0) carr[left++] = 'b';
            while (left < carr.Length)
            {
                carr[left++] = 'a';
            }

            return new string(carr);
        }
    }
}
