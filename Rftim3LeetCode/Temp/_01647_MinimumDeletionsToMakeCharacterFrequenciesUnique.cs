namespace Rftim3LeetCode.Temp
{
    public class _01647_MinimumDeletionsToMakeCharacterFrequenciesUnique
    {
        /// <summary>
        /// A string s is called good if there are no two different characters in s that have the same frequency.
        /// Given a string s, return the minimum number of characters you need to delete to make s good.
        /// The frequency of a character in a string is the number of times it appears in the string. 
        /// For example, in the string "aab", the frequency of 'a' is 2, while the frequency of 'b' is 1.
        /// </summary>
        public _01647_MinimumDeletionsToMakeCharacterFrequenciesUnique()
        {
            Console.WriteLine(MinimumDeletionsToMakeCharacterFrequenciesUnique0("aab"));
            Console.WriteLine(MinimumDeletionsToMakeCharacterFrequenciesUnique0("aaabbbcc"));
            Console.WriteLine(MinimumDeletionsToMakeCharacterFrequenciesUnique0("ceabaacb"));
            Console.WriteLine(MinimumDeletionsToMakeCharacterFrequenciesUnique0("abcabc"));
            Console.WriteLine(MinimumDeletionsToMakeCharacterFrequenciesUnique0("bbcebabd"));
        }

        public static int MinimumDeletionsToMakeCharacterFrequenciesUnique0(string a0) => RftMinimumDeletionsToMakeCharacterFrequenciesUnique0(a0);

        public static int MinimumDeletionsToMakeCharacterFrequenciesUnique1(string a0) => RftMinimumDeletionsToMakeCharacterFrequenciesUnique1(a0);

        private static int RftMinimumDeletionsToMakeCharacterFrequenciesUnique0(string s)
        {
            int n = s.Length;
            int[] x = new int[26];

            for (int i = 0; i < n; i++)
            {
                x[s[i] - 97]++;
            }
            Array.Sort(x);

            int r = 0;
            for (int i = 25; i > 0; i--)
            {
                if (x[i] == 0)
                {
                    if (x[i - 1] != 0)
                    {
                        r += x[i - 1];
                        x[i - 1] = 0;
                    }
                    else break;
                }

                else if (x[i] <= x[i - 1])
                {
                    r += x[i - 1] - x[i] + 1;
                    x[i - 1] = x[i] - 1;
                }
            }

            return r;
        }

        private static int RftMinimumDeletionsToMakeCharacterFrequenciesUnique1(string s)
        {
            int[] count = new int[26];
            foreach (char c in s)
            {
                count[c - 'a']++;
            }

            HashSet<int> set = [];
            int result = 0;
            foreach (int cnt in count)
            {
                int c = cnt;
                while (c > 0 && !set.Add(c))
                {
                    c--;
                    result++;
                }
            }

            return result;
        }
    }
}