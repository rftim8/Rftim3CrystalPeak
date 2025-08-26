namespace Rftim3LeetCode.Temp
{
    public class _01046_LastStoneWeight
    {
        /// <summary>
        /// You are given an array of integers stones where stones[i] is the weight of the ith stone.
        /// We are playing a game with the stones.On each turn, we choose the heaviest two stones and smash them together. 
        /// Suppose the heaviest two stones have weights x and y with x <= y.The result of this smash is:
        /// If x == y, both stones are destroyed, and
        /// If x != y, the stone of weight x is destroyed, and the stone of weight y has new weight y - x.
        /// At the end of the game, there is at most one stone left.
        /// Return the weight of the last remaining stone.If there are no stones left, return 0.
        /// </summary>
        public _01046_LastStoneWeight()
        {
            Console.WriteLine(LastStoneWeight([2, 7, 4, 1, 8, 1]));
            Console.WriteLine(LastStoneWeight([1]));
        }

        private static int LastStoneWeight(int[] stones)
        {
            List<int> x = [.. stones];
            x.Sort();

            while (x.Count > 1)
            {
                if (x[^1] == x[^2]) x.RemoveRange(x.Count - 2, 2);
                else
                {
                    x[^1] = x[^1] - x[^2];
                    x.RemoveAt(x.Count - 2);
                }
                x.Sort();
            }

            return x.Count > 0 ? x[0] : 0;
        }
    }
}
