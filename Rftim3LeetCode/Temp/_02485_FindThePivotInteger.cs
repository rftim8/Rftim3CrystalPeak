namespace Rftim3LeetCode.Temp
{
    public class _02485_FindThePivotInteger
    {
        /// <summary>
        /// Given a positive integer n, find the pivot integer x such that:
        /// The sum of all elements between 1 and x inclusively equals the sum of all elements between x and n inclusively.
        /// Return the pivot integer x. If no such integer exists, return -1. 
        /// It is guaranteed that there will be at most one pivot index for the given input.
        /// </summary>
        public _02485_FindThePivotInteger()
        {
            Console.WriteLine(PivotInteger(8));
            Console.WriteLine(PivotInteger(1));
            Console.WriteLine(PivotInteger(4));
        }

        private static int PivotInteger(int n)
        {
            int[] x = Enumerable.Range(1, n).ToArray();

            for (int i = 1; i <= n; i++)
            {
                if (x[..i].Sum() == x[(i - 1)..].Sum()) return i;
            }

            return -1;
        }

        private static int PivotInteger0(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if ((1 + i) * i == (i + n) * (n - i + 1)) return i;
            }

            return -1;
        }
    }
}
