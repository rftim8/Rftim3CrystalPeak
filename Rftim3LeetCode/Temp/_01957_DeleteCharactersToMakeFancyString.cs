using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01957_DeleteCharactersToMakeFancyString
    {
        /// <summary>
        /// A fancy string is a string where no three consecutive characters are equal.
        /// Given a string s, delete the minimum possible number of characters from s to make it fancy.
        /// Return the final string after the deletion. It can be shown that the answer will always be unique.
        /// </summary>
        public _01957_DeleteCharactersToMakeFancyString()
        {
            Console.WriteLine(MakeFancyString("leeetcode"));
            Console.WriteLine(MakeFancyString("aaabaaaa"));
            Console.WriteLine(MakeFancyString("aab"));
        }

        private static string MakeFancyString(string s)
        {
            int n = s.Length;
            StringBuilder sb = new();

            int c = 1;
            sb.Append(s[0]);
            for (int i = 1; i < n; i++)
            {
                if (s[i - 1] == s[i])
                {
                    c++;
                    if (c < 3) sb.Append(s[i]);
                }
                else
                {
                    sb.Append(s[i]);
                    c = 1;
                }
            }

            return sb.ToString();
        }
    }
}
