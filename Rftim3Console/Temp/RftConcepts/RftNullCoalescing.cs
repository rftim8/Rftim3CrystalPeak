namespace Rftim3Console.Temp.RftConcepts
{
    public class RftNullCoalescing
    {
        public RftNullCoalescing()
        {
            RftCoalesce();
        }

        private static void RftCoalesce()
        {
            int? i = null;

            Console.WriteLine($"{i ??= 20}");
        }
    }
}
