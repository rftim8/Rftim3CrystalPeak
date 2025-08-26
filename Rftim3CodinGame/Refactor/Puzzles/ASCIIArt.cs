namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class ASCIIArt
    {
        public ASCIIArt()
        {
            string t = "E";

            string row = " #  ##   ## ##  ### ###  ## # # ###  ##";
            Solve(t, row);
        }

        private static void Solve(string t, string row)
        {
            string alphaUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int[] indexes = new int[t.Length];

            for (int i = 0; i < t.Length; i++)
            {
                if (!alphaUpper.Contains(t[i].ToString().ToUpper())) indexes[i] = 26;
                else indexes[i] = alphaUpper.IndexOf(t[i].ToString().ToUpper());
            }

            string result = "";

            if (row.Length < 150)
            {
                for (int i = 0; i < indexes.Length; i++)
                {
                    result += row.Substring(indexes[i] * 4, 4);
                }
            }
            else
            {
                for (int i = 0; i < indexes.Length; i++)
                {
                    result += row.Substring(indexes[i] * 20, 20);
                }
            }

            Console.WriteLine(result);
        }
    }
}
