namespace Rftim3LeetCode.Temp
{
    public class _00557_ReverseWordsInAString3
    {
        /// <summary>
        /// Given a string s, reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.
        /// </summary>
        public _00557_ReverseWordsInAString3()
        {
            Console.WriteLine(ReverseWords0("Let's take LeetCode contest"));
            Console.WriteLine(ReverseWords0("God Ding"));
        }

        public static string ReverseWords0(string a0) => RftReverseWords0(a0);

        private static string RftReverseWords0(string s)
        {
            string c = string.Empty;

            List<string> x = [.. s.Split(' ')];

            for (int i = 0; i < x.Count; i++)
            {
                IEnumerable<char> temp = x[i].Reverse();
                c += $"{string.Join("", temp)} ";
            }

            return c.Trim();
        }
    }
}
