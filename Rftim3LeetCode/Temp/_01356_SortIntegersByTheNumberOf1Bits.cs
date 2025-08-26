using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01356_SortIntegersByTheNumberOf1Bits
    {
        /// <summary>
        /// You are given an integer array arr. Sort the integers in the array in ascending order by the number of 1's in 
        /// their binary representation and in case of two or more integers have the same number of 1's you have to sort them in ascending order.
        /// Return the array after sorting it.
        /// </summary>
        public _01356_SortIntegersByTheNumberOf1Bits()
        {
            int[] x = SortByBits([0, 1, 2, 3, 4, 5, 6, 7, 8]);
            int[] x0 = SortByBits([1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] SortByBits(int[] arr)
        {
            int n = arr.Length;
            Array.Sort(arr);
            List<(int, int)> x = [];

            for (int i = 0; i < n; i++)
            {
                x.Add((arr[i], Convert.ToString(arr[i], 2).Count(o => o == '1')));
            }

            return x.OrderBy(o => o.Item2).Select(o => o.Item1).ToArray();
        }
    }
}
