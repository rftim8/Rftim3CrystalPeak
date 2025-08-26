namespace Rftim3LeetCode.Temp
{
    public class _01654_MinimumJumpsToReachHome
    {
        /// <summary>
        /// A certain bug's home is on the x-axis at position x. Help them get there from position 0.
        /// The bug jumps according to the following rules:
        /// It can jump exactly a positions forward(to the right).
        /// It can jump exactly b positions backward(to the left).
        /// It cannot jump backward twice in a row.
        /// It cannot jump to any forbidden positions.
        /// The bug may jump forward beyond its home, but it cannot jump to positions numbered with negative integers.
        /// Given an array of integers forbidden, where forbidden[i] means that the bug cannot jump to the position forbidden[i], 
        /// and integers a, b, and x, return the minimum number of jumps needed for the bug to reach its home. 
        /// If there is no possible sequence of jumps that lands the bug on position x, return -1.
        /// </summary>
        public _01654_MinimumJumpsToReachHome()
        {
            Console.WriteLine(MinimumJumps([14, 4, 18, 1, 15], 3, 15, 9));
            Console.WriteLine(MinimumJumps([8, 3, 16, 6, 12, 20], 15, 13, 11));
            Console.WriteLine(MinimumJumps([1, 6, 2, 14, 5, 17, 4], 16, 9, 7));
        }

        private static int MinimumJumps(int[] forbidden, int a, int b, int x)
        {
            HashSet<int> visited = new(forbidden);
            int max = Math.Max(x, visited.Max());

            Queue<(int, int, bool)> q = new();
            q.Enqueue((0, 0, false));

            while (q.Count != 0)
            {
                (int crt, int step, bool back) = q.Dequeue();

                if (crt == x) return step;
                if (!visited.Add(crt)) continue;
                if (!back && crt - b > 0) q.Enqueue((crt - b, step + 1, true));
                if (crt + a <= max + a + b) q.Enqueue((crt + a, step + 1, false));
            }

            return -1;
        }
    }
}
