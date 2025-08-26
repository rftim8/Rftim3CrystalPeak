namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class Darts
    {
        public Darts()
        {
            //int size = 20;
            //List<Friend> friends = new()
            //{
            //    new Friend("Eric", 0),
            //    new Friend("Joe", 0),
            //    new Friend("Molly", 0),
            //    new Friend("Louis", 0),
            //    new Friend("Brandon", 0)
            //};
            //List<Dart> darts = new()
            //{
            //    new Dart("Joe", 0, 0),
            //    new Dart("Molly", 0, 0),
            //    new Dart("Brandon", 0, 0),
            //    new Dart("Eric", -50, 50),
            //    new Dart("Louis", 50, -50),
            //    new Dart("Joe", 10, 10),
            //    new Dart("Molly", -10, 10),
            //    new Dart("Brandon", -10, -10),
            //    new Dart("Eric", 5, 5),
            //    new Dart("Louis", 0, 0)
            //};

            int size = 100;
            List<Friend> friends = new()
            {
                new Friend("Will", 0),
                new Friend("Bill", 0),
                new Friend("Jill", 0),
                new Friend("Rekt", 0)
            };
            List<Dart> darts = new()
            {
                new Dart("Will", -51, 0),
                new Dart("Bill", 51, 0),
                new Dart("Jill", 49, 2),
                new Dart("Rekt", 0, 0),
                new Dart("Will", 35, 35),
                new Dart("Bill", -20, -21),
                new Dart("Jill", 1, 50),
                new Dart("Rekt", -13, 39)
            };

            //Joe 20
            //Molly 20
            //Brandon 20
            //Eric 15
            //Louis 15

            Solve(size, friends, darts);
        }

        private static void Solve(int size, List<Friend> friends, List<Dart> darts)
        {
            int radius = size / 2;

            foreach (Dart dart in darts)
            {
                double d = Dist(0, dart.x, 0, dart.y);

                Rft2DPoint p = new(dart.x, dart.y);

                bool ur = PointInTriangleArea(new RftTriangle(0, 0, 0, -radius, radius, 0), p);
                bool dr = PointInTriangleArea(new RftTriangle(0, 0, radius, 0, 0, radius), p);
                bool dl = PointInTriangleArea(new RftTriangle(0, 0, 0, radius, -radius, 0), p);
                bool ul = PointInTriangleArea(new RftTriangle(0, 0, -radius, 0, 0, -radius), p);

                bool romb = false;
                bool circle = false;
                bool square = false;

                if (ur || dr || dl || ul) romb = true;
                if (!romb)
                {
                    circle = d <= radius;
                    if (!circle) if (dart.x >= -radius && dart.x <= radius && dart.y >= -radius && dart.y <= radius) square = true;
                }

                Console.Write($"{radius}: {d}");
                Console.WriteLine($": {romb} {circle} {square}");

                foreach (Friend friend in friends)
                {
                    if (dart.name == friend.name)
                    {
                        if (romb) friend.score += 15;
                        if (circle) friend.score += 10;
                        if (square) friend.score += 5;
                    }
                }
            }
            IOrderedEnumerable<Friend> z = friends.OrderByDescending(o => o.score);

            foreach (Friend friend in z) Console.WriteLine($"{friend.name} {friend.score}");
        }

        private static bool PointInTriangleArea(RftTriangle t, Rft2DPoint p)
        {
            double a = ((t.AY - t.BY) * (p.x - t.BX) + (t.BX - t.AX) * (p.y - t.BY)) / ((t.AY - t.BY) * (t.OX - t.BX) + (t.BX - t.AX) * (t.OY - t.BY));
            double b = ((t.BY - t.OX) * (p.x - t.BX) + (t.OX - t.BX) * (p.y - t.BY)) / ((t.AY - t.BY) * (t.OX - t.BX) + (t.BX - t.AX) * (t.OY - t.BY));
            double c = 1 - a - b;

            if (a >= 0 && a <= 1 && b >= 0 && b <= 1 && c >= 0 && c <= 1) return true; // Point is inside of the triangle
            else return false; // Point is outside of the triangle
        }

        private static double Dist(int x1, int x2, int y1, int y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        class Rft2DPoint
        {
            public double x, y;

            public Rft2DPoint(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        class RftTriangle
        {
            public double OX, OY, AX, AY, BX, BY;

            public RftTriangle(double oX, double oY, double aX, double aY, double bX, double bY)
            {
                OX = oX;
                OY = oY;
                AX = aX;
                AY = aY;
                BX = bX;
                BY = bY;
            }
        }

        class Friend
        {
            public string name;
            public int score;

            public Friend(string name, int score)
            {
                this.name = name;
                this.score = score;
            }
        }

        class Dart
        {
            public string name;
            public int x, y;

            public Dart(string name, int x, int y)
            {
                this.name = name;
                this.x = x;
                this.y = y;
            }
        }
    }
}
