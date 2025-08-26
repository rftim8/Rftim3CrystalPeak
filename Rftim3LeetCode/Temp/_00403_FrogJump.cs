namespace Rftim3LeetCode.Temp
{
    public class _00403_FrogJump
    {
        /// <summary>
        /// A frog is crossing a river. 
        /// The river is divided into some number of units, and at each unit, there may or may not exist a stone. 
        /// The frog can jump on a stone, but it must not jump into the water.
        /// Given a list of stones' positions (in units) in sorted ascending order, determine if the frog can cross the river by landing on the last stone. 
        /// Initially, the frog is on the first stone and assumes the first jump must be 1 unit.
        /// If the frog's last jump was k units, its next jump must be either k - 1, k, or k + 1 units. 
        /// The frog can only jump in the forward direction.
        /// </summary>
        public _00403_FrogJump()
        {
            Console.WriteLine(CanCross([0, 1, 3, 5, 6, 8, 12, 17]));
            Console.WriteLine(CanCross([0, 1, 2, 3, 4, 8, 9, 11]));
        }

        private static Dictionary<int, int>? mark;
        private static bool[][]? dp;
        private static int[][]? dpi;

        // Top-Down DP
        private static bool Solve(int[] stones, int n, int index, int prevJump)
        {
            if (index == n - 1) return true;

            if (dpi![index][prevJump] != -1) return dpi[index][prevJump] == 1;

            bool ans = false;
            for (int nextJump = prevJump - 1; nextJump <= prevJump + 1; nextJump++)
            {
                if (nextJump > 0 && mark!.ContainsKey(stones[index] + nextJump)) ans = ans || Solve(stones, n, mark[stones[index] + nextJump], nextJump);
            }

            dpi[index][prevJump] = ans ? 1 : 0;

            return ans;
        }

        private static bool CanCross(int[] stones)
        {
            mark = [];
            int n = stones.Length;
            dpi = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dpi[i] = new int[n];
                Array.Fill(dpi[i], -1);
                mark[stones[i]] = i;
            }

            return Solve(stones, n, 0, 0);
        }

        // Bottom-Up DP
        private static bool CanCross0(int[] stones)
        {
            mark = [];
            int n = stones.Length;
            dp = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new bool[n];
                mark[stones[i]] = i;
            }

            dp[0][0] = true;
            for (int index = 0; index < n; index++)
            {
                for (int prevJump = 0; prevJump <= index; prevJump++)
                {
                    if (dp[index][prevJump])
                    {
                        if (mark.ContainsKey(stones[index] + prevJump)) dp[mark[stones[index] + prevJump]][prevJump] = true;
                        if (mark.ContainsKey(stones[index] + prevJump + 1)) dp[mark[stones[index] + prevJump + 1]][prevJump + 1] = true;
                        if (mark.ContainsKey(stones[index] + prevJump - 1)) dp[mark[stones[index] + prevJump - 1]][prevJump - 1] = true;
                    }
                }
            }

            for (int index = 0; index < n; index++)
            {
                if (dp[n - 1][index]) return true;
            }

            return false;
        }

        private static bool CanCross1(int[] stones)
        {
            int n = stones.Length;
            Dictionary<int, int> dict = [];
            for (int i = 0; i < n; ++i)
            {
                dict.Add(stones[i], i);
            }

            PriorityQueue<(int i, int k), int> queue = new();
            queue.Enqueue((0, 0), 0);

            bool result = false;
            int steps = 2 * n * 3;

            while (queue.Count > 0 && steps-- > 0)
            {
                (int i, int k) s = queue.Dequeue();
                if (s.i == n - 1)
                {
                    result = true;
                    break;
                }
                int k = s.k;

                int pos = stones[s.i];
                for (int i = 1; i >= -1; --i)
                {
                    if (dict.ContainsKey(pos + k + i))
                    {
                        int index = dict[pos + k + i];
                        queue.Enqueue((index, k + i), -index);
                    }
                }
            }

            return result;
        }
    }
}
