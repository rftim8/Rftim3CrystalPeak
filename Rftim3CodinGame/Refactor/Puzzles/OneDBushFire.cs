namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class OneDBushFire
    {
        public OneDBushFire()
        {
            int n = 2;
            List<string> lines =
            [
                "....f....f..",
                "fff..ffff.."
            ];

            Solve(n, lines);
        }

        private static void Solve(int n, List<string> lines)
        {
            for (int j = 0; j < n; j++)
            {
                lines[j] = $".{lines[j]}.";
                int counter = 0;

                for (int i = 1; i < lines[j].Length - 1; i++)
                {
                    string fire = lines[j][(i - 1)..(i + 2)];
                    if (fire.Contains('f'))
                    {
                        Console.WriteLine($"Bush: {fire}");
                        if (fire == "fff" || fire == "ff." || fire == "f.." || fire == "f.f")
                        {
                            lines[j] = lines[j][..(i - 1)] + "..." + lines[j][(i + 2)..];
                            Console.WriteLine($"Line: {lines[j]}");
                            counter++;
                        }

                    }
                }
                if (lines[j].Contains('f')) counter++;

                Console.WriteLine($"{counter}");
            }

            Console.WriteLine($"{lines[0]}");
            Console.WriteLine($"{lines[1]}");
        }
    }
}
