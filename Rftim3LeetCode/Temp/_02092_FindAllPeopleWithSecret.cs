using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02092_FindAllPeopleWithSecret
    {
        /// <summary>
        /// You are given an integer n indicating there are n people numbered from 0 to n - 1.
        /// You are also given a 0-indexed 2D integer array meetings where meetings[i] = [xi, yi, timei] indicates that person xi and person yi have a meeting at timei.
        /// A person may attend multiple meetings at the same time. 
        /// Finally, you are given an integer firstPerson.
        /// 
        /// Person 0 has a secret and initially shares the secret with a person firstPerson at time 0. 
        /// This secret is then shared every time a meeting takes place with a person that has the secret.
        /// More formally, for every meeting, if a person xi has the secret at timei, then they will share the secret with person yi, and vice versa.
        /// 
        /// The secrets are shared instantaneously. 
        /// That is, a person may receive the secret and share it with people in other meetings within the same time frame.
        /// 
        /// Return a list of all the people that have the secret after all the meetings have taken place. 
        /// You may return the answer in any order.
        /// </summary>
        public _02092_FindAllPeopleWithSecret()
        {
            IList<int> a0 = FindAllPeopleWithSecret0(6, [[1, 2, 5], [2, 3, 8], [1, 5, 10]], 1);
            RftTerminal.RftReadResult(a0);

            IList<int> a1 = FindAllPeopleWithSecret0(4, [[3, 1, 3], [1, 2, 2], [0, 3, 3]], 3);
            RftTerminal.RftReadResult(a1);

            IList<int> a2 = FindAllPeopleWithSecret0(5, [[3, 4, 2], [1, 2, 1], [2, 3, 1]], 1);
            RftTerminal.RftReadResult(a2);
        }

        public static IList<int> FindAllPeopleWithSecret0(int a0, int[][] a1, int a2) => RftFindAllPeopleWithSecret0(a0, a1, a2);

        public static IList<int> FindAllPeopleWithSecret1(int a0, int[][] a1, int a2) => RftFindAllPeopleWithSecret1(a0, a1, a2);

        public static IList<int> FindAllPeopleWithSecret2(int a0, int[][] a1, int a2) => RftFindAllPeopleWithSecret2(a0, a1, a2);

        public static IList<int> FindAllPeopleWithSecret3(int a0, int[][] a1, int a2) => RftFindAllPeopleWithSecret3(a0, a1, a2);

        public static IList<int> FindAllPeopleWithSecret4(int a0, int[][] a1, int a2) => RftFindAllPeopleWithSecret4(a0, a1, a2);

        public static IList<int> FindAllPeopleWithSecret5(int a0, int[][] a1, int a2) => RftFindAllPeopleWithSecret5(a0, a1, a2);

        // BFS
        private static List<int> RftFindAllPeopleWithSecret0(int n, int[][] meetings, int firstPerson)
        {
            Dictionary<int, List<int[]>> graph = [];
            foreach (int[] meeting in meetings)
            {
                int x = meeting[0], y = meeting[1], t = meeting[2];
                if (!graph.TryGetValue(x, out List<int[]>? value)) graph[x] = [[t, y]];
                else value.Add([t, y]);

                if (!graph.TryGetValue(y, out List<int[]>? value0)) graph[y] = [[t, x]];
                else value0.Add([t, x]);
            }

            int[] earliest = new int[n];
            Array.Fill(earliest, int.MaxValue);
            earliest[0] = 0;
            earliest[firstPerson] = 0;

            Queue<int[]> q = [];
            q.Enqueue([0, 0]);
            q.Enqueue([firstPerson, 0]);

            while (q.Count != 0)
            {
                int[] personTime = q.Dequeue();
                int person = personTime[0], time = personTime[1];
                foreach (int[] nextPersonTime in graph.GetValueOrDefault(person, []))
                {
                    int t = nextPersonTime[0], nextPerson = nextPersonTime[1];
                    if (t >= time && earliest[nextPerson] > t)
                    {
                        earliest[nextPerson] = t;
                        q.Enqueue([nextPerson, t]);
                    }
                }
            }

            List<int> ans = [];
            for (int i = 0; i < n; ++i)
            {
                if (earliest[i] != int.MaxValue) ans.Add(i);
            }

            return ans;
        }

        // DFS
        private static List<int> RftFindAllPeopleWithSecret1(int n, int[][] meetings, int firstPerson)
        {
            Dictionary<int, List<int[]>> graph = [];
            foreach (int[] meeting in meetings)
            {
                int x = meeting[0], y = meeting[1], t = meeting[2];
                if (!graph.TryGetValue(x, out List<int[]>? value)) graph[x] = [[t, y]];
                else value.Add([t, y]);

                if (!graph.TryGetValue(y, out List<int[]>? value0)) graph[y] = [[t, x]];
                else value0.Add([t, x]);
            }

            int[] earliest = new int[n];
            Array.Fill(earliest, int.MaxValue);
            earliest[0] = 0;
            earliest[firstPerson] = 0;

            Stack<int[]> stack = [];
            stack.Push([0, 0]);
            stack.Push([firstPerson, 0]);

            while (stack.Count != 0)
            {
                int[] personTime = stack.Pop();
                int person = personTime[0], time = personTime[1];
                foreach (int[] nextPersonTime in graph.GetValueOrDefault(person, []))
                {
                    int t = nextPersonTime[0], nextPerson = nextPersonTime[1];
                    if (t >= time && earliest[nextPerson] > t)
                    {
                        earliest[nextPerson] = t;
                        stack.Push([nextPerson, t]);
                    }
                }
            }

            List<int> ans = [];
            for (int i = 0; i < n; ++i)
            {
                if (earliest[i] != int.MaxValue) ans.Add(i);
            }

            return ans;
        }

        // DFS using recursion
        private static List<int> RftFindAllPeopleWithSecret2(int n, int[][] meetings, int firstPerson)
        {
            Dictionary<int, List<int[]>> graph = [];
            foreach (int[] meeting in meetings)
            {
                int x = meeting[0], y = meeting[1], t = meeting[2];
                if (!graph.TryGetValue(x, out List<int[]>? value)) graph[x] = [[t, y]];
                else value.Add([t, y]);

                if (!graph.TryGetValue(y, out List<int[]>? value0)) graph[y] = [[t, x]];
                else value0.Add([t, x]);
            }

            int[] earliest = new int[n];
            Array.Fill(earliest, int.MaxValue);
            earliest[0] = 0;
            earliest[firstPerson] = 0;

            Dfs(0, 0, graph, earliest);
            Dfs(firstPerson, 0, graph, earliest);

            List<int> ans = [];
            for (int i = 0; i < n; ++i)
            {
                if (earliest[i] != int.MaxValue) ans.Add(i);
            }

            return ans;
        }

        private static void Dfs(int person, int time, Dictionary<int, List<int[]>> graph, int[] earliest)
        {
            foreach (int[] nextPersonTime in graph.GetValueOrDefault(person, []))
            {
                int t = nextPersonTime[0], nextPerson = nextPersonTime[1];
                if (t >= time && earliest[nextPerson] > t)
                {
                    earliest[nextPerson] = t;
                    Dfs(nextPerson, t, graph, earliest);
                }
            }
        }

        // Earliest Informed Traversal
        private static List<int> RftFindAllPeopleWithSecret3(int n, int[][] meetings, int firstPerson)
        {
            Dictionary<int, List<int[]>> graph = [];
            foreach (int[] meeting in meetings)
            {
                int x = meeting[0], y = meeting[1], t = meeting[2];
                if (!graph.TryGetValue(x, out List<int[]>? value)) graph[x] = [[t, y]];
                else value.Add([t, y]);

                if (!graph.TryGetValue(y, out List<int[]>? value0)) graph[y] = [[t, x]];
                else value0.Add([t, x]);
            }

            PriorityQueue<int[], int[]> pq = new(Comparer<int[]>.Create((a, b) => a[0] - b[0]));
            pq.Enqueue([0, 0], [0, 0]);
            pq.Enqueue([0, firstPerson], [0, firstPerson]);

            bool[] visited = new bool[n];

            while (pq.Count != 0)
            {
                int[] timePerson = pq.Dequeue();
                int time = timePerson[0], person = timePerson[1];

                if (visited[person]) continue;

                visited[person] = true;
                foreach (int[] nextPersonTime in graph.GetValueOrDefault(person, []))
                {
                    int t = nextPersonTime[0], nextPerson = nextPersonTime[1];
                    if (!visited[nextPerson] && t >= time) pq.Enqueue([t, nextPerson], [t, nextPerson]);
                }
            }

            List<int> ans = [];
            for (int i = 0; i < n; ++i)
            {
                if (visited[i]) ans.Add(i);
            }

            return ans;
        }

        // BFS on time scale
        private static List<int> RftFindAllPeopleWithSecret4(int n, int[][] meetings, int firstPerson)
        {
            Array.Sort(meetings, (a, b) => a[2] - b[2]);

            Dictionary<int, List<int[]>> sameTimeMeetings = [];
            foreach (int[] meeting in meetings)
            {
                int x = meeting[0], y = meeting[1], t = meeting[2];
                if (!sameTimeMeetings.TryGetValue(t, out List<int[]>? value)) sameTimeMeetings[t] = [[x, y]];
                else value.Add([x, y]);
            }

            bool[] knowsSecret = new bool[n];
            knowsSecret[0] = true;
            knowsSecret[firstPerson] = true;

            foreach (int t in sameTimeMeetings.Keys)
            {
                Dictionary<int, List<int>> meet = [];
                foreach (int[] meeting in sameTimeMeetings[t])
                {
                    int x = meeting[0], y = meeting[1];
                    if (!meet.TryGetValue(x, out List<int>? value)) meet[x] = [y];
                    else value.Add(y);

                    if (!meet.TryGetValue(y, out List<int>? value0)) meet[y] = [x];
                    else value0.Add(x);
                }

                HashSet<int> start = [];
                foreach (int[] meeting in sameTimeMeetings[t])
                {
                    int x = meeting[0], y = meeting[1];
                    if (knowsSecret[x]) start.Add(x);
                    if (knowsSecret[y]) start.Add(y);
                }

                Queue<int> q = new(start);
                while (q.Count != 0)
                {
                    int person = q.Dequeue();
                    foreach (int nextPerson in meet.GetValueOrDefault(person, []))
                    {
                        if (!knowsSecret[nextPerson])
                        {
                            knowsSecret[nextPerson] = true;
                            q.Enqueue(nextPerson);
                        }
                    }
                }
            }

            List<int> ans = [];
            for (int i = 0; i < n; ++i)
            {
                if (knowsSecret[i]) ans.Add(i);
            }

            return ans;
        }

        // Union-Find with Reset
        private static List<int> RftFindAllPeopleWithSecret5(int n, int[][] meetings, int firstPerson)
        {
            Array.Sort(meetings, (a, b) => a[2] - b[2]);

            Dictionary<int, List<int[]>> sameTimeMeetings = [];
            foreach (int[] meeting in meetings)
            {
                int x = meeting[0], y = meeting[1], t = meeting[2];
                if (!sameTimeMeetings.TryGetValue(t, out List<int[]>? value)) sameTimeMeetings[t] = [[x, y]];
                else value.Add([x, y]);
            }

            UnionFind graph = new(n);
            graph.Unite(firstPerson, 0);

            foreach (int t in sameTimeMeetings.Keys)
            {
                foreach (int[] meeting in sameTimeMeetings[t])
                {
                    int x = meeting[0], y = meeting[1];
                    graph.Unite(x, y);
                }

                foreach (int[] meeting in sameTimeMeetings[t])
                {
                    int x = meeting[0], y = meeting[1];
                    if (!graph.Connected(x, 0))
                    {
                        graph.Reset(x);
                        graph.Reset(y);
                    }
                }
            }

            List<int> ans = [];
            for (int i = 0; i < n; ++i)
            {
                if (graph.Connected(i, 0)) ans.Add(i);
            }

            return ans;
        }

        private class UnionFind
        {
            private readonly int[] parent;
            private readonly int[] rank;

            public UnionFind(int n)
            {
                parent = new int[n];
                rank = new int[n];
                for (int i = 0; i < n; ++i)
                {
                    parent[i] = i;
                }
            }

            public int Find(int x)
            {
                if (parent[x] != x) parent[x] = Find(parent[x]);

                return parent[x];
            }

            public void Unite(int x, int y)
            {
                int px = Find(x);
                int py = Find(y);
                if (px != py)
                {
                    if (rank[px] > rank[py]) parent[py] = px;
                    else if (rank[px] < rank[py]) parent[px] = py;
                    else
                    {
                        parent[py] = px;
                        rank[px] += 1;
                    }
                }
            }

            public bool Connected(int x, int y) => Find(x) == Find(y);

            public void Reset(int x)
            {
                parent[x] = x;
                rank[x] = 0;
            }
        }
    }
}
