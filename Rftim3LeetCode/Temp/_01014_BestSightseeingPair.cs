namespace Rftim3LeetCode.Temp
{
    public class _01014_BestSightSeeingPair
    {
        /// <summary>
        /// You are given an integer array values where values[i] represents the value of the ith sightseeing spot. 
        /// Two sightseeing spots i and j have a distance j - i between them.
        /// The score of a pair(i<j) of sightseeing spots is values[i] + values[j] + i - j: 
        /// the sum of the values of the sightseeing spots, minus the distance between them.
        /// Return the maximum score of a pair of sightseeing spots.
        /// </summary>
        public _01014_BestSightSeeingPair()
        {
            Console.WriteLine(BestSightSeeingPair0([8, 1, 5, 2, 6]));
            Console.WriteLine(BestSightSeeingPair0([1, 2]));
        }

        public static int BestSightSeeingPair0(int[] a0) => RftBestSightSeeingPair0(a0);

        private static int RftBestSightSeeingPair0(int[] values)
        {
            int n = values.Length;
            int[] x = new int[n];
            x[0] = values[0];

            for (int i = 1; i < n; i++)
            {
                x[i] = Math.Max(x[i - 1], values[i] + i);
            }

            int c = int.MinValue;
            for (int i = 1; i < n; i++)
            {
                c = Math.Max(c, values[i] - i + x[i - 1]);
            }

            return c;
        }
    }
}