namespace Rftim3LeetCode.Temp
{
    public class _00276_PaintFence
    {
        /// <summary>
        /// You are painting a fence of n posts with k different colors. 
        /// You must paint the posts following these rules:
        /// 
        /// Every post must be painted exactly one color.
        /// There cannot be three or more consecutive posts with the same color.
        /// Given the two integers n and k, return the number of ways you can paint the fence.
        /// </summary>
        public _00276_PaintFence()
        {
            Console.WriteLine(PaintFence0(3, 2));
            Console.WriteLine(PaintFence0(1, 1));
            Console.WriteLine(PaintFence0(7, 2));
        }

        public static int PaintFence0(int a0, int a1) => RftPaintFence0(a0, a1);

        public static int PaintFence1(int a0, int a1) => RftPaintFence1(a0, a1);

        public static int PaintFence2(int a0, int a1) => RftPaintFence2(a0, a1);

        public static int PaintFence3(int a0, int a1) => RftPaintFence3(a0, a1);

        // Bottom-Up DP
        private static int RftPaintFence0(int n, int k)
        {
            if (n == 1) return k;
            if (n == 2) return k * k;

            int[] totalWays = new int[n + 1];
            totalWays[1] = k;
            totalWays[2] = k * k;

            for (int i = 3; i <= n; i++)
            {
                totalWays[i] = (k - 1) * (totalWays[i - 1] + totalWays[i - 2]);
            }

            return totalWays[n];
        }

        // Bottom-Up Space Optimized
        private static int RftPaintFence1(int n, int k)
        {
            if (n == 1) return k;

            int twoPostsBack = k;
            int onePostBack = k * k;

            for (int i = 3; i <= n; i++)
            {
                int curr = (k - 1) * (onePostBack + twoPostsBack);
                twoPostsBack = onePostBack;
                onePostBack = curr;
            }

            return onePostBack;
        }

        // Top_Down DP (Recursion + Memoization)
        private static Dictionary<int, int>? memo;

        private static int RftPaintFence2(int n, int k)
        {
            memo = [];

            return TotalWays(n, k);
        }

        private static int TotalWays(int i, int k)
        {
            if (i == 1) return k;
            if (i == 2) return k * k;

            if (memo!.TryGetValue(i, out int value)) return value;

            memo.Add(i, (k - 1) * (TotalWays(i - 1, k) + TotalWays(i - 2, k)));
            return memo[i];
        }

        // Bottom-Up
        private static int RftPaintFence3(int n, int k)
        {
            if (n == 1) return k;
            else if (n == 2) return k * k;

            int[] ways = new int[n + 1];
            ways[1] = k;
            ways[2] = k * k;
            for (int i = 3; i < ways.Length; i++)
            {
                ways[i] = (k - 1) * ways[i - 1];
                ways[i] += 1 * (k - 1) * ways[i - 2];
            }

            return ways[n];
        }
    }
}
