namespace Rftim3LeetCode.Temp
{
    public class _00207_CourseSchedule
    {
        /// <summary>
        /// There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. 
        /// You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.
        /// For example, the pair[0, 1], indicates that to take course 0 you have to first take course 1.
        /// Return true if you can finish all courses.Otherwise, return false.
        /// </summary>
        public _00207_CourseSchedule()
        {
            Console.WriteLine(CanFinish(2, new int[][]
            {
                new int[] { 1,0 }
            }));

            Console.WriteLine(CanFinish(2, new int[][]
            {
                new int[] { 1,0 },
                new int[] { 0,1 }
            }));
        }

        // Topological Sort Kahn's Algorithm
        private static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            int[] indegree = new int[numCourses];
            List<List<int>> adj = new(numCourses);

            for (int i = 0; i < numCourses; i++)
            {
                adj.Add(new());
            }

            foreach (int[] prerequisite in prerequisites)
            {
                adj[prerequisite[1]].Add(prerequisite[0]);
                indegree[prerequisite[0]]++;
            }

            Queue<int> queue = new();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0) queue.Enqueue(i);
            }

            int nodesVisited = 0;
            while (queue.Any())
            {
                int node = queue.Dequeue();
                nodesVisited++;

                foreach (int neighbor in adj[node])
                {
                    indegree[neighbor]--;
                    if (indegree[neighbor] == 0) queue.Enqueue(neighbor);
                }
            }

            return nodesVisited == numCourses;
        }

        // DFS
        private static bool Dfs(int node, List<List<int>> adj, bool[] visit, bool[] inStack)
        {
            if (inStack[node]) return true;
            if (visit[node]) return false;

            visit[node] = true;
            inStack[node] = true;
            foreach (int neighbor in adj[node])
            {
                if (Dfs(neighbor, adj, visit, inStack)) return true;
            }
            inStack[node] = false;

            return false;
        }

        private static bool CanFinish0(int numCourses, int[][] prerequisites)
        {
            List<List<int>> adj = new(numCourses);
            for (int i = 0; i < numCourses; i++)
            {
                adj.Add(new());
            }

            foreach (int[] prerequisite in prerequisites)
            {
                adj[prerequisite[1]].Add(prerequisite[0]);
            }

            bool[] visit = new bool[numCourses];
            bool[] inStack = new bool[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                if (Dfs(i, adj, visit, inStack)) return false;
            }

            return true;
        }
    }
}
