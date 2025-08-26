namespace Rftim3LeetCode.Temp
{
    public class _00709_ToLowerCase
    {
        /// <summary>
        /// Given a string s, return the string after replacing every uppercase letter with the same lowercase letter.
        /// </summary>
        public _00709_ToLowerCase()
        {
            Console.WriteLine(ToLowerCase("Hello"));
            Console.WriteLine(ToLowerCase("here"));
            Console.WriteLine(ToLowerCase("LOVELY"));
        }

        private static string ToLowerCase(string s)
        {
            int n = s.Length;
            string x = "";

            for (int i = 0; i < n; i++)
            {
                x += char.IsUpper(s[i]) ? s[i].ToString().ToLower() : s[i];
            }

            return x;
        }

        private static string ToLowerCase0(string s)
        {
            string ans = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 65 && s[i] <= 90) ans += (char)(s[i] + 32);
                else ans += s[i];
            }

            return ans;
        }
    }
}
