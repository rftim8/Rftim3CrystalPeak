namespace Rftim3LeetCode.Temp
{
    public class _00495_TeemoAttacking
    {
        /// <summary>
        /// Our hero Teemo is attacking an enemy Ashe with poison attacks! 
        /// When Teemo attacks Ashe, Ashe gets poisoned for a exactly duration seconds.
        /// More formally, an attack at second t will mean Ashe is poisoned during the inclusive time interval [t, t + duration - 1]. 
        /// If Teemo attacks again before the poison effect ends, the timer for it is reset, and the poison effect will end duration seconds after the new attack.
        /// You are given a non-decreasing integer array timeSeries, where timeSeries[i] denotes that Teemo attacks Ashe at second timeSeries[i], and an integer duration.
        /// Return the total number of seconds that Ashe is poisoned.
        /// </summary>
        public _00495_TeemoAttacking()
        {
            Console.WriteLine(FindPoisonedDuration0([1, 4], 2));
            Console.WriteLine(FindPoisonedDuration0([1, 2], 2));
        }

        public static int FindPoisonedDuration0(int[] a0, int a1) => RftFindPoisonedDuration0(a0, a1);

        public static int FindPoisonedDuration1(int[] a0, int a1) => RftFindPoisonedDuration1(a0, a1);

        private static int RftFindPoisonedDuration0(int[] timeSeries, int duration)
        {
            int r = 0;
            int n = timeSeries.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < duration; j++)
                {
                    if (i < n - 1)
                    {
                        if (timeSeries[i] + j < timeSeries[i + 1]) r++;
                        else break;
                    }
                    else r++;
                }
            }

            return r;
        }

        private static int RftFindPoisonedDuration1(int[] timeSeries, int duration)
        {
            int total = 0;

            for (int i = 0; i < timeSeries.Length - 1; i++)
            {
                int timeInterval = timeSeries[i + 1] - timeSeries[i];

                if (timeInterval > duration) total += duration;
                else total += timeInterval;
            }

            return total + duration;
        }
    }
}
