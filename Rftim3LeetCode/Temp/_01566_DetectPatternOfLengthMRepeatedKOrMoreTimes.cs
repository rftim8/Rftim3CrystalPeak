namespace Rftim3LeetCode.Temp
{
    public class _01566_DetectPatternOfLengthMRepeatedKOrMoreTimes
    {
        /// <summary>
        /// Given an array of positive integers arr, find a pattern of length m that is repeated k or more times.
        /// A pattern is a subarray(consecutive sub-sequence) that consists of one or more values, repeated multiple times consecutively without overlapping.
        /// A pattern is defined by its length and the number of repetitions.
        /// Return true if there exists a pattern of length m that is repeated k or more times, otherwise return false.
        /// </summary>
        public _01566_DetectPatternOfLengthMRepeatedKOrMoreTimes()
        {
            Console.WriteLine(DetectPatternOfLengthMRepeatedKOrMoreTimes0([1, 2, 4, 4, 4, 4], 1, 3));
            Console.WriteLine(DetectPatternOfLengthMRepeatedKOrMoreTimes0([1, 2, 1, 2, 1, 1, 1, 3], 2, 2));
            Console.WriteLine(DetectPatternOfLengthMRepeatedKOrMoreTimes0([1, 2, 1, 2, 1, 3], 2, 3));
        }

        public static bool DetectPatternOfLengthMRepeatedKOrMoreTimes0(int[] a0, int a1, int a2) => RftDetectPatternOfLengthMRepeatedKOrMoreTimes0(a0, a1, a2);

        public static bool DetectPatternOfLengthMRepeatedKOrMoreTimes1(int[] a0, int a1, int a2) => RftDetectPatternOfLengthMRepeatedKOrMoreTimes1(a0, a1, a2);

        private static bool RftDetectPatternOfLengthMRepeatedKOrMoreTimes0(int[] arr, int m, int k)
        {
            for (int i = 0, count = 1; i <= arr.Length - m; i++, count = 1)
            {
                int[] Target = new int[m];
                Array.Copy(arr, i, Target, 0, m);

                for (int j = i + m; j <= arr.Length - m; j += m)
                {
                    int[] Current = new int[m];
                    Array.Copy(arr, j, Current, 0, m);

                    if (!Target.SequenceEqual(Current)) break;
                    if (++count >= k) return true;
                }
            }

            return false;
        }

        private static bool RftDetectPatternOfLengthMRepeatedKOrMoreTimes1(int[] arr, int m, int k)
        {
            int[] pattern = new int[m];
            int l;

            for (int i = 0; i < arr.Length - m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    pattern[j] = arr[i + j];
                }

                l = i + m;
                while (l < arr.Length)
                {
                    if (arr[l] != pattern[(l - i) % m]) break;
                    l++;
                }

                if ((l - i) / m >= k) return true;
            }

            return false;
        }
    }
}