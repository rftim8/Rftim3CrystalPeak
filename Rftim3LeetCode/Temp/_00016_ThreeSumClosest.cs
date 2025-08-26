namespace Rftim3LeetCode.Temp
{
    public class _00016_ThreeSumClosest
    {
        /// <summary>
        /// Given an integer array nums of length n and an integer target, 
        /// find three integers in nums such that the sum is closest to target.
        /// Return the sum of the three integers.
        /// You may assume that each input would have exactly one solution.
        /// </summary>
        public _00016_ThreeSumClosest()
        {

        }

        public static int ThreeSumClosest0(int[] a0, int a1) => RftThreeSumClosest0(a0, a1);

        public static int ThreeSumClosest1(int[] a0, int a1) => RftThreeSumClosest1(a0, a1);

        private static int RftThreeSumClosest0(int[] nums, int target)
        {
            int n = nums.Length;
            Array.Sort(nums);

            int x = int.MaxValue, diff = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                int l = i + 1, r = n - 1;

                while (l < r)
                {
                    int s = nums[i] + nums[l] + nums[r];
                    if (Math.Abs(s - target) < diff)
                    {
                        diff = Math.Abs(s - target);
                        x = s;
                    }

                    if (s > target) r--;
                    else l++;
                }
            }

            return x;
        }

        private static int RftThreeSumClosest1(int[] nums, int target)
        {
            int n = nums.Length;
            int closest = 0;
            int closestDiff = int.MaxValue;
            Array.Sort(nums);
            for (int start = 0; start < n - 2; start++)
            {
                int mid = start + 1, end = n - 1;
                while (mid < end)
                {
                    int sum = nums[start] + nums[mid] + nums[end];
                    int diff = Math.Abs(target - sum);
                    if (closestDiff >= diff)
                    {
                        closestDiff = diff;
                        closest = sum;
                    }
                    if (sum > target) end--;
                    else mid++;
                }
            }

            return closest;
        }
    }
}
