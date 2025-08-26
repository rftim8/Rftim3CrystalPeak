namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class CreateTheLongestSequenceOfOnes
    {
        public CreateTheLongestSequenceOfOnes()
        {
            string b = "00";
            //string b = "01010";
            //string b = "11011101111";
            //string b = "01110100110011000101001100011110010010101011111011";
            //string b = "0010000011000101001110010011011001000111010010101111000011011110001000000000100010100011010100011101";

            Solve(b);
        }

        private static void Solve(string b)
        {
            int result = 0;

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].ToString() == "0")
                {
                    b = b[..i] + "1" + b[(i + 1)..];
                    int count = b.Split('0').Max(o => o.Length);
                    if (result < count) result = count;
                    b = b[..i] + "0" + b[(i + 1)..];
                }
            }

            Console.WriteLine(result);
        }
    }
}
