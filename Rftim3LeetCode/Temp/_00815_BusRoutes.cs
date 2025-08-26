namespace Rftim3LeetCode.Temp
{
    public class _00815_BusRoutes
    {
        /// <summary>
        /// You are given an array routes representing bus routes where routes[i] is a bus route that the ith bus repeats forever.
        /// For example, if routes[0] = [1, 5, 7], this means that the 0th bus travels in the sequence 1 -> 5 -> 7 -> 1 -> 5 -> 7 -> 1 -> ... forever.
        /// You will start at the bus stop source(You are not on any bus initially), and you want to go to the bus stop target.You can travel between bus stops by buses only.
        /// Return the least number of buses you must take to travel from source to target.Return -1 if it is not possible.
        /// </summary>
        public _00815_BusRoutes()
        {
            Console.WriteLine(NumBusesToDestination(
                [
                [1,2,7],
                [3,6,7]
                ],
                1,
                6
            ));
        }

        private static int NumBusesToDestination(int[][] routes, int source, int target)
        {
            int n = routes.Length;
            if (source == target) return 0;

            List<List<int>> graph = [];
            for (int i = 0; i < n; ++i)
            {
                Array.Sort(routes[i]);
                graph.Add([]);
            }
            HashSet<int> seen = [];
            HashSet<int> targets = [];
            Queue<(int, int)> queue = new();

            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    if (Intersect(routes[i], routes[j]))
                    {
                        graph[i].Add(j);
                        graph[j].Add(i);
                    }
                }
            }

            for (int i = 0; i < n; ++i)
            {
                if (Array.BinarySearch(routes[i], source) >= 0)
                {
                    seen.Add(i);
                    queue.Enqueue((i, 0));
                }
                if (Array.BinarySearch(routes[i], target) >= 0) targets.Add(i);
            }

            while (queue.Count != 0)
            {
                (int x, int y) = queue.Dequeue();
                int node = x, depth = y;
                if (targets.Contains(node)) return depth + 1;
                foreach (int item in graph[node])
                {
                    if (!seen.Contains(item))
                    {
                        seen.Add(item);
                        queue.Enqueue((item, depth + 1));
                    }
                }
            }

            return -1;
        }

        private static bool Intersect(int[] a, int[] b)
        {
            int i = 0, j = 0;
            while (i < a.Length && j < b.Length)
            {
                if (a[i] == b[j]) return true;
                if (a[i] < b[j]) i++; else j++;
            }

            return false;
        }
    }
}
