namespace Rftim3LeetCode.Temp
{
    public class _01342_NumberOfStepsToReduceANumberToZero
    {
        /// <summary>
        /// Given an integer num, return the number of steps to reduce it to zero.
        /// In one step, if the current number is even, you have to divide it by 2, otherwise, you have to subtract 1 from it.
        /// </summary>
        public _01342_NumberOfStepsToReduceANumberToZero()
        {
            Console.WriteLine(NumberOfStepsToReduceANumberToZero0(14));
            Console.WriteLine(NumberOfStepsToReduceANumberToZero0(8));
            Console.WriteLine(NumberOfStepsToReduceANumberToZero0(123));
        }

        public static int NumberOfStepsToReduceANumberToZero0(int a0) => RftNumberOfStepsToReduceANumberToZero0(a0);

        private static int RftNumberOfStepsToReduceANumberToZero0(int num)
        {
            int c = 0;
            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                    c++;
                }
                else
                {
                    num--;
                    c++;
                }
            }

            return c;
        }
    }
}