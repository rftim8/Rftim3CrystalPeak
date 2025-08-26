namespace Rftim3LeetCode.Temp
{
    public class _00171_ExcelSheetColumnNumber
    {
        /// <summary>
        /// Given a string columnTitle that represents the column title as appears in an Excel sheet, return its corresponding column number.
        /// </summary>
        public _00171_ExcelSheetColumnNumber()
        {
            Console.WriteLine(TitleToNumber0("A"));
            Console.WriteLine(TitleToNumber0("AB"));
            Console.WriteLine(TitleToNumber0("ZY"));
        }

        public static int TitleToNumber0(string a0) => RftTitleToNumber0(a0);

        private static int RftTitleToNumber0(string columnTitle)
        {
            int x = 0;
            foreach (char c in columnTitle)
            {
                int d = c - 'A' + 1;
                x = x * 26 + d;
            }

            return x;
        }
    }
}
