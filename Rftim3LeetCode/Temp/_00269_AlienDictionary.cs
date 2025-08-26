using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00269_AlienDictionary
    {
        /// <summary>
        /// There is a new alien language that uses the English alphabet. 
        /// However, the order of the letters is unknown to you.
        /// 
        /// You are given a list of strings words from the alien language's dictionary. 
        /// Now it is claimed that the strings in words are 
        /// sorted lexicographically by the rules of this new language.
        /// 
        /// If this claim is incorrect, and the given arrangement of string in words cannot correspond to any order of letters, return "".
        /// 
        /// Otherwise, return a string of the unique letters in the new alien language sorted in lexicographically increasing order by the new language's rules. 
        /// If there are multiple solutions, return any of them.
        /// </summary>
        public _00269_AlienDictionary()
        {
            Console.WriteLine(AlienDictionary1(["wrt", "wrf", "er", "ett", "rftt"]));
            Console.WriteLine(AlienDictionary1(["z", "x"]));
            Console.WriteLine(AlienDictionary1(["z", "x", "z"]));
        }

        public static string AlienDictionary0(string[] a0) => RftAlienDictionary0(a0);

        public static string AlienDictionary1(string[] a0) => RftAlienDictionary1(a0);

        public static string AlienDictionary2(string[] a0) => RftAlienDictionary2(a0);

        // BFS
        private static string RftAlienDictionary0(string[] words)
        {
            Dictionary<char, List<char>> adjList = [];
            Dictionary<char, int> counts = [];
            foreach (string word in words)
            {
                foreach (char c in word.ToCharArray())
                {
                    counts.TryAdd(c, 0);
                    adjList.TryAdd(c, []);
                }
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                string word1 = words[i];
                string word2 = words[i + 1];
                if (word1.Length > word2.Length && word1.StartsWith(word2)) return "";
                for (int j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    if (word1[j] != word2[j])
                    {
                        adjList[word1[j]].Add(word2[j]);
                        if (!counts.TryGetValue(word2[j], out int value)) counts.Add(word2[j], counts[word2[j]] + 1);
                        else counts[word2[j]] = value + 1;
                        break;
                    }
                }
            }

            StringBuilder sb = new();
            Queue<char> queue = [];
            foreach (char c in counts.Keys)
            {
                if (counts[c].Equals(0)) queue.Enqueue(c);
            }
            while (queue.Count != 0)
            {
                char c = queue.Dequeue();
                sb.Append(c);
                foreach (char next in adjList[c])
                {
                    if (!counts.TryGetValue(next, out int value)) counts.Add(next, counts[next] - 1);
                    else counts[next] = value - 1;

                    if (counts[next].Equals(0)) queue.Enqueue(next);
                }
            }

            if (sb.Length < counts.Count) return "";

            return sb.ToString();
        }

        private static Dictionary<char, List<char>>? reverseAdjList;
        private static Dictionary<char, bool>? seen;
        private static StringBuilder? output;

        // DFS
        private static string RftAlienDictionary1(string[] words)
        {
            reverseAdjList = [];
            seen = [];
            output = new();

            foreach (string word in words)
            {
                foreach (char c in word.ToCharArray())
                {
                    if (!reverseAdjList.ContainsKey(c)) reverseAdjList[c] = [];
                }
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                string word1 = words[i];
                string word2 = words[i + 1];
                if (word1.Length > word2.Length && word1.StartsWith(word2)) return "";

                for (int j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    if (word1[j] != word2[j])
                    {
                        reverseAdjList[word2[j]].Add(word1[j]);
                        break;
                    }
                }
            }

            foreach (char c in reverseAdjList.Keys)
            {
                bool result = Dfs(c);
                if (!result) return "";
            }

            return output.ToString();
        }

        private static bool Dfs(char c)
        {
            if (seen!.TryGetValue(c, out bool value)) return value;

            seen.Add(c, false);
            foreach (char next in reverseAdjList![c])
            {
                bool result = Dfs(next);
                if (!result) return false;
            }
            seen[c] = true;
            output!.Append(c);

            return true;
        }

        private static string RftAlienDictionary2(string[] words)
        {
            Dictionary<char, HashSet<char>> graph = [];
            Dictionary<char, int> inDegree = [];

            foreach (string word in words)
            {
                foreach (char w in word)
                {
                    if (!graph.ContainsKey(w))
                    {
                        graph.Add(w, []);
                        inDegree[w] = 0;
                    }
                }
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                string word1 = words[i];
                string word2 = words[i + 1];

                int minLength = Math.Min(word1.Length, word2.Length);
                bool foundOrder = false;

                for (int j = 0; j < minLength; j++)
                {
                    if (word1[j] == word2[j]) continue;

                    if (!graph[word1[j]].Contains(word2[j]))
                    {
                        graph[word1[j]].Add(word2[j]);
                        inDegree[word2[j]]++;
                    }

                    foundOrder = true;
                    break;
                }

                if (!foundOrder && word1.Length > word2.Length) return "";
            }

            Queue<char> queue = new();
            foreach (KeyValuePair<char, int> item in inDegree)
            {
                if (item.Value == 0) queue.Enqueue(item.Key);
            }

            StringBuilder sb = new();
            while (queue.Count != 0)
            {
                char node = queue.Dequeue();
                sb.Append(node);

                if (!graph.ContainsKey(node)) continue;

                foreach (char child in graph[node])
                {
                    inDegree[child]--;
                    if (inDegree[child] == 0) queue.Enqueue(child);
                }
            }

            return sb.Length == graph.Count ? sb.ToString() : "";
        }
    }
}
