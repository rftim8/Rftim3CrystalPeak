namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class NetworkCabling
    {
        public NetworkCabling()
        {
            //List<Point> points = new()
            //{
            //    new Point(0, 0),
            //    new Point(1, 1),
            //    new Point(2, 2)
            //};

            //List<Point> points = new()
            //{
            //    new Point(0, 0),
            //    new Point(1, 2),
            //    new Point(2, 2)
            //};

            //List<Point> points = new()
            //{
            //    new Point(1, 2),
            //    new Point(0, 0),
            //    new Point(2, 2),
            //    new Point(1, 3)
            //};

            //List<Point> points = new()
            //{
            //    new Point(-5, -3),
            //    new Point(-9, 2),
            //    new Point(3, -4)
            //};

            //List<Point> points = new()
            //{
            //    new Point(-5, -3),
            //    new Point(-9, 2),
            //    new Point(3, -4)
            //};

            List<Point> points = new()
            {
                new Point(2, 3),
                new Point(1, 1),
                new Point(4, 4)
            };


            Solve(points);
        }

        private static void Solve(List<Point> points)
        {
            points = points.OrderBy(o => o.y).ThenBy(o => o.x).ToList();
            long result = 0;

            foreach (Point point in points)
            {
                Console.WriteLine($"{point.x} : {point.y}");
            }

            long q = points[(int)Math.Ceiling((decimal)points.Count / 2) - 1].y;

            foreach (Point point in points)
            {
                if (point.y < q)
                {
                    if (point.y < 0) result += -point.y + q;
                    if (point.y >= 0) result += q - point.y;
                }

                if (point.y > q)
                {
                    if (q < 0) result += -q + point.y;
                    if (q >= 0) result += point.y - q;
                }
            }

            if (points.Count > 1)
            {
                long xmin = points.Min(o => o.x);
                long xmax = points.Max(o => o.x);

                if (xmin < 0) result += -xmin + xmax;
                else result += xmax - xmin;
            }

            Console.WriteLine(q);
            Console.WriteLine(Math.Abs(points.Max(o => o.x)) + Math.Abs(points.Min(o => o.x)));
            Console.WriteLine(result);
        }

        class Point
        {
            public long x, y;

            public Point(long x, long y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
