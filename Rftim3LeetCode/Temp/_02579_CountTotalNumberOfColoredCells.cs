namespace Rftim3LeetCode.Temp
{
    public class _02579_CountTotalNumberOfColoredCells
    {
        /// <summary>
        /// There exists an infinitely large two-dimensional grid of uncolored unit cells. 
        /// You are given a positive integer n, indicating that you must do the following routine for n minutes:
        /// At the first minute, color any arbitrary unit cell blue.
        /// Every minute thereafter, color blue every uncolored cell that touches a blue cell.
        /// Below is a pictorial representation of the state of the grid after minutes 1, 2, and 3.
        /// </summary>
        public _02579_CountTotalNumberOfColoredCells()
        {
            Console.WriteLine(ColoredCells(1));
            Console.WriteLine(ColoredCells(69675)); // 9709071901
        }

        private static long ColoredCells(int n)
        {
            long c = 1;
            if (n == 1) return 1;

            for (int i = 1; i < n; i++)
            {
                c += 2 * (i + 1) + 2 * (i + 1 - 2);
            }

            return c;
        }
    }
}
