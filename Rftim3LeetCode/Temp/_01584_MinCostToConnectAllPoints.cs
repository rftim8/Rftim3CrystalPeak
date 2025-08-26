namespace Rftim3LeetCode.Temp
{
    public class _01584_MinCostToConnectAllPoints
    {
        /// <summary>
        /// You are given an array points representing integer coordinates of some points on a 2D-plane, where points[i] = [xi, yi].
        /// The cost of connecting two points[xi, yi] and[xj, yj] is the manhattan distance between them: |xi - xj| + |yi - yj|, where |val| denotes the absolute value of val.
        /// Return the minimum cost to make all points connected. All points are connected if there is exactly one simple path between any two points.
        /// </summary>
        public _01584_MinCostToConnectAllPoints()
        {
            Console.WriteLine(MinCostConnectPoints(
            [
                [0, 0],
                [2, 2],
                [3, 10],
                [5, 2],
                [7, 0]
            ]));

            Console.WriteLine(MinCostConnectPoints(
            [
                [3, 12],
                [-2, 5],
                [-4, 1]
            ]));

            Console.WriteLine(MinCostConnectPoints(
            [
                [0, 0]
            ]));

            Console.WriteLine(MinCostConnectPoints(
            [
                [2, -3],
                [-17, -8],
                [13 ,8],
                [-17, -15]
            ]));
        }

        // Prim
        private static int MinCostConnectPoints(int[][] points)
        {
            PriorityQueue<int, int> minHeap = new();
            minHeap.Enqueue(0, 0);
            HashSet<int> visited = [];

            int cost = 0;
            while (visited.Count < points.Length)
            {
                minHeap.TryDequeue(out int curr, out int distance);

                if (visited.Contains(curr)) continue;

                visited.Add(curr);
                cost += distance;

                for (int i = 0; i < points.Length; i++)
                {
                    if (!visited.Contains(i))
                    {
                        minHeap.Enqueue(i, Math.Abs(points[i][0] - points[curr][0]) + Math.Abs(points[i][1] - points[curr][1]));
                    }
                }
            }

            return cost;
        }

        private static int MinCostConnectPoints0(int[][] points)
        {
            int n = points.Length;

            int[] dist = new int[n];
            Array.Fill(dist, int.MaxValue - 1);

            int minCost = 0;
            for (int connected = 1, cur = 0; connected < n; connected++)
            {
                dist[cur] = int.MaxValue;
                int[] x = points[cur];
                int min = cur;
                for (int v = 0; v < n; v++)
                    if (dist[v] != int.MaxValue)
                    {
                        int[] y = points[v];
                        dist[v] = Math.Min(dist[v], Math.Abs(x[0] - y[0]) + Math.Abs(x[1] - y[1]));

                        if (dist[min] > dist[v]) min = v;
                    }

                minCost += dist[min];
                cur = min;
            }

            return minCost;
        }

        // Prim
        private static int MinCostConnectPoints1(int[][] points)
        {
            int n = points.Length;
            int result = 0;
            HashSet<int> visited = [];
            int[][] graph = new int[n][];

            PriorityQueue<(int, int), int> pq = new();
            pq.Enqueue((0, 0), 0);

            for (int i = 0; i < n; ++i)
            {
                graph[i] = new int[n];
                for (int j = 0; j < n; ++j)
                {
                    if (i != j)
                    {
                        int distance = Math.Abs(points[i][0] - points[j][0]) +
                                       Math.Abs(points[i][1] - points[j][1]);
                        graph[i][j] = distance;
                    }
                }
            }

            while (visited.Count < n)
            {
                (int x, int y) = pq.Dequeue();
                if (!visited.Contains(y))
                {
                    visited.Add(y);
                    result += graph[x][y];

                    for (int i = 0; i < n; ++i)
                    {
                        if (!visited.Contains(i)) pq.Enqueue((y, i), graph[y][i]);
                    }
                }
            }

            return result;
        }

        // Kruskal's Algorithm
        private static int MinCostConnectPoints2(int[][] points)
        {
            Dictionary<int, int> dict = [];

            if (points == null || points.Length == 0) return 0;

            int size = points.Length;
            List<Edge> edges = [];

            for (int i = 0; i < size; i++)
            {
                int[] coordinate1 = points[i];
                for (int j = i + 1; j < size; j++)
                {
                    int[] coordinate2 = points[j];

                    int cost = Math.Abs(coordinate1[0] - coordinate2[0]) +
                               Math.Abs(coordinate1[1] - coordinate2[1]);

                    Edge edge = new(i, j, cost);
                    edges.Add(edge);
                }
            }

            edges.Sort((x, y) => x.cost - y.cost);

            int result = 0;
            int count = size - 1;

            foreach (Edge edge in edges)
            {
                int group1 = Find(edge.point1, dict), group2 = Find(edge.point2, dict);
                if (group1 != group2)
                {
                    result += edge.cost;
                    dict[group1] = group2;
                }
            }

            return result;
        }

        private class Edge(int point1, int point2, int cost)
        {
            public int point1 = point1;
            public int point2 = point2;
            public int cost = cost;
        }

        private static int Find(int x, Dictionary<int, int> dict)
        {
            if (!dict.ContainsKey(x)) dict[x] = x;
            if (dict[x] != x) dict[x] = Find(dict[x], dict);
            return dict[x];
        }

        // Finding closest points not necessarily connected
        private static int MinCostConnectPoints3(int[][] points)
        {
            int n = points.Length;

            Dictionary<(int, int), int> v = [];
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                int t = int.MaxValue;
                int crt = -1;

                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        int w = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                        if (w < t)
                        {
                            t = w;
                            crt = j;
                        }
                    }
                }
                Console.WriteLine($"{i}: {crt} -> {t}");
                if (!v.ContainsKey((i, crt)) && !v.ContainsKey((crt, i)))
                {
                    v[(i, crt)] = 1;
                    v[(crt, i)] = 1;
                    if (t != int.MaxValue) c += t;
                }
            }

            return c;
        }

        // Distinct crossing point
        private static int MinCostConnectPoints4(int[][] points)
        {
            int n = points.Length;
            List<(int, int)> r = [];

            for (int k = 0; k < n; k++)
            {
                r.Add((points[k][0], points[k][1]));
            }

            int c = 0;
            int i = 0;
            while (r.Count > 1)
            {
                int t = int.MaxValue;
                int crt = -1;

                int j = 0;
                while (j < r.Count)
                {
                    if (i != j)
                    {
                        int w = Math.Abs(r[i].Item1 - r[j].Item1) + Math.Abs(r[i].Item2 - r[j].Item2);
                        if (w < t)
                        {
                            t = w;
                            crt = j;
                        }
                    }
                    j++;
                }
                Console.WriteLine($"{i}: {crt} {t}");
                r.RemoveAt(i);
                i = crt - 1;
                c += t;
            }

            return c;
        }
    }
}
