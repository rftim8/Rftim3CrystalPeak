namespace Rftim3LeetCode.Temp
{
    public class _01422_MaximumScoreAfterSplittingAString
    {
        /// <summary>
        /// Given a string s of zeros and ones, return the maximum score after splitting the string 
        /// into two non-empty substrings (i.e. left substring and right substring).
        /// The score after splitting a string is the number of zeros in the left substring 
        /// plus the number of ones in the right substring.
        /// </summary>
        public _01422_MaximumScoreAfterSplittingAString()
        {
            Console.WriteLine(MaximumScoreAfterSplittingAString0("011101"));
            Console.WriteLine(MaximumScoreAfterSplittingAString0("00111"));
            Console.WriteLine(MaximumScoreAfterSplittingAString0("1111"));
        }

        public static int MaximumScoreAfterSplittingAString0(string a0) => RftMaximumScoreAfterSplittingAString0(a0);

        public static int MaximumScoreAfterSplittingAString1(string a0) => RftMaximumScoreAfterSplittingAString1(a0);

        private static int RftMaximumScoreAfterSplittingAString0(string s)
        {
            HashSet<int> x = [];
            for (int i = 0; i < s.Length - 1; i++)
            {
                int l = s[..(i + 1)].Select(o => o).Where(o => o == '0').Count();
                int r = s[(i + 1)..].Select(o => o).Where(o => o == '1').Count();
                x.Add(l + r);
            }

            return x.Max();
        }

        private static int RftMaximumScoreAfterSplittingAString1(string s)
        {
            int zeroCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0') zeroCount++;
            }

            int oneCount = s.Length - zeroCount;
            int result, leftZero, rightOne;
            if (s[0] == '0')
            {
                leftZero = 1;
                rightOne = oneCount;
            }
            else
            {
                leftZero = 0;
                rightOne = oneCount - 1;
            }

            result = leftZero + rightOne;
            for (int i = 1; i < s.Length - 1; i++)
            {
                if (s[i] == '0') leftZero++;
                if (s[i] == '1') rightOne--;

                result = Math.Max(result, rightOne + leftZero);
            }

            return result;
        }
    }
}