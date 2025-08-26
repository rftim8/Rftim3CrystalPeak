namespace Rftim3LeetCode.Temp
{
    public class _00941_ValidMountainArray
    {
        /// <summary>
        /// Given an array of integers arr, return true if and only if it is a valid mountain array.
        /// Recall that arr is a mountain array if and only if:
        /// arr.length >= 3
        /// There exists some i with 0 < i<arr.length - 1 such that:
        /// arr[0] < arr[1] < ... < arr[i - 1] < arr[i]
        /// arr[i]> arr[i + 1] > ... > arr[arr.length - 1]
        /// </summary>
        public _00941_ValidMountainArray()
        {
            Console.WriteLine(ValidMountainArray0([2, 1]));
            Console.WriteLine(ValidMountainArray0([3, 5, 5]));
            Console.WriteLine(ValidMountainArray0([0, 3, 2, 1]));
            Console.WriteLine(ValidMountainArray0([0, 1, 2, 3, 4, 5, 6, 7, 8, 9]));
        }

        private static bool ValidMountainArray0(int[] arr)
        {
            int n = arr.Length - 1;
            if (n < 2) return false;

            bool down = false;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] == arr[i + 1]) return false;
                if (i == 0 && arr[i] > arr[i + 1]) return false;
                else
                {
                    if (arr[i] > arr[i + 1]) down = true;
                    if (arr[i] < arr[i + 1] && down == true) return false;
                }
                if (i == n - 1 && down == false) return false;
            }

            return true;
        }
    }
}
