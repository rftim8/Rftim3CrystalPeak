namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class TheGreatestNumber
    {
        public TheGreatestNumber()
        {
            //int N = 8;
            //string input = "4 9 8 . 8 5 2 -";
            //int N = 9;
            //string input = "7 4 1 . 2 5 8 9 9";
            //int N = 8;
            //string input = "- 7 7 8 8 6 5 1";
            //int N = 9;
            //string input = "- 4 0 0 5 9 8 . 2";
            string input = "0 0 0 1 0 0 0 .";
            //int N = 9;
            //string input = "- 0 0 0 0 0 0 0 .";
            //int N = 9;
            //string input = "1 2 3 4 5 6 7 8 9";


            Solve(input);
        }

        private static void Solve(string input)
        {
            List<string> list = new();
            List<int> digits = new();
            List<string> signs = new();
            list = input.Split(' ').ToList();
            string result = "";

            foreach (string item in list)
            {
                if (int.TryParse(item, out int i)) digits.Add(Convert.ToInt32(item));
                else signs.Add(item);
            }
            if (digits.Sum() != 0)
            {
                if (signs.Contains("-"))
                {
                    digits.Sort((a, b) => a.CompareTo(b));

                    result += "-";
                    if (signs.Contains("."))
                    {
                        for (int i = 0; i < digits.Count; i++)
                        {
                            result += digits[i].ToString();
                            if (i == 0) result += ".";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < digits.Count; i++) result += digits[i].ToString();
                    }

                }
                else
                {
                    digits.Sort((a, b) => b.CompareTo(a));
                    if (signs.Contains("."))
                    {
                        for (int i = 0; i < digits.Count; i++)
                        {
                            result += digits[i].ToString();
                            if (i == digits.Count - 2) result += ".";
                            if (i == digits.Count - 1 && digits[i].ToString() == "0" && result[^2].ToString() == ".") result = result[..^2];
                        }
                    }
                    else
                    {
                        for (int i = 0; i < digits.Count; i++) result += digits[i].ToString();
                    }
                }
            }
            else result = "0";

            Console.WriteLine($"{result}");

            #region Testing
            Console.WriteLine("\nDigits:");

            foreach (int item in digits) Console.WriteLine($"{item}");

            Console.WriteLine("\nSigns");

            foreach (string item in signs) Console.WriteLine($"{item}");
            #endregion
        }
    }
}
