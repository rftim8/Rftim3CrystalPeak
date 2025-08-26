namespace Rftim3LeetCode.Temp
{
    public class _01376_TimeNeededToInformAllEmployees
    {
        /// <summary>
        /// A company has n employees with a unique ID for each employee from 0 to n - 1. The head of the company is the one with headID.
        /// Each employee has one direct manager given in the manager array where manager[i] is the direct manager of the i-th employee, manager[headID] = -1.
        /// Also, it is guaranteed that the subordination relationships have a tree structure.
        /// The head of the company wants to inform all the company employees of an urgent piece of news.He will inform his direct subordinates, 
        /// and they will inform their subordinates, and so on until all employees know about the urgent news.
        /// The i-th employee needs informTime[i] minutes to inform all of his direct subordinates (i.e., After informTime[i] minutes, 
        /// all his direct subordinates can start spreading the news).
        /// Return the number of minutes needed to inform all the employees about the urgent news.
        /// </summary>
        public _01376_TimeNeededToInformAllEmployees()
        {
            Console.WriteLine(NumOfMinutes(1, 0, [-1], [0]));
            Console.WriteLine(NumOfMinutes(6, 2, [2, 2, -1, 2, 2, 2], [0, 0, 1, 0, 0, 0]));
        }

        private static int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            if (n <= 1) return 0;

            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = [];
            }

            for (int i = 0; i < manager.Length; i++)
            {
                if (manager[i] != -1) graph[manager[i]].Add(i);
            }

            Queue<(int, int)> q = new();
            q.Enqueue((headID, 0));
            int time = 0;

            while (q.Count != 0)
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    (int, int) crt = q.Dequeue();
                    time = Math.Max(time, crt.Item2);

                    foreach (int item in graph[crt.Item1])
                    {
                        int crtTime = crt.Item2 + informTime[crt.Item1];
                        q.Enqueue((item, crtTime));
                    }
                }
            }

            return time;
        }

        private static int NumOfMinutes0(int n, int headID, int[] manager, int[] informTime)
        {
            Dictionary<int, HashSet<int>> graph = [];

            for (int i = 0; i < n; i++)
            {
                graph[i] = [];
            }

            for (int i = 0; i < manager.Length; i++)
            {
                int man = manager[i];
                if (man != -1) graph[man].Add(i);
            }

            return NumOfMinutes(graph, headID, informTime);
        }

        private static int NumOfMinutes(Dictionary<int, HashSet<int>> graph, int curr, int[] informTime)
        {
            int max = 0;

            foreach (int directReport in graph[curr])
            {
                max = Math.Max(max, NumOfMinutes(graph, directReport, informTime));
            }

            return informTime[curr] + max;
        }

        private static int NumOfMinutes1(int n, int headID, int[] manager, int[] informTime)
        {
            int result = 0;
            for (int i = 0; i < n; i++)
            {
                result = Math.Max(result, Dfs(i, informTime, manager));
            }

            return result;
        }

        private static int Dfs(int i, int[] informTime, int[] manager)
        {
            if (manager[i] != -1)
            {
                informTime[i] += Dfs(manager[i], informTime, manager);
                manager[i] = -1;
            }

            return informTime[i];
        }
    }
}
