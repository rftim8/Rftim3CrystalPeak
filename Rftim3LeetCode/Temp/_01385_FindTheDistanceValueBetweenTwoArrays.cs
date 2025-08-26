namespace Rftim3LeetCode.Temp
{
    public class _01385_FindTheDistanceValueBetweenTwoArrays
    {
        /// <summary>
        /// Given two integer arrays arr1 and arr2, and the integer d, return the distance value between the two arrays.
        /// The distance value is defined as the number of elements arr1[i] such that there is not any element arr2[j] where |arr1[i]-arr2[j]| <= d.
        /// </summary>
        public _01385_FindTheDistanceValueBetweenTwoArrays()
        {
            Console.WriteLine(FindTheDistanceValue([4, 5, 8], [10, 9, 1, 8], 2));
            Console.WriteLine(FindTheDistanceValue([1, 4, 2, 3], [-4, -3, 6, 10, 20, 30], 3));
            Console.WriteLine(FindTheDistanceValue([2, 1, 100, 3], [-5, -2, 10, -3, 7], 6));
        }

        private static int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            int n = arr1.Length;
            int m = arr2.Length;

            int x = 0;

            for (int i = 0; i < n; i++)
            {
                bool c = true;
                for (int j = 0; j < m; j++)
                {
                    if (Math.Abs(arr1[i] - arr2[j]) <= d)
                    {
                        c = false;
                        break;
                    }
                }
                if (c) x++;
            }

            return x;
        }
    }
}
