namespace Rftim3LeetCode.Temp
{
    public class _00273_IntegerToEnglishWords
    {
        /// <summary>
        /// Convert a non-negative integer num to its English words representation.
        /// </summary>
        public _00273_IntegerToEnglishWords()
        {
            Console.WriteLine(IntegerToEnglishWords0(123));
            Console.WriteLine(IntegerToEnglishWords0(12345));
            Console.WriteLine(IntegerToEnglishWords0(1234567));
        }

        public static string IntegerToEnglishWords0(int a0) => RftIntegerToEnglishWords0(a0);

        public static string IntegerToEnglishWords1(int a0) => RftIntegerToEnglishWords1(a0);

        private static readonly string[] lessThan20 = ",One,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten,Eleven,Twelve,Thirteen,Fourteen,Fifteen,Sixteen,Seventeen,Eighteen,Nineteen".Split(",");
        private static readonly string[] tens = ",Ten,Twenty,Thirty,Forty,Fifty,Sixty,Seventy,Eighty,Ninety".Split(",");
        private static readonly string[] thousands = ",Thousand,Million,Billion".Split(",");

        private static string RftIntegerToEnglishWords0(int num)
        {
            if (num == 0) return "Zero";
            List<string> result = [];
            for (int i = 0; i < thousands.Length; i++)
            {
                int lessThanThousand = num % 1000;
                num /= 1000;
                if (lessThanThousand != 0)
                {
                    List<string> res = ConvertLessThanThousand(lessThanThousand);
                    res.Add(thousands[i]);
                    res.AddRange(result);
                    result = res;
                }
            }

            return string.Join(" ", result.Where(x => !string.IsNullOrWhiteSpace(x))).Trim();
        }

        private static List<string> ConvertLessThanThousand(int n)
        {
            List<string> result = [];
            if (n < 20) result.Add(lessThan20[n]);
            else if (n < 100)
            {
                result.Add(tens[n / 10]);
                result.AddRange(ConvertLessThanThousand(n % 10));
            }
            else
            {
                result.AddRange(ConvertLessThanThousand(n / 100));
                result.Add("Hundred");
                result.AddRange(ConvertLessThanThousand(n % 100));
            }

            return result;
        }

        private static readonly string[] LessThan20 = ["",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
            "Ten",
            "Eleven",
            "Twelve",
            "Thirteen",
            "Fourteen",
            "Fifteen",
            "Sixteen",
            "Seventeen",
            "Eighteen",
            "Nineteen"];
        private static readonly string[] Tens = ["", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"];
        private static readonly string[] Thousands = ["", "Thousand", "Million", "Billion"];

        private static string RftIntegerToEnglishWords1(int num)
        {
            if (num == 0) return "Zero";

            int i = 0;
            string res = "";
            while (num > 0)
            {
                if (num % 1000 != 0) res = $"{Helper(num % 1000)}{Thousands[i]} {res}";

                num /= 1000;
                i++;
            }

            return res.Trim();
        }

        private static string Helper(int num)
        {
            if (num == 0) return "";
            else if (num < 20) return $"{LessThan20[num]} ";
            else if (num < 100) return $"{Tens[num / 10]} {Helper(num % 10)}";
            else return $"{LessThan20[num / 100]} Hundred {Helper(num % 100)}";
        }
    }
}
