namespace Rftim3LeetCode.Temp
{
    public class _00028_FindTheIndexOfTheFirstOccurrenceInAString
    {
        /// <summary>
        /// Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
        /// </summary>
        public _00028_FindTheIndexOfTheFirstOccurrenceInAString()
        {
            Console.WriteLine(FindTheIndexOfTheFirstOccurrenceInAString0("sadbutsad", "sad"));
            Console.WriteLine(FindTheIndexOfTheFirstOccurrenceInAString0("a", "a"));
            Console.WriteLine(FindTheIndexOfTheFirstOccurrenceInAString0("abc", "c"));
        }

        public static int FindTheIndexOfTheFirstOccurrenceInAString0(string a0, string a1) => RftFindTheIndexOfTheFirstOccurrenceInAString0(a0, a1);

        private static int RftFindTheIndexOfTheFirstOccurrenceInAString0(string haystack, string needle)
        {
            int n = haystack.Length;
            int m = needle.Length;
            if (n < m || n == m && haystack != needle) return -1;
            if (n == m && haystack == needle) return 0;

            int o = n - m;
            int c = -1;

            for (int i = 0; i <= o; i++)
            {
                if (haystack.Substring(i, m) == needle)
                {
                    c = i;
                    break;
                }
            }

            return c;
        }
    }
}
