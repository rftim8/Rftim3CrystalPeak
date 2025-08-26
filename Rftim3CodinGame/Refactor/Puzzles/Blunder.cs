namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class Blunder
    {
        public Blunder()
        {
            //List<string> map = new()
            //{
            //    "#####",
            //    "#@  #",
            //    "#   #",
            //    "#  $#",
            //    "#####"
            //};

            //List<string> map = new()
            //{
            //    "########",
            //    "# @    #",
            //    "#     X#",
            //    "# XXX  #",
            //    "#   XX #",
            //    "#   XX #",
            //    "#     $#",
            //    "########"
            //};

            //List<string> map = new()
            //{
            //    "########",
            //    "#     $#",
            //    "#      #",
            //    "#      #",
            //    "#  @   #",
            //    "#      #",
            //    "#      #",
            //    "########"
            //};

            //List<string> map = new()
            //{
            //    "########",
            //    "#      #",
            //    "# @    #",
            //    "# XX   #",
            //    "#  XX  #",
            //    "#   XX #",
            //    "#     $#",
            //    "########"
            //};

            //List<string> map = new()
            //{
            //    "##########",
            //    "#        #",
            //    "#  S   W #",
            //    "#        #",
            //    "#  $     #",
            //    "#        #",
            //    "#@       #",
            //    "#        #",
            //    "#E     N #",
            //    "##########"
            //};

            //List<string> map = new()
            //{
            //    "##########",
            //    "# @      #",
            //    "# B      #",
            //    "#XXX     #",
            //    "# B      #",
            //    "#    BXX$#",
            //    "#XXXXXXXX#",
            //    "#        #",
            //    "#        #",
            //    "##########"
            //};

            //List<string> map = new()
            //{
            //    "##########",
            //    "#    I   #",
            //    "#        #",
            //    "#       $#",
            //    "#       @#",
            //    "#        #",
            //    "#       I#",
            //    "#        #",
            //    "#        #",
            //    "##########"
            //};

            //List<string> map = new()
            //{
            //    "##########",
            //    "#    T   #",
            //    "#        #",
            //    "#        #",
            //    "#        #",
            //    "#@       #",
            //    "#        #",
            //    "#        #",
            //    "#    T  $#",
            //    "##########"
            //};

            //List<string> map = new()
            //{
            //    "##########",
            //    "#        #",
            //    "#  @     #",
            //    "#  B     #",
            //    "#  S   W #",
            //    "# XXX    #",
            //    "#  B   N #",
            //    "# XXXXXXX#",
            //    "#       $#",
            //    "##########"
            //};

            //List<string> map = new()
            //{
            //    "###############",
            //    "#      IXXXXX #",
            //    "#  @          #",
            //    "#             #",
            //    "#             #",
            //    "#  I          #",
            //    "#  B          #",
            //    "#  B   S     W#",
            //    "#  B   T      #",
            //    "#             #",
            //    "#         T   #",
            //    "#         B   #",
            //    "#            $#",
            //    "#        XXXX #",
            //    "###############"
            //};

            //List<string> map = new()
            //{
            //    "###############",
            //    "#      IXXXXX #",
            //    "#  @          #",
            //    "#E S          #",
            //    "#             #",
            //    "#  I          #",
            //    "#  B          #",
            //    "#  B   S     W#",
            //    "#  B   T      #",
            //    "#             #",
            //    "#         T   #",
            //    "#         B   #",
            //    "#N          W$#",
            //    "#        XXXX #",
            //    "###############"
            //};

            List<string> map = new()
            {
                "###############",
                "#  #@#I  T$#  #",
                "#  #    IB #  #",
                "#  #     W #  #",
                "#  #      ##  #",
                "#  #B XBN# #  #",
                "#  ##      #  #",
                "#  #       #  #",
                "#  #     W #  #",
                "#  #      ##  #",
                "#  #B XBN# #  #",
                "#  ##      #  #",
                "#  #       #  #",
                "#  #     W #  #",
                "#  #      ##  #",
                "#  #B XBN# #  #",
                "#  ##      #  #",
                "#  #       #  #",
                "#  #       #  #",
                "#  #      ##  #",
                "#  #  XBIT #  #",
                "#  #########  #",
                "#             #",
                "# ##### ##### #",
                "# #     #     #",
                "# #     #  ## #",
                "# #     #   # #",
                "# ##### ##### #",
                "#             #",
                "###############"
            };


            Solve(map);
        }

        private static void Solve(List<string> map)
        {
            InitPos initPos = new(0, 0);
            TeleportPos teleportPos1 = new(0, 0);
            TeleportPos teleportPos2 = new(0, 0);
            bool rotateS = true;
            bool rotateE = false;
            bool rotateN = false;
            bool rotateW = false;
            int countBreaker = 0;
            int countInverter = 0;
            List<string> moves = new();

            #region Points Collection
            foreach (string row in map)
            {
                #region InitPos
                if (row.Contains('@')) initPos = new(row.IndexOf("@"), map.IndexOf(row));
                #endregion
                #region TeleportPos
                if (row.Contains('T'))
                {
                    if (teleportPos1.x != 0 && teleportPos1.y != 0) teleportPos2 = new(row.IndexOf("T"), map.IndexOf(row));
                    else teleportPos1 = new(row.IndexOf("T"), map.IndexOf(row));
                }
                #endregion
            }
            #endregion

            int i = 0;
            #region Move
            while (i < 1000)
            {
                i++;
                if (rotateS)
                {
                    switch (map[initPos.y + 1][initPos.x].ToString())
                    {
                        #region Cardinals
                        case " ":
                            moves.Add("SOUTH");
                            initPos.y++;
                            break;
                        case "S":
                            moves.Add("SOUTH");
                            initPos.y++;
                            break;
                        case "E":
                            rotateE = true;
                            rotateS = false;
                            moves.Add("SOUTH");
                            initPos.y++;
                            break;
                        case "N":
                            rotateN = true;
                            rotateS = false;
                            moves.Add("SOUTH");
                            initPos.y++;
                            break;
                        case "W":
                            rotateW = true;
                            rotateS = false;
                            moves.Add("SOUTH");
                            initPos.y++;
                            break;
                        #endregion

                        #region PowerUps
                        case "B":
                            moves.Add("SOUTH");
                            initPos.y++;
                            countBreaker++;
                            break;
                        case "I":
                            moves.Add("SOUTH");
                            initPos.y++;
                            countInverter++;
                            break;
                        case "T":
                            moves.Add("SOUTH");
                            if (teleportPos1.x == initPos.x && teleportPos1.y == initPos.y + 1)
                            {
                                initPos.x = teleportPos2.x;
                                initPos.y = teleportPos2.y;
                            }
                            else
                            {
                                initPos.x = teleportPos1.x;
                                initPos.y = teleportPos1.y;
                            }
                            break;
                        #endregion

                        case "#":
                            if (countInverter % 2 != 0 && map[initPos.y][initPos.x - 1].ToString() != "#")
                            {
                                rotateW = true;
                                rotateS = false;
                            }
                            else
                            {
                                if (map[initPos.y][initPos.x + 1].ToString() != "#")
                                {
                                    rotateE = true;
                                    rotateS = false;
                                }
                                else
                                {
                                    rotateW = true;
                                    rotateS = false;
                                }
                            }
                            break;
                        case "X":
                            if (countBreaker % 2 != 0)
                            {
                                map[initPos.y + 1] = map[initPos.y + 1][..initPos.x] + " " + map[initPos.y + 1][(initPos.x + 1)..];
                                moves.Add("SOUTH");
                                initPos.y++;
                            }
                            else
                            {
                                if (countInverter % 2 != 0 && map[initPos.y][initPos.x - 1].ToString() != "X")
                                {
                                    rotateW = true;
                                    rotateS = false;
                                }
                                else
                                {
                                    if (map[initPos.y][initPos.x + 1].ToString() != "X")
                                    {
                                        rotateE = true;
                                        rotateS = false;
                                    }
                                    else
                                    {
                                        rotateW = true;
                                        rotateS = false;
                                    }
                                }
                            }
                            break;

                        #region End
                        case "$":
                            moves.Add("SOUTH");
                            ShowMoves(moves);
                            return;
                        default:
                            break;
                            #endregion
                    }
                }
                else if (rotateE)
                {
                    switch (map[initPos.y][initPos.x + 1].ToString())
                    {
                        #region Cardinals
                        case " ":
                            moves.Add("EAST");
                            initPos.x++;
                            break;
                        case "E":
                            moves.Add("EAST");
                            initPos.x++;
                            break;
                        case "N":
                            rotateN = true;
                            rotateE = false;
                            moves.Add("EAST");
                            initPos.x++;
                            break;
                        case "W":
                            rotateW = true;
                            rotateE = false;
                            moves.Add("EAST");
                            initPos.x++;
                            break;
                        case "S":
                            rotateS = true;
                            rotateE = false;
                            moves.Add("EAST");
                            initPos.x++;
                            break;
                        #endregion

                        #region PowerUps
                        case "B":
                            moves.Add("EAST");
                            initPos.x++;
                            countBreaker++;
                            break;
                        case "I":
                            moves.Add("EAST");
                            initPos.x++;
                            countInverter++;
                            break;
                        case "T":
                            moves.Add("EAST");
                            if (teleportPos1.x == initPos.x + 1 && teleportPos1.y == initPos.y)
                            {
                                initPos.x = teleportPos2.x;
                                initPos.y = teleportPos2.y;
                            }
                            else
                            {
                                initPos.x = teleportPos1.x;
                                initPos.y = teleportPos1.y;
                            }
                            break;
                        #endregion

                        case "#":
                            if (countInverter % 2 != 0 && map[initPos.y - 1][initPos.x].ToString() != "#")
                            {
                                rotateN = true;
                                rotateE = false;
                            }
                            else
                            {
                                if (map[initPos.y + 1][initPos.x].ToString() != "#")
                                {
                                    rotateS = true;
                                    rotateE = false;
                                }
                                else
                                {
                                    rotateN = true;
                                    rotateE = false;
                                }
                            }
                            break;
                        case "X":
                            if (countBreaker % 2 != 0)
                            {
                                map[initPos.y] = map[initPos.y][..(initPos.x + 1)] + " " + map[initPos.y][(initPos.x + 2)..];
                                moves.Add("EAST");
                                initPos.x++;
                            }
                            else
                            {
                                if (countInverter % 2 != 0 && map[initPos.y - 1][initPos.x].ToString() != "X")
                                {
                                    rotateN = true;
                                    rotateE = false;
                                }
                                else
                                {
                                    if (map[initPos.y + 1][initPos.x].ToString() != "X")
                                    {
                                        rotateS = true;
                                        rotateE = false;
                                    }
                                    else
                                    {
                                        rotateN = true;
                                        rotateE = false;
                                    }
                                }
                            }
                            break;

                        #region End
                        case "$":
                            moves.Add("EAST");
                            ShowMoves(moves);
                            return;
                        default:
                            break;
                            #endregion
                    }
                }
                else if (rotateN)
                {
                    switch (map[initPos.y - 1][initPos.x].ToString())
                    {
                        #region Cardinals
                        case " ":
                            moves.Add("NORTH");
                            initPos.y--;
                            break;
                        case "N":
                            moves.Add("NORTH");
                            initPos.y--;
                            break;
                        case "W":
                            rotateW = true;
                            rotateN = false;
                            moves.Add("NORTH");
                            initPos.y--;
                            break;
                        case "S":
                            rotateS = true;
                            rotateN = false;
                            moves.Add("NORTH");
                            initPos.y--;
                            break;
                        case "E":
                            rotateE = true;
                            rotateN = false;
                            moves.Add("NORTH");
                            initPos.y--;
                            break;
                        #endregion

                        #region PowerUps
                        case "B":
                            moves.Add("NORTH");
                            initPos.y--;
                            countBreaker++;
                            break;
                        case "I":
                            moves.Add("NORTH");
                            initPos.y--;
                            countInverter++;
                            break;
                        case "T":
                            moves.Add("NORTH");
                            if (teleportPos1.x == initPos.x && teleportPos1.y == initPos.y - 1)
                            {
                                initPos.x = teleportPos2.x;
                                initPos.y = teleportPos2.y;
                            }
                            else
                            {
                                initPos.x = teleportPos1.x;
                                initPos.y = teleportPos1.y;
                            }
                            break;
                        #endregion

                        case "#":
                            if (countInverter % 2 != 0 && map[initPos.y][initPos.x - 1].ToString() != "#")
                            {
                                rotateW = true;
                                rotateN = false;
                            }
                            else
                            {
                                if (map[initPos.y][initPos.x + 1].ToString() != "#")
                                {
                                    rotateE = true;
                                    rotateN = false;
                                }
                                else
                                {
                                    rotateW = true;
                                    rotateN = false;
                                }
                            }
                            break;
                        case "X":
                            if (countBreaker % 2 != 0)
                            {
                                map[initPos.y - 1] = map[initPos.y - 1][..initPos.x] + " " + map[initPos.y - 1][(initPos.x + 1)..];
                                moves.Add("NORTH");
                                initPos.y--;
                            }
                            else
                            {
                                if (countInverter % 2 != 0 && map[initPos.y][initPos.x - 1].ToString() != "X")
                                {
                                    rotateW = true;
                                    rotateN = false;
                                }
                                else
                                {
                                    if (map[initPos.y][initPos.x + 1].ToString() != "X")
                                    {
                                        rotateE = true;
                                        rotateN = false;
                                    }
                                    else
                                    {
                                        rotateW = true;
                                        rotateN = false;
                                    }
                                }
                            }
                            break;

                        #region End
                        case "$":
                            moves.Add("NORTH");
                            ShowMoves(moves);
                            return;
                        default:
                            break;
                            #endregion
                    }
                }
                else if (rotateW)
                {
                    switch (map[initPos.y][initPos.x - 1].ToString())
                    {
                        #region Cardinals
                        case " ":
                            moves.Add("WEST");
                            initPos.x--;
                            break;
                        case "W":
                            moves.Add("WEST");
                            initPos.x--;
                            break;
                        case "S":
                            rotateS = true;
                            rotateW = false;
                            moves.Add("WEST");
                            initPos.x--;
                            break;
                        case "E":
                            rotateE = true;
                            rotateW = false;
                            moves.Add("WEST");
                            initPos.x--;
                            break;
                        case "N":
                            rotateN = true;
                            rotateW = false;
                            moves.Add("WEST");
                            initPos.x--;
                            break;
                        #endregion

                        #region PowerUps
                        case "B":
                            moves.Add("WEST");
                            initPos.x--;
                            countBreaker++;
                            break;
                        case "I":
                            moves.Add("WEST");
                            initPos.x--;
                            countInverter++;
                            break;
                        case "T":
                            moves.Add("WEST");
                            if (teleportPos1.x == initPos.x - 1 && teleportPos1.y == initPos.y)
                            {
                                initPos.x = teleportPos2.x;
                                initPos.y = teleportPos2.y;
                            }
                            else
                            {
                                initPos.x = teleportPos1.x;
                                initPos.y = teleportPos1.y;
                            }
                            break;
                        #endregion

                        case "#":
                            if (countInverter % 2 != 0 && map[initPos.y - 1][initPos.x].ToString() != "#")
                            {
                                rotateN = true;
                                rotateW = false;
                            }
                            else
                            {
                                if (map[initPos.y + 1][initPos.x].ToString() != "#")
                                {
                                    rotateS = true;
                                    rotateW = false;
                                }
                                else
                                {
                                    rotateS = true;
                                    rotateW = false;
                                }
                            }
                            break;
                        case "X":
                            if (countBreaker % 2 != 0)
                            {
                                map[initPos.y] = map[initPos.y][..(initPos.x - 1)] + " " + map[initPos.y][initPos.x..];
                                moves.Add("WEST");
                                initPos.x--;
                            }
                            else
                            {
                                if (countInverter % 2 != 0 && map[initPos.y - 1][initPos.x].ToString() != "X")
                                {
                                    rotateN = true;
                                    rotateW = false;
                                }
                                else
                                {
                                    if (map[initPos.y + 1][initPos.x].ToString() != "X")
                                    {
                                        rotateS = true;
                                        rotateW = false;
                                    }
                                    else
                                    {
                                        rotateS = true;
                                        rotateW = false;
                                    }
                                }
                            }
                            break;

                        #region End
                        case "$":
                            moves.Add("WEST");
                            ShowMoves(moves);
                            return;
                        default:
                            break;
                            #endregion
                    }
                }
            }
            #endregion

            if (i == 1000) Console.WriteLine("LOOP");
        }

        public static void ShowMoves(List<string> moves)
        {
            foreach (string move in moves)
            {
                Console.WriteLine($"{move}");
            }
        }

        class InitPos
        {
            public int x, y;

            public InitPos(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        class ExitPos
        {
            public int x, y;

            public ExitPos(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        class TeleportPos
        {
            public int x, y;

            public TeleportPos(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
