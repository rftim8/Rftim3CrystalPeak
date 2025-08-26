namespace Rftim3LeetCode.Temp
{
    public class _00740_DeleteAndEarn
    {
        /// <summary>
        /// You are given an integer array nums. You want to maximize the number of points you get by performing the following operation any number of times:
        /// Pick any nums[i] and delete it to earn nums[i] points.Afterwards, you must delete every element equal to nums[i] - 1 and every element equal to nums[i] + 1.
        /// Return the maximum number of points you can earn by applying the above operation some number of times.
        /// </summary>
        public _00740_DeleteAndEarn()
        {
            Console.WriteLine(DeleteAndEarn0([3, 4, 2]));
            Console.WriteLine(DeleteAndEarn0([2, 2, 3, 3, 3, 4]));
            Console.WriteLine(DeleteAndEarn0([3, 1]));
        }

        public static int DeleteAndEarn0(int[] a0) => RftDeleteAndEarn0(a0);

        private static int RftDeleteAndEarn0(int[] nums)
        {
            int[] x = new int[10001];

            foreach (int item in nums)
            {
                x[item] += item;
            }

            int next = 0;
            int previous = 0;
            int current = 0;

            for (int i = 0; i < 10001; i++)
            {
                next = Math.Max(previous + x[i], current);
                previous = current;
                current = next;
            }

            return next;
        }
    }
}