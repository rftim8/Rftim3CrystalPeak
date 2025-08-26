namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class EscapingTheCat
    {
        public EscapingTheCat()
        {
            // Solve();
        }

        private static void Solve()
        {
            int catSpeed = int.Parse(Console.ReadLine());
            int lastCatX = 0;
            int dist = 0;

            // game loop
            while (true)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int mouseX = int.Parse(inputs[0]);
                int mouseY = int.Parse(inputs[1]);
                int catX = int.Parse(inputs[2]);
                int catY = int.Parse(inputs[3]);

                if (dist <= 650)
                {
                    dist = (int)Dist(mouseX, catX, mouseY, catY);
                }

                Console.Error.WriteLine($"dist: {dist}");

                if (dist <= 650)
                {
                    if (catX >= 0 && catY >= 0) Console.WriteLine(catX > lastCatX ? $"{mouseX - 10} {mouseY}" : $"{mouseX} {mouseY - 10}");
                    else if (catX >= 0 && catY <= 0) Console.WriteLine(catX < lastCatX ? $"{mouseX} {mouseY + 10}" : $"{mouseX - 10} {mouseY}");
                    else if (catX <= 0 && catY <= 0) Console.WriteLine(catX < lastCatX ? $"{mouseX + 10} {mouseY}" : $"{mouseX} {mouseY + 10}");
                    else if (catX <= 0 && catY >= 0) Console.WriteLine(catX > lastCatX ? $"{mouseX} {mouseY - 10}" : $"{mouseX + 10} {mouseY}");
                }
                else
                {
                    if (mouseX >= 0 && mouseY >= 0) Console.WriteLine(mouseX > mouseY ? $"{mouseX + 10} {mouseY}" : $"{mouseX} {mouseY + 10}");
                    else if (mouseX >= 0 && mouseY <= 0) Console.WriteLine(mouseX > -mouseY ? $"{mouseX + 10} {mouseY}" : $"{mouseX} {mouseY - 10}");
                    else if (mouseX <= 0 && mouseY <= 0) Console.WriteLine(mouseX < mouseY ? $"{mouseX - 10} {mouseY}" : $"{mouseX} {mouseY - 10}");
                    else if (mouseX <= 0 && mouseY >= 0) Console.WriteLine(-mouseX > mouseY ? $"{mouseX - 10} {mouseY}" : $"{mouseX} {mouseY + 10}");
                }
                lastCatX = catX;
            }
        }

        private static double Dist(int a, int b, int c, int d)
        {
            return Math.Sqrt((a - b) * (a - b) + (c - d) * (c - d));
        }
    }
}
