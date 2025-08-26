namespace Rftim3LeetCode.Temp
{
    public class _01725_NumberOfRectanglesThatCanFormTheLargestSquare
    {
        /// <summary>
        /// You are given an array rectangles where rectangles[i] = [li, wi] represents the ith rectangle of length li and width wi.
        /// You can cut the ith rectangle to form a square with a side length of k if both k <= li and k <= wi.
        /// For example, if you have a rectangle[4, 6], you can cut it to get a square with a side length of at most 4.
        /// Let maxLen be the side length of the largest square you can obtain from any of the given rectangles.
        /// Return the number of rectangles that can make a square with a side length of maxLen.
        /// </summary>
        public _01725_NumberOfRectanglesThatCanFormTheLargestSquare()
        {
            Console.WriteLine(CountGoodRectangles(
            [
                [5,8],
                [3,9],
                [5,12],
                [16,5]
            ]));
            Console.WriteLine(CountGoodRectangles(
            [
                [2,3],
                [3,7],
                [4,3],
                [3,7]
            ]));
        }

        private static int CountGoodRectangles(int[][] rectangles)
        {
            Dictionary<int, int> r = [];

            for (int i = 0; i < rectangles.Length; i++)
            {
                int t = Math.Min(rectangles[i][0], rectangles[i][1]);

                if (r.TryGetValue(t, out int value)) r[t] = ++value;
                else r[t] = 1;
            }

            return r.MaxBy(o => o.Key).Value;
        }

        private static int CountGoodRectangles0(int[][] rectangles)
        {
            int max = 0, count = 0;
            for (int i = 0; i < rectangles.Length; i++)
            {
                int val = Math.Min(rectangles[i][0], rectangles[i][1]);
                if (val > max)
                {
                    max = val;
                    count = 1;
                }
                else if (val == max) count++;
            }

            return count;
        }
    }
}
