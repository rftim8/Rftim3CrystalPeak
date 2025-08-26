using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00973_KClosestPointsToOrigin
    {
        /// <summary>
        /// Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane and an integer k, 
        /// return the k closest points to the origin (0, 0).
        /// The distance between two points on the X-Y plane is the Euclidean distance(i.e., √(x1 - x2)2 + (y1 - y2)2).
        /// You may return the answer in any order.
        /// The answer is guaranteed to be unique (except for the order that it is in).
        /// </summary>
        public _00973_KClosestPointsToOrigin()
        {
            int[][] x = KClosestPointsToOrigin0(
                [
                    [1, 3],
                    [-2, 2]
                ],
                1
            );
            RftTerminal.RftReadResult<int>(x);

            int[][] x0 = KClosestPointsToOrigin0(
                [
                    [3, 3],
                    [5, -1],
                    [-2, 4],
                ],
                2
            );
            RftTerminal.RftReadResult<int>(x0);

            int[][] x1 = KClosestPointsToOrigin0(
                [
                    [-5, 4],
                    [-6, -5],
                    [4, 6],
                ],
                2
            );
            RftTerminal.RftReadResult<int>(x1);
        }

        public static int[][] KClosestPointsToOrigin0(int[][] a0, int a1) => RftKClosestPointsToOrigin0(a0, a1);
        public static int[][] KClosestPointsToOrigin1(int[][] a0, int a1) => RftKClosestPointsToOrigin1(a0, a1);

        private static int[][] RftKClosestPointsToOrigin0(int[][] points, int k)
        {
            int n = points.Length;
            Dictionary<int[], double> kvp = [];

            for (int i = 0; i < n; i++)
            {
                kvp.Add(points[i], Dist(points[i][0], points[i][1], 0, 0));
            }

            kvp = kvp.OrderBy(o => o.Value).ToDictionary(o => o.Key, o => o.Value);
            int[][] x = new int[k][];

            int j = 0;
            foreach (KeyValuePair<int[], double> item in kvp)
            {
                if (k > 0)
                {
                    x[j] = new int[2];
                    Array.Copy(item.Key, x[j], 2);
                    k--;
                }
                else break;
                j++;
            }

            return x;
        }

        private static double Dist(int x0, int y0, int x1, int y1) => Math.Sqrt((x0 - x1) * (x0 - x1) + (y0 - y1) * (y0 - y1));

        private static int[][] RftKClosestPointsToOrigin1(int[][] points, int k)
        {
            PriorityQueue<int[], int> queue = new();
            foreach (int[] point in points)
            {
                queue.Enqueue(point, point[0] * point[0] + point[1] * point[1]);
            }

            int[][] res = new int[k][];
            while (k > 0)
            {
                res[--k] = queue.Dequeue();
            }

            return res;
        }
    }
}