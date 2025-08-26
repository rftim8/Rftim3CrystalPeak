namespace Rftim3LeetCode.Temp
{
    public class _00070_ClimbingStairs
    {
        /// <summary>
        /// You are climbing a staircase. It takes n steps to reach the top.
        /// Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
        /// </summary>
        public _00070_ClimbingStairs()
        {
            Console.WriteLine(ClimbStairs0(2));
            Console.WriteLine(ClimbStairs0(3));
        }

        public static int ClimbStairs0(int a0) => RftClimbStairs0(a0);

        private static int RftClimbStairs0(int n)
        {
            int f0 = 0, f1 = 1, f2 = 1;

            for (int i = 2; i <= n + 1; i++)
            {
                f2 = f1 + f0;
                f0 = f1;
                f1 = f2;
            }

            return f2;
        }
    }
}
