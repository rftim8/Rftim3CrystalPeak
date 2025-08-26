namespace Rftim3LeetCode.Temp
{
    public class _02283_CheckIfNumberHasEqualDigitCountAndDigitValue
    {
        /// <summary>
        /// You are given a 0-indexed string num of length n consisting of digits.
        /// Return true if for every index i in the range 0 <= i<n, the digit i occurs num[i] times in num, otherwise return false.
        /// </summary>
        public _02283_CheckIfNumberHasEqualDigitCountAndDigitValue()
        {
            Console.WriteLine(DigitCount("1210"));
            Console.WriteLine(DigitCount("030"));
        }

        private static bool DigitCount(string num)
        {
            int n = num.Length;

            for (int i = 0; i < n; i++)
            {
                if (int.Parse(num[i].ToString()) != num.Split($"{i}").Length - 1) return false;
            }

            return true;
        }
    }
}
