namespace Rftim3LeetCode.Temp
{
    public class _01239_MaximumLengthOfAConcatenatedStringWithUniqueCharacters
    {
        /// <summary>
        /// You are given an array of strings arr. A string s is formed by the concatenation of a subsequence of arr that has unique characters.
        /// 
        /// Return the maximum possible length of s.
        /// 
        /// A subsequence is an array that can be derived from another array by deleting some or no elements without changing the order of the remaining elements.
        /// </summary>
        public _01239_MaximumLengthOfAConcatenatedStringWithUniqueCharacters()
        {
            Console.WriteLine(MaxLength0(["un", "iq", "ue"]));
            Console.WriteLine(MaxLength0(["cha", "r", "act", "ers"]));
            Console.WriteLine(MaxLength0(["abcdefghijklmnopqrstuvwxyz"]));
        }

        public static int MaxLength0(IList<string> a0) => RftMaxLength0(a0);

        public static int MaxLength1(IList<string> a0) => RftMaxLength1(a0);

        public static int MaxLength2(IList<string> a0) => RftMaxLength2(a0);

        public static int MaxLength3(IList<string> a0) => RftMaxLength3(a0);

        public static int MaxLength4(IList<string> a0) => RftMaxLength4(a0);

        public static int MaxLength5(IList<string> a0) => RftMaxLength5(a0);

        // Iterative
        private static int RftMaxLength0(IList<string> arr)
        {
            List<string> l = [""];
            int res = 0;

            foreach (string word in arr)
            {
                int n = l.Count;
                for (int i = 0; i < n; i++)
                {
                    string t = l[i] + word;
                    HashSet<char> hs = [];
                    foreach (char item in t.ToCharArray())
                    {
                        hs.Add(item);
                    }

                    if (t.Length != hs.Count) continue;

                    l.Add(t);
                    res = Math.Max(res, t.Length);
                }
            }

            return res;
        }

        // Iterative optimized
        private static int RftMaxLength1(IList<string> arr)
        {
            HashSet<int> results = [0];
            int best = 0;

            foreach (string word in arr)
            {
                best = Math.Max(best, AddWord(word, results));
            }

            return best;
        }

        private static int AddWord(string word, HashSet<int> results)
        {
            int charBitSet = 0;
            int best = 0;
            foreach (char c in word.ToCharArray())
            {
                int mask = 1 << c - 'a';

                if ((charBitSet & mask) > 0) return 0;

                charBitSet += mask;
            }

            if (results.Contains(charBitSet + (word.Length << 26))) return 0;

            HashSet<int> newResults = [];
            foreach (int res in results)
            {
                if ((res & charBitSet) > 0) continue;

                int newResLen = (res >> 26) + word.Length;
                int newCharBitSet = charBitSet + res & (1 << 26) - 1;

                newResults.Add((newResLen << 26) + newCharBitSet);
                best = Math.Max(best, newResLen);
            }
            results.UnionWith(newResults);

            return best;
        }

        // Backtracking
        private static int RftMaxLength2(IList<string> arr)
        {
            return Backtracking(arr, 0, []);
        }

        private static int Backtracking(IList<string> arr, int pos, Dictionary<char, int> resMap)
        {
            foreach (int val in resMap.Values)
            {
                if (val > 1) return 0;
            }

            int best = resMap.Count;
            for (int i = pos; i < arr.Count; i++)
            {
                char[] wordArr = arr[i].ToCharArray();
                foreach (char c in wordArr)
                {
                    if (resMap.TryGetValue(c, out int value)) resMap[c] = ++value;
                    else resMap.Add(c, 1);
                }

                best = Math.Max(best, Backtracking(arr, i + 1, resMap));

                foreach (char c in wordArr)
                {
                    if (resMap[c] == 1) resMap.Remove(c);
                    else resMap[c]--;
                }
            }

            return best;
        }

        // Backtracking optimized
        private static int RftMaxLength3(IList<string> arr)
        {
            HashSet<int> optSet = [];
            foreach (string word in arr)
            {
                WordToBitSet(optSet, word);
            }

            int[] optArr = new int[optSet.Count];
            int i = 0;
            foreach (int num in optSet)
            {
                optArr[i++] = num;
            }

            return Backtracking(optArr, 0, 0, 0);
        }

        private static void WordToBitSet(HashSet<int> optSet, string word)
        {
            int charBitSet = 0;
            foreach (char c in word.ToCharArray())
            {
                int mask = 1 << c - 'a';

                if ((charBitSet & mask) > 0) return;

                charBitSet += mask;
            }

            optSet.Add(charBitSet + (word.Length << 26));
        }

        private static int Backtracking(int[] optArr, int pos, int resChars, int resLen)
        {
            int best = resLen;
            for (int i = pos; i < optArr.Length; i++)
            {
                int newChars = optArr[i] & (1 << 26) - 1;
                int newLen = optArr[i] >> 26;

                if ((resChars & newChars) > 0) continue;

                resChars += newChars;
                resLen += newLen;
                best = Math.Max(best, Backtracking(optArr, i + 1, resChars, resLen));

                resChars -= newChars;
                resLen -= newLen;
            }

            return best;
        }

        // Recursion
        private static int RftMaxLength4(IList<string> arr)
        {
            return Dfs(arr, 0, "");
        }

        private static int Dfs(IList<string> arr, int pos, string res)
        {
            HashSet<char> resSet = [];
            foreach (char c in res.ToCharArray())
            {
                resSet.Add(c);
            }

            if (res.Length != resSet.Count) return 0;

            int best = res.Length;
            for (int i = pos; i < arr.Count; i++)
            {
                best = Math.Max(best, Dfs(arr, i + 1, res + arr[i]));
            }

            return best;
        }

        // Recursion optimized
        private static int RftMaxLength5(IList<string> arr)
        {
            HashSet<int> optSet = [];
            foreach (string word in arr)
            {
                WordToBitSet5(optSet, word);
            }

            int[] optArr = new int[optSet.Count];
            int i = 0;
            foreach (int num in optSet)
            {
                optArr[i++] = num;
            }

            return Dfs5(optArr, 0, 0);
        }

        private static void WordToBitSet5(HashSet<int> optSet, string word)
        {
            int charBitSet = 0;
            foreach (char c in word.ToCharArray())
            {
                int mask = 1 << c - 'a';

                if ((charBitSet & mask) > 0) return;

                charBitSet += mask;
            }

            optSet.Add(charBitSet + (word.Length << 26));
        }

        private static int Dfs5(int[] optArr, int pos, int res)
        {
            int oldChars = res & (1 << 26) - 1;
            int oldLen = res >> 26;
            int best = oldLen;

            for (int i = pos; i < optArr.Length; i++)
            {
                int newChars = optArr[i] & (1 << 26) - 1;
                int newLen = optArr[i] >> 26;

                if ((newChars & oldChars) != 0) continue;

                int newRes = newChars + oldChars + (newLen + oldLen << 26);
                best = Math.Max(best, Dfs5(optArr, i + 1, newRes));
            }

            return best;
        }
    }
}
