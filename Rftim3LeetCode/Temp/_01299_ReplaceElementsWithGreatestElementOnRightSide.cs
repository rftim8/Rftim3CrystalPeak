using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01299_ReplaceElementsWithGreatestElementOnRightSide
    {
        /// <summary>
        /// Given an array arr, replace every element in that array with the greatest element among the elements to its right, and replace the last element with -1.
        /// After doing so, return the array.
        /// </summary>
        public _01299_ReplaceElementsWithGreatestElementOnRightSide()
        {
            int[] x = ReplaceElements([17, 18, 5, 4, 6, 1]);

            RftTerminal.RftReadResult(x);
        }

        private static int[] ReplaceElements(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                int x = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j > i && arr[j] > x) x = arr[j];
                }
                if (i == n - 1) arr[i] = -1;
                else arr[i] = x;
            }

            return arr;
        }

        private static int[] ReplaceElements0(int[] arr)
        {
            int n = arr.Length - 1, c = -1;
            for (int i = n; i > -1; --i)
            {
                int temp = arr[i];
                arr[i] = c;
                if (c < temp) c = temp;
            }

            return arr;
        }
    }
}