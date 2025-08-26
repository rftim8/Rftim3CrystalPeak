namespace Rftim3LeetCode.Temp
{
    public class _01921_EliminateMaximumNumberOfMonsters
    {
        /// <summary>
        /// You are playing a video game where you are defending your city from a group of n monsters. 
        /// You are given a 0-indexed integer array dist of size n, where dist[i] is the initial distance in kilometers of the ith monster from the city.
        /// 
        /// The monsters walk toward the city at a constant speed.The speed of each monster is given to you in an integer array speed of size n, 
        /// where speed[i] is the speed of the ith monster in kilometers per minute.
        /// 
        /// You have a weapon that, once fully charged, can eliminate a single monster.However, the weapon takes one minute to charge.
        /// The weapon is fully charged at the very start.
        /// 
        /// You lose when any monster reaches your city. If a monster reaches the city at the exact moment the weapon is fully charged,
        /// it counts as a loss, and the game ends before you can use your weapon.
        /// 
        /// Return the maximum number of monsters that you can eliminate before you lose, or n if you can eliminate all the monsters before they reach the city.
        /// </summary>
        public _01921_EliminateMaximumNumberOfMonsters()
        {
            int x = EliminateMaximum0([1, 3, 4], [1, 1, 1]);
            Console.WriteLine(x);

            int x0 = EliminateMaximum0([1, 1, 2, 3], [1, 1, 1, 1]);
            Console.WriteLine(x0);

            int x1 = EliminateMaximum0([3, 2, 4], [5, 3, 2]);
            Console.WriteLine(x1);

            int x2 = EliminateMaximum0([4, 2, 8], [2, 1, 4]);
            Console.WriteLine(x2); // 2

            int x3 = EliminateMaximum0([3, 5, 7, 4, 5], [2, 3, 6, 3, 2]);
            Console.WriteLine(x3); // 2
        }

        public static int EliminateMaximum0(int[] a0, int[] a1) => RftEliminateMaximum0(a0, a1);

        public static int EliminateMaximum1(int[] a0, int[] a1) => RftEliminateMaximum1(a0, a1);

        private static int RftEliminateMaximum0(int[] dist, int[] speed)
        {
            double[] arrival = new double[dist.Length];
            for (int i = 0; i < dist.Length; i++)
            {
                arrival[i] = (double)dist[i] / speed[i];
            }

            Array.Sort(arrival);
            int ans = 0;

            for (int i = 0; i < arrival.Length; i++)
            {
                if (arrival[i] <= i) break;

                ans++;
            }

            return ans;
        }

        private static int RftEliminateMaximum1(int[] distances, int[] speeds)
        {
            int[] arrivalTimes = new int[distances.Length];

            for (int i = 0; i < arrivalTimes.Length; i++)
            {
                arrivalTimes[i] = Math.DivRem(distances[i], speeds[i], out int remainder);
                if (remainder > 0) arrivalTimes[i]++;
            }

            Array.Sort(arrivalTimes);

            for (int i = 0; i < arrivalTimes.Length; i++)
            {
                int shotTime = i;
                if (shotTime >= arrivalTimes[i]) return i;
            }

            return arrivalTimes.Length;
        }
    }
}
