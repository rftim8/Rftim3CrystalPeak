namespace Rftim3LeetCode.Temp
{
    public class _01971_FindIfPathExistsInGraph
    {
        /// <summary>
        /// There is a bi-directional graph with n vertices, where each vertex is labeled from 0 to n - 1 (inclusive). 
        /// The edges in the graph are represented as a 2D integer array edges, where each edges[i] = [ui, vi] denotes a bi-directional edge between vertex ui and vertex vi. 
        /// Every vertex pair is connected by at most one edge, and no vertex has an edge to itself.
        /// You want to determine if there is a valid path that exists from vertex source to vertex destination.
        /// Given edges and the integers n, source, and destination, return true if there is a valid path from source to destination, or false otherwise.
        /// </summary>
        public _01971_FindIfPathExistsInGraph()
        {
            Console.WriteLine(ValidPath(
                3,
                [
                    [0,1],
                    [1,2],
                    [2,0]
                ],
                0,
                2
            ));

            Console.WriteLine(ValidPath(
                6,
                [
                    [0,1],
                    [0,2],
                    [3,5],
                    [5,4],
                    [4,3]
                ],
                0,
                5
            ));

            Console.WriteLine(ValidPath(
                10,
                [
                    [4,3],
                    [1,4],
                    [4,8],
                    [1,7],
                    [6,4],
                    [4,2],
                    [7,4],
                    [4,0],
                    [0,9],
                    [5,4]
                ],
                5,
                9
            ));
        }

        private static int[]? set = null;

        private static bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            set = new int[n];

            for (int i = 0; i < n; i++)
            {
                set[i] = i;
            }

            foreach (int[] e in edges)
            {
                Union(e[0], e[1]);
            }

            return Find(source) == Find(destination);
        }

        private static void Union(int x, int y)
        {
            int px = Find(x),
                py = Find(y);

            if (px != py) set![px] = py;
        }

        private static int Find(int x)
        {
            if (set![x] != x) set[x] = Find(set[x]);

            return set[x];
        }

        private static bool ValidPath0(int n, int[][] edges, int start, int end)
        {

            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = [];
            }

            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            bool[] visited = new bool[n];
            if (Dfs(graph, start, end, visited)) return true;

            return false;
        }

        private static bool Dfs(List<int>[] graph, int start, int end, bool[] visited)
        {
            if (start == end) return true;

            visited[start] = true;
            foreach (int next in graph[start])
            {
                if (!visited[next])
                {
                    if (Dfs(graph, next, end, visited)) return true;
                }
            }

            return false;
        }
    }
}
