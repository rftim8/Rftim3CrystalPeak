using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01489_FindCriticalAndPseudoCriticalEdgesInMinimumSpanningTree
    {
        /// <summary>
        /// Given a weighted undirected connected graph with n vertices numbered from 0 to n - 1, 
        /// and an array edges where edges[i] = [ai, bi, weighti] represents a bidirectional and weighted edge between nodes ai and bi. 
        /// A minimum spanning tree (MST) is a subset of the graph's edges that connects all vertices without cycles and with the minimum possible total edge weight.
        /// Find all the critical and pseudo-critical edges in the given graph's minimum spanning tree (MST). 
        /// An MST edge whose deletion from the graph would cause the MST weight to increase is called a critical edge. 
        /// On the other hand, a pseudo-critical edge is that which can appear in some MSTs but not all.
        /// Note that you can return the indices of the edges in any order.
        /// </summary>
        public _01489_FindCriticalAndPseudoCriticalEdgesInMinimumSpanningTree()
        {
            IList<IList<int>> x = FindCriticalAndPseudoCriticalEdgesInMinimumSpanningTree0(5,
            [
                [0, 1, 1],
                [1, 2, 1],
                [2, 3, 2],
                [0, 3, 2],
                [0, 4, 3],
                [3, 4, 3],
                [1, 4, 6]
            ]);
            RftTerminal.RftReadResult(x);

            IList<IList<int>> x0 = FindCriticalAndPseudoCriticalEdgesInMinimumSpanningTree0(4,
            [
                [0, 1, 1],
                [1, 2, 1],
                [2, 3, 1],
                [0, 3, 1]
            ]);
            RftTerminal.RftReadResult(x0);
        }

        public static IList<IList<int>> FindCriticalAndPseudoCriticalEdgesInMinimumSpanningTree0(int a0, int[][] a1) => RftFindCriticalAndPseudoCriticalEdgesInMinimumSpanningTree0(a0, a1);

        private static List<IList<int>> RftFindCriticalAndPseudoCriticalEdgesInMinimumSpanningTree0(int n, int[][] edges)
        {
            int m = edges.Length;
            int[][] newEdges = new int[m][];

            for (int i = 0; i < m; i++)
            {
                newEdges[i] = new int[4];
                for (int j = 0; j < 3; j++)
                {
                    newEdges[i][j] = edges[i][j];
                }
                newEdges[i][3] = i;
            }

            Array.Sort(newEdges, (a, b) => a[2].CompareTo(b[2]));

            UnionFind ufStd = new(n);
            int stdWeight = 0;
            foreach (int[] edge in newEdges)
            {
                if (ufStd.Union(edge[0], edge[1])) stdWeight += edge[2];
            }

            List<IList<int>> result = [];
            for (int i = 0; i < 2; i++)
            {
                result.Add([]);
            }

            for (int i = 0; i < m; i++)
            {
                UnionFind ufIgnore = new(n);
                int ignoreWeight = 0;
                for (int j = 0; j < m; j++)
                {
                    if (i != j && ufIgnore.Union(newEdges[j][0], newEdges[j][1])) ignoreWeight += newEdges[j][2];
                }
                if (ufIgnore.maxSize < n || ignoreWeight > stdWeight) result[0].Add(newEdges[i][3]);
                else
                {
                    UnionFind ufForce = new(n);
                    ufForce.Union(newEdges[i][0], newEdges[i][1]);
                    int forceWeight = newEdges[i][2];
                    for (int j = 0; j < m; j++)
                    {
                        if (i != j && ufForce.Union(newEdges[j][0], newEdges[j][1])) forceWeight += newEdges[j][2];
                    }
                    if (forceWeight == stdWeight) result[1].Add(newEdges[i][3]);
                }
            }

            return result;
        }

        private class UnionFind
        {
            private readonly int[] parent;
            private readonly int[] size;
            public int maxSize;

            public UnionFind(int n)
            {
                parent = new int[n];
                size = new int[n];
                maxSize = 1;
                for (int i = 0; i < n; i++)
                {
                    parent[i] = i;
                    size[i] = 1;
                }
            }

            public int Find(int x)
            {
                if (x != parent[x]) parent[x] = Find(parent[x]);

                return parent[x];
            }

            public bool Union(int x, int y)
            {
                int rootX = Find(x);
                int rootY = Find(y);
                if (rootX != rootY)
                {
                    if (size[rootX] < size[rootY]) (rootY, rootX) = (rootX, rootY);

                    parent[rootY] = rootX;
                    size[rootX] += size[rootY];
                    maxSize = Math.Max(maxSize, size[rootX]);

                    return true;
                }

                return false;
            }
        }
    }
}