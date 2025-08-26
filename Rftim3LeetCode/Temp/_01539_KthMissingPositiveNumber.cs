namespace Rftim3LeetCode.Temp
{
    public class _01539_KthMissingPositiveNumber
    {
        /// <summary>
        /// Given an array arr of positive integers sorted in a strictly increasing order, and an integer k.
        /// Return the kth positive integer that is missing from this array.
        /// </summary>
        public _01539_KthMissingPositiveNumber()
        {
            Console.WriteLine(FindKthPositive([2, 3, 4, 7, 11], 5));
            Console.WriteLine(FindKthPositive([1, 2, 3, 4], 2));
            Console.WriteLine(FindKthPositive([1, 2], 1));
        }

        private static int FindKthPositive(int[] arr, int k)
        {
            int c = 0;
            int a = 0;
            while (k > 0)
            {
                c++;
                if (a < arr.Length && arr[a] == c)
                {
                    a++;
                    k++;
                }
                k--;
            }

            return c;
        }
    }
}
