using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00015_ThreeSum
    {
        /// <summary>
        /// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] 
        /// such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
        /// Notice that the solution set must not contain duplicate triplets.
        /// </summary>
        public _00015_ThreeSum()
        {
            IList<IList<int>> x = ThreeSum0([-1, 0, 1, 2, -1, -4]);

            RftTerminal.RftReadResult(x);
        }

        public static IList<IList<int>> ThreeSum0(int[] a0) => RftThreeSum0(a0);

        private static List<IList<int>> RftThreeSum0(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            List<IList<int>> x = [];

            for (int i = 0; i < n; i++)
            {
                if (i > 0 && nums[i - 1] == nums[i]) continue;

                int l = i + 1;
                int r = n - 1;

                while (l < r)
                {
                    int sum = nums[i] + nums[l] + nums[r];
                    if (sum == 0)
                    {
                        x.Add([nums[i], nums[l], nums[r]]);
                        while (l < r && nums[l] == nums[l + 1]) l++;
                        while (l < r && nums[r] == nums[r - 1]) r--;
                        l++;
                        r--;
                    }
                    else if (sum < 0) l++;
                    else r--;
                }
            }

            return x;
        }
    }
}
