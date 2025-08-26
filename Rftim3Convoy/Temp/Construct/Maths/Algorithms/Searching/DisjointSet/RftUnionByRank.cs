namespace Rftim3Convoy.Temp.Construct.Maths.Algorithms.Searching.DisjointSet
{
    public class RftUnionByRank
    {
        public RftUnionByRank()
        {
            UnionFind uf = new(10);
            // 1-2-5-6-7 3-8-9 4
            uf.Union(1, 2);
            uf.Union(2, 5);
            uf.Union(5, 6);
            uf.Union(6, 7);
            uf.Union(3, 8);
            uf.Union(8, 9);
            Console.WriteLine(uf.Connected(1, 5)); // true
            Console.WriteLine(uf.Connected(5, 7)); // true
            Console.WriteLine(uf.Connected(4, 9)); // false
                                                   // 1-2-5-6-7 3-8-9-4
            uf.Union(9, 4);
            Console.WriteLine(uf.Connected(4, 9)); // true
        }

        private class UnionFind
        {
            private readonly int[] root;
            private readonly int[] rank;

            public UnionFind(int size)
            {
                root = new int[size];
                rank = new int[size];

                for (int i = 0; i < size; i++)
                {
                    root[i] = i;
                    rank[i] = 1;
                }
            }

            public int Find(int x)
            {
                while (x != root[x])
                {
                    x = root[x];
                }

                return x;
            }

            public void Union(int x, int y)
            {
                int rootX = Find(x);
                int rootY = Find(y);

                if (rootX != rootY)
                {
                    if (rank[rootX] > rank[rootY]) root[rootY] = rootX;
                    else if (rank[rootX] < rank[rootY]) root[rootX] = rootY;
                    else
                    {
                        root[rootY] = rootX;
                        rank[rootX] += 1;
                    }
                }
            }

            public bool Connected(int x, int y)
            {
                return Find(x) == Find(y);
            }
        }
    }
}
