namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class FlipTheSign
    {
        public FlipTheSign()
        {
            List<int> numbers = new()
            {
                -6,
                76,
                82,
                -48,
                74,
                39,
                -232,
                -149,
                24,
                -36,
                -115,
                90,
                -43,
                -40,
                405,
                28,
                -87,
                -2,
                -115,
                -469,
                -56,
                89,
                -472,
                -20,
                -49,
                73,
                233,
                191,
                -73,
                79,
                -113,
                449,
                72,
                212,
                -178,
                384,
                21,
                197,
                238,
                451
            };
            List<string> chars = new()
            {
                "X",
                "0",
                "0",
                "0",
                "0",
                "X",
                "0",
                "0",
                "0",
                "0",
                "X",
                "0",
                "0",
                "0",
                "0",
                "X",
                "0",
                "0",
                "X",
                "0",
                "0",
                "X",
                "0",
                "0",
                "X",
                "0",
                "0",
                "0",
                "0",
                "X",
                "0",
                "0",
                "0",
                "0",
                "X",
                "0",
                "0",
                "0",
                "0",
                "X"
            };

            Solve(numbers, chars);
        }

        public static void Solve(List<int> numbers, List<string> chars)
        {
            bool sign = true;
            int counter = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (chars[i] == "X")
                {
                    if (counter == 0)
                    {
                        sign = numbers[i] > 0;
                        counter++;
                    }
                    else
                    {
                        if (sign && numbers[i] < 0) sign = false;
                        else if (!sign && numbers[i] > 0) sign = true;
                        else
                        {
                            Console.WriteLine(false.ToString().ToLower());
                            return;
                        }
                    }
                }
            }

            Console.WriteLine(true.ToString().ToLower());
        }
    }
}
