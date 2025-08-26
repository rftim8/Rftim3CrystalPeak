namespace Rftim3LeetCode.Temp
{
    public class _00136_SingleNumber
    {
        /// <summary>
        /// Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
        /// You must implement a solution with a linear runtime complexity and use only constant extra space.
        /// </summary>
        public _00136_SingleNumber()
        {
            Console.WriteLine(SingleNumber0([2, 2, 1]));
            Console.WriteLine(SingleNumber0([4, 1, 2, 1, 2]));
            Console.WriteLine(SingleNumber0([1]));
        }

        public static int SingleNumber0(int[] a0) => RftSingleNumber0(a0);

        public static int SingleNumber1(int[] a0) => RftSingleNumber1(a0);

        private static int RftSingleNumber0(int[] nums)
        {
            int res = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                res ^= nums[i];
            }

            return res;
        }

        private static int RftSingleNumber1(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return nums[0];

            for (int i = 0; i < n; i++)
            {
                if (nums[i] != int.MaxValue)
                {
                    int c = 0;
                    for (int j = i + 1; j < n; j++)
                    {
                        Console.WriteLine($"{nums[i]} {nums[j]}");
                        if (nums[i] == nums[j])
                        {
                            nums[i] = int.MaxValue;
                            nums[j] = int.MaxValue;
                            c++;
                            break;
                        }
                    }
                    if (c == 0) return nums[i];
                }
            }

            return 0;
        }
    }
}
