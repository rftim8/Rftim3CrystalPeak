namespace Rftim3LeetCode.Temp
{
    public class _02971_FindPolygonWithTheLargestPerimeter
    {
        /// <summary>
        /// You are given an array of positive integers nums of length n.
        /// 
        /// A polygon is a closed plane figure that has at least 3 sides.
        /// The longest side of a polygon is smaller than the sum of its other sides.
        /// 
        /// Conversely, if you have k (k >= 3) positive real numbers a1, a2, a3, ..., 
        /// ak where a1 <= a2 <= a3 <= ... <= ak and a1 + a2 + a3 + ... + ak-1 > ak, 
        /// then there always exists a polygon with k sides whose lengths are a1, a2, a3, ..., ak.
        /// 
        /// The perimeter of a polygon is the sum of lengths of its sides.
        /// 
        /// Return the largest possible perimeter of a polygon whose sides can be formed from nums, 
        /// or -1 if it is not possible to create a polygon.
        /// </summary>
        public _02971_FindPolygonWithTheLargestPerimeter()
        {
            Console.WriteLine(FindPolygonWithTheLargestPerimeter0([5, 5, 5]));
            Console.WriteLine(FindPolygonWithTheLargestPerimeter0([1, 12, 1, 2, 5, 50, 3]));
            Console.WriteLine(FindPolygonWithTheLargestPerimeter0([5, 5, 50]));
        }

        public static long FindPolygonWithTheLargestPerimeter0(int[] a0) => RftFindPolygonWithTheLargestPerimeter0(a0);

        public static long FindPolygonWithTheLargestPerimeter1(int[] a0) => RftFindPolygonWithTheLargestPerimeter1(a0);

        private static long RftFindPolygonWithTheLargestPerimeter0(int[] nums)
        {
            long res = -1;
            Array.Sort(nums);
            int n = nums.Length;
            long[] x = new long[n];
            Array.Copy(nums, x, n);
            for (int i = 0; i < n - 1; i++)
            {
                x[i + 1] += x[i];
            }
            for (int i = n - 1; i > 0; i--)
            {
                if (nums[i] < x[i - 1]) return x[i - 1] + nums[i];
            }

            return res;
        }

        private static long RftFindPolygonWithTheLargestPerimeter1(int[] nums)
        {
            Array.Sort(nums);
            long[] prefix = new long[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
            }

            for (int i = nums.Length - 1; i >= 2; i--)
            {
                if (nums[i] >= prefix[i - 1]) continue;
                return prefix[i];
            }

            return -1;
        }
    }
}
