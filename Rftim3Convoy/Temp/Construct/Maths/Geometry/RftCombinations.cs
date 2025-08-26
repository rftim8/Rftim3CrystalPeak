namespace Rftim3Convoy.Temp.Construct.Maths.Geometry
{
    public class RftCombinations
    {
        public RftCombinations()
        {
            ListCombinationsLinq();
        }

        private static void ListCombinationsLinq()
        {
            List<int> list = [0, 1, 2, 3];

            IEnumerable<int[]> r = Combinations(list);

            foreach (int[] r2 in r)
            {
                foreach (int r1 in r2)
                {
                    Console.Write($"{r1} ");
                }
                Console.WriteLine();
            }
        }

        private static IEnumerable<T[]> Combinations<T>(IEnumerable<T> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            T[] data = source.ToArray();

            return Enumerable
              .Range(0, 1 << data.Length)
              .Select(index => data
                 .Where((v, i) => (index & 1 << i) != 0)
                 .ToArray());
        }
    }
}
