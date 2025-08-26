using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01317_ConvertIntegerToTheSumOfTwoNoZeroIntegers
    {
        /// <summary>
        /// No-Zero integer is a positive integer that does not contain any 0 in its decimal representation.
        /// Given an integer n, return a list of two integers[a, b] where:
        /// a and b are No-Zero integers.
        /// a + b = n
        /// The test cases are generated so that there is at least one valid solution.If there are many valid solutions, you can return any of them.
        /// </summary>
        public _01317_ConvertIntegerToTheSumOfTwoNoZeroIntegers()
        {
            int[] x = GetNoZeroIntegers(2);
            int[] x0 = GetNoZeroIntegers(11);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] GetNoZeroIntegers(int n)
        {
            for (int i = 1; i < n; i++)
            {
                if (!i.ToString().Contains('0') && !(n - i).ToString().Contains('0')) return [i, n - i];
            }

            return [];
        }
    }
}
