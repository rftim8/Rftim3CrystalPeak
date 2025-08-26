namespace Rftim3LeetCode.Temp
{
    public class _01742_MaximumNumberOfBallsInABox
    {
        /// <summary>
        /// You are working in a ball factory where you have n balls numbered from lowLimit up to highLimit inclusive (i.e., n == highLimit - lowLimit + 1), 
        /// and an infinite number of boxes numbered from 1 to infinity.
        /// Your job at this factory is to put each ball in the box with a number equal to the sum of digits of the ball's number.
        /// For example, the ball number 321 will be put in the box number 3 + 2 + 1 = 6 and the ball number 10 will be put in the box number 1 + 0 = 1.
        /// Given two integers lowLimit and highLimit, return the number of balls in the box with the most balls.
        /// </summary>
        public _01742_MaximumNumberOfBallsInABox()
        {
            Console.WriteLine(CountBalls(1, 10));
            Console.WriteLine(CountBalls(5, 15));
            Console.WriteLine(CountBalls(19, 28));
        }

        private static int CountBalls(int lowLimit, int highLimit)
        {
            int[] boxIndexs = new int[highLimit];

            int r = 0;
            for (int i = lowLimit; i <= highLimit; i++)
            {
                int t = i;
                int boxIndex = 0;
                while (t > 0)
                {
                    int digit = t % 10;
                    boxIndex += digit;
                    t /= 10;
                }

                boxIndexs[boxIndex]++;
                r = Math.Max(r, boxIndexs[boxIndex]);
            }

            return r;
        }
    }
}
