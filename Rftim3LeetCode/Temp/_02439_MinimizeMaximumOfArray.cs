namespace Rftim3LeetCode.Temp
{
    public class _02439_MinimizeMaximumOfArray
    {
        /// <summary>
        /// You are given a 0-indexed array nums comprising of n non-negative integers.
        /// In one operation, you must:
        /// Choose an integer i such that 1 <= i<n and nums[i]> 0.
        /// Decrease nums[i] by 1.
        /// Increase nums[i - 1] by 1.
        /// Return the minimum possible value of the maximum integer of nums after performing any number of operations.
        /// </summary>
        public _02439_MinimizeMaximumOfArray()
        {
            Console.WriteLine(MinimizeArrayValue([3, 7, 1, 6]));
            Console.WriteLine(MinimizeArrayValue([10, 1]));
            Console.WriteLine(MinimizeArrayValue([4, 7, 2, 2, 9, 19, 16, 0, 3, 15]));
            Console.WriteLine(MinimizeArrayValue([153096409, 343881218, 741913853, 343594218, 864722890, 354938680, 279386271, 616365038, 896106991, 540459582, 124304477, 856321779, 533947835, 590383040, 708653960, 928865842, 501462358, 113265076, 786991139, 83872665, 314304738, 719655858, 685019739, 773289565, 224287062, 961183249, 922185605, 437586814, 431957201, 622418600, 246298056, 991189969, 411305056, 270647246, 245431042, 698124847, 829853159, 270399508, 670957159, 333775594, 8772554, 816887664, 443241521, 730170733, 221327413, 52643856, 245385722, 79672837, 350678160, 899468390, 969547281, 790832565, 240362170, 335105823, 56655569, 352858708, 282269718, 803703253, 304986773, 102709585, 615892285, 759458532, 699157897, 706378502, 217026516, 963906270, 328782137, 832395397, 801082006, 736947500, 740380649, 320003089, 442712291, 921177417, 319837024, 864463340, 925725724, 623163350, 720854915, 677738988, 571962532, 2080028]));
        }

        private static int MinimizeArrayValue(int[] nums)
        {
            int n = nums.Length;
            int c = 0;
            long prefixSum = 0;

            for (int i = 0; i < n; i++)
            {
                prefixSum += nums[i];
                c = Math.Max(c, (int)((prefixSum + i) / (i + 1)));
            }

            return c;
        }
    }
}
