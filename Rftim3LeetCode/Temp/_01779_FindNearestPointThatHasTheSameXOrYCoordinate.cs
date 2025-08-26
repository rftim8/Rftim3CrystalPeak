namespace Rftim3LeetCode.Temp
{
    public class _01779_FindNearestPointThatHasTheSameXOrYCoordinate
    {
        /// <summary>
        /// You are given two integers, x and y, which represent your current location on a Cartesian grid: (x, y). 
        /// You are also given an array points where each points[i] = [ai, bi] represents that a point exists at (ai, bi). 
        /// A point is valid if it shares the same x-coordinate or the same y-coordinate as your location.
        /// Return the index(0-indexed) of the valid point with the smallest Manhattan distance from your current location.
        /// If there are multiple, return the valid point with the smallest index.If there are no valid points, return -1.
        /// The Manhattan distance between two points(x1, y1) and(x2, y2) is abs(x1 - x2) + abs(y1 - y2).
        /// </summary>
        public _01779_FindNearestPointThatHasTheSameXOrYCoordinate()
        {
            Console.WriteLine(FindNearestPointThatHasTheSameXOrYCoordinate0(3, 4, [
                [1, 2],
                [3, 1],
                [2, 4],
                [2, 3],
                [4, 4]
            ]));

            Console.WriteLine(FindNearestPointThatHasTheSameXOrYCoordinate0(3, 4, [
                [3, 4]
            ]));

            Console.WriteLine(FindNearestPointThatHasTheSameXOrYCoordinate0(3, 4, [
                [2, 3]
            ]));
        }

        public static int FindNearestPointThatHasTheSameXOrYCoordinate0(int a0, int a1, int[][] a2) => RftFindNearestPointThatHasTheSameXOrYCoordinate0(a0, a1, a2);

        private static int RftFindNearestPointThatHasTheSameXOrYCoordinate0(int x, int y, int[][] points)
        {
            int n = points.Length;
            int min = int.MaxValue;
            int z = -1;

            for (int i = 0; i < n; i++)
            {
                if (x == points[i][0] || y == points[i][1])
                {
                    int dist = Math.Abs(x - points[i][0]) + Math.Abs(y - points[i][1]);
                    if (dist < min)
                    {
                        z = i;
                        min = dist;
                    }
                }
            }

            return z;
        }
    }
}