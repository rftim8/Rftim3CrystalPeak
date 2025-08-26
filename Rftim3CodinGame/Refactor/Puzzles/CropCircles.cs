namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class CropCircles
    {
        public CropCircles()
        {
            //string instructions = "fg9 ls11 oe7";
            string instructions = "ft17 PLANTft9 nf17 PLANTnf9 PLANTjm5";
            string alpha = "abcdefghijklmnopqrstuvwxyz";

            Solve(instructions, alpha);
        }

        private static void Solve(string message, string ascii)
        {
            string[,] field = new string[25, 19];

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 19; j++) field[i, j] = "{}";
            }

            List<Crop> cc = new();

            foreach (var item in message.Split(" "))
            {
                if (item.StartsWith("PLANTMOW")) cc.Add(new Crop(ascii.IndexOf(item[8..9]), ascii.IndexOf(item[9..10]), int.Parse(item[10..]), false, true));
                else if (item.StartsWith("PLANT")) cc.Add(new Crop(ascii.IndexOf(item[5..6]), ascii.IndexOf(item[6..7]), int.Parse(item[7..]), true, false));
                else cc.Add(new Crop(ascii.IndexOf(item[..1]), ascii.IndexOf(item[1..2]), int.Parse(item[2..]), false, false));
            }

            foreach (var item in cc) Console.WriteLine($"{item.x} {item.y}: {item.rad}");

            foreach (var item in cc)
            {
                int radius = item.rad / 2;

                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 19; j++)
                    {
                        if (Math.Round(Dist(j, item.x, i, item.y)) <= radius)
                        {
                            if (item.plant) field[i, j] = "{}";
                            else if (item.mow)
                            {
                                if (field[i, j] == "{}") field[i, j] = "  ";
                                else field[i, j] = "{}";
                            }
                            else field[i, j] = "  ";
                        }
                        Console.Write(field[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 19; j++) Console.Write(field[i, j]);
                Console.WriteLine();
            }
        }

        public static double Dist(int a, int b, int c, int d)
        {
            return Math.Sqrt((a - b) * (a - b) + (c - d) * (c - d));
        }

        class Crop
        {
            public int x, y, rad;
            public bool plant, mow;

            public Crop(int x, int y, int rad, bool plant, bool mow)
            {
                this.x = x;
                this.y = y;
                this.rad = rad;
                this.plant = plant;
                this.mow = mow;
            }
        }
    }
}
