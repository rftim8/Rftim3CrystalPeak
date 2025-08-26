using Rftim3Convoy.Temp.Construct.Terminal;
using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00179_LargestNumber
    {
        /// <summary>
        /// Given a list of non-negative integers nums, arrange them such that they form the largest number and return it.
        /// Since the result may be very large, so you need to return a string instead of an integer.
        /// </summary>
        public _00179_LargestNumber()
        {
            Console.WriteLine(LargestNumber([10, 2]));
            Console.WriteLine(LargestNumber([3, 30, 34, 5, 9]));
            Console.WriteLine(LargestNumber([432, 43243]));
            Console.WriteLine(LargestNumber([111311, 1113]));
            Console.WriteLine(LargestNumber([0, 0]));
            Console.WriteLine(LargestNumber([1000000000, 1000000000]));
        }

        private static string LargestNumber(int[] nums)
        {
            RftTerminal.RftReadResult(nums);
            int n = nums.Length;

            for (int i = 1; i < n; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (ulong.Parse($"{nums[j]}{nums[j - 1]}") > ulong.Parse($"{nums[j - 1]}{nums[j]}")) (nums[j], nums[j - 1]) = (nums[j - 1], nums[j]);
                    j--;
                }
            }

            return nums.Count(o => o == 0) == nums.Length ? "0" : string.Concat(nums);
        }

        public static string LargestNumber0(int[] nums)
        {
            List<string> values = [];
            foreach (int num in nums)
            {
                values.Add(num.ToString());
            }

            values.Sort((o1, o2) => (o2 + o1).CompareTo(o1 + o2));

            if (values.Count > 0 && values[0] == "0") return "0";

            StringBuilder builder = new();
            values.ForEach(v => builder.Append(v));

            return builder.ToString();
        }
    }
}
