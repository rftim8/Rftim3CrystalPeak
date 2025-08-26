namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class TheFallEpisode1
    {
        public TheFallEpisode1()
        {
            //Solve();
        }

        private static void Solve()
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int W = int.Parse(inputs[0]); // number of columns.
            int H = int.Parse(inputs[1]); // number of rows.
            List<string> map = new();
            for (int i = 0; i < H; i++)
            {
                string LINE = Console.ReadLine(); // represents a line in the grid and contains W integers. Each integer represents one room of a given type.
                Console.Error.WriteLine(LINE);
                map.Add(LINE);
            }
            int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit (not useful for this first mission, but must be read).

            // game loop
            while (true)
            {
                inputs = Console.ReadLine().Split(' ');
                int XI = int.Parse(inputs[0]);
                int YI = int.Parse(inputs[1]);
                string POS = inputs[2];

                switch (map[YI].Split(' ')[XI])
                {
                    case "1":
                        Console.WriteLine($"{XI} {YI + 1}");
                        break;
                    case "2":
                        if (POS == "LEFT") Console.WriteLine($"{XI + 1} {YI}");
                        else Console.WriteLine($"{XI - 1} {YI}");
                        break;
                    case "3":
                        Console.WriteLine($"{XI} {YI + 1}");
                        break;
                    case "4":
                        if (POS == "TOP") Console.WriteLine($"{XI - 1} {YI}");
                        else Console.WriteLine($"{XI} {YI + 1}");
                        break;
                    case "5":
                        if (POS == "TOP") Console.WriteLine($"{XI + 1} {YI}");
                        else Console.WriteLine($"{XI} {YI + 1}");
                        break;
                    case "6":
                        if (POS == "RIGHT") Console.WriteLine($"{XI - 1} {YI}");
                        else Console.WriteLine($"{XI + 1} {YI}");
                        break;
                    case "7":
                        Console.WriteLine($"{XI} {YI + 1}");
                        break;
                    case "8":
                        Console.WriteLine($"{XI} {YI + 1}");
                        break;
                    case "9":
                        Console.WriteLine($"{XI} {YI + 1}");
                        break;
                    case "10":
                        Console.WriteLine($"{XI - 1} {YI}");
                        break;
                    case "11":
                        Console.WriteLine($"{XI + 1} {YI}");
                        break;
                    case "12":
                        Console.WriteLine($"{XI} {YI + 1}");
                        break;
                    case "13":
                        Console.WriteLine($"{XI} {YI + 1}");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
