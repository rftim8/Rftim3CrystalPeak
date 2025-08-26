namespace Rftim3LeetCode.Temp
{
    public class _01281_SubtractTheProductAndSumOfDigitsOfAnInteger
    {
        /// <summary>
        /// Given an integer number n, return the difference between the product of its digits and the sum of its digits.
        /// </summary>
        public _01281_SubtractTheProductAndSumOfDigitsOfAnInteger()
        {
            Console.WriteLine(SubtractProductAndSum(234));
            Console.WriteLine(SubtractProductAndSum(4421));
        }

        private static int SubtractProductAndSum(int n)
        {
            int x = 0, y = 1;

            while (n > 0)
            {
                x += n % 10;
                y *= n % 10;
                n /= 10;
            }

            return y - x;
        }
    }
}
