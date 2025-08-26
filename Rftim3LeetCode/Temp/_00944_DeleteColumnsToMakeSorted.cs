namespace Rftim3LeetCode.Temp
{
    public class _00944_DeleteColumnsToMakeSorted
    {
        /// <summary>
        /// You are given an array of n strings strs, all of the same length.
        /// The strings can be arranged such that there is one on each line, making a grid.
        /// For example, strs = ["abc", "bce", "cae"] can be arranged as follows:
        /// abc
        /// bce
        /// cae
        /// You want to delete the columns that are not sorted lexicographically. 
        /// In the above example (0-indexed), columns 0 ('a', 'b', 'c') and 2 ('c', 'e', 'e') are sorted, 
        /// while column 1 ('b', 'c', 'a') is not, so you would delete column 1.
        /// Return the number of columns that you will delete.
        /// </summary>
        public _00944_DeleteColumnsToMakeSorted()
        {
            Console.WriteLine(DeleteColumnsToMakeSorted0(["cba", "daf", "ghi"]));
            Console.WriteLine(DeleteColumnsToMakeSorted0(["a", "b"]));
            Console.WriteLine(DeleteColumnsToMakeSorted0(["zyx", "wvu", "tsr"]));
        }

        public static int DeleteColumnsToMakeSorted0(string[] a0) => RftDeleteColumnsToMakeSorted0(a0);

        public static int DeleteColumnsToMakeSorted1(string[] a0) => RftDeleteColumnsToMakeSorted1(a0);

        private static int RftDeleteColumnsToMakeSorted0(string[] strs)
        {
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            int n = strs.Length;
            int m = strs[0].Length;

            int r = 0;

            int j = 0;
            while (j < m)
            {
                for (int i = 1; i < n; i++)
                {
                    if (alpha.IndexOf(strs[i - 1][j]) > alpha.IndexOf(strs[i][j]))
                    {
                        r++;
                        break;
                    }
                }

                j++;
            }

            return r;
        }

        private static int RftDeleteColumnsToMakeSorted1(string[] strs)
        {
            int count = 0;

            for (int i = 0; i < strs[0].Length; i++)
            {
                int rowNumber = i;
                int columnNumber = 0;
                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[columnNumber][rowNumber] > strs[j][rowNumber])
                    {
                        count++;
                        j = strs.Length;
                    }
                    else columnNumber++;
                }
            }

            return count;
        }
    }
}