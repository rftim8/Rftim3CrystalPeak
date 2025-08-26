namespace Rftim3LeetCode.Temp
{
    public class _02833_FurthestPointFromOrigin
    {
        /// <summary>
        /// You are given a string moves of length n consisting only of characters 'L', 'R', and '_'. 
        /// The string represents your movement on a number line starting from the origin 0.
        /// In the ith move, you can choose one of the following directions:
        /// move to the left if moves[i] = 'L' or moves[i] = '_'
        /// move to the right if moves[i] = 'R' or moves[i] = '_'
        /// Return the distance from the origin of the furthest point you can get to after n moves.
        /// </summary>
        public _02833_FurthestPointFromOrigin()
        {
            Console.WriteLine(FurthestDistanceFromOrigin("L_RL__R"));
            Console.WriteLine(FurthestDistanceFromOrigin("_R__LL_"));
            Console.WriteLine(FurthestDistanceFromOrigin("_______"));
        }

        private static int FurthestDistanceFromOrigin(string moves)
        {
            Dictionary<char, int> r = new()
            {
                { 'L', 0 },
                { 'R', 0 },
                { '_', 0 }
            };
            foreach (char item in moves)
            {
                r[item]++;
            }

            return Math.Abs(r['L'] - r['R']) + r['_'];
        }
    }
}
