namespace Rftim3LeetCode.Temp
{
    public class _00127_WordLadder
    {
        /// <summary>
        /// A transformation sequence from word beginWord to word endWord using a dictionary wordList is a sequence of words beginWord -> s1 -> s2 -> ... -> sk such that:
        /// Every adjacent pair of words differs by a single letter.
        /// Every si for 1 <= i <= k is in wordList.
        /// Note that beginWord does not need to be in wordList.
        /// sk == endWord
        /// Given two words, beginWord and endWord, and a dictionary wordList, return the number of words in the shortest transformation sequence from beginWord to endWord, 
        /// or 0 if no such sequence exists.
        /// </summary>
        public _00127_WordLadder()
        {
            Console.WriteLine(LadderLength("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" }));
            Console.WriteLine(LadderLength("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log" }));
        }

        private static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            int c = 1;
            HashSet<string> h = new(wordList);
            Queue<string> q = new();
            q.Enqueue(beginWord);

            while (q.Any())
            {
                int cl = q.Count;

                while (cl-- > 0)
                {
                    string cw = q.Dequeue();
                    if (cw == endWord) return c;

                    char[] t = cw.ToCharArray();
                    for (int i = 0; i < t.Length; i++)
                    {
                        t = cw.ToCharArray();

                        for (int j = 0; j < 26; j++)
                        {
                            t[i] = (char)('a' + j);
                            string x = new(t);
                            if (h.Contains(x))
                            {
                                q.Enqueue(x);
                                h.Remove(x);
                            }
                        }
                    }
                }

                c++;
            }

            return 0;
        }
    }
}
