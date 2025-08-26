namespace Rftim3LeetCode.Temp
{
    public class _01287_ElementAppearingMoreThan25PercentInSortedArray
    {
        /// <summary>
        /// Given an integer array sorted in non-decreasing order, there is exactly one integer in the array that occurs more than 25% of the time, return that integer.
        /// </summary>
        public _01287_ElementAppearingMoreThan25PercentInSortedArray()
        {
            Console.WriteLine(FindSpecialInteger([1, 2, 2, 6, 6, 6, 6, 7, 10]));
            Console.WriteLine(FindSpecialInteger([1, 1]));
        }

        private static int FindSpecialInteger(int[] arr)
        {
            int n = arr.Length;
            if (n == 1) return arr[0];

            int m = n / 4;
            int c = 1;
            for (int i = 1; i < n; i++)
            {
                if (arr[i - 1] == arr[i]) c++;
                else c = 1;
                if (c > m) return arr[i];
            }

            return -1;
        }

        private static int FindSpecialInteger0(int[] arr)
        {
            int quater = arr.Length / 4;

            for (int i = 0; i < arr.Length - quater; i++)
            {
                if (arr[i] == arr[i + quater]) return arr[i];
            }

            return -1;
        }
    }
}
