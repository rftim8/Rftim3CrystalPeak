namespace Rftim3LeetCode.Temp
{
    public class _02642_DesignGraphWithShortestPathCalculator
    {
        /// <summary>
        /// There is a directed weighted graph that consists of n nodes numbered from 0 to n - 1. 
        /// The edges of the graph are initially represented by the given array edges where edges[i] = [fromi, toi, edgeCosti] meaning that there is an edge 
        /// from fromi to toi with the cost edgeCosti.
        /// 
        /// Implement the Graph class:
        /// 
        /// Graph(int n, int[][] edges) initializes the object with n nodes and the given edges.
        /// addEdge(int[] edge) adds an edge to the list of edges where edge = [from, to, edgeCost].
        /// It is guaranteed that there is no edge between the two nodes before adding this one.
        /// int shortestPath(int node1, int node2) returns the minimum cost of a path from node1 to node2.If no path exists, return -1. 
        /// The cost of a path is the sum of the costs of the edges in the path.
        /// </summary>
        public _02642_DesignGraphWithShortestPathCalculator()
        {
            string[] x = ["Graph", "shortestPath", "shortestPath", "addEdge", "shortestPath"];
            object[] y =
            [
                new object[] { 4, new int[][] { [0, 2, 5], [0, 1, 2], [1, 2, 1], [3, 0, 3] } },
                new int[] { 3, 2 },
                new int[] { 0, 3 },
                new int[][] { [1, 3, 4] },
                new int[] { 0, 3 }
            ];
        }

        // Dijkstra
        private class Graph
        {
            private readonly List<List<(int, int)>> adjList;

            public Graph(int n, int[][] edges)
            {
                adjList = [];
                for (int i = 0; i < n; i++)
                {
                    adjList.Add([]);
                }

                foreach (int[] e in edges)
                {
                    adjList[e[0]].Add((e[1], e[2]));
                }
            }

            public void AddEdge(int[] edge)
            {
                adjList[edge[0]].Add((edge[1], edge[2]));
            }

            public int ShortestPath(int node1, int node2)
            {
                Comparer<List<int>> comparer = Comparer<List<int>>.Create((a, b) => a[0].CompareTo(b[0]));

                int n = adjList.Count;
                PriorityQueue<List<int>, List<int>> pq = new(comparer);
                int[] costForNode = new int[n];
                Array.Fill(costForNode, int.MaxValue);
                costForNode[node1] = 0;
                pq.Enqueue([0, node1], [0, node1]);

                while (pq.Count != 0)
                {
                    List<int> curr = pq.Dequeue();
                    int currCost = curr[0];
                    int currNode = curr[1];

                    if (currCost > costForNode[currNode]) continue;
                    if (currNode == node2) return currCost;

                    foreach ((int, int) neighbor in adjList[currNode])
                    {
                        int neighborNode = neighbor.Item1;
                        int cost = neighbor.Item2;
                        int newCost = currCost + cost;

                        if (newCost < costForNode[neighborNode])
                        {
                            costForNode[neighborNode] = newCost;
                            pq.Enqueue([newCost, neighborNode], [newCost, neighborNode]);
                        }
                    }
                }

                return -1;
            }
        }

        // Floyd-Warshall
        private class Graph0
        {
            private readonly int[][] adjMatrix;

            public Graph0(int n, int[][] edges)
            {
                adjMatrix = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    adjMatrix[i] = new int[n];
                    Array.Fill(adjMatrix[i], (int)1e9);
                }

                foreach (int[] e in edges)
                {
                    adjMatrix[e[0]][e[1]] = e[2];
                }

                for (int i = 0; i < n; i++)
                {
                    adjMatrix[i][i] = 0;
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            adjMatrix[j][k] = Math.Min(adjMatrix[j][k], adjMatrix[j][i] + adjMatrix[i][k]);
                        }
                    }
                }
            }

            public void AddEdge(int[] edge)
            {
                int n = adjMatrix.Length;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        adjMatrix[i][j] = Math.Min(adjMatrix[i][j], adjMatrix[i][edge[0]] + adjMatrix[edge[1]][j] + edge[2]);
                    }
                }
            }

            public int ShortestPath(int node1, int node2)
            {
                if (adjMatrix[node1][node2] == (int)1e9) return -1;

                return adjMatrix[node1][node2];
            }
        }
    }
}
