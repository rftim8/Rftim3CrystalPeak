using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01304_FindNUniqueIntegersSumUpToZero
    {
        /// <summary>
        /// Given an integer n, return any array containing n unique integers such that they add up to 0.
        /// </summary>
        public _01304_FindNUniqueIntegersSumUpToZero()
        {
            int[] x = SumZero(5);
            int[] x0 = SumZero(3);
            int[] x1 = SumZero(1);
            int[] x2 = SumZero(4);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
            RftTerminal.RftReadResult(x2);
        }

        private static int[] SumZero(int n)
        {
            List<int> x = [];
            int c = n / 2;
            if (n % 2 == 1) x.Add(0);
            for (int i = 1; i <= c; i++)
            {
                x.Add(-i);
                x.Add(i);
            }
            x.Sort();

            return [.. x];
        }
    }
}
