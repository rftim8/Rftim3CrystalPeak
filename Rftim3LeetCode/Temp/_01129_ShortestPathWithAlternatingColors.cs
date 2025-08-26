using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01129_ShortestPathWithAlternatingColors
    {
        /// <summary>
        /// You are given an integer n, the number of nodes in a directed graph where the nodes are labeled from 0 to n - 1. 
        /// Each edge is red or blue in this graph, and there could be self-edges and parallel edges.
        /// You are given two arrays redEdges and blueEdges where:
        /// redEdges[i] = [ai, bi] indicates that there is a directed red edge from node ai to node bi in the graph, and
        /// blueEdges[j] = [uj, vj] indicates that there is a directed blue edge from node uj to node vj in the graph.
        /// Return an array answer of length n, where each answer[x] is the length of the shortest path from node 0 to node x 
        /// such that the edge colors alternate along the path, or -1 if such a path does not exist.
        /// </summary>
        public _01129_ShortestPathWithAlternatingColors()
        {
            int[] x = ShortestAlternatingPaths(
                3,
                [
                    [0,1],
                    [0,2]
                ],
                [
                    [1,0]
                ]
            );

            RftTerminal.RftReadResult(x);
        }

        private static int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
        {
            Dictionary<int, List<List<int>>> adj = [];

            foreach (int[] redEdge in redEdges)
            {
                if (!adj.TryGetValue(redEdge[0], out List<List<int>>? value)) adj.Add(redEdge[0], [[redEdge[1], 0]]);
                else
                    value.Add([redEdge[1], 0]);
            }

            foreach (int[] blueEdge in blueEdges)
            {
                if (!adj.TryGetValue(blueEdge[0], out List<List<int>>? value)) adj.Add(blueEdge[0], [[blueEdge[1], 1]]);
                else
                    value.Add([blueEdge[1], 1]);
            }

            int[] answer = new int[n];
            Array.Fill(answer, -1);
            bool[,] visit = new bool[n, 2];
            Queue<int[]> q = new();

            q.Enqueue([0, 0, -1]);
            answer[0] = 0;
            visit[0, 1] = visit[0, 0] = true;

            while (q.Count != 0)
            {
                int[] element = q.Dequeue();
                int node = element[0], steps = element[1], prevColor = element[2];

                if (!adj.ContainsKey(node)) continue;

                foreach (List<int> nei in adj[node])
                {
                    int neighbor = nei[0];
                    int color = nei[1];
                    if (!visit[neighbor, color] && color != prevColor)
                    {
                        if (answer[neighbor] == -1) answer[neighbor] = 1 + steps;
                        visit[neighbor, color] = true;
                        q.Enqueue([neighbor, 1 + steps, color]);
                    }
                }
            }

            return answer;
        }
    }
}
