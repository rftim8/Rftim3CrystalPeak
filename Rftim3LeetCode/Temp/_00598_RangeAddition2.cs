namespace Rftim3LeetCode.Temp
{
    public class _00598_RangeAddition2
    {
        /// <summary>
        /// You are given an m x n matrix M initialized with all 0's and an array of operations ops, 
        /// where ops[i] = [ai, bi] means M[x][y] should be incremented by one for all 0 <= x < ai and 0 <= y < bi.
        /// Count and return the number of maximum integers in the matrix after performing all the operations.
        /// </summary>
        public _00598_RangeAddition2()
        {
            Console.WriteLine(MaxCount(
                3,
                3,
                [
                [2,2],
                [3,3]
            ]
            ));

            Console.WriteLine(MaxCount(
                3,
                3,
                [
                [2,2],
                [3,3],
                [3,3],
                [3,3],
                [2,2],
                [3,3],
                [3,3],
                [3,3],
                [2,2],
                [3,3],
                [3,3],
                [3,3]
            ]
            ));

            Console.WriteLine(MaxCount(
                3,
                3,
                []
            ));
        }

        private static int MaxCount(int m, int n, int[][] ops)
        {
            if (ops.Length == 0) return m * n;

            int minx = ops.Min(o => o[0]);
            int miny = ops.Min(o => o[1]);

            return minx * miny;
        }
    }
}
