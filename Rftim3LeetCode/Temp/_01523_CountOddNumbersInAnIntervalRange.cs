namespace Rftim3LeetCode.Temp
{
    public class _01523_CountOddNumbersInAnIntervalRange
    {
        /// <summary>
        /// Given two non-negative integers low and high. Return the count of odd numbers between low and high (inclusive).
        /// </summary>
        public _01523_CountOddNumbersInAnIntervalRange()
        {
            Console.WriteLine(CountOdds(3, 7));
            Console.WriteLine(CountOdds(8, 10));
            Console.WriteLine(CountOdds(0, 10));
        }

        private static int CountOdds(int low, int high)
        {
            bool l = low % 2 == 0;
            bool r = high % 2 == 0;

            if (l && r) return (high - low) / 2;
            else return (high - low) / 2 + 1;
        }
    }
}
