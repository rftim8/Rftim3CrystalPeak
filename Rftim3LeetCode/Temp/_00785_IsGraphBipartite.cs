namespace Rftim3LeetCode.Temp
{
    public class _00785_IsGraphBipartite
    {
        /// <summary>
        /// There is an undirected graph with n nodes, where each node is numbered between 0 and n - 1. 
        /// You are given a 2D array graph, where graph[u] is an array of nodes that node u is adjacent to. 
        /// More formally, for each v in graph[u], there is an undirected edge between node u and node v. 
        /// The graph has the following properties:
        /// There are no self-edges(graph[u] does not contain u).
        /// There are no parallel edges(graph[u] does not contain duplicate values).
        /// If v is in graph[u], then u is in graph[v] (the graph is undirected).
        /// The graph may not be connected, meaning there may be two nodes u and v such that there is no path between them.
        /// A graph is bipartite if the nodes can be partitioned into two independent sets A and B such that every edge in the graph connects a node in set A and a node in set B.
        /// Return true if and only if it is bipartite.
        /// </summary>
        public _00785_IsGraphBipartite()
        {
            Console.WriteLine(IsBipartite(
            [
                [1,2,3],
                [0,2],
                [0,1,3],
                [0,2]
            ]));

            Console.WriteLine(IsBipartite(
            [
                [1,3],
                [0,2],
                [1,3],
                [0,2]
            ]));
        }

        private static bool IsBipartite(int[][] graph)
        {
            int n = graph.Length;
            bool?[] info = new bool?[n];
            for (int i = 0; i < n; i++)
            {
                if (info[i] is null)
                {
                    info[i] = true;
                    bool result = Visit(graph, info, i);
                    if (result) return false;
                }
            }

            return true;
        }

        private static bool Visit(int[][] graph, bool?[] info, int i)
        {
            foreach (int item in graph[i])
            {
                if (info[item] is null)
                {
                    info[item] = !info[i];
                    bool result = Visit(graph, info, item);
                    if (result) return true;
                }
                else if (info[item] == info[i]) return true;
            }

            return false;
        }

        private static bool IsBipartite0(int[][] graph)
        {

            int n = graph.Length;
            int[] color = new int[n];
            Array.Fill(color, -1);

            for (int start = 0; start < n; ++start)
            {
                if (color[start] == -1)
                {
                    Stack<int> stack = new();
                    stack.Push(start);
                    color[start] = 0;

                    while (stack.Count > 0)
                    {
                        int node = stack.Pop();
                        foreach (int item in graph[node])
                        {
                            if (color[item] == -1)
                            {
                                stack.Push(item);
                                color[item] = color[node] ^ 1;
                            }
                            else if (color[item] == color[node]) return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
