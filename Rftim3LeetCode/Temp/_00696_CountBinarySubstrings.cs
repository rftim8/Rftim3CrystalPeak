namespace Rftim3LeetCode.Temp
{
    public class _00696_CountBinarySubstrings
    {
        /// <summary>
        /// Given a binary string s, return the number of non-empty substrings that have the same number of 0's and 1's, 
        /// and all the 0's and all the 1's in these substrings are grouped consecutively.
        /// Substrings that occur multiple times are counted the number of times they occur.
        /// </summary>
        public _00696_CountBinarySubstrings()
        {
            Console.WriteLine(CountBinarySubstrings("00110011"));
            Console.WriteLine(CountBinarySubstrings("10101"));
        }

        private static int CountBinarySubstrings(string s)
        {
            int ans = 0, prev = 0, cur = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                {
                    ans += Math.Min(prev, cur);
                    prev = cur;
                    cur = 1;
                }
                else cur++;

                Console.WriteLine($"{ans}: {prev} -> {cur}");
            }

            return ans + Math.Min(prev, cur);
        }

        private static int CountBinarySubstrings0(string s)
        {
            s += " ";
            List<int> countList = [];
            int c = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1]) c++;
                else
                {
                    countList.Add(c);
                    c = 1;
                }
            }

            int answ = 0;
            for (int i = 1; i < countList.Count; i++)
            {
                answ += Math.Min(countList[i], countList[i - 1]);
            }

            return answ;
        }
    }
}
