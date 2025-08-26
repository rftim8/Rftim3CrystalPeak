using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02248_IntersectionOfMultipleArrays
    {
        /// <summary>
        /// Given a 2D integer array nums where nums[i] is a non-empty array of distinct positive integers, 
        /// return the list of integers that are present in each array of nums sorted in ascending order.
        /// </summary>
        public _02248_IntersectionOfMultipleArrays()
        {
            IList<int> x = Intersection(
            [
                [3, 1, 2, 4, 5],
                [1, 2, 3, 4],
                [3, 4, 5, 6]
            ]);
            RftTerminal.RftReadResult(x);
            IList<int> x0 = Intersection(
            [
                [1, 2, 3],
                [4, 5, 6]
            ]);
            RftTerminal.RftReadResult(x0);
        }

        private static IList<int> Intersection(int[][] nums)
        {
            int n = nums.Length;
            if (n == 1)
            {
                Array.Sort(nums[0]);
                return nums[0];
            }
            List<int> r = [];

            for (int i = 1; i < nums.Length; i++)
            {
                r = nums[i - 1].Intersect(nums[i]).ToList();
                nums[i] = [.. r];
            }
            r.Sort();

            return r;
        }
    }
}
