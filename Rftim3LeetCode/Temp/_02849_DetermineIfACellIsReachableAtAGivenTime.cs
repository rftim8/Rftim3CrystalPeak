namespace Rftim3LeetCode.Temp
{
    public class _02849_DetermineIfACellIsReachableAtAGivenTime
    {
        /// <summary>
        /// You are given four integers sx, sy, fx, fy, and a non-negative integer t.
        /// 
        /// In an infinite 2D grid, you start at the cell(sx, sy). Each second, you must move to any of its adjacent cells.
        /// 
        /// Return true if you can reach cell (fx, fy) after exactly t seconds, or false otherwise.
        /// 
        /// A cell's adjacent cells are the 8 cells around it that share at least one corner with it. You can visit the same cell several times.
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="fx"></param>
        /// <param name="fy"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public _02849_DetermineIfACellIsReachableAtAGivenTime()
        {
            bool x = IsReachableAtTime0(2, 4, 7, 7, 6);
            Console.WriteLine(x);

            bool x0 = IsReachableAtTime0(3, 1, 7, 3, 3);
            Console.WriteLine(x0);
        }

        public static bool IsReachableAtTime0(int a0, int a1, int a2, int a3, int a4) => RftIsReachableAtTime0(a0, a1, a2, a3, a4);

        private static bool RftIsReachableAtTime0(int sx, int sy, int fx, int fy, int t)
        {
            int width = Math.Abs(sx - fx);
            int height = Math.Abs(sy - fy);

            if (width == 0 && height == 0 && t == 1) return false;

            return t >= Math.Max(width, height);
        }
    }
}
