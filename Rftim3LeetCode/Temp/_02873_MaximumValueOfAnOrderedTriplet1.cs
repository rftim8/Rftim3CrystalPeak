namespace Rftim3LeetCode.Temp
{
    public class _02873_MaximumValueOfAnOrderedTriplet1
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums.
        /// 
        /// Return the maximum value over all triplets of indices(i, j, k) such that i<j<k.
        /// If all such triplets have a negative value, return 0.
        /// 
        /// The value of a triplet of indices (i, j, k) is equal to(nums[i] - nums[j]) * nums[k].
        /// </summary>
        public _02873_MaximumValueOfAnOrderedTriplet1()
        {
            Console.WriteLine(MaximumTripletValue0([12, 6, 1, 2, 7]));
            Console.WriteLine(MaximumTripletValue0([1, 10, 3, 4, 19]));
            Console.WriteLine(MaximumTripletValue0([1, 2, 3]));
        }

        public static long MaximumTripletValue0(int[] a0) => RftMaximumTripletValue0(a0);

        public static long MaximumTripletValue1(int[] a0) => RftMaximumTripletValue1(a0);

        private static long RftMaximumTripletValue0(int[] nums)
        {
            int n = nums.Length;
            long r = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    long t = nums[i] - nums[j];
                    if (t >= 0)
                    {
                        for (int k = j + 1; k < n; k++)
                        {
                            r = Math.Max(r, t * nums[k]);
                        }
                    }
                }
            }

            return r;
        }

        private static long RftMaximumTripletValue1(int[] nums)
        {
            long rslt = 0, curr;
            int b;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] - nums[j] < 0) continue;

                    b = 0;

                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (0 > nums[k]) continue;
                        if (nums[k] > b) b = nums[k]; else continue;

                        curr = (nums[i] - nums[j]) * (long)nums[k];

                        if (curr > rslt) rslt = curr;
                    }
                }
            }

            return rslt;
        }
    }
}
