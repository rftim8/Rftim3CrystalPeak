namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class Asteroids
    {
        public Asteroids()
        {
            //int W = 5;
            //const int H = 5;
            //int T1 = 1;
            //int T2 = 2;
            //int T3 = 5;

            //int W = 6;
            //const int H = 6;
            //int T1 = 1;
            //int T2 = 5;
            //int T3 = 6;

            //int W = 6;
            //const int H = 6;
            //int T1 = 1;
            //int T2 = 6;
            //int T3 = 11;

            //int W = 6;
            //const int H = 6;
            //int T1 = 1;
            //int T2 = 6;
            //int T3 = 11;

            int W = 20;
            const int H = 20;
            int T1 = 25;
            int T2 = 75;
            int T3 = 100;

            //string[] firstPictureRow = new string[H]
            //{
            //        "..A..",
            //        ".....",
            //        ".....",
            //        ".....",
            //        "....."
            //};
            //string[] secondPictureRow = new string[H]
            //{
            //        ".A...",
            //        ".....",
            //        ".....",
            //        ".....",
            //        "....."
            //};

            //string[] firstPictureRow = new string[H]
            //{
            //        "A.....",
            //        "......",
            //        "......",
            //        "......",
            //        "......",
            //        "......"
            //};
            //string[] secondPictureRow = new string[H]
            //{
            //        "....A.",
            //        "......",
            //        "......",
            //        "......",
            //        "......",
            //        "......"
            //};

            //string[] firstPictureRow = new string[H]
            //{
            //        "..H...",
            //        "......",
            //        "E...G.",
            //        "......",
            //        "..F...",
            //        "......"
            //};
            //string[] secondPictureRow = new string[H]
            //{
            //        "......",
            //        "..H...",
            //        ".E.G..",
            //        "..F...",
            //        "......",
            //        "......"
            //};

            //string[] firstPictureRow = new string[H]
            //{
            //        "A.....",
            //        "......",
            //        "B.....",
            //        "......",
            //        "......",
            //        "......"
            //};
            //string[] secondPictureRow = new string[H]
            //{
            //        ".A....",
            //        "B.....",
            //        "......",
            //        "......",
            //        "......",
            //        "......"
            //};

            string[] firstPictureRow = new string[H]
            {
                ".................O..",
                ".....N...........U..",
                ".............L.R....",
                "....................",
                "..........Z..V.H....",
                "................X...",
                ".............P......",
                ".............A......",
                ".Q.............T....",
                "..................F.",
                "....................",
                "......K............W",
                "...............Y....",
                "..............S.....",
                "...........JE......D",
                "...M................",
                "......B..G...C....I.",
                "....................",
                "....................",
                "...................."
            };
            string[] secondPictureRow = new string[H]
            {
                "G...................",
                "...............W....",
                "...................C",
                "...E................",
                "..............K.....",
                "...........T........",
                "............A.......",
                ".....P...FLI......N.",
                "....................",
                "........D...........",
                "......S..Y.........M",
                ".........B....Z.....",
                "....................",
                "....V.............J.",
                ".........O..........",
                "..X...........U.....",
                "....................",
                "....................",
                "..Q................R",
                ".......H............"
            };


            Solve(W, H, T1, T2, T3, firstPictureRow, secondPictureRow);
        }

        public static void Solve(int w, int h, int t1, int t2, int t3, string[] firstPictureRow, string[] secondPictureRow)
        {
            List<Asteroid> asteroids = new();

            #region Process First Picture
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (firstPictureRow[i][j].ToString() != ".")
                    {
                        asteroids.Add(new Asteroid(firstPictureRow[i][j].ToString(), t1, t2, t3, j, 0, 0, i, 0, 0));
                    }
                }
            }
            #endregion

            #region Process Second Picture
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (secondPictureRow[i][j].ToString() != ".")
                    {
                        foreach (Asteroid asteroid in asteroids)
                        {
                            if (asteroid.name == secondPictureRow[i][j].ToString())
                            {
                                asteroid.x2 = j;
                                asteroid.y2 = i;
                            }
                        }
                    }
                }
            }
            #endregion

            foreach (Asteroid asteroid1 in asteroids)
            {
                if (asteroid1.x1 != asteroid1.x2)
                {
                    if (asteroid1.x1 < asteroid1.x2)
                    {
                        if (t2 - t1 == t3 - t2)
                        {
                            asteroid1.x3 = asteroid1.x2 + (asteroid1.x2 - asteroid1.x1);
                        }
                        else
                        {
                            float deltaT = (float)(t3 - t2) / (t2 - t1);
                            asteroid1.x3 = asteroid1.x2 + (int)Math.Floor(deltaT * (asteroid1.x2 - asteroid1.x1));
                        }
                    }
                    else if (asteroid1.x1 > asteroid1.x2)
                    {
                        if (t2 - t1 == t3 - t2)
                        {
                            asteroid1.x3 = asteroid1.x2 - (asteroid1.x1 - asteroid1.x2);
                        }
                        else
                        {
                            float deltaT = (float)(t3 - t2) / (t2 - t1);
                            asteroid1.x3 = asteroid1.x2 - (int)Math.Ceiling(deltaT * (asteroid1.x1 - asteroid1.x2));
                        }
                    }
                }
                else
                {
                    asteroid1.x3 = asteroid1.x2;
                }

                if (asteroid1.y1 != asteroid1.y2)
                {
                    if (asteroid1.y1 < asteroid1.y2)
                    {
                        if (t2 - t1 == t3 - t2)
                        {
                            asteroid1.y3 = asteroid1.y2 + (asteroid1.y2 - asteroid1.y1);
                        }
                        else
                        {
                            float deltaT = (float)(t3 - t2) / (t2 - t1);
                            asteroid1.y3 = asteroid1.y2 + (int)Math.Floor(deltaT * (asteroid1.y2 - asteroid1.y1));
                        }
                    }
                    else if (asteroid1.y1 > asteroid1.y2)
                    {
                        if (t2 - t1 == t3 - t2)
                        {
                            asteroid1.y3 = asteroid1.y2 - (asteroid1.y1 - asteroid1.y2);
                        }
                        else
                        {
                            float deltaT = (float)(t3 - t2) / (t2 - t1);
                            asteroid1.y3 = asteroid1.y2 - (int)Math.Ceiling(deltaT * (asteroid1.y1 - asteroid1.y2));

                            if (asteroid1.name == "K")
                            {
                                Console.WriteLine($"{deltaT}");
                                Console.WriteLine($"{asteroid1.y2}");
                                Console.WriteLine($"{(int)Math.Floor(deltaT * (asteroid1.y1 - asteroid1.y2))}");
                                Console.WriteLine($"{asteroid1.y3}");
                            }
                        }
                    }
                }
                else
                {
                    asteroid1.y3 = asteroid1.y2;
                }
            }

            #region Render Pictures
            Console.WriteLine();

            asteroids.Sort((a, b) => a.name.CompareTo(b.name));

            string[,] thirdPicture = new string[w, h];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    foreach (Asteroid asteroid in asteroids)
                    {
                        if (asteroid.x3 == j && asteroid.y3 == i)
                        {
                            thirdPicture[i, j] = asteroid.name;
                            break;
                        }
                        else
                        {
                            thirdPicture[i, j] = ".";
                        }
                    }
                }
            }

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Console.Write($"{thirdPicture[i, j]}");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\n\n");
            #endregion

            #region Testing
            foreach (Asteroid item in asteroids)
            {
                Console.WriteLine($"{item.name}: \tt: {item.t1} -> {item.t2} -> {item.t3}\n \tx: {item.x1} -> {item.x2} -> {item.x3} \n\ty: {item.y1} -> {item.y2} -> {item.y3}");
            }
            #endregion
        }

        class Asteroid
        {
            public string name;
            public int t1, t2, t3, x1, x2, x3, y1, y2, y3;

            public Asteroid(string name, int t1, int t2, int t3, int x1, int x2, int x3, int y1, int y2, int y3)
            {
                this.name = name;
                this.t1 = t1;
                this.t2 = t2;
                this.t3 = t3;
                this.x1 = x1;
                this.x2 = x2;
                this.x3 = x3;
                this.y1 = y1;
                this.y2 = y2;
                this.y3 = y3;
            }
        }
    }
}
