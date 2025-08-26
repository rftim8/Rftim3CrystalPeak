namespace Rftim3LeetCode.Temp
{
    public class _02050_ParallelCourses3
    {
        /// <summary>
        /// You are given an integer n, which indicates that there are n courses labeled from 1 to n. 
        /// You are also given a 2D integer array relations where relations[j] = [prevCoursej, nextCoursej] denotes that course prevCoursej 
        /// has to be completed before course nextCoursej (prerequisite relationship). 
        /// Furthermore, you are given a 0-indexed integer array time where time[i] denotes how many months it takes to complete the (i+1)th course.
        /// You must find the minimum number of months needed to complete all the courses following these rules:
        /// You may start taking a course at any time if the prerequisites are met.
        /// Any number of courses can be taken at the same time.
        /// Return the minimum number of months needed to complete all the courses.
        /// Note: The test cases are generated such that it is possible to complete every course (i.e., the graph is a directed acyclic graph).
        /// </summary>
        public _02050_ParallelCourses3()
        {
            Console.WriteLine(MinimumTime0(
                3,
                [[1, 3], [2, 3]],
                [3, 2, 5]
                ));

            Console.WriteLine(MinimumTime0(
                5,
                [[1, 5], [2, 5], [3, 5], [3, 4], [4, 5]],
                [1, 2, 3, 4, 5]
                ));
        }

        public static int MinimumTime0(int a0, int[][] a1, int[] a2) => RftMinimumTime0(a0, a1, a2);

        public static int MinimumTime1(int a0, int[][] a1, int[] a2) => RftMinimumTime1(a0, a1, a2);

        // Kahn's algorithm
        private static int RftMinimumTime0(int n, int[][] relations, int[] time)
        {
            Dictionary<int, List<int>>? graph = [];
            for (int i = 0; i < n; i++)
            {
                graph.Add(i, []);
            }

            int[] indegree = new int[n];
            foreach (int[] edge in relations)
            {
                int x = edge[0] - 1;
                int y = edge[1] - 1;
                graph[x].Add(y);
                indegree[y]++;
            }

            Queue<int> queue = new();
            int[] maxTime = new int[n];

            for (int node = 0; node < n; node++)
            {
                if (indegree[node] == 0)
                {
                    queue.Enqueue(node);
                    maxTime[node] = time[node];
                }
            }

            while (queue.Count != 0)
            {
                int node = queue.Dequeue();
                foreach (int neighbor in graph[node])
                {
                    maxTime[neighbor] = Math.Max(maxTime[neighbor], maxTime[node] + time[neighbor]);
                    indegree[neighbor]--;

                    if (indegree[neighbor] == 0) queue.Enqueue(neighbor);
                }
            }

            int ans = 0;
            for (int node = 0; node < n; node++)
            {
                ans = Math.Max(ans, maxTime[node]);
            }

            return ans;
        }

        // DFS + Memoization (Top-Down DP)
        private static Dictionary<int, List<int>>? graph;
        private static Dictionary<int, int>? memo;

        private static int RftMinimumTime1(int n, int[][] relations, int[] time)
        {
            graph = [];
            memo = [];

            for (int i = 0; i < n; i++)
            {
                graph.Add(i, []);
            }

            foreach (int[] edge in relations)
            {
                int x = edge[0] - 1;
                int y = edge[1] - 1;
                graph[x].Add(y);
            }

            int ans = 0;
            for (int node = 0; node < n; node++)
            {
                ans = Math.Max(ans, Dfs(node, time));
            }

            return ans;
        }

        private static int Dfs(int node, int[] time)
        {
            if (memo!.TryGetValue(node, out int value)) return value;

            if (graph![node].Count == 0) return time[node];

            int ans = 0;
            foreach (int neighbor in graph[node])
            {
                ans = Math.Max(ans, Dfs(neighbor, time));
            }

            memo.Add(node, time[node] + ans);

            return time[node] + ans;
        }
    }
}
