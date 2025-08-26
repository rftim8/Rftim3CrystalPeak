namespace Rftim3LeetCode.Temp
{
    public class _02103_RingsAndRods
    {
        /// <summary>
        /// There are n rings and each ring is either red, green, or blue. 
        /// The rings are distributed across ten rods labeled from 0 to 9.
        /// You are given a string rings of length 2n that describes the n rings that are placed onto the rods.
        /// Every two characters in rings forms a color-position pair that is used to describe each ring where:
        /// The first character of the ith pair denotes the ith ring's color ('R', 'G', 'B').
        /// The second character of the ith pair denotes the rod that the ith ring is placed on ('0' to '9').
        /// For example, "R3G2B1" describes n == 3 rings: a red ring placed onto the rod labeled 3, a green ring placed onto the rod labeled 2, 
        /// and a blue ring placed onto the rod labeled 1.
        /// Return the number of rods that have all three colors of rings on them.
        /// </summary>
        public _02103_RingsAndRods()
        {
            Console.WriteLine(RingsAndRods0("B0B6G0R6R0R6G9"));
            Console.WriteLine(RingsAndRods0("B0R0G0R9R0B0G0"));
            Console.WriteLine(RingsAndRods0("G4"));
        }

        public static int RingsAndRods0(string a0) => RftRingsAndRods0(a0);

        private static int RftRingsAndRods0(string rings)
        {
            Dictionary<int, HashSet<char>> r = [];

            for (int i = 1; i < rings.Length; i += 2)
            {
                if (!r.ContainsKey(rings[i])) r.Add(rings[i], []);
                r[rings[i]].Add(rings[i - 1]);
            }

            return r.Where(o => o.Value.Count == 3).Count();
        }
    }
}