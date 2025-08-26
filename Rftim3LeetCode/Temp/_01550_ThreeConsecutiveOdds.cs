namespace Rftim3LeetCode.Temp
{
    public class _01550_ThreeConsecutiveOdds
    {
        /// <summary>
        /// Given an integer array arr, return true if there are three consecutive odd numbers in the array. Otherwise, return false.
        /// </summary>
        public _01550_ThreeConsecutiveOdds()
        {
            Console.WriteLine(ThreeConsecutiveOdds([2, 6, 4, 1]));
            Console.WriteLine(ThreeConsecutiveOdds([1, 2, 34, 3, 4, 5, 7, 23, 12]));
        }

        private static bool ThreeConsecutiveOdds(int[] arr)
        {
            int n = arr.Length;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    c++;
                    if (c == 3) return true;
                }
                else c = 0;
            }

            return false;
        }
    }
}
