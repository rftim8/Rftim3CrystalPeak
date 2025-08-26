namespace Rftim3LeetCode.Temp
{
    public class _01502_CanMakeArithmeticProgressionFromSequence
    {
        /// <summary>
        /// A sequence of numbers is called an arithmetic progression if the difference between any two consecutive elements is the same.
        /// Given an array of numbers arr, return true if the array can be rearranged to form an arithmetic progression.Otherwise, return false.
        /// </summary>
        public _01502_CanMakeArithmeticProgressionFromSequence()
        {
            Console.WriteLine(CanMakeArithmeticProgression(new int[] { 3, 5, 1 }));
            Console.WriteLine(CanMakeArithmeticProgression(new int[] { 1, 2, 4 }));
        }

        private static bool CanMakeArithmeticProgression(int[] arr)
        {
            int n = arr.Length - 1;
            if (n == 1) return true;
            Array.Sort(arr);

            int c = arr[1] - arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i + 1] - arr[i] != c) return false;
            }

            return true;
        }
    }
}
