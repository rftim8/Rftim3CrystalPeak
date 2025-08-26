namespace Rftim3LeetCode.Temp
{
    public class _01748_SumOfUniqueElements
    {
        /// <summary>
        /// You are given an integer array nums. The unique elements of an array are the elements that appear exactly once in the array.
        /// Return the sum of all the unique elements of nums.
        /// </summary>
        public _01748_SumOfUniqueElements()
        {
            Console.WriteLine(SumOfUnique([1, 2, 3, 2]));
            Console.WriteLine(SumOfUnique([1, 1, 1, 1]));
            Console.WriteLine(SumOfUnique([1, 2, 3, 4, 5]));
        }

        private static int SumOfUnique(int[] nums)
        {
            Dictionary<int, int> r = [];

            for (int i = 0; i < nums.Length; i++)
            {
                if (r.TryGetValue(nums[i], out int value)) r[nums[i]] = ++value;
                else r[nums[i]] = 1;
            }

            return r.Where(o => o.Value == 1).Sum(o => o.Key);
        }

        private static int SumOfUnique0(int[] nums)
        {

            bool isUnique = true;
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j & nums[i] == nums[j]) isUnique = false;
                }
                if (isUnique == true) sum += nums[i];

                isUnique = true;
            }

            return sum;
        }
    }
}
