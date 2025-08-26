namespace Rftim3LeetCode.Temp
{
    public class _01503_LastMomentBeforeAllAntsFallOutOfAPlank
    {
        /// <summary>
        /// We have a wooden plank of the length n units.Some ants are walking on the plank, each ant moves with a speed of 1 unit per second.
        /// Some of the ants move to the left, the other move to the right.
        /// 
        /// When two ants moving in two different directions meet at some point, they change their directions and continue moving again.
        /// Assume changing directions does not take any additional time.
        /// 
        /// When an ant reaches one end of the plank at a time t, it falls out of the plank immediately.
        /// 
        /// Given an integer n and two integer arrays left and right, the positions of the ants moving to the left and the right,
        /// return the moment when the last ant(s) fall out of the plank.
        /// </summary>
        public _01503_LastMomentBeforeAllAntsFallOutOfAPlank()
        {
            int x = GetLastMoment0(4, [4, 3], [0, 1]);
            Console.WriteLine(x);

            int x0 = GetLastMoment0(7, [], [0, 1, 2, 3, 4, 5, 6, 7]);
            Console.WriteLine(x0);

            int x1 = GetLastMoment0(7, [0, 1, 2, 3, 4, 5, 6, 7], []);
            Console.WriteLine(x1);
        }

        public static int GetLastMoment0(int a0, int[] a1, int[] a2) => RftGetLastMoment0(a0, a1, a2);

        public static int GetLastMoment1(int a0, int[] a1, int[] a2) => RftGetLastMoment1(a0, a1, a2);

        private static int RftGetLastMoment0(int n, int[] left, int[] right)
        {
            int r = 0;

            foreach (int item in left)
            {
                r = Math.Max(r, item);
            }

            foreach (int item in right)
            {
                r = Math.Max(r, n - item);
            }

            return r;
        }

        // Linq
        private static int RftGetLastMoment1(int n, int[] left, int[] right)
        {
            return left.Union(right.Select(x => n - x)).DefaultIfEmpty(0).Max();
        }
    }
}
