namespace Rftim3LeetCode.Temp
{
    public class _02259_RemoveDigitFromNumberToMaximizeResult
    {
        /// <summary>
        /// You are given a string number representing a positive integer and a character digit.
        /// Return the resulting string after removing exactly one occurrence of digit from number such that the value of the resulting string in decimal form is maximized.
        /// The test cases are generated such that digit occurs at least once in number.
        /// </summary>
        public _02259_RemoveDigitFromNumberToMaximizeResult()
        {
            Console.WriteLine(RemoveDigit("123", '3'));
            Console.WriteLine(RemoveDigit("1231", '1'));
            Console.WriteLine(RemoveDigit("551", '5'));
        }

        private static string? RemoveDigit(string number, char digit)
        {
            List<string> r = [];

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == digit)
                {
                    r.Add($"{number[..i]}{number[(i + 1)..]}");
                }
            }

            return r.Count > 0 ? r.Max() : "";
        }
    }
}
