using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01122_RelativeSortArray
    {
        /// <summary>
        /// Given two arrays arr1 and arr2, the elements of arr2 are distinct, and all elements in arr2 are also in arr1.
        /// Sort the elements of arr1 such that the relative ordering of items in arr1 are the same as in arr2.
        /// Elements that do not appear in arr2 should be placed at the end of arr1 in ascending order.
        /// </summary>
        public _01122_RelativeSortArray()
        {
            int[] x = RelativeSortArray(
                [2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19],
                [2, 1, 4, 3, 9, 6]
            );

            int[] x0 = RelativeSortArray(
                [28, 6, 22, 8, 44, 17],
                [22, 28, 8, 6]
            );

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            int n = arr1.Length;
            int m = arr2.Length;

            List<int> r = [];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (arr1[j] == arr2[i])
                    {
                        r.Add(arr1[j]);
                        arr1[j] = -1;
                    }
                }
            }

            Array.Sort(arr1);
            for (int i = 0; i < n; i++)
            {
                if (arr1[i] != -1) r.Add(arr1[i]);
            }

            return [.. r];
        }
    }
}
