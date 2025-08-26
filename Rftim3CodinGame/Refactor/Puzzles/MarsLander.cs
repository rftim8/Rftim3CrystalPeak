namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class MarsLander
    {
        public MarsLander()
        {
            //Solve();
        }

        private static void Solve()
        {
            string[] inputs;
            int surfaceN = int.Parse(Console.ReadLine() ?? ""); // the number of points used to draw the surface of Mars.
            for (int i = 0; i < surfaceN; i++)
            {
                inputs = Console.ReadLine()!.Split(' ');
                _ = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
                _ = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.
            }

            // game loop
            while (true)
            {
                inputs = Console.ReadLine()!.Split(' ');
                _ = int.Parse(inputs[0]);
                _ = int.Parse(inputs[1]);
                _ = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
                int vSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
                _ = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
                _ = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
                _ = int.Parse(inputs[6]); // the thrust power (0 to 4).

                Console.WriteLine("0 " + (vSpeed > -40 ? 0 : 4).ToString());
            }
        }
    }
}
