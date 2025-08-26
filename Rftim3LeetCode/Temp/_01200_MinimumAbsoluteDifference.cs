using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01200_MinimumAbsoluteDifference
    {
        /// <summary>
        /// Given an array of distinct integers arr, find all pairs of elements with the minimum absolute difference of any two elements.
        /// Return a list of pairs in ascending order(with respect to pairs), each pair[a, b] follows
        /// a, b are from arr
        /// a<b
        /// b - a equals to the minimum absolute difference of any two elements in arr
        /// </summary>
        public _01200_MinimumAbsoluteDifference()
        {
            IList<IList<int>> x = MinimumAbsDifference([4, 2, 1, 3]);

            RftTerminal.RftReadResult(x);
        }

        private static List<IList<int>> MinimumAbsDifference(int[] arr)
        {
            List<IList<int>> x = [];
            int n = arr.Length;
            int m = int.MaxValue;
            Array.Sort(arr);

            for (int i = 1; i < n; i++)
            {
                int d = Math.Abs(arr[i] - arr[i - 1]);
                if (d <= m) m = d;
            }

            for (int i = 1; i < n; i++)
            {
                if (Math.Abs(arr[i] - arr[i - 1]) == m) x.Add([arr[i - 1], arr[i]]);
            }

            return x;
        }
    }
}
