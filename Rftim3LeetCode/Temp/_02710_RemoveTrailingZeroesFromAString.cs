namespace Rftim3LeetCode.Temp
{
    public class _02710_RemoveTrailingZeroesFromAString
    {
        /// <summary>
        /// Given a positive integer num represented as a string, return the integer num without trailing zeros as a string.
        /// </summary>
        public _02710_RemoveTrailingZeroesFromAString()
        {
            Console.WriteLine(RemoveTrailingZeros("51230100"));
            Console.WriteLine(RemoveTrailingZeros("123"));
        }

        private static string RemoveTrailingZeros(string num)
        {
            int n = num.Length;

            int c = 0;
            for (int i = n - 1; i > -1; i--)
            {
                if (num[i] == '0') c++;
                else break;
            }

            return num[..^c];
        }
    }
}
