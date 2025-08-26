namespace Rftim3LeetCode.Temp
{
    public class _01051_HeightChecker
    {
        /// <summary>
        /// A school is trying to take an annual photo of all the students. 
        /// The students are asked to stand in a single file line in non-decreasing order by height. 
        /// Let this ordering be represented by the integer array expected where expected[i] is the expected height of the ith student in line.
        /// You are given an integer array heights representing the current order that the students are standing in. 
        /// Each heights[i] is the height of the ith student in line(0-indexed).
        /// Return the number of indices where heights[i] != expected[i].
        /// </summary>
        public _01051_HeightChecker()
        {
            Console.WriteLine(HeightChecker0([5, 1, 2, 3, 4]));
        }

        private static int HeightChecker0(int[] heights)
        {
            int n = heights.Length;
            int m = n;
            int[] x = new int[n];
            Array.Copy(heights, x, n);
            Array.Sort(heights);

            for (int i = 0; i < n; i++)
            {
                if (x[i] == heights[i]) m--;
            }

            return m;
        }
    }
}
