namespace Rftim3Console.Temp.RftConcepts
{
    class RftParameterOutput
    {
        static void Divide(int x, int y, out int result, out int remainder)
        {
            result = x / y;
            remainder = x % y;
        }

        public RftParameterOutput()
        {
            Divide(100, 2, out int res, out int rem);
            Console.WriteLine($"{res} {rem}");
        }
    }
}
