namespace Rftim3LeetCode.Temp
{
    public class _02133_CheckIfEveryRowAndColumnContainsAllNumbers
    {
        /// <summary>
        /// An n x n matrix is valid if every row and every column contains all the integers from 1 to n (inclusive).
        /// Given an n x n integer matrix matrix, return true if the matrix is valid.
        /// Otherwise, return false.
        /// </summary>
        public _02133_CheckIfEveryRowAndColumnContainsAllNumbers()
        {
            Console.WriteLine(CheckValid(
            [
                [1,2,3],
                [3,1,2],
                [2,3,1]
            ]));

            Console.WriteLine(CheckValid(
            [
                [1,1,1],
                [1,2,3],
                [1,2,3]
            ]));
        }

        private static bool CheckValid(int[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;

            HashSet<int> h = Enumerable.Range(1, n).ToHashSet();
            HashSet<int> v = Enumerable.Range(1, n).ToHashSet();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    h.Remove(matrix[i][j]);
                }
                if (h.Count != 0) return false;
                else h = Enumerable.Range(1, n).ToHashSet();
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    v.Remove(matrix[j][i]);
                }
                if (v.Count != 0) return false;
                else v = Enumerable.Range(1, n).ToHashSet();
            }

            return true;
        }

        private static bool CheckValid0(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                HashSet<int> row = [];
                HashSet<int> column = [];

                for (int j = 0; j < matrix.Length; j++)
                {
                    if (!row.Add(matrix[i][j]) || !column.Add(matrix[j][i])) return false;
                }
            }

            return true;
        }
    }
}
