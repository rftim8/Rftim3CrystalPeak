namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class BlowingFuse
    {
        public BlowingFuse()
        {
            //int c = 10;
            //List<Appliance> nx = new()
            //{
            //    new Appliance(11, false),
            //    new Appliance(6, false),
            //    new Appliance(11, false),
            //    new Appliance(10, false),
            //    new Appliance(10, false)
            //};
            //List<int> mx = new()
            //{
            //    3,
            //    3
            //};

            //int c = 82;
            //List<Appliance> nx = new()
            //{
            //    new Appliance(18, false),
            //    new Appliance(20, false),
            //    new Appliance(3, false),
            //    new Appliance(1, false),
            //    new Appliance(20, false)
            //};
            //List<int> mx = new()
            //{
            //    2,
            //    4,
            //    3,
            //    3,
            //    5,
            //    4,
            //    2,
            //    3
            //};

            int c = 71;
            List<Appliance> nx = new()
            {
                new Appliance(10, false),
                new Appliance(10, false),
                new Appliance(14, false),
                new Appliance(14, false),
                new Appliance(14, false),
                new Appliance(15, false)
            };
            List<int> mx = new()
            {
                4,
                3,
                3,
                5,
                4,
                1,
                5,
                5,
                5,
                4,
                1,
                5,
                5,
                4,
                2,
                3,
                3,
                3,
                1,
                6,
                2,
                1,
                5,
                5
            };

            Solve(nx, mx, c);
        }

        private static void Solve(List<Appliance> nx, List<int> mx, int c)
        {
            int currentConsumed = 0;
            int maxConsumed = 0;

            for (int i = 0; i < mx.Count; i++)
            {
                if (nx[mx[i] - 1].onoff)
                {
                    currentConsumed -= nx[mx[i] - 1].capacity;
                    nx[mx[i] - 1].onoff = false;
                }
                else
                {
                    if (currentConsumed < c && currentConsumed + nx[mx[i] - 1].capacity < c)
                    {
                        currentConsumed += nx[mx[i] - 1].capacity;
                        nx[mx[i] - 1].onoff = true;

                        if (maxConsumed < currentConsumed) maxConsumed = currentConsumed;
                    }
                    else
                    {
                        Console.WriteLine($"Fuse was blown.");
                        return;
                    }
                }
                Console.WriteLine($"{currentConsumed}");
            }

            Console.WriteLine($"Fuse was not blown.\nMaximal consumed current was {maxConsumed} A.");
        }

        class Appliance
        {
            public int capacity;
            public bool onoff;

            public Appliance(int capacity, bool onoff)
            {
                this.capacity = capacity;
                this.onoff = onoff;
            }
        }
    }
}
