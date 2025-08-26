namespace Rftim3Convoy.Temp.Construct.Terminal
{
    public class RftTerminal
    {
        public RftTerminal()
        {

        }

        public static void RftReadResult<T>(IList<T> x)
        {
            foreach (T item in x)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public static void RftReadResult<T>(IList<IList<T>> x)
        {
            foreach (IList<T> item in x)
            {
                foreach (T item1 in item)
                {
                    Console.Write($"{item1} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void RftReadResult<T>(HashSet<T> x)
        {
            foreach (T item in x)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public static void RftReadResult<T>(IList<HashSet<T>> x)
        {
            foreach (HashSet<T> item in x)
            {
                foreach (T item1 in item)
                {
                    Console.Write($"{item1} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void RftReadResult<K, V>(IDictionary<K, V> x)
        {
            foreach (KeyValuePair<K, V> item in x)
            {
                Console.Write($"[{item.Key}]: {item.Value}; ");
            }
            Console.WriteLine();
        }

        public static List<string> RftReadFile(string path)
        {
            return [.. File.ReadAllLines(path)];
        }
    }
}
