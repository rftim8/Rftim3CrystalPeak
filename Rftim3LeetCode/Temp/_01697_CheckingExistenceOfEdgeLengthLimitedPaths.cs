using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01697_CheckingExistenceOfEdgeLengthLimitedPaths
    {
        /// <summary>
        /// An undirected graph of n nodes is defined by edgeList, where edgeList[i] = [ui, vi, disi] denotes an edge between nodes ui and vi with distance disi. 
        /// Note that there may be multiple edges between two nodes.
        /// Given an array queries, where queries[j] = [pj, qj, limitj], your task is to determine for each queries[j] whether there is a path
        /// between pj and qj such that each edge on the path has a distance strictly less than limitj.
        /// Return a boolean array answer, where answer.length == queries.length and the jth value of answer is true if there is a path 
        /// for queries[j] is true, and false otherwise.
        /// </summary>
        public _01697_CheckingExistenceOfEdgeLengthLimitedPaths()
        {
            bool[] x = DistanceLimitedPathsExist(
                3,
                [
                    [0,1,2],
                    [1,2,4],
                    [2,0,8],
                    [1,0,16]
                ],
                [
                    [0,1,2],
                    [0,2,5]
                ]
            );

            RftTerminal.RftReadResult(x);
        }

        private static bool[] DistanceLimitedPathsExist(int n, int[][] edgeList, int[][] queries)
        {
            UnionFind uf = new(n);
            int queriesCount = queries.Length;
            bool[] answer = new bool[queriesCount];

            int[][] queriesWithIndex = new int[queriesCount][];
            for (int i = 0; i < queriesCount; ++i)
            {
                queriesWithIndex[i] = [
                    queries[i][0],
                    queries[i][1],
                    queries[i][2],
                    i
                ];
            }

            Array.Sort(edgeList, (a, b) => a[2] - b[2]);
            Array.Sort(queriesWithIndex, (a, b) => a[2] - b[2]);

            int edgesIndex = 0;

            for (int queryIndex = 0; queryIndex < queriesCount; queryIndex++)
            {
                int p = queriesWithIndex[queryIndex][0];
                int q = queriesWithIndex[queryIndex][1];
                int limit = queriesWithIndex[queryIndex][2];
                int queryOriginalIndex = queriesWithIndex[queryIndex][3];

                while (edgesIndex < edgeList.Length && edgeList[edgesIndex][2] < limit)
                {
                    int node1 = edgeList[edgesIndex][0];
                    int node2 = edgeList[edgesIndex][1];
                    uf.Join(node1, node2);
                    edgesIndex++;
                }

                answer[queryOriginalIndex] = uf.AreConnected(p, q);
            }

            return answer;
        }

        private class UnionFind
        {
            private readonly int[] group;
            private readonly int[] rank;

            public UnionFind(int size)
            {
                group = new int[size];
                rank = new int[size];
                for (int i = 0; i < size; ++i)
                {
                    group[i] = i;
                }
            }

            public int Find(int node)
            {
                if (group[node] != node) group[node] = Find(group[node]);

                return group[node];
            }

            public void Join(int node1, int node2)
            {
                int group1 = Find(node1);
                int group2 = Find(node2);

                if (group1 == group2) return;

                if (rank[group1] > rank[group2]) group[group2] = group1;
                else if (rank[group1] < rank[group2]) group[group1] = group2;
                else
                {
                    group[group1] = group2;
                    rank[group2] += 1;
                }
            }

            public bool AreConnected(int node1, int node2)
            {
                int group1 = Find(node1);
                int group2 = Find(node2);
                return group1 == group2;
            }
        };

        private static bool[] DistanceLimitedPathsExist0(int n, int[][] edgeList, int[][] queries)
        {
            DisjointSet disjointSet = new(n);

            for (int i = 0; i < queries.Length; i++)
            {
                queries[i] = [queries[i][0], queries[i][1], queries[i][2], i];
            }

            Array.Sort(edgeList, (x, y) => { return x[2] - y[2]; });
            Array.Sort(queries, (x, y) => { return x[2] - y[2]; });

            bool[] res = new bool[queries.Length];

            int edgeIndex = 0;
            for (int i = 0; i < queries.Length; i++)
            {
                int dist = queries[i][2];
                int x = queries[i][0];
                int y = queries[i][1];
                int pos = queries[i][3];

                while (edgeIndex < edgeList.Length && edgeList[edgeIndex][2] < dist)
                {
                    int p = edgeList[edgeIndex][0];
                    int q = edgeList[edgeIndex][1];
                    disjointSet.Union(p, q);
                    edgeIndex++;
                }

                int parX = disjointSet.Find(x);
                int parY = disjointSet.Find(y);

                if (parX == parY) res[pos] = true;
            }

            return res;
        }

        private class DisjointSet
        {
            private readonly int[] rank;
            private readonly int[] parent;

            public DisjointSet(int n)
            {
                rank = new int[n];
                parent = new int[n];
                for (int i = 0; i < n; i++)
                {
                    parent[i] = i;
                    rank[i] = 0;
                }
            }

            public int Find(int x)
            {
                if (parent[x] == x) return x;
                parent[x] = Find(parent[x]);

                return parent[x];
            }

            public void Union(int x, int y)
            {
                int parX = Find(x);
                int parY = Find(y);

                if (parX != parY)
                {
                    if (rank[parX] > rank[parY]) parent[parY] = parX;
                    else if (rank[parX] < rank[parY]) parent[parX] = parY;
                    else
                    {
                        parent[parX] = parY;
                        rank[parY]++;
                    }
                }
            }
        }
    }
}
