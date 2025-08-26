namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftStruct
    {
        private readonly struct StructA(double x, double y)
        {
            public double X { get; } = x;
            public double Y { get; } = y;

            public StructA RotateRight() { return new StructA(-Y, X); }

            public static StructA operator +(StructA a, StructA b) { return new StructA(a.X + b.X, a.Y + b.Y); }

            public override string ToString() => $"{X} {Y}";
        }

        public RftStruct()
        {
            RftExample();
        }

        private static void RftExample()
        {
            StructA x = new(1, 2);
            StructA y = new(2, 3);
            Console.WriteLine($"{x + y}");
            Console.WriteLine($"{x.RotateRight()}");
            Console.WriteLine(x);
        }
    }
}
