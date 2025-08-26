using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00210_CourseSchedule2
    {
        /// <summary>
        /// There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. 
        /// You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.
        /// For example, the pair[0, 1], indicates that to take course 0 you have to first take course 1.
        /// Return the ordering of courses you should take to finish all courses.If there are many valid answers, return any of them.
        /// If it is impossible to finish all courses, return an empty array.
        /// </summary>
        public _00210_CourseSchedule2()
        {
            int[] x = FindOrder(2,
            [
                [1,0]
            ]);

            int[] x0 = FindOrder(4,
            [
                [1,0],
                [2,0],
                [3,1],
                [3,2]
            ]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> adjList = [];
            int[] indegree = new int[numCourses];
            int[] topologicalOrder = new int[numCourses];

            for (int i = 0; i < prerequisites.Length; i++)
            {
                int dest = prerequisites[i][0];
                int src = prerequisites[i][1];
                List<int> lst = adjList.TryGetValue(src, out var found) ? found : [];
                lst.Add(dest);
                adjList.TryAdd(src, lst);
                indegree[dest] += 1;
            }

            Queue<int> q = new();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0) q.Enqueue(i);
            }

            int j = 0;
            while (q.Count != 0)
            {
                int node = q.Dequeue();
                topologicalOrder[j++] = node;

                if (adjList.TryGetValue(node, out var value))
                {
                    foreach (int neighbor in value)
                    {
                        indegree[neighbor]--;

                        if (indegree[neighbor] == 0) q.Enqueue(neighbor);
                    }
                }
            }

            if (j == numCourses) return topologicalOrder;

            return [];
        }

        private static int[] FindOrder0(int numCourses, int[][] prerequisites)
        {
            int[] res = new int[numCourses];
            int[] indegree = new int[numCourses];
            List<int>[] graph = new List<int>[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = [];
            }

            foreach (int[] pre in prerequisites)
            {
                indegree[pre[0]]++;
                graph[pre[1]].Add(pre[0]);
            }

            int idx = 0;
            Queue<int> queue = new();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0) queue.Enqueue(i);
            }

            int edges = prerequisites.Length;
            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();
                res[idx++] = curr;
                foreach (int course in graph[curr])
                {
                    edges--;
                    if (--indegree[course] == 0) queue.Enqueue(course);
                }
            }

            return edges == 0 ? res : [];
        }
    }
}
