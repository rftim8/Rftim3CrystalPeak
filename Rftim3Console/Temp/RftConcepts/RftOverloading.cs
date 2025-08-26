namespace Rftim3Console.Temp.RftConcepts
{
    public class RftOverloading
    {
        public RftOverloading()
        {
            Example1.UsageExample();
        }

        public class Example1
        {
            private static void F() => Console.WriteLine("F()");
            private static void F(object x) => Console.WriteLine($"F: {x.GetType()}");
            private static void F(int x) => Console.WriteLine($"F: {x.GetType()}");
            private static void F(double x) => Console.WriteLine($"F: {x.GetType()}");
            private static void F<T>(T x) => Console.WriteLine($"F: {x?.GetType()}");
            private static void F(double x, double y) => Console.WriteLine($"F: {x.GetType()} {y.GetType()}");
            public static void UsageExample()
            {
                F(); // Invokes F()
                F(4.0f); // Invokes F(object)
                F(3); // Invokes F(int)
                F(1.0); // Invokes F(double)
                F("abc"); // Invokes F<string>(string)
                F((double)1); // Invokes F(double)
                F((object)1); // Invokes F(object)
                F<int>(1); // Invokes F<int>(int)
                F(1, 1); // Invokes F(double, double)
            }
        }
    }
}
