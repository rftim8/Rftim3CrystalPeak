namespace Rftim3LeetCode.Temp
{
    public class _01732_FindTheHighestAltitude
    {
        /// <summary>
        /// There is a biker going on a road trip. 
        /// The road trip consists of n + 1 points at different altitudes. 
        /// The biker starts his trip on point 0 with altitude equal 0.
        /// You are given an integer array gain of length n where gain[i] is the net gain 
        /// in altitude between points i​​​​​​ and i + 1 for all(0 <= i<n). 
        /// Return the highest altitude of a point.
        /// </summary>
        public _01732_FindTheHighestAltitude()
        {
            Console.WriteLine(FindTheHighestAltitude0([-5, 1, 5, 0, -7]));
            Console.WriteLine(FindTheHighestAltitude0([-4, -3, -2, -1, 4, 3, 2]));
        }

        public static int FindTheHighestAltitude0(int[] a0) => RftFindTheHighestAltitude0(a0);

        public static int FindTheHighestAltitude1(int[] a0) => RftFindTheHighestAltitude1(a0);

        private static int RftFindTheHighestAltitude0(int[] gain)
        {
            int n = gain.Length;

            int r = Math.Max(0, gain[0]);
            for (int i = 1; i < n; i++)
            {
                gain[i] += gain[i - 1];
                r = Math.Max(r, gain[i]);
            }

            return r;
        }

        private static int RftFindTheHighestAltitude1(int[] gain)
        {
            if (gain is null) return 0;

            int n = gain.Length;
            int[] alt = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                alt[i] = alt[i - 1] + gain[i - 1];
            }

            return alt.Max();
        }
    }
}