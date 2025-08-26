namespace Rftim3LeetCode.Temp
{
    public class _01657_DetermineIfTwoStringsAreClose
    {
        /// <summary>
        /// Two strings are considered close if you can attain one from the other using the following operations:
        /// 
        /// Operation 1: Swap any two existing characters.
        /// For example, abcde -> aecdb
        /// Operation 2: Transform every occurrence of one existing character into another existing character, 
        /// and do the same with the other character.
        /// For example, aacabb -> bbcbaa (all a's turn into b's, and all b's turn into a's)
        /// You can use the operations on either string as many times as necessary.
        /// 
        /// Given two strings, word1 and word2, return true if word1 and word2 are close, and false otherwise.
        /// </summary>
        public _01657_DetermineIfTwoStringsAreClose()
        {
            Console.WriteLine(CloseStrings0("abc", "bca"));
            Console.WriteLine(CloseStrings0("a", "aa"));
            Console.WriteLine(CloseStrings0("cabbba", "abbccc"));
            Console.WriteLine(CloseStrings0("uau", "ssx"));
            Console.WriteLine(CloseStrings0("xxxxxxxxxxxxxxxxxxx", "zzzzzzzzzzzzzzzzzzz"));
        }

        public static bool CloseStrings0(string a0, string a1) => RftCloseStrings0(a0, a1);

        public static bool CloseStrings1(string a0, string a1) => RftCloseStrings1(a0, a1);

        private static bool RftCloseStrings0(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;

            int[] w1c = new int[26];
            int[] w2c = new int[26];

            foreach (char c in word1) w1c[c - 'a']++;
            foreach (char c in word2) w2c[c - 'a']++;

            for (int i = 0; i < 26; i++)
            {
                if (w1c[i] == 0 != (w2c[i] == 0)) return false;
            }

            Array.Sort(w1c);
            Array.Sort(w2c);

            return w1c.SequenceEqual(w2c);
        }

        private static bool RftCloseStrings1(string word1, string word2)
        {
            List<int> f1 = Freqs(word1);
            int m1 = Mask(f1);
            f1.Sort();

            List<int> f2 = Freqs(word2);
            int m2 = Mask(f2);
            f2.Sort();

            return m1 == m2 && f1.SequenceEqual(f2);
        }

        private static List<int> Freqs(string word)
        {
            List<int> f = new(Enumerable.Repeat(0, 26));

            foreach (char c in word)
            {
                ++f[c - 'a'];
            }

            return f;
        }

        private static int Mask(List<int> f)
        {
            int m = 0;

            foreach (int c in f)
            {
                m = m << 1 | (c > 0 ? 1 : 0);
            }

            return m;
        }
    }
}
