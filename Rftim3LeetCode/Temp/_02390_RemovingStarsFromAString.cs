using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _02390_RemovingStarsFromAString
    {
        /// <summary>
        /// You are given a string s, which contains stars *.
        /// In one operation, you can:
        /// Choose a star in s.
        /// Remove the closest non-star character to its left, as well as remove the star itself.
        /// Return the string after all stars have been removed.
        /// Note:
        /// The input will be generated such that the operation is always possible.
        /// It can be shown that the resulting string will always be unique.
        /// </summary>
        public _02390_RemovingStarsFromAString()
        {
            Console.WriteLine(RemoveStars("leet**cod*e"));
            Console.WriteLine(RemoveStars("erase*****"));
        }

        private static string RemoveStars(string s)
        {
            int n = s.Length;
            string x = "";

            int c = 0;
            for (int i = n - 1; i > -1; i--)
            {
                if (s[i] == '*') c++;
                else
                {
                    if (c > 0) c--;
                    else x = s[i] + x;
                }
            }

            return x;
        }

        private static string RemoveStars0(string s)
        {
            StringBuilder sb = new(s.Length);

            foreach (char c in s)
            {
                if (c == '*') sb.Length -= 1;
                else sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
