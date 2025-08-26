namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class ShadowsOfTheKnight
    {
        public ShadowsOfTheKnight()
        {
            //Solve();
        }

        private static void Solve()
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int W = int.Parse(inputs[0]); // width of the building.
            int H = int.Parse(inputs[1]); // height of the building.
            int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
            inputs = Console.ReadLine().Split(' ');
            int X0 = int.Parse(inputs[0]);
            int Y0 = int.Parse(inputs[1]);

            List<double> locationsVert = new()
            {
                0,
                H
            };

            List<double> locationsHoriz = new()
            {
                0,
                W
            };

            // game loop
            while (true)
            {
                string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)
                Console.Error.WriteLine($"X: {X0}");
                Console.Error.WriteLine($"Y: {Y0}");

                switch (bombDir)
                {
                    case "D":
                        if (Y0 != 0 && Y0 != H)
                        {
                            locationsVert.Add(Y0);
                        }
                        locationsVert.Sort((a, b) => a.CompareTo(b));
                        Y0 += (int)Math.Ceiling((locationsVert[locationsVert.IndexOf(Y0) + 1] - Y0) / 2);
                        break;
                    case "U":
                        if (Y0 != 0 && Y0 != H)
                        {
                            locationsVert.Add(Y0);
                        }
                        locationsVert.Sort((a, b) => a.CompareTo(b));
                        Y0 -= (int)Math.Ceiling((Y0 - locationsVert[locationsVert.IndexOf(Y0) - 1]) / 2);
                        break;
                    case "R":
                        if (X0 != 0 && X0 != W)
                        {
                            locationsHoriz.Add(X0);
                        }
                        locationsHoriz.Sort((a, b) => a.CompareTo(b));
                        X0 += (int)Math.Ceiling((locationsHoriz[locationsHoriz.IndexOf(X0) + 1] - X0) / 2);
                        break;
                    case "L":
                        if (X0 != 0 && X0 != W)
                        {
                            locationsHoriz.Add(X0);
                        }
                        locationsHoriz.Sort((a, b) => a.CompareTo(b));
                        X0 -= (int)Math.Ceiling((X0 - locationsHoriz[locationsHoriz.IndexOf(X0) - 1]) / 2);
                        break;
                    case "DR":
                        if (Y0 != 0 && Y0 != H)
                        {
                            locationsVert.Add(Y0);
                        }
                        locationsVert.Sort((a, b) => a.CompareTo(b));
                        Y0 += (int)Math.Ceiling((locationsVert[locationsVert.IndexOf(Y0) + 1] - Y0) / 2);
                        if (X0 != 0 && X0 != W)
                        {
                            locationsHoriz.Add(X0);
                        }
                        locationsHoriz.Sort((a, b) => a.CompareTo(b));
                        X0 += (int)Math.Ceiling((locationsHoriz[locationsHoriz.IndexOf(X0) + 1] - X0) / 2);
                        break;
                    case "UR":
                        if (Y0 != 0 && Y0 != H)
                        {
                            locationsVert.Add(Y0);
                        }
                        locationsVert.Sort((a, b) => a.CompareTo(b));
                        Y0 -= (int)Math.Ceiling((Y0 - locationsVert[locationsVert.IndexOf(Y0) - 1]) / 2);
                        if (X0 != 0 && X0 != W)
                        {
                            locationsHoriz.Add(X0);
                        }
                        locationsHoriz.Sort((a, b) => a.CompareTo(b));
                        X0 += (int)Math.Ceiling((locationsHoriz[locationsHoriz.IndexOf(X0) + 1] - X0) / 2);
                        break;
                    case "UL":
                        if (Y0 != 0 && Y0 != H)
                        {
                            locationsVert.Add(Y0);
                        }
                        locationsVert.Sort((a, b) => a.CompareTo(b));
                        Y0 -= (int)Math.Ceiling((Y0 - locationsVert[locationsVert.IndexOf(Y0) - 1]) / 2);
                        if (X0 != 0 && X0 != W)
                        {
                            locationsHoriz.Add(X0);
                        }
                        locationsHoriz.Sort((a, b) => a.CompareTo(b));
                        X0 -= (int)Math.Ceiling((X0 - locationsHoriz[locationsHoriz.IndexOf(X0) - 1]) / 2);
                        break;
                    case "DL":
                        if (Y0 != 0 && Y0 != H)
                        {
                            locationsVert.Add(Y0);
                        }
                        locationsVert.Sort((a, b) => a.CompareTo(b));
                        Y0 += (int)Math.Ceiling((locationsVert[locationsVert.IndexOf(Y0) + 1] - Y0) / 2);
                        if (X0 != 0 && X0 != W)
                        {
                            locationsHoriz.Add(X0);
                        }
                        locationsHoriz.Sort((a, b) => a.CompareTo(b));
                        X0 -= (int)Math.Ceiling((X0 - locationsHoriz[locationsHoriz.IndexOf(X0) - 1]) / 2);
                        break;
                    default:
                        break;
                }

                // the location of the next window Batman should jump to.
                Console.WriteLine($"{X0} {Y0}");
            }
        }
    }
}
