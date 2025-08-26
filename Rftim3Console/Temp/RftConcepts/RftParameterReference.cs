namespace Rftim3Console.Temp.RftConcepts
{
    class RftParameterReference
    {
        static void Swap(ref int x, ref int y)
        {
            (y, x) = (x, y);
        }

        public RftParameterReference()
        {
            int i = 1, j = 2;
            Swap(ref i, ref j);
            Console.WriteLine($"{i} {j}");

            (j, i) = (i, j);
            Console.WriteLine($"{i} {j}");
        }
    }
}
