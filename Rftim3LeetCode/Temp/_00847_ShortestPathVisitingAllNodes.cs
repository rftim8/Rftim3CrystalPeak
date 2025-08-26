namespace Rftim3LeetCode.Temp
{
    public class _00847_ShortestPathVisitingAllNodes
    {
        /// <summary>
        /// You have an undirected, connected graph of n nodes labeled from 0 to n - 1.
        /// You are given an array graph where graph[i] is a list of all the nodes connected with node i by an edge.
        /// Return the length of the shortest path that visits every node.You may start and stop at any node, you may revisit nodes multiple times, and you may reuse edges.
        /// </summary>
        public _00847_ShortestPathVisitingAllNodes()
        {
            Console.WriteLine(ShortestPathLength([
                [1,2,3],
                [0],
                [0],
                [0]
            ]));

            Console.WriteLine(ShortestPathLength([
                [1],
                [0,2,4],
                [1,3,4],
                [2],
                [1,2]
            ]));
        }

        private static int ShortestPathLength(int[][] graph)
        {
            int n = graph.Length;
            int[,] x = new int[n, 1 << n];
            Queue<(int, int)> q = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 1 << n; j++)
                {
                    x[i, j] = int.MaxValue;
                }
            }

            for (int i = 0; i < n; i++)
            {
                x[i, 1 << i] = 0;
                q.Enqueue((i, 1 << i));
            }

            while (q.Count != 0)
            {
                (int, int) crt = q.Dequeue();
                foreach (int item in graph[crt.Item1])
                {
                    int mask = 1 << item | crt.Item2;
                    if (x[item, mask] > x[crt.Item1, crt.Item2] + 1)
                    {
                        x[item, mask] = x[crt.Item1, crt.Item2] + 1;
                        q.Enqueue((item, mask));
                    }
                }
            }

            int result = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                result = Math.Min(result, x[i, (1 << n) - 1]);
            }

            return result;
        }

        private static int ShortestPathLength0(int[][] graph)
        {
            int n = graph.Length;
            if (n == 1) return 0;

            int endingMask = (1 << n) - 1;
            bool[][] seen = new bool[n][];
            Queue<(int node, int mask)> queue = new();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue((i, 1 << i));

                seen[i] = new bool[endingMask];
                seen[i][1 << i] = true;
            }

            int steps = 0;

            while (queue.Count != 0)
            {
                int nextCnt = queue.Count;
                for (int i = 0; i < nextCnt; i++)
                {
                    (int node, int mask) = queue.Dequeue();
                    foreach (int neighbor in graph[node])
                    {
                        int nextMask = mask | 1 << neighbor;

                        if (nextMask == endingMask) return 1 + steps;

                        if (!seen[neighbor][nextMask])
                        {
                            seen[neighbor][nextMask] = true;
                            queue.Enqueue((neighbor, nextMask));
                        }
                    }
                }
                steps++;
            }

            return -1;
        }
    }
}
