using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01964_FindTheLongestValidObstacleCourseAtEachPosition
    {
        /// <summary>
        /// You want to build some obstacle courses. You are given a 0-indexed integer array obstacles of length n, where obstacles[i] describes the height of the ith obstacle.
        /// For every index i between 0 and n - 1 (inclusive), find the length of the longest obstacle course in obstacles such that:
        /// You choose any number of obstacles between 0 and i inclusive.
        /// You must include the ith obstacle in the course.
        /// You must put the chosen obstacles in the same order as they appear in obstacles.
        /// Every obstacle (except the first) is taller than or the same height as the obstacle immediately before it.
        /// Return an array ans of length n, where ans[i] is the length of the longest obstacle course for index i as described above.
        /// </summary>
        public _01964_FindTheLongestValidObstacleCourseAtEachPosition()
        {
            int[] x0 = LongestObstacleCourseAtEachPosition([1, 2, 3, 2]);
            int[] x1 = LongestObstacleCourseAtEachPosition([2, 2, 1]);
            int[] x2 = LongestObstacleCourseAtEachPosition([3, 1, 5, 6, 4, 2]);
            int[] x3 = LongestObstacleCourseAtEachPosition([5, 1, 5, 5, 1, 3, 4, 5, 1, 4]);

            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
            RftTerminal.RftReadResult(x2);
            RftTerminal.RftReadResult(x3);
        }

        private static int[] LongestObstacleCourseAtEachPosition(int[] obstacles)
        {
            int n = obstacles.Length, m = 0;

            int[] x = new int[n];
            int[] y = new int[n];

            for (int i = 0; i < n; ++i)
            {
                int h = obstacles[i];
                int r = m;
                int index = 0;

                if (r != 0)
                {
                    int l = 0;
                    while (l < r)
                    {
                        int mid = l + (r - l) / 2;
                        if (y[mid] <= h) l = mid + 1;
                        else r = mid;
                    }
                    index = l;
                }

                if (index == m) m++;

                y[index] = h;
                x[i] = index + 1;
            }

            return x;
        }
    }
}
