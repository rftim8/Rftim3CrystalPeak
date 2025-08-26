namespace Rftim3LeetCode.Temp
{
    public class _00839_SimilarStringGroups
    {
        /// <summary>
        /// Two strings X and Y are similar if we can swap two letters (in different positions) of X, so that it equals Y. 
        /// Also two strings X and Y are similar if they are equal.
        /// For example, "tars" and "rats" are similar(swapping at positions 0 and 2), and "rats" and "arts" are similar, 
        /// but "star" is not similar to "tars", "rats", or "arts".
        /// Together, these form two connected groups by similarity: {"tars", "rats", "arts"} and {"star"}.  
        /// Notice that "tars" and "arts" are in the same group even though they are not similar.Formally, each group is such that a word is in the group 
        /// if and only if it is similar to at least one other word in the group.
        /// We are given a list strs of strings where every string in strs is an anagram of every other string in strs.How many groups are there?
        /// </summary>
        public _00839_SimilarStringGroups()
        {
            Console.WriteLine(NumSimilarGroups(["tars", "rats", "arts", "star"]));
            Console.WriteLine(NumSimilarGroups(["omv", "ovm"]));
        }

        private static void Dfs(int node, Dictionary<int, List<int>> adj, bool[] visit)
        {
            visit[node] = true;

            if (!adj.TryGetValue(node, out List<int>? value)) return;

            foreach (int neighbor in value)
            {
                if (!visit[neighbor])
                {
                    visit[neighbor] = true;
                    Dfs(neighbor, adj, visit);
                }
            }
        }

        private static bool IsSimilar(string a, string b)
        {
            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) diff++;
            }

            return diff == 0 || diff == 2;
        }

        private static int NumSimilarGroups(string[] strs)
        {
            int n = strs.Length;
            Dictionary<int, List<int>> adj = [];
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (IsSimilar(strs[i], strs[j]))
                    {
                        if (!adj.TryGetValue(i, out List<int>? value)) adj.Add(i, [j]);
                        else
                            value.Add(j);

                        if (!adj.TryGetValue(j, out List<int>? value0)) adj.Add(j, [i]);
                        else
                            value0.Add(i);
                    }
                }
            }

            bool[] visit = new bool[n];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (!visit[i])
                {
                    Dfs(i, adj, visit);
                    count++;
                }
            }

            return count;
        }

        private static void Bfs0(int node, Dictionary<int, List<int>> adj, bool[] visit)
        {
            Queue<int> q = new();
            q.Enqueue(node);
            visit[node] = true;
            while (q.Count != 0)
            {
                node = q.Dequeue();
                if (!adj.ContainsKey(node))
                {
                    continue;
                }
                foreach (int neighbor in adj[node])
                {
                    if (!visit[neighbor])
                    {
                        visit[neighbor] = true;
                        q.Enqueue(neighbor);
                    }
                }
            }
        }

        private static bool IsSimilar0(string a, string b)
        {
            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    diff++;
                }
            }

            return diff == 0 || diff == 2;
        }

        private static int NumSimilarGroups0(string[] strs)
        {
            int n = strs.Length;
            Dictionary<int, List<int>> adj = [];
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (IsSimilar0(strs[i], strs[j]))
                    {
                        if (!adj.TryGetValue(i, out List<int>? value)) adj.Add(i, [j]);
                        else
                            value.Add(j);

                        if (!adj.TryGetValue(j, out List<int>? value0)) adj.Add(j, [i]);
                        else
                            value0.Add(i);
                    }
                }
            }

            bool[] visit = new bool[n];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (!visit[i])
                {
                    Bfs0(i, adj, visit);
                    count++;
                }
            }

            return count;
        }

        private static int NumSimilarGroups1(string[] strs)
        {
            int n = strs.Length;
            int m = strs[0].Length;

            UnionFind uf = new(n);

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (uf.Connected(i, j)) continue;
                    int diffsCount = 0;

                    for (int k = 0; k < m; k++)
                    {
                        if (strs[i][k] == strs[j][k]) continue;
                        diffsCount++;
                        if (diffsCount > 2) break;
                    }

                    if (diffsCount > 2) continue;
                    uf.Union(i, j);
                }
            }

            return uf.ComponentsCount;
        }

        private class UnionFind(int size)
        {
            private readonly int[] _roots = Enumerable.Range(0, size).ToArray();
            private readonly int[] _ranks = Enumerable.Repeat(1, size).ToArray();

            public int ComponentsCount { get; private set; } = size;

            private int Find(int x) => x == _roots[x] ? x : _roots[x] = Find(_roots[x]);

            public void Union(int x, int y)
            {
                int rootX = Find(x);
                int rootY = Find(y);

                if (rootX == rootY) return;

                int rankX = _ranks[rootX];
                int rankY = _roots[rootY];

                if (rankX < rankY) _roots[rootX] = rootY;
                else if (rankX > rankY) _roots[rootY] = rootX;
                else
                {
                    _roots[rootX] = rootY;
                    _ranks[rootY]++;
                }

                ComponentsCount--;
            }

            public bool Connected(int x, int y) => Find(x) == Find(y);
        }
    }
}
