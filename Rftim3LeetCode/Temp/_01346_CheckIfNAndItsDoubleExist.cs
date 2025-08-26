namespace Rftim3LeetCode.Temp
{
    public class _01346_CheckIfNAndItsDoubleExist
    {
        /// <summary>
        /// Given an array arr of integers, check if there exist two indices i and j such that :
        /// i != j
        /// 0 <= i, j<arr.length
        /// arr[i] == 2 * arr[j]
        /// </summary>
        public _01346_CheckIfNAndItsDoubleExist()
        {
            Console.WriteLine(CheckIfNAndItsDoubleExist0([10, 2, 5, 3]));
            Console.WriteLine(CheckIfNAndItsDoubleExist0([3, 1, 7, 11]));
        }

        public static bool CheckIfNAndItsDoubleExist0(int[] a0) => RftCheckIfNAndItsDoubleExist0(a0);

        private static bool RftCheckIfNAndItsDoubleExist0(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j && (arr[i] == 2 * arr[j] || arr[j] == arr[i] * 2)) return true;
                }
            }

            return false;
        }
    }
}