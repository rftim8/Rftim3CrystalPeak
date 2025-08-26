namespace Rftim3LeetCode.Temp
{
    public class _02367_NumberOfArithmeticTriplets
    {
        /// <summary>
        /// You are given a 0-indexed, strictly increasing integer array nums and a positive integer diff. 
        /// A triplet (i, j, k) is an arithmetic triplet if the following conditions are met:
        /// i<j<k,
        /// nums[j] - nums[i] == diff, and
        /// nums[k] - nums[j] == diff.
        /// Return the number of unique arithmetic triplets.
        /// </summary>
        public _02367_NumberOfArithmeticTriplets()
        {
            Console.WriteLine(ArithmeticTriplets([0, 1, 4, 6, 7, 10], 3));
            Console.WriteLine(ArithmeticTriplets([4, 5, 6, 7, 8, 9], 2));
        }

        private static int ArithmeticTriplets(int[] nums, int diff)
        {
            int n = nums.Length;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[i] + diff == nums[j])
                    {
                        for (int k = j + 1; k < n; k++)
                        {
                            if (nums[j] + diff == nums[k]) c++;
                        }
                    }
                }
            }

            return c;
        }

        private static int ArithmeticTriplets0(int[] nums, int diff)
        {
            int triplets = 0;

            for (int i = nums.Length - 1; i >= 2; i--)
            {
                if (nums.Contains(nums[i] - diff) && nums.Contains(nums[i] - diff - diff)) triplets++;
            }

            return triplets;
        }
    }
}
