using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00038_CountAndSay
    {
        /// <summary>
        /// The count-and-say sequence is a sequence of digit strings defined by the recursive formula:
        /// countAndSay(1) = "1"
        /// countAndSay(n) is the way you would "say" the digit string from countAndSay(n-1), which is then converted into a different digit string.
        /// To determine how you "say" a digit string, split it into the minimal number of substrings such that each substring contains exactly one unique digit.
        /// Then for each substring, say the number of digits, then say the digit.
        /// Finally, concatenate every said digit.
        /// For example, the saying and conversion for digit string "3322251":
        /// Given a positive integer n, return the nth term of the count-and-say sequence.
        /// </summary>
        public _00038_CountAndSay()
        {
            Console.WriteLine(CountAndSay0(1));
            Console.WriteLine(CountAndSay0(4));
        }

        public static string CountAndSay0(int a0) => RftCountAndSay0(a0);

        private static string RftCountAndSay0(int n)
        {
            string r = "1";
            if (n == 1) return r;

            for (int i = 1; i < n; i++)
            {
                r = Say(r);
            }

            return r;
        }

        private static string Say(string n)
        {
            StringBuilder sb = new();
            int i = 0;
            while (i < n.Length)
            {
                char c = n[i];
                int d = 0;

                while (i < n.Length && n[i] == c)
                {
                    ++i;
                    ++d;
                }
                sb.Append($"{d}");
                sb.Append(c);
            }

            return sb.ToString();
        }

        public static string RftCountAndSay1(int n)
        {

            if (n == 1) return "1";

            string num = "1";

            for (int i = 2; i <= n; i++)
            {
                List<int> numbers = [];
                int currentNum = Convert.ToInt32(num[..1]);
                numbers.Add(1);
                numbers.Add(currentNum);

                for (int j = 1; j < num.Length; j++)
                {
                    currentNum = Convert.ToInt32(num.Substring(j, 1));
                    int length = numbers.Count;
                    if (currentNum == numbers[length - 1]) numbers[length - 2]++;
                    else
                    {
                        numbers.Add(1);
                        numbers.Add(currentNum);
                    }
                };

                num = string.Join("", numbers);
            }

            return num;
        }
    }
}
