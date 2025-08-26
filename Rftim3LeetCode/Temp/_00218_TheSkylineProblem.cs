using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00218_TheSkylineProblem
    {
        /// <summary>
        /// A city's skyline is the outer contour of the silhouette formed by all the buildings in that city when viewed from a distance. 
        /// Given the locations and heights of all the buildings, return the skyline formed by these buildings collectively.
        /// 
        /// The geometric information of each building is given in the array buildings where buildings[i] = [lefti, righti, heighti]:
        /// 
        /// lefti is the x coordinate of the left edge of the ith building.
        /// righti is the x coordinate of the right edge of the ith building.
        /// heighti is the height of the ith building.
        /// You may assume all buildings are perfect rectangles grounded on an absolutely flat surface at height 0.
        /// 
        /// The skyline should be represented as a list of "key points" sorted by their x-coordinate in the form [[x1, y1], [x2, y2],...]. 
        /// Each key point is the left endpoint of some horizontal segment in the skyline except the last point in the list,
        /// which always has a y-coordinate 0 and is used to mark the skyline's termination where the rightmost building ends. 
        /// Any ground between the leftmost and rightmost buildings should be part of the skyline's contour.
        /// 
        /// Note: There must be no consecutive horizontal lines of equal height in the output skyline.
        /// For instance, [...,[2 3], [4 5], [7 5], [11 5], [12 7],...] is not acceptable; 
        /// the three lines of height 5 should be merged into one in the final output as such: [...,[2 3],[4 5],[12 7],...]
        /// </summary>
        public _00218_TheSkylineProblem()
        {
            IList<IList<int>> a0 = TheSkylineProblem2([[2, 9, 10], [3, 7, 15], [5, 12, 12], [15, 20, 10], [19, 24, 8]]);
            RftTerminal.RftReadResult(a0);

            IList<IList<int>> a1 = TheSkylineProblem2([[0, 2, 3], [2, 5, 3]]);
            RftTerminal.RftReadResult(a1);
        }

        public static IList<IList<int>> TheSkylineProblem0(int[][] a0) => RftTheSkylineProblem0(a0);

        public static IList<IList<int>> TheSkylineProblem1(int[][] a0) => RftTheSkylineProblem1(a0);

        public static IList<IList<int>> TheSkylineProblem2(int[][] a0) => RftTheSkylineProblem2(a0);

        public static IList<IList<int>> TheSkylineProblem3(int[][] a0) => RftTheSkylineProblem3(a0);

        // Brute Force
        private static List<IList<int>> RftTheSkylineProblem0(int[][] buildings)
        {
            SortedSet<int> edgeSet = [];
            foreach (int[] building in buildings)
            {
                int left = building[0], right = building[1];
                edgeSet.Add(left);
                edgeSet.Add(right);
            }
            List<int> edges = new(edgeSet);

            Dictionary<int, int> edgeIndexMap = [];
            for (int i = 0; i < edges.Count; ++i)
            {
                edgeIndexMap.Add(edges[i], i);
            }

            int[] heights = new int[edges.Count];

            foreach (int[] building in buildings)
            {
                int left = building[0], right = building[1], height = building[2];
                int leftIndex = edgeIndexMap[left], rightIndex = edgeIndexMap[right];

                for (int idx = leftIndex; idx < rightIndex; ++idx)
                {
                    heights[idx] = Math.Max(heights[idx], height);
                }
            }

            List<IList<int>> answer = [];

            for (int i = 0; i < heights.Length; ++i)
            {
                int currHeight = heights[i], currPos = edges[i];

                if (answer.Count == 0 || answer[^1][1] != currHeight)
                {
                    answer.Add([currPos, currHeight]);
                }
            }

            return answer;
        }

        // Sweep Line + Priority Queue
        private static List<IList<int>> RftTheSkylineProblem1(int[][] buildings)
        {
            List<List<int>> edges = [];
            for (int i = 0; i < buildings.Length; ++i)
            {
                edges.Add([buildings[i][0], i]);
                edges.Add([buildings[i][1], i]);
            }
            edges.Sort(Comparer<List<int>>.Create((a, b) =>
            {
                return a[0] - b[0];
            }));

            PriorityQueue<List<int>, List<int>> live = new(Comparer<List<int>>.Create((a, b) =>
            {
                return b[0] - a[0];
            }));
            List<IList<int>> answer = [];

            int idx = 0;

            while (idx < edges.Count)
            {
                int currX = edges[idx][0];

                while (idx < edges.Count && edges[idx][0] == currX)
                {
                    int b = edges[idx][1];

                    if (buildings[b][0] == currX)
                    {
                        int right = buildings[b][1];
                        int height = buildings[b][2];
                        live.Enqueue([height, right], [height, right]);
                    }
                    idx += 1;
                }

                while (live.Count != 0 && live.Peek()[1] <= currX)
                {
                    live.Dequeue();
                }

                int currHeight = live.Count == 0 ? 0 : live.Peek()[0];

                if (answer.Count == 0 || answer[^1][1] != currHeight) answer.Add([currX, currHeight]);
            }

            return answer;
        }

        // Sweep Line + Two Priority Queue
        private static List<IList<int>> RftTheSkylineProblem2(int[][] buildings)
        {
            List<List<int>> edges = [];
            for (int i = 0; i < buildings.Length; ++i)
            {
                edges.Add([buildings[i][0], buildings[i][2]]);
                edges.Add([buildings[i][1], -buildings[i][2]]);
            }
            edges.Sort(Comparer<List<int>>.Create((a, b) =>
            {
                return a[0] - b[0];
            }));

            PriorityQueue<int, int> live = new(Comparer<int>.Create((a, b) =>
            {
                return b - a;
            }));

            PriorityQueue<int, int> past = new(Comparer<int>.Create((a, b) =>
            {
                return b - a;
            }));
            List<IList<int>> answer = [];

            int idx = 0;

            while (idx < edges.Count)
            {
                int currX = edges[idx][0];

                while (idx < edges.Count && edges[idx][0] == currX)
                {
                    int height = edges[idx][1];

                    if (height > 0) live.Enqueue(height, height);
                    else past.Enqueue(-height, -height);

                    idx++;
                }

                while (past.Count != 0 && live.Peek().Equals(past.Peek()))
                {
                    live.Dequeue();
                    past.Dequeue();
                }

                int currHeight = live.Count == 0 ? 0 : live.Peek();

                if (answer.Count == 0 || answer[^1][1] != currHeight) answer.Add([currX, currHeight]);
            }

            return answer;
        }

        // Union Find
        // Define the disjoint-set structure.
        private class UnionFind
        {
            private readonly int[] root;

            public UnionFind(int n)
            {
                root = new int[n];
                for (int i = 0; i < n; ++i)
                {
                    root[i] = i;
                }
            }

            public int Find(int x) => root[x] == x ? x : (root[x] = Find(root[x]));

            public void Union(int x, int y) => root[x] = root[y];
        }

        private static List<IList<int>> RftTheSkylineProblem3(int[][] buildings)
        {
            SortedSet<int> edgeSet = [];
            foreach (int[] building in buildings)
            {
                edgeSet.Add(building[0]);
                edgeSet.Add(building[1]);
            }
            int[] edges = [.. edgeSet];
            Array.Sort(edges);

            Dictionary<int, int> edgeIndexMap = [];
            for (int i = 0; i < edges.Length; ++i)
            {
                edgeIndexMap.Add(edges[i], i);
            }

            Array.Sort(buildings, (a, b) => b[2] - a[2]);

            int n = edges.Length;
            UnionFind edgeUF = new(n);
            int[] heights = new int[n];

            foreach (int[] building in buildings)
            {
                int leftEdge = building[0], rightEdge = building[1];
                int height = building[2];

                int leftIndex = edgeIndexMap[leftEdge], rightIndex = edgeIndexMap[rightEdge];

                while (leftIndex < rightIndex)
                {
                    leftIndex = edgeUF.Find(leftIndex);

                    if (leftIndex < rightIndex)
                    {
                        edgeUF.Union(leftIndex, rightIndex);
                        heights[leftIndex] = height;
                        leftIndex++;
                    }
                }
            }

            List<IList<int>> answer = [];
            for (int i = 0; i < n; ++i)
            {
                if (i == 0 || heights[i] != heights[i - 1]) answer.Add([edges[i], heights[i]]);
            }

            return answer;
        }
    }
}
