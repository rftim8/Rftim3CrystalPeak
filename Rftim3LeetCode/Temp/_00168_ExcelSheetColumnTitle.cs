using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00168_ExcelSheetColumnTitle
    {
        /// <summary>
        /// Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.
        /// </summary>
        public _00168_ExcelSheetColumnTitle()
        {
            Console.WriteLine(ConvertToTitle0(1));
            Console.WriteLine(ConvertToTitle0(28));
            Console.WriteLine(ConvertToTitle0(701));
        }

        public static string ConvertToTitle0(int a0) => RftConvertToTitle0(a0);

        public static string ConvertToTitle1(int a0) => RftConvertToTitle1(a0);

        private static string RftConvertToTitle0(int columnNumber)
        {
            Stack<char> s = new();
            StringBuilder x = new();

            while (columnNumber != 0)
            {
                columnNumber--;

                s.Push((char)(columnNumber % 26 + 'A'));
                columnNumber /= 26;
            }

            while (s.Count != 0)
            {
                x.Append(s.Pop());
            }

            return x.ToString();
        }

        private static string RftConvertToTitle1(int columnNumber)
        {
            StringBuilder sb = new();

            while (columnNumber-- > 0)
            {
                char c = (char)(columnNumber % 26 + 'A');

                sb.Append(c);

                columnNumber /= 26;
            }

            for (int i = 0, j = sb.Length - 1; i < sb.Length / 2; i++, j--)
            {
                (sb[j], sb[i]) = (sb[i], sb[j]);
            }

            return sb.ToString();
        }
    }
}
