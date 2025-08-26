using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01694_ReformatPhoneNumber
    {
        /// <summary>
        /// You are given a phone number as a string number. number consists of digits, spaces ' ', and/or dashes '-'.
        /// You would like to reformat the phone number in a certain manner.Firstly, remove all spaces and dashes.
        /// Then, group the digits from left to right into blocks of length 3 until there are 4 or fewer digits.The final digits are then grouped as follows:
        /// 2 digits: A single block of length 2.
        /// 3 digits: A single block of length 3.
        /// 4 digits: Two blocks of length 2 each.
        /// The blocks are then joined by dashes.Notice that the reformatting process should never produce any blocks of length 1 and produce at most two blocks of length 2.
        /// Return the phone number after formatting.
        /// </summary>
        public _01694_ReformatPhoneNumber()
        {
            Console.WriteLine(ReformatNumber("1-23-45 6"));
            Console.WriteLine(ReformatNumber("123 4-567"));
            Console.WriteLine(ReformatNumber("123 4-5678"));
        }

        private static string ReformatNumber(string number)
        {
            number = number.Replace("-", "").Replace(" ", "");
            int n = number.Length;
            if (n < 4) return number;

            StringBuilder sb = new();
            if (n % 3 == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    sb.Append($"{number[i..(i + 3)]}-");
                    i += 2;
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (n - i > 4)
                    {
                        sb.Append($"{number[i..(i + 3)]}-");
                        i += 2;
                    }
                    else
                    {
                        sb.Append($"{number[i..(i + 2)]}-");
                        i += 1;
                    }
                }
            }

            return sb.ToString()[..^1];
        }

        private static string ReformatNumber0(string number)
        {
            number = number.Replace("-", "");
            number = number.Replace(" ", "");

            int rest = number.Length;
            int start = 0;
            string returnStr = "";

            while (rest > 4)
            {
                returnStr += $"{number.Substring(start, 3)}-";
                start += 3;
                rest = number.Length - start;
            }

            if (rest == 4) return $"{returnStr}{number.Substring(start, 2)}-{number.Substring(start + 2, 2)}";
            else return string.Concat(returnStr, number.AsSpan(start, rest));
        }
    }
}
