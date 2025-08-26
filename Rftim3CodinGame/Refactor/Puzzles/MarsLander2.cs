namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class MarsLander2
    {
        public MarsLander2()
        {
            //Solve();
        }

        private static void Solve()
        {
            int lastX = -1;
            int lastY = -1;
            int startX = -1;
            int endX = -1;
            int landingY = -1;
            string[] inputs;
            int N = int.Parse(Console.ReadLine() ?? ""); // the number of points used to draw the surface of Mars.
            for (int i = 0; i < N; i++)
            {
                inputs = Console.ReadLine()!.Split(' ');
                int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
                int landY = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.

                #region Landing Zone + Height
                if (lastY == landY && -1 == startX)
                {
                    startX = lastX;
                    landingY = landY;
                }
                else if (-1 != startX && -1 == endX) endX = lastX;

                lastX = landX;
                lastY = landY;

                // Console.Error.WriteLine($"[{startX}...{endX}]");
                // Console.Error.WriteLine($"_ = {landingY}");
                // Console.Error.WriteLine($"({lastX},{lastY})\n");
                #endregion
            }

            Console.Error.WriteLine($"Landing zone: [{startX}...{endX}]");
            Console.Error.WriteLine($"Height: {landingY}");

            double G = 3.711;
            int maxHS = 20;
            int maxVS = 40;
            // game loop
            while (true)
            {
                inputs = Console.ReadLine()!.Split(' ');
                int X = int.Parse(inputs[0]);
                int Y = int.Parse(inputs[1]);
                int HS = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
                int VS = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
                _ = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
                _ = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
                _ = int.Parse(inputs[6]); // the thrust power (0 to 4).
                double speed = Math.Sqrt(Math.Pow(HS, 2) + Math.Pow(VS, 2));
                double aimAngle = RadiandsToDegrees(Math.Acos(G / 4));

                int R = 0;
                int P = 4;

                #region Shuttle away from landing zone
                if (!(startX <= X && X <= endX))
                {
                    if (X < startX && HS < 0 || endX < X && HS > 0 || Math.Abs(HS) > 4 * maxHS) R = (int)Math.Truncate(RadiandsToDegrees(Math.Asin(HS / speed)));
                    else if (Math.Abs(HS) < 2 * maxHS) R = (int)Math.Truncate(X < startX ? -aimAngle : endX < X ? aimAngle : 0);
                    else if (VS >= 0) P = 3;
                }
                #endregion

                #region Shuttle above landing zone
                else
                {
                    if (Y < 200 + landingY) P = 3;
                    else if (Math.Abs(HS) <= maxHS - 5 && Math.Abs(VS) <= maxVS - 5) P = 2;
                    else R = (int)Math.Truncate(RadiandsToDegrees(Math.Asin(HS / speed)));
                }
                #endregion

                Console.WriteLine($"{R} {P}");
            }
        }

        private static double RadiandsToDegrees(double radians) => radians * 180 / Math.PI;
    }
}