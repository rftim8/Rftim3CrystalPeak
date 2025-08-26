namespace Rftim3LeetCode.Temp
{
    public class _01514_PathWithMaximumProbability
    {
        /// <summary>
        /// You are given an undirected weighted graph of n nodes (0-indexed), represented by an edge list where edges[i] = [a, b] 
        /// is an undirected edge connecting the nodes a and b with a probability of success of traversing that edge succProb[i].
        /// Given two nodes start and end, find the path with the maximum probability of success to go from start to end and return its success probability.
        /// If there is no path from start to end, return 0. Your answer will be accepted if it differs from the correct answer by at most 1e-5.
        /// </summary>
        public _01514_PathWithMaximumProbability()
        {
            Console.WriteLine(MaxProbability(
                3,
                [
                    [0,1],
                    [1,2],
                    [0,2]
                ],
                [0.5, 0.5, 0.2],
                0,
                2
            ));
            Console.WriteLine(MaxProbability(
                3,
                [
                    [0,1],
                    [1,2],
                    [0,2]
                ],
                [0.5, 0.5, 0.3],
                0,
                2
            ));
            Console.WriteLine(MaxProbability(
                3,
                [
                    [0,1]
                ],
                [0.5],
                0,
                2
            ));
        }

        // Bellman-Ford Algorithm
        private static double MaxProbability1(int n, int[][] edges, double[] succProb, int start, int end)
        {
            double[] maxProb = new double[n];
            maxProb[start] = 1.0;

            for (int i = 0; i < n - 1; i++)
            {
                bool hasUpdate = false;
                for (int j = 0; j < edges.Length; j++)
                {
                    int u = edges[j][0];
                    int v = edges[j][1];
                    double pathProb = succProb[j];
                    if (maxProb[u] * pathProb > maxProb[v])
                    {
                        maxProb[v] = maxProb[u] * pathProb;
                        hasUpdate = true;
                    }
                    if (maxProb[v] * pathProb > maxProb[u])
                    {
                        maxProb[u] = maxProb[v] * pathProb;
                        hasUpdate = true;
                    }
                }
                if (!hasUpdate) break;
            }

            return maxProb[end];
        }

        // Shortest Path Faster Algorithm SPFA
        private static double MaxProbability0(int n, int[][] edges, double[] succProb, int start, int end)
        {
            Dictionary<int, List<(int, double)>> graph = [];
            for (int i = 0; i < edges.Length; i++)
            {
                int u = edges[i][0], v = edges[i][1];
                double pathProb = succProb[i];

                if (graph.TryGetValue(u, out List<(int, double)>? value)) value.Add((v, pathProb));
                else graph.Add(u, [(v, pathProb)]);

                if (graph.TryGetValue(v, out List<(int, double)>? value0)) value0.Add((u, pathProb));
                else graph.Add(v, [(u, pathProb)]);
            }

            double[] maxProb = new double[n];
            maxProb[start] = 1d;

            Queue<int> queue = new();
            queue.Enqueue(start);
            while (queue.Count != 0)
            {
                int curNode = queue.Dequeue();

                if (graph.TryGetValue(curNode, out List<(int, double)>? value))
                {
                    foreach ((int, double) neighbor in value)
                    {
                        int nxtNode = neighbor.Item1;
                        double pathProb = neighbor.Item2;

                        if (maxProb[curNode] * pathProb > maxProb[nxtNode])
                        {
                            maxProb[nxtNode] = maxProb[curNode] * pathProb;
                            queue.Enqueue(nxtNode);
                        }
                    }
                }
            }

            return maxProb[end];
        }

        // Dijkstra's Algorithm
        private static double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {
            Dictionary<int, List<(int, double)>> graph = [];
            for (int i = 0; i < edges.Length; i++)
            {
                int u = edges[i][0], v = edges[i][1];
                double pathProb = succProb[i];

                if (graph.TryGetValue(u, out List<(int, double)>? value)) value.Add((v, pathProb));
                else graph.Add(u, [(v, pathProb)]);

                if (graph.TryGetValue(v, out List<(int, double)>? value0)) value0.Add((u, pathProb));
                else graph.Add(v, [(u, pathProb)]);
            }

            double[] maxProb = new double[n];
            maxProb[start] = 1d;

            PriorityQueue<(double, int), (double, int)> pq = new(Comparer<(double, int)>.Create((a, b) => -a.Item1.CompareTo(b.Item1)));
            pq.Enqueue((1.0, start), (1.0, start));
            while (pq.Count != 0)
            {
                (double, int) cur = pq.Dequeue();
                double curProb = cur.Item1;
                int curNode = cur.Item2;

                if (curNode == end) return curProb;

                if (graph.TryGetValue(curNode, out List<(int, double)>? value))
                {
                    foreach ((int, double) nxt in value)
                    {
                        int nxtNode = nxt.Item1;
                        double pathProb = nxt.Item2;
                        if (curProb * pathProb > maxProb[nxtNode])
                        {
                            maxProb[nxtNode] = curProb * pathProb;
                            pq.Enqueue((maxProb[nxtNode], nxtNode), (maxProb[nxtNode], nxtNode));
                        }
                    }
                }
            }

            return 0d;
        }

        private static double MaxProbability2(int n, int[][] edges, double[] succProb, int start, int end)
        {
            double[] dist = new double[n];
            Array.Fill(dist, 0);
            dist[start] = 1;

            for (int k = 0; k < n; k++)
            {
                bool keepGoing = false;
                for (int i = 0; i < edges.Length; i++)
                {
                    int[] edge = edges[i];
                    int v = edge[0];
                    int w = edge[1];
                    double vw = succProb[i];

                    if (dist[v] * vw > dist[w])
                    {
                        dist[w] = dist[v] * vw;
                        keepGoing = true;
                    }

                    if (dist[w] * vw > dist[v])
                    {
                        dist[v] = dist[w] * vw;
                        keepGoing = true;
                    }
                }
                if (keepGoing == false) break;
            }

            return dist[end];
        }
    }
}
