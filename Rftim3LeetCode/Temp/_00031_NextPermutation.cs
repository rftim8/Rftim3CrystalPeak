using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00031_NextPermutation
    {
        /// <summary>
        /// A permutation of an array of integers is an arrangement of its members into a sequence or linear order.
        /// For example, for arr = [1,2,3], the following are all the permutations of arr: [1,2,3], [1,3,2], [2, 1, 3], [2, 3, 1], [3,1,2], [3,2,1].
        /// The next permutation of an array of integers is the next lexicographically greater permutation of its integer.
        /// More formally, if all the permutations of the array are sorted in one container according to their lexicographical order, 
        /// then the next permutation of that array is the permutation that follows it in the sorted container.
        /// If such arrangement is not possible, the array must be rearranged as the lowest possible order (i.e., sorted in ascending order).
        /// For example, the next permutation of arr = [1, 2, 3] is [1, 3, 2].
        /// Similarly, the next permutation of arr = [2,3,1] is [3,1,2].
        /// While the next permutation of arr = [3, 2, 1] is [1, 2, 3] because [3,2,1] does not have a lexicographical larger rearrangement.
        /// Given an array of integers nums, find the next permutation of nums.
        /// The replacement must be in place and use only constant extra memory.
        /// </summary>
        public _00031_NextPermutation()
        {
            int[] x = NextPermutation0([1, 2, 3]);
            RftTerminal.RftReadResult(x);

            int[] x0 = NextPermutation0([3, 2, 1]);
            RftTerminal.RftReadResult(x0);

            int[] x1 = NextPermutation0([1, 1, 5]);
            RftTerminal.RftReadResult(x1);
        }

        public static int[] NextPermutation0(int[] a0) => RftNextPermutation0(a0);

        private static int[] RftNextPermutation0(int[] nums)
        {
            int n = nums.Length;
            int swap = -1;
            for (int i = n - 2; i >= 0; i--)
            {
                if (nums[i] < nums[i + 1])
                {
                    swap = i;
                    break;
                }
            }

            if (swap == -1)
            {
                Reverse(nums, 0, n - 1);
                return nums;
            }

            for (int i = n - 1; i >= 0; i--)
            {
                if (nums[i] > nums[swap])
                {
                    (nums[i], nums[swap]) = (nums[swap], nums[i]);
                    break;
                }
            }

            Reverse(nums, swap + 1, n - 1);

            return nums;
        }

        private static void Reverse(int[] nums, int k, int l)
        {
            while (k < l)
            {
                (nums[k], nums[l]) = (nums[l], nums[k]);
                k++;
                l--;
            }
        }
    }
}
