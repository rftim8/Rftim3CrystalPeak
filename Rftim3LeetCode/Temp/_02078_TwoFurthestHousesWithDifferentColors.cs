namespace Rftim3LeetCode.Temp
{
    public class _02078_TwoFurthestHousesWithDifferentColors
    {
        /// <summary>
        /// There are n houses evenly lined up on the street, and each house is beautifully painted.
        /// You are given a 0-indexed integer array colors of length n, where colors[i] represents the color of the ith house.
        /// Return the maximum distance between two houses with different colors.
        /// The distance between the ith and jth houses is abs(i - j), where abs(x) is the absolute value of x.
        /// </summary>
        public _02078_TwoFurthestHousesWithDifferentColors()
        {
            Console.WriteLine(MaxDistance([1, 1, 1, 6, 1, 1, 1]));
            Console.WriteLine(MaxDistance([1, 8, 3, 8, 3]));
            Console.WriteLine(MaxDistance([0, 1]));
        }

        private static int MaxDistance(int[] colors)
        {
            int n = colors.Length;

            int r = 0;
            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int j = n - 1; j > i; j--)
                {
                    if (colors[i] != colors[j])
                    {
                        c = j - i;
                        break;
                    }
                }
                r = Math.Max(r, c);
            }

            return r;
        }
    }
}
