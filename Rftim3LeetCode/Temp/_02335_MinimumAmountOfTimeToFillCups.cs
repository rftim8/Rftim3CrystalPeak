namespace Rftim3LeetCode.Temp
{
    public class _02335_MinimumAmountOfTimeToFillCups
    {
        /// <summary>
        /// You have a water dispenser that can dispense cold, warm, and hot water. 
        /// Every second, you can either fill up 2 cups with different types of water, or 1 cup of any type of water.
        /// You are given a 0-indexed integer array amount of length 3 where amount[0], amount[1], and amount[2] denote the number of cold, warm, 
        /// and hot water cups you need to fill respectively.
        /// Return the minimum number of seconds needed to fill up all the cups.
        /// </summary>
        public _02335_MinimumAmountOfTimeToFillCups()
        {
            Console.WriteLine(FillCups([1, 4, 2]));
            Console.WriteLine(FillCups([5, 4, 4]));
        }

        private static int FillCups(int[] amount)
        {
            List<int> r = [.. amount];

            int c = 0;
            while (r.Count > 0)
            {
                r.RemoveAll(o => o == 0);
                r.Sort();
                if (r.Count > 1)
                {
                    r[^1]--;
                    r[^2]--;
                    c++;
                }
                else if (r.Count > 0)
                {
                    r[^1]--;
                    c++;
                }
            }

            return c;
        }

        private static int FillCups0(int[] amount)
        {
            int max = 0;
            int sum = 0;

            foreach (int x in amount)
            {
                max = Math.Max(x, max);
                sum += x;
            }

            return Math.Max(max, (sum + 1) / 2);
        }
    }
}
