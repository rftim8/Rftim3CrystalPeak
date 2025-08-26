using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01309_DecryptStringFromAlphabetToIntegerMapping
    {
        /// <summary>
        /// You are given a string s formed by digits and '#'. We want to map s to English lowercase characters as follows:
        /// Characters('a' to 'i') are represented by('1' to '9') respectively.
        /// Characters('j' to 'z') are represented by('10#' to '26#') respectively.
        /// Return the string formed after mapping.
        /// The test cases are generated so that a unique mapping will always exist.
        /// </summary>
        public _01309_DecryptStringFromAlphabetToIntegerMapping()
        {
            Console.WriteLine(FreqAlphabets("10#11#12"));
            Console.WriteLine(FreqAlphabets("1326#"));
            Console.WriteLine(FreqAlphabets("12345678910#11#12#13#14#15#16#17#18#19#20#21#22#23#24#25#26#"));
        }

        private static string FreqAlphabets(string s)
        {
            int n = s.Length;
            string x = "";

            for (int i = 0; i < n; i++)
            {
                if (i < n - 2 && s[i + 2] == '#')
                {
                    x += (char)(int.Parse(s.Substring(i, 2)) + 96);
                    i += 2;
                }
                else if (i < n - 1 && s[i + 1] == '#')
                {
                    x += (char)(int.Parse(s[i].ToString()) + 96);
                    i++;
                }
                else x += (char)(int.Parse(s[i].ToString()) + 96);
            }

            return x;
        }

        private static string FreqAlphabets0(string s)
        {
            StringBuilder sb = new();

            for (int i = 0; i < s.Length; ++i)
            {
                int v;
                if (i < s.Length - 2 && s[i + 2] == '#')
                {
                    v = (s[i] - '0') * 10 + (s[i + 1] - '0');
                    i += 2;
                }
                else v = s[i] - '0';

                sb.Append((char)(v + 'a' - 1));
            }

            return sb.ToString();
        }
    }
}
