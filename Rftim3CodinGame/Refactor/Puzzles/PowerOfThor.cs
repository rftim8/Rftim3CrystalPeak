namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class PowerOfThor
    {
        public PowerOfThor()
        {
            //Solve();
        }

        private static void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int lightX = int.Parse(inputs[0]); // the X position of the light of power
            int lightY = int.Parse(inputs[1]); // the Y position of the light of power
            int initialTx = int.Parse(inputs[2]); // Thor's starting X position
            int initialTy = int.Parse(inputs[3]); // Thor's starting Y position

            int ThorX = initialTx;
            int ThorY = initialTy;

            // game loop
            while (true)
            {
                _ = int.Parse(Console.ReadLine()); // The remaining amount of turns Thor can move. Do not remove this line.

                string dirX = "";
                string dirY = "";

                if (lightX > ThorX)
                {
                    dirX = "E";
                    ThorX--;
                }
                else if (lightX < ThorX)
                {
                    dirX = "W";
                    ThorX++;
                }

                if (lightY < ThorY)
                {
                    dirY = "N";
                    ThorY--;
                }
                else if (lightY > ThorY)
                {
                    dirY = "S";
                    ThorY++;
                }

                Console.WriteLine(dirY + dirX);
            }
        }
    }
}
