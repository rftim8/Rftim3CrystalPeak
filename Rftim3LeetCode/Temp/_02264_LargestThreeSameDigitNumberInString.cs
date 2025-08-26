namespace Rftim3LeetCode.Temp
{
    public class _02264_LargestThreeSameDigitNumberInString
    {
        /// <summary>
        /// You are given a string num representing a large integer. 
        /// An integer is good if it meets the following conditions:
        /// It is a substring of num with length 3.
        /// It consists of only one unique digit.
        /// Return the maximum good integer as a string or an empty string "" if no such integer exists.
        /// Note:
        /// A substring is a contiguous sequence of characters within a string.
        /// There may be leading zeroes in num or a good integer.
        /// </summary>
        public _02264_LargestThreeSameDigitNumberInString()
        {
            Console.WriteLine(LargestGoodInteger("6777133339"));
            Console.WriteLine(LargestGoodInteger("2300019"));
            Console.WriteLine(LargestGoodInteger("42352338"));
        }

        private static string? LargestGoodInteger(string num)
        {
            int n = num.Length;
            HashSet<string> r = [];

            for (int i = 0; i < n - 2; i++)
            {
                if (num[i] == num[i + 1] && num[i + 1] == num[i + 2]) r.Add(num[i..(i + 3)]);
            }

            return r.Count > 0 ? r.Max() : "";
        }
    }
}
