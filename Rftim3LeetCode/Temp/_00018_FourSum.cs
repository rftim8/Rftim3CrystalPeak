using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00018_FourSum
    {
        /// <summary>
        /// Given an array nums of n integers, return an array of all the unique quadruplets
        /// [nums[a], nums[b], nums[c], nums[d]] such that:
        /// 0 <= a, b, c, d<n
        /// a, b, c, and d are distinct.
        /// nums[a] + nums[b] + nums[c] + nums[d] == target
        /// You may return the answer in any order.
        /// </summary>
        public _00018_FourSum()
        {
            IList<IList<int>> x = FourSum0([1, 0, -1, 0, -2, 2], 0);
            RftTerminal.RftReadResult(x);

            IList<IList<int>> x0 = FourSum0([2, 2, 2, 2, 2], 8);
            RftTerminal.RftReadResult(x0);
        }

        public static IList<IList<int>> FourSum0(int[] a0, int a1) => RftFourSum0(a0, a1);

        private static List<IList<int>> RftFourSum0(int[] nums, int target)
        {
            int n = nums.Length;
            Array.Sort(nums);

            List<IList<int>> r = [];
            for (int i = 0; i < n - 3; i++)
            {
                if (i > 0 && nums[i - 1] == nums[i]) continue;
                else
                {
                    for (int j = i + 1; j < n - 2; j++)
                    {
                        if (j > i + 1 && nums[j - 1] == nums[j]) continue;
                        else
                        {
                            int k = j + 1, l = n - 1;
                            while (k < l)
                            {
                                long sum = (long)nums[i] + nums[j] + nums[k] + nums[l];

                                if (sum < target) k++;
                                else if (sum > target) l--;
                                else
                                {
                                    r.Add([nums[i], nums[j], nums[k], nums[l]]);
                                    while (k < l && nums[k] == nums[k + 1]) k++;
                                    while (k < l && nums[l] == nums[l - 1]) l--;
                                    k++;
                                    l--;
                                }
                            }
                        }
                    }
                }
            }

            return r;
        }
    }
}
