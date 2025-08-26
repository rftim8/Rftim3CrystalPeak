namespace Rftim3LeetCode.Temp
{
    public class _02101_DetonateTheMaximumBombs
    {
        /// <summary>
        /// You are given a list of bombs. 
        /// The range of a bomb is defined as the area where its effect can be felt. 
        /// This area is in the shape of a circle with the center as the location of the bomb.
        /// The bombs are represented by a 0-indexed 2D integer array bombs where bombs[i] = [xi, yi, ri]. 
        /// xi and yi denote the X-coordinate and Y-coordinate of the location of the ith bomb, whereas ri denotes the radius of its range.
        /// You may choose to detonate a single bomb.
        /// When a bomb is detonated, it will detonate all bombs that lie in its range. 
        /// These bombs will further detonate the bombs that lie in their ranges.
        /// Given the list of bombs, return the maximum number of bombs that can be detonated if you are allowed to detonate only one bomb.
        /// </summary>
        public _02101_DetonateTheMaximumBombs()
        {
            Console.WriteLine(MaximumDetonation(
            [
                [2,1,3],
                [6,1,4]
            ]));

            Console.WriteLine(MaximumDetonation(
            [
                [1,1,5],
                [10,10,5]
            ]));

            Console.WriteLine(MaximumDetonation(
            [
                [1,2,3],
                [2,3,1],
                [3,4,2],
                [4,5,3],
                [5,6,4]
            ]));
        }

        private static int MaximumDetonation(int[][] bombs)
        {
            Dictionary<int, List<int>> graph = [];
            int n = bombs.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) continue;

                    int xi = bombs[i][0], yi = bombs[i][1], zi = bombs[i][2];
                    int xj = bombs[j][0], yj = bombs[j][1];

                    if ((long)zi * zi >= (long)(xi - xj) * (xi - xj) + (long)(yi - yj) * (yi - yj))
                    {
                        if (!graph.TryGetValue(i, out List<int>? value)) graph.Add(i, [j]);
                        else
                            value.Add(j);
                    }
                }
            }

            int answer = 0;
            for (int i = 0; i < n; i++)
            {
                //answer = Math.Max(answer, Dfs(i, graph));
                answer = Math.Max(answer, Bfs(i, graph));
            }

            return answer;
        }

        private static int Dfs(int i, Dictionary<int, List<int>> graph)
        {
            Stack<int> stack = new();
            HashSet<int> visited = [];
            stack.Push(i);
            visited.Add(i);
            while (stack.Count != 0)
            {
                int crt = stack.Pop();
                if (graph.TryGetValue(crt, out List<int>? value))
                {
                    foreach (int item in value)
                    {
                        if (!visited.Contains(item))
                        {
                            visited.Add(item);
                            stack.Push(item);
                        }
                    }
                }
            }

            return visited.Count;
        }

        private static int Bfs(int i, Dictionary<int, List<int>> graph)
        {
            Queue<int> queue = new();
            HashSet<int> visited = [];
            queue.Enqueue(i);
            visited.Add(i);
            while (queue.Count != 0)
            {
                int crt = queue.Dequeue();
                if (graph.TryGetValue(crt, out List<int>? value))
                {
                    foreach (int item in value)
                    {
                        if (!visited.Contains(item))
                        {
                            visited.Add(item);
                            queue.Enqueue(item);
                        }
                    }
                }
            }

            return visited.Count;
        }
    }
}
