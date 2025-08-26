namespace Rftim3LeetCode.Temp
{
    public class _00319_BulbSwitcher
    {
        /// <summary>
        /// There are n bulbs that are initially off. You first turn on all the bulbs, then you turn off every second bulb.
        /// On the third round, you toggle every third bulb(turning on if it's off or turning off if it's on). 
        /// For the ith round, you toggle every i bulb.For the nth round, you only toggle the last bulb.
        /// Return the number of bulbs that are on after n rounds.
        /// </summary>
        public _00319_BulbSwitcher()
        {
            Console.WriteLine(BulbSwitch(4));
            Console.WriteLine(BulbSwitch(3));
            Console.WriteLine(BulbSwitch(2));
            Console.WriteLine(BulbSwitch(0));
            Console.WriteLine(BulbSwitch(1));
            Console.WriteLine(BulbSwitch(99999));
        }

        private static int BulbSwitch(int n)
        {
            return (int)Math.Sqrt(n);
        }

        private static int BulbSwitch0(int n)
        {
            if (n == 1) return 1;
            bool[] x = new bool[n + 1];
            Array.Fill(x, false);

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (j % i == 0)
                    {
                        if (x[j] == true) x[j] = false;
                        else x[j] = true;
                    }
                }
            }

            return x.Count(o => o == true);
        }
    }
}
