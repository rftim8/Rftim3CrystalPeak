namespace Rftim3LeetCode.Temp
{
    public class _00006_ZigzagConversion
    {
        /// <summary>
        /// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)
        /// P A   H N
        /// A P L S I I G
        /// Y   I R
        /// And then read line by line: "PAHNAPLSIIGYIR"
        /// Write the code that will take a string and make this conversion given a number of rows:
        /// string convert(string s, int numRows);
        /// </summary>
        public _00006_ZigzagConversion()
        {
            Console.WriteLine(ZigzagConversion0("PAYPALISHIRING", 3));
            Console.WriteLine(ZigzagConversion0("PAYPALISHIRING", 4));
            Console.WriteLine(ZigzagConversion0("A", 1));
            Console.WriteLine(ZigzagConversion0("AB", 1));
        }

        public static string ZigzagConversion0(string a0, int a1) => RftZigzagConversion0(a0, a1);

        public static string ZigzagConversion1(string a0, int a1) => RftZigzagConversion1(a0, a1);

        private static string RftZigzagConversion0(string s, int numRows)
        {
            int n = s.Length;
            string r = "";

            List<List<char>> x = [];
            for (int i = 0; i < numRows; i++)
            {
                x.Add([]);
            }

            int c = 0;
            bool up = true;
            for (int j = 0; j < n; j++)
            {
                x[c].Add(s[j]);
                if (up)
                {
                    c++;
                    if (c == numRows - 1) up = false;
                    if (c > numRows - 1) c--;
                }
                else
                {
                    c--;
                    if (c == 0) up = true;
                    if (c < 0) c++;
                }
            }

            foreach (List<char> item in x)
            {
                r += string.Concat(item);
            }

            return r;
        }

        private static string RftZigzagConversion1(string s, int numRows)
        {
            if (numRows == 1) return s;

            string[] rows = new string[numRows];
            int x = 0;
            int row = 0;
            int rowAdjust = 1;

            for (int i = 0; i < numRows; i++)
            {
                rows[i] = "";
            }

            while (x < s.Length)
            {
                rows[row] += s[x];
                row += rowAdjust;

                if (row.Equals(numRows - 1) || row.Equals(0)) rowAdjust *= -1;

                x++;
            }

            return string.Join("", rows);
        }
    }
}