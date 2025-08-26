namespace Rftim3LeetCode.Temp
{
    public class _01319_NumberOfOperationsToMakeNetworkConnected
    {
        /// <summary>
        /// There are n computers numbered from 0 to n - 1 connected by ethernet cables connections forming a network 
        /// where connections[i] = [ai, bi] represents a connection between computers ai and bi. 
        /// Any computer can reach any other computer directly or indirectly through the network.
        /// You are given an initial computer network connections.You can extract certain cables between two directly connected computers, 
        /// and place them between any pair of disconnected computers to make them directly connected.
        /// Return the minimum number of times you need to do this in order to make all the computers connected.If it is not possible, return -1.
        /// </summary>
        public _01319_NumberOfOperationsToMakeNetworkConnected()
        {
            Console.WriteLine(MakeConnected(4, [
                [0,1],
                [0,2],
                [1,2]
            ]));
        }

        private static int MakeConnected(int n, int[][] connections)
        {
            if (connections.Length < n - 1) return -1;

            UnionFind x = new(n);
            int m = n;
            foreach (int[] item in connections)
            {
                if (x.Find(item[0]) != x.Find(item[1]))
                {
                    m--;
                    x.Union(item[0], item[1]);
                }
            }

            return m - 1;
        }

        private class UnionFind
        {
            private readonly int[] parent;

            public UnionFind(int size)
            {
                parent = new int[size];
                for (int i = 0; i < parent.Length; ++i)
                {
                    parent[i] = i;
                }
            }

            public void Union(int x, int y)
            {
                parent[Find(x)] = parent[Find(y)];
            }

            public int Find(int x)
            {
                if (parent[x] != x) parent[x] = Find(parent[x]);

                return parent[x];
            }
        }
    }
}
