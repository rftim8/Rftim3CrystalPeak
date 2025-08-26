using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00126_WordLadder2
    {
        /// <summary>
        /// A transformation sequence from word beginWord to word endWord using a dictionary wordList is a sequence of words beginWord -> s1 -> s2 -> ... -> sk such that:
        /// Every adjacent pair of words differs by a single letter.
        /// Every si for 1 <= i <= k is in wordList.Note that beginWord does not need to be in wordList.
        /// sk == endWord
        /// Given two words, beginWord and endWord, and a dictionary wordList, return all the shortest transformation sequences from beginWord to endWord, 
        /// or an empty list if no such sequence exists. 
        /// Each sequence should be returned as a list of the words[beginWord, s1, s2, ..., sk].
        /// </summary>
        public _00126_WordLadder2()
        {
            IList<IList<string>> x = FindLadders("hit", "cog", ["hot", "dot", "dog", "lot", "log", "cog"]);
            RftTerminal.RftReadResult(x);
            IList<IList<string>> x0 = FindLadders("hit", "cog", ["hot", "dot", "dog", "lot", "log"]);
            RftTerminal.RftReadResult(x0);
        }

        private static List<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            int n = beginWord.Length;
            int m = endWord.Length;
            List<IList<string>> r = [];
            if (n != m) return r;

            HashSet<string> w = new(wordList);
            if (!w.Contains(endWord)) return r;

            Queue<List<string>> q = new();
            List<string> p = [beginWord];
            q.Enqueue(p);
            HashSet<string> v = [];
            bool f = false;

            while (q.Count > 0)
            {
                int s = q.Count;
                for (int i = 0; i < s; i++)
                {
                    List<string> cl = q.Dequeue();
                    string c = cl[^1];

                    char[] a = c.ToCharArray();
                    for (int j = 0; j < a.Length; j++)
                    {
                        char o = a[j];
                        for (char k = 'a'; k <= 'z'; k++)
                        {
                            a[j] = k;
                            string x = new(a);
                            if (w.Contains(x))
                            {
                                v.Add(x);
                                cl.Add(x);

                                if (x == endWord)
                                {
                                    f = true;
                                    r.Add(new List<string>(cl));
                                }

                                q.Enqueue(new List<string>(cl));
                                cl.RemoveAt(cl.Count - 1);
                            }
                        }
                        a[j] = o;
                    }
                }

                foreach (string item in v)
                {
                    w.Remove(item);
                }

                if (f) break;
            }

            return r;
        }

        private static List<IList<string>> FindLadders0(string beginWord, string endWord, IList<string> wordList)
        {
            Queue<string> available = new(wordList.Where(x => x != beginWord));
            Dictionary<string, List<string>> incoming = [];
            List<string> pending = new([beginWord]);
            Dictionary<string, List<string>> processing = [];

            while (available.Count > 0 && pending.Count > 0 && !incoming.ContainsKey(endWord))
            {
                for (int availableCount = available.Count; availableCount > 0; availableCount--)
                {
                    string availableWord = available.Dequeue();
                    foreach (string pendingWord in pending)
                    {
                        int diffs = 0;
                        for (int i = 0; i < availableWord.Length && diffs < 2; i++)
                        {
                            if (availableWord[i] != pendingWord[i]) diffs++;
                        }

                        if (diffs < 2)
                        {
                            if (!processing.TryGetValue(availableWord, out List<string>? list)) processing.Add(availableWord, list = []);
                            list.Add(pendingWord);
                        }
                    }
                    if (!processing.ContainsKey(availableWord)) available.Enqueue(availableWord);
                }
                pending.Clear();

                foreach (KeyValuePair<string, List<string>> entry in processing)
                {
                    pending.Add(entry.Key);
                    incoming[entry.Key] = entry.Value;
                }

                processing.Clear();
            }

            List<IList<string>> ladders = [];
            Stack<string> stack = new();

            void dfs(string word)
            {
                stack.Push(word);
                if (word == beginWord) ladders.Add([.. stack]);
                else if (incoming.TryGetValue(word, out List<string>? list))
                {
                    foreach (string next in list) dfs(next);
                }
                stack.Pop();
            }
            dfs(endWord);

            return ladders;
        }
    }
}
