namespace Rftim3LeetCode.Temp
{
    public class _01295_FindNumbersWithEvenNumberOfDigits
    {
        /// <summary>
        /// Given an array nums of integers, return how many of them contain an even number of digits.
        /// </summary>
        public _01295_FindNumbersWithEvenNumberOfDigits()
        {
            Console.WriteLine(FindNumbers([12, 345, 2, 6, 7896]));
        }

        private static int FindNumbers(int[] nums)
        {
            int c = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i].ToString().Length % 2 == 0) c++;
            }

            return c;
        }
    }
}
