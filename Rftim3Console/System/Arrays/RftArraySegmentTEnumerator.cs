namespace Rftim3Console.System.Arrays
{
    public class RftArraySegmentTEnumerator
    {
        public RftArraySegmentTEnumerator()
        {
            string[] x = ["one", "two", "three", "four"];

            ArraySegment<string> y = new(x, 1, 2);
            ArraySegment<string>.Enumerator z = y.GetEnumerator();

            while (z.MoveNext())
            {
                Console.WriteLine(z.Current);
            }
        }
    }
}
