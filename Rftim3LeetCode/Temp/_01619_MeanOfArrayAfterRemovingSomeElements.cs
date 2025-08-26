namespace Rftim3LeetCode.Temp
{
    public class _01619_MeanOfArrayAfterRemovingSomeElements
    {
        /// <summary>
        /// Given an integer array arr, return the mean of the remaining integers after removing the smallest 5% and the largest 5% of the elements.
        /// Answers within 10-5 of the actual answer will be considered accepted.
        /// </summary>
        public _01619_MeanOfArrayAfterRemovingSomeElements()
        {
            Console.WriteLine(TrimMean([1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3]));
            Console.WriteLine(TrimMean([6, 2, 7, 5, 1, 2, 0, 3, 10, 2, 5, 0, 5, 5, 0, 8, 7, 6, 8, 0]));
            Console.WriteLine(TrimMean([6, 0, 7, 0, 7, 5, 7, 8, 3, 4, 0, 7, 8, 1, 6, 8, 1, 1, 2, 4, 8, 1, 9, 5, 4, 3, 8, 5, 10, 8, 6, 6, 1, 0, 6, 10, 8, 2, 3, 4]));
        }

        private static double TrimMean(int[] arr)
        {
            Array.Sort(arr);
            int n = arr.Length;
            int m = (int)(n / 100d * 5d);

            int c = 0;
            for (int i = m; i < n - m; i++)
            {
                c += arr[i];
            }

            return c / (n - 2d * m);
        }
    }
}
