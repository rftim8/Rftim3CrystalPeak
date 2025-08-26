namespace Rftim3LeetCode.Temp
{
    public class _01228_MissingNumberInArithmeticProgression
    {
        /// <summary>
        /// In some array arr, the values were in arithmetic progression: 
        /// the values arr[i + 1] - arr[i] are all equal for every 0 <= i < arr.length - 1.
        /// 
        /// A value from arr was removed that was not the first or last value in the array.
        /// 
        /// Given arr, return the removed value.
        /// </summary>
        public _01228_MissingNumberInArithmeticProgression()
        {
            Console.WriteLine(MissingNumberInArithmeticProgression0([5, 7, 11, 13])); // 9
            Console.WriteLine(MissingNumberInArithmeticProgression0([15, 13, 12])); // 14
        }

        public static int MissingNumberInArithmeticProgression0(int[] a0) => RftMissingNumberInArithmeticProgression0(a0);

        private static int RftMissingNumberInArithmeticProgression0(int[] arr)
        {
            int n = arr.Length;
            int difference = (arr[n - 1] - arr[0]) / n;
            int expected = arr[0];

            foreach (int val in arr)
            {
                if (val != expected) return expected;

                expected += difference;
            }

            return expected;
        }
    }
}
