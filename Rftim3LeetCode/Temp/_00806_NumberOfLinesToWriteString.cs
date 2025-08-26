using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00806_NumberOfLinesToWriteString
    {
        /// <summary>
        /// You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. 
        /// Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        /// You are trying to write s across several lines, where each line is no longer than 100 pixels.
        /// Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels.
        /// Then, from where you stopped in s, continue writing as many letters as you can on the second line.
        /// Continue this process until you have written all of s.
        /// Return an array result of length 2 where:
        /// result[0] is the total number of lines.
        /// result[1] is the width of the last line in pixels.
        /// </summary>
        public _00806_NumberOfLinesToWriteString()
        {
            int[] x = NumberOfLinesToWriteString0(
                [10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10],
                "abcdefghijklmnopqrstuvwxyz"
            );
            RftTerminal.RftReadResult(x);

            int[] x0 = NumberOfLinesToWriteString0(
                [4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10],
                "bbbcccdddaaa"
            );
            RftTerminal.RftReadResult(x0);
        }

        public static int[] NumberOfLinesToWriteString0(int[] a0, string a1) => RftNumberOfLinesToWriteString0(a0, a1);

        private static int[] RftNumberOfLinesToWriteString0(int[] widths, string s)
        {
            int lines = 1, width = 0;
            foreach (char c in s.ToCharArray())
            {
                int w = widths[c - 'a'];
                width += w;
                if (width > 100)
                {
                    lines++;
                    width = w;
                }
            }

            return [lines, width];
        }
    }
}