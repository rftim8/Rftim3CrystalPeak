namespace Rftim3LeetCode.Temp
{
    public class _01579_RemoveMaxNumberOfEdgesToKeepGraphFullyTraversable
    {
        /// <summary>
        /// Alice and Bob have an undirected graph of n nodes and three types of edges:
        /// Type 1: Can be traversed by Alice only.
        /// Type 2: Can be traversed by Bob only.
        /// Type 3: Can be traversed by both Alice and Bob.
        /// Given an array edges where edges[i] = [typei, ui, vi] represents a bidirectional edge of type typei between nodes ui and vi, 
        /// find the maximum number of edges you can remove so that after removing the edges, the graph can still be fully traversed by both Alice and Bob.
        /// The graph is fully traversed by Alice and Bob if starting from any node, they can reach all other nodes.
        /// Return the maximum number of edges you can remove, or return -1 if Alice and Bob cannot fully traverse the graph.
        /// </summary>
        public _01579_RemoveMaxNumberOfEdgesToKeepGraphFullyTraversable()
        {
            Console.WriteLine(MaxNumEdgesToRemove(4,
            [
                [3,1,2],
                [3,2,3],
                [1,1,3],
                [1,2,4],
                [1,1,2],
                [2,3,4]
            ]));
            Console.WriteLine(MaxNumEdgesToRemove(4,
            [
                [3,1,2],
                [3,2,3],
                [1,1,4],
                [2,1,4]
            ]));
            Console.WriteLine(MaxNumEdgesToRemove(4,
            [
                [3,2,3],
                [1,1,2],
                [2,3,4]
            ]));
        }

        private static int MaxNumEdgesToRemove(int n, int[][] edges)
        {
            UnionFind Alice = new(n);
            UnionFind Bob = new(n);

            int edgesRequired = 0;
            foreach (int[] edge in edges)
            {
                if (edge[0] == 3) edgesRequired += Alice.PerformUnion(edge[1], edge[2]) | Bob.PerformUnion(edge[1], edge[2]);
            }

            foreach (int[] edge in edges)
            {
                if (edge[0] == 1) edgesRequired += Alice.PerformUnion(edge[1], edge[2]);
                else if (edge[0] == 2) edgesRequired += Bob.PerformUnion(edge[1], edge[2]);
            }

            if (Alice.IsConnected() && Bob.IsConnected()) return edges.Length - edgesRequired;

            return -1;
        }

        private class UnionFind
        {
            private readonly int[] representative;
            private readonly int[] componentSize;
            int components;

            public UnionFind(int n)
            {
                components = n;
                representative = new int[n + 1];
                componentSize = new int[n + 1];

                for (int i = 0; i <= n; i++)
                {
                    representative[i] = i;
                    componentSize[i] = 1;
                }
            }

            private int FindRepresentative(int x)
            {
                if (representative[x] == x) return x;

                return representative[x] = FindRepresentative(representative[x]);
            }

            public int PerformUnion(int x, int y)
            {
                x = FindRepresentative(x); y = FindRepresentative(y);

                if (x == y) return 0;

                if (componentSize[x] > componentSize[y])
                {
                    componentSize[x] += componentSize[y];
                    representative[y] = x;
                }
                else
                {
                    componentSize[y] += componentSize[x];
                    representative[x] = y;
                }

                components--;
                return 1;
            }

            public bool IsConnected()
            {
                return components == 1;
            }
        }

        private static int MaxNumEdgesToRemove0(int n, int[][] edges)
        {
            int res = 0;
            UnionFind0 alice = new(n);
            UnionFind0 bob = new(n);
            foreach (int[] edge in edges)
            {
                if (edge[0] == 3 && (!alice.Union(edge[1], edge[2]) || !bob.Union(edge[1], edge[2]))) res++;
            }

            foreach (int[] edge in edges)
            {
                if (edge[0] == 1 && !alice.Union(edge[1], edge[2])) res++;
                if (edge[0] == 2 && !bob.Union(edge[1], edge[2])) res++;
            }

            return alice.Componets == 1 && bob.Componets == 1 ? res : -1;
        }

        private class UnionFind0
        {
            private readonly int[] parent;
            public int Componets { get; private set; }
            public UnionFind0(int n)
            {
                Componets = n;
                parent = new int[n + 1];
                for (int i = 0; i <= n; i++)
                {
                    parent[i] = i;
                }
            }

            public int Find(int x)
            {
                if (parent[x] != x) parent[x] = Find(parent[x]);

                return parent[x];
            }

            public bool Union(int x, int y)
            {
                int px = Find(x);
                int py = Find(y);
                if (px != py)
                {
                    parent[px] = py;
                    Componets--;
                    return true;
                }

                return false;
            }
        }
    }
}
