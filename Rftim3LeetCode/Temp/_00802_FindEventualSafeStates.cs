using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00802_FindEventualSafeStates
    {
        /// <summary>
        /// There is a directed graph of n nodes with each node labeled from 0 to n - 1. 
        /// The graph is represented by a 0-indexed 2D integer array graph where graph[i] is an integer array of nodes adjacent to node i,
        /// meaning there is an edge from node i to each node in graph[i].
        /// A node is a terminal node if there are no outgoing edges.A node is a safe node if every possible path starting
        /// from that node leads to a terminal node(or another safe node).
        /// Return an array containing all the safe nodes of the graph.The answer should be sorted in ascending order.
        /// </summary>
        public _00802_FindEventualSafeStates()
        {
            IList<int> x = EventualSafeNodes([
                [1,2],
                [2,3],
                [5],
                [0],
                [5],
                [],
                []
            ]);

            RftTerminal.RftReadResult(x);
        }

        private static List<int> EventualSafeNodes(int[][] graph)
        {
            int n = graph.Length;
            bool[] safe = new bool[n];

            List<HashSet<int>> l = [];
            List<HashSet<int>> r = [];
            for (int i = 0; i < n; ++i)
            {
                l.Add([]);
                r.Add([]);
            }

            Queue<int> q = new();

            for (int i = 0; i < n; ++i)
            {
                if (graph[i].Length == 0) q.Enqueue(i);

                foreach (int j in graph[i])
                {
                    l[i].Add(j);
                    r[j].Add(i);
                }
            }

            while (q.Count != 0)
            {
                int j = q.Dequeue();
                safe[j] = true;
                foreach (int i in r[j])
                {
                    l[i].Remove(j);

                    if (l[i].Count == 0) q.Enqueue(i);
                }
            }

            List<int> x = [];
            for (int i = 0; i < n; ++i)
            {
                if (safe[i]) x.Add(i);
            }

            return x;
        }

        private static List<int> EventualSafeNodes0(int[][] graph)
        {
            int n = graph.Length;
            int[] color = new int[n];
            List<int> ans = [];

            for (int i = 0; i < n; ++i)
            {
                if (Dfs(i, color, graph)) ans.Add(i);
            }

            return ans;
        }

        private static bool Dfs(int node, int[] color, int[][] graph)
        {
            if (color[node] > 0) return color[node] == 2;

            color[node] = 1;
            foreach (int item in graph[node])
            {
                if (color[item] == 2) continue;
                if (color[item] == 1 || !Dfs(item, color, graph)) return false;
            }

            color[node] = 2;

            return true;
        }
    }
}
