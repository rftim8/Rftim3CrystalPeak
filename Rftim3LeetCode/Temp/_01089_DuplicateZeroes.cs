using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01089_DuplicateZeroes
    {
        /// <summary>
        /// Given a fixed-length integer array arr, duplicate each occurrence of zero, shifting the remaining elements to the right.
        /// Note that elements beyond the length of the original array are not written.Do the above modifications to the input array in place and do not return anything.
        /// </summary>
        public _01089_DuplicateZeroes()
        {
            int[] x = DuplicateZeros([1, 0, 2, 3, 0, 4, 5, 0]);

            RftTerminal.RftReadResult(x);
        }

        private static int[] DuplicateZeros(int[] arr)
        {
            int[] t = new int[arr.Length];

            int n = arr.Length;
            int j = 0;
            for (int i = 0; j < n; i++)
            {
                if (arr[i] == 0 && j != n - 1)
                {
                    t[j] = 0;
                    j++;
                    t[j] = 0;
                }
                else
                {
                    t[j] = arr[i];
                }
                j++;
            }
            Array.Copy(t, arr, t.Length);

            return arr;
        }
    }
}
