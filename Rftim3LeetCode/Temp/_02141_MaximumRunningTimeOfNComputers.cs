namespace Rftim3LeetCode.Temp
{
    public class _02141_MaximumRunningTimeOfNComputers
    {
        /// <summary>
        /// You have n computers. 
        /// You are given the integer n and a 0-indexed integer array batteries where the ith battery can run a computer for batteries[i] minutes. 
        /// You are interested in running all n computers simultaneously using the given batteries.
        /// <para>
        /// Initially, you can insert at most one battery into each computer.
        /// After that and at any integer time moment, you can remove a battery from a computer and insert another battery any number of times. 
        /// The inserted battery can be a totally new battery or a battery from another computer.
        /// You may assume that the removing and inserting processes take no time.
        /// Note that the batteries cannot be recharged.
        /// </para>
        /// <para>
        /// Return the maximum number of minutes you can run all the n computers simultaneously.
        /// </para>
        /// </summary>

        // Sorting and Prefix Sum
        private static long MaxRunTime(int n, int[] batteries)
        {
            int m = batteries.Length;
            int o = m - n;
            Array.Sort(batteries);
            long extra = 0;
            for (int i = 0; i < o; i++)
            {
                extra += batteries[i];
            }

            int[] live = new int[n];
            Array.Copy(batteries, o, live, 0, n);

            for (int i = 0; i < n - 1; i++)
            {
                if (extra < (long)(i + 1) * (live[i + 1] - live[i])) return live[i] + extra / (i + 1);

                extra -= (long)(i + 1) * (live[i + 1] - live[i]);
            }

            return live[n - 1] + extra / n;
        }

        // BS
        private static long MaxRunTime1(int n, int[] batteries)
        {
            long sumPower = 0;

            foreach (int power in batteries)
            {
                sumPower += power;
            }

            long left = 1, right = sumPower / n;

            while (left < right)
            {
                long target = right - (right - left) / 2;
                long extra = 0;

                foreach (int power in batteries)
                {
                    extra += Math.Min(power, target);
                }

                if (extra >= n * target) left = target;
                else right = target - 1;
            }

            return left;
        }
    }
}
