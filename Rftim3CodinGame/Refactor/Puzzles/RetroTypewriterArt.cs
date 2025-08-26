namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class RetroTypewriterArt
    {
        public RetroTypewriterArt()
        {
            string t = "1sp 1/ 1bS 1_ 1/ 1bS nl 1( 1sp 1o 1. 1o 1sp 1) nl 1sp 1> 1sp 1^ 1sp 1< nl 2sp 3|";

            Solve(t);
        }

        private static void Solve(string t)
        {
            List<string> commands = t.Split(' ').ToList();

            foreach (string item in commands)
            {
                if (item.Contains("sp"))
                {
                    int counter = int.Parse(item[..^2]);

                    for (int i = 0; i < counter; i++) Console.Write(" ");
                }
                else if (item.Contains("bS"))
                {
                    int counter = int.Parse(item[..^2]);

                    for (int i = 0; i < counter; i++) Console.Write("\\");
                }
                else if (item.Contains("sQ"))
                {
                    int counter = int.Parse(item[..^2]);

                    for (int i = 0; i < counter; i++) Console.Write("'");
                }
                else if (item.Contains("nl")) Console.WriteLine();
                else
                {
                    int counter = int.Parse(item[..^1]);
                    string x = item[^1..];

                    for (int i = 0; i < counter; i++) Console.Write(x);
                }
            }
        }
    }
}
