namespace Rftim3LeetCode.Temp
{
    public class _01903_LargestOddNumberInString
    {
        /// <summary>
        /// You are given a string num, representing a large integer. 
        /// Return the largest-valued odd integer (as a string) that is a non-empty substring of num, or an empty string "" if no odd integer exists.
        /// A substring is a contiguous sequence of characters within a string.
        /// </summary>
        public _01903_LargestOddNumberInString()
        {
            Console.WriteLine(LargestOddNumber("52"));
            Console.WriteLine(LargestOddNumber("4206"));
            Console.WriteLine(LargestOddNumber("35427"));
        }

        private static string LargestOddNumber(string num)
        {
            int n = num.Length;

            for (int i = 1; i <= n; i++)
            {
                if (int.Parse(num[^i].ToString()) % 2 == 1) return num[..^(i - 1)];
            }

            return "";
        }
    }
}
