namespace Rftim3LeetCode.Temp
{
    public class _01394_FindLuckyIntegerInAnArray
    {
        /// <summary>
        /// Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        /// Return the largest lucky integer in the array.If there is no lucky integer return -1.
        /// </summary>
        public _01394_FindLuckyIntegerInAnArray()
        {
            Console.WriteLine(FindLucky([2, 2, 3, 4]));
            Console.WriteLine(FindLucky([1, 2, 2, 3, 3, 3]));
            Console.WriteLine(FindLucky([2, 2, 2, 3, 3]));
        }

        private static int FindLucky(int[] arr)
        {
            int n = arr.Length;
            int r = -1;
            if (n == 1) return arr[0] == 1 ? 1 : r;

            Array.Sort(arr);
            HashSet<int> l = [];
            int c = 1;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] == arr[i - 1]) c++;
                else
                {
                    if (arr[i - 1] == c) l.Add(arr[i - 1]);
                    c = 1;
                }
                if (i == n - 1)
                {
                    if (arr[i] == c) l.Add(arr[i]);
                }
            }

            return l.Count > 0 ? l.Max() : r;
        }

        private static int FindLucky0(int[] arr)
        {
            int[] counts = new int[501];

            foreach (int num in arr) counts[num]++;

            for (int i = 500; i > 0; i--)
            {
                if (counts[i] == i) return i;
            }

            return -1;
        }
    }
}
