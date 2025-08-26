namespace Rftim3LeetCode.Temp
{
    public class _01466_ReorderRoutesToMakeAllPathsLeadToTheCityZero
    {
        /// <summary>
        /// There are n cities numbered from 0 to n - 1 and n - 1 roads such that there is only one way to travel between two different cities (this network form a tree). 
        /// Last year, The ministry of transport decided to orient the roads in one direction because they are too narrow.
        /// Roads are represented by connections where connections[i] = [ai, bi] represents a road from city ai to city bi.
        /// This year, there will be a big event in the capital (city 0), and many people want to travel to this city.
        /// Your task consists of reorienting some roads such that each city can visit the city 0. Return the minimum number of edges changed.
        /// It's guaranteed that each city can reach city 0 after reorder.
        /// </summary>
        public _01466_ReorderRoutesToMakeAllPathsLeadToTheCityZero()
        {
            Console.WriteLine(MinReorder(6, [
                [0,1],
                [1,3],
                [2,3],
                [4,0],
                [4,5]
            ]));
            count = 0;

            Console.WriteLine(MinReorder(5, [
                [1,0],
                [1,2],
                [3,2],
                [3,4]
            ]));
            count = 0;

            Console.WriteLine(MinReorder(3, [
                [1,0],
                [2,0]
            ]));
        }

        private static int count = 0;

        #region DFS
        private static int MinReorder(int n, int[][] connections)
        {
            Dictionary<int, List<List<int>>> adj = [];

            foreach (int[] connection in connections)
            {
                if (!adj.TryGetValue(connection[0], out List<List<int>>? value)) adj.Add(connection[0], [[connection[1], 1]]);
                else
                    value.Add([connection[1], 1]);

                if (!adj.TryGetValue(connection[1], out List<List<int>>? value0)) adj.Add(connection[1], [[connection[0], 0]]);
                else
                    value0.Add([connection[0], 0]);
            }
            Dfs(0, -1, adj);

            return count;
        }

        private static void Dfs(int node, int parent, Dictionary<int, List<List<int>>> adj)
        {
            if (!adj.TryGetValue(node, out List<List<int>>? value)) return;

            foreach (List<int> item in value)
            {
                int child = item[0];
                int sign = item[1];

                if (child != parent)
                {
                    count += sign;
                    Dfs(child, node, adj);
                }
            }
        }
        #endregion

        #region BFS
        private static int MinReorder0(int n, int[][] connections)
        {
            Dictionary<int, List<List<int>>> adj = [];

            foreach (int[] connection in connections)
            {
                if (!adj.TryGetValue(connection[0], out List<List<int>>? value)) adj.Add(connection[0], [[connection[1], 1]]);
                else
                    value.Add([connection[1], 1]);

                if (!adj.TryGetValue(connection[1], out List<List<int>>? value0)) adj.Add(connection[1], [[connection[0], 0]]);
                else
                    value0.Add([connection[0], 0]);

            }
            Bfs(0, n, adj);

            return count;
        }

        private static void Bfs(int node, int n, Dictionary<int, List<List<int>>> adj)
        {
            Queue<int> q = new();
            bool[] visit = new bool[n];
            q.Enqueue(node);
            visit[node] = true;

            while (q.Count != 0)
            {
                node = q.Dequeue();

                if (!adj.ContainsKey(node)) continue;

                foreach (List<int> item in adj[node])
                {
                    int neighbor = item[0];
                    int sign = item[1];
                    if (!visit[neighbor])
                    {
                        count += sign;
                        visit[neighbor] = true;
                        q.Enqueue(neighbor);
                    }
                }
            }
        }
        #endregion

        #region DFS2
        private static int MinReorder1(int n, int[][] connections)
        {
            var al = new List<List<int>>();
            for (int i = 0; i < n; ++i)
            {
                al.Add([]);
            }

            foreach (int[] c in connections)
            {
                al[c[0]].Add(c[1]);
                al[c[1]].Add(-c[0]);
            }

            return Dfs(al, new bool[n], 0);
        }

        private static int Dfs(List<List<int>> al, bool[] visited, int from)
        {
            int change = 0;
            visited[from] = true;

            foreach (int to in al[from])
            {
                if (!visited[Math.Abs(to)]) change += Dfs(al, visited, Math.Abs(to)) + (to > 0 ? 1 : 0);
            }

            return change;
        }
        #endregion
    }
}
