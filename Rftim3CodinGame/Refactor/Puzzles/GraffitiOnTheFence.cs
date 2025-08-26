namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class GraffitiOnTheFence
    {
        public GraffitiOnTheFence()
        {
            int L = 10;
            List<Paint> paints = new()
            {
                new Paint(1, 4),
                new Paint(5, 6)
            };

            //int L = 10;
            //List<Paint> paints = new()
            //{
            //    new Paint(1, 4),
            //    new Paint(3, 5)
            //};

            //int L = 12;
            //List<Paint> paints = new()
            //{
            //    new Paint(6, 10),
            //    new Paint(0, 4),
            //    new Paint(7, 8),
            //    new Paint(3, 7),
            //    new Paint(8, 12)
            //};

            //int L = 10;
            //List<Paint> paints = new()
            //{
            //    new Paint(1, 4),
            //    new Paint(2, 3)
            //};

            //int L = 100;
            //List<Paint> paints = new()
            //{
            //    new Paint(2, 3),
            //    new Paint(3, 20),
            //    new Paint(20, 30),
            //    new Paint(30, 40),
            //    new Paint(41, 60),
            //    new Paint(60, 70),
            //    new Paint(70, 88),
            //    new Paint(88, 99),
            //    new Paint(99, 100),
            //    new Paint(40, 41)
            //};

            Solve(L, paints);
        }

        private static void Solve(int l, List<Paint> paints)
        {
            List<Paint> result = new();
            paints.Sort((a, b) => a.x.CompareTo(b.x));
            Paint temp = new(paints[0].x, paints[0].y);

            for (int i = 1; i < paints.Count; i++)
            {
                if (temp.y >= paints[i].x && temp.y <= paints[i].y) temp = new(temp.x, paints[i].y);

                if (temp.y < paints[i].x)
                {
                    result.Add(temp);
                    temp = new(paints[i].x, paints[i].y);
                }

                if (i == paints.Count - 1) result.Add(temp);
            }

            result.Sort((a, b) => a.x.CompareTo(b.x));

            foreach (Paint item in result)
            {
                Console.WriteLine($"{item.x} : {item.y}");
            }
            Console.WriteLine();

            for (int i = 0; i < result.Count; i++)
            {
                if (i == 0)
                {
                    if (result[i].x > 0 && result[i].y < l && result.Count == 1)
                    {
                        Console.WriteLine($"0 {result[i].x}");
                        Console.WriteLine($"{result[i].y} {l}");
                    }
                    else if (result[i].x > 0 && result[i].y < l && result.Count > 1) Console.WriteLine($"0 {result[i].x}");
                    else if (result[i].x > 0 && result[i].y == l) Console.WriteLine($"0 {result[i].x}");
                    else if (result[i].x == 0 && result[i].y == l) Console.WriteLine($"All painted");
                    else if (result[i].x == 0 && result[i].y < l && result.Count == 1) Console.WriteLine($"{result[i].y} {l}");
                }

                if (result.Count > 1 && i < result.Count - 1) Console.WriteLine($"{result[i].y} {result[i + 1].x}");

                if (i == result.Count - 1)
                {
                    if (result.Count > 1 && result[i].y < l) Console.WriteLine($"{result[i].y} {l}");
                }

            }
        }

        class Paint
        {
            public int x, y;

            public Paint(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
