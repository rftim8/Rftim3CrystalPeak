using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02194_CellsInARangeOnAnExcelSheet
    {
        /// <summary>
        /// A cell (r, c) of an excel sheet is represented as a string "<col><row>" where:
        /// <col> denotes the column number c of the cell.It is represented by alphabetical letters.
        /// For example, the 1st column is denoted by 'A', the 2nd by 'B', the 3rd by 'C', and so on.
        /// <row> is the row number r of the cell.The rth row is represented by the integer r.
        /// You are given a string s in the format "<col1><row1>:<col2><row2>", where<col1> represents the column c1, 
        /// <row1> represents the row r1, <col2> represents the column c2, and<row2> represents the row r2, such that r1 <= r2 and c1 <= c2.
        /// Return the list of cells (x, y) such that r1 <= x <= r2 and c1 <= y <= c2.
        /// The cells should be represented as strings in the format mentioned above and be sorted in non-decreasing order first by columns and then by rows.
        /// </summary>
        public _02194_CellsInARangeOnAnExcelSheet()
        {
            IList<string> x = CellsInRange("K1:L2");
            RftTerminal.RftReadResult(x);
            IList<string> x0 = CellsInRange("A1:F1");
            RftTerminal.RftReadResult(x0);
        }

        private static List<string> CellsInRange(string s)
        {
            int min = int.Parse(s.Split(':')[0][1].ToString());
            char minc = s.Split(':')[0][0];
            int max = int.Parse(s.Split(':')[1][1].ToString());
            char maxc = s.Split(':')[1][0];

            List<string> r = [];
            for (int j = minc; j <= maxc; j++)
            {
                for (int i = min; i <= max; i++)
                {
                    r.Add($"{(char)j}{i}");
                }
            }

            return r;
        }
    }
}
