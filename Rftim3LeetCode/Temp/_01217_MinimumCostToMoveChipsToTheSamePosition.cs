namespace Rftim3LeetCode.Temp
{
    public class _01217_MinimumCostToMoveChipsToTheSamePosition
    {
        /// <summary>
        /// We have n chips, where the position of the ith chip is position[i].
        /// We need to move all the chips to the same position.
        /// In one step, we can change the position of the ith chip from position[i] to:
        /// position[i] + 2 or position[i] - 2 with cost = 0.
        /// position[i] + 1 or position[i] - 1 with cost = 1.
        /// Return the minimum cost needed to move all the chips to the same position.
        /// </summary>
        public _01217_MinimumCostToMoveChipsToTheSamePosition()
        {
            Console.WriteLine(MinimumCostToMoveChipsToTheSamePosition0([1, 2, 3]));
            Console.WriteLine(MinimumCostToMoveChipsToTheSamePosition0([2, 2, 2, 3, 3]));
            Console.WriteLine(MinimumCostToMoveChipsToTheSamePosition0([1, 1000000000]));
        }

        public static int MinimumCostToMoveChipsToTheSamePosition0(int[] a0) => RftMinimumCostToMoveChipsToTheSamePosition0(a0);

        private static int RftMinimumCostToMoveChipsToTheSamePosition0(int[] position)
        {
            int even = 0, odd = 0;
            for (int i = 0; i < position.Length; i++)
            {
                if (position[i] % 2 == 0) even++;
                else odd++;
            }

            return Math.Min(even, odd);
        }
    }
}