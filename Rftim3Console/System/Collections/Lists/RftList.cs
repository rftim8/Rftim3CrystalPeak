namespace Rftim3Console.System.Collections.Lists
{
    class RftList
    {
        private static readonly List<string> names = ["asd", "qwe", "zxc"];
        private static readonly List<int> l0 = [0, 1, 2, 3, 4, 5];

        public RftList()
        {
            RftProperties();
            StringToList("test\ntes0\ntest1\ntest2\ntest3");
        }

        private static void RftProperties()
        {
            foreach (string item in names)
            {
                Console.WriteLine($"{item.ToUpper()}");
            }

            Console.WriteLine(names.Contains("ASD", StringComparer.OrdinalIgnoreCase));

            int[] a = [9, 8, 7, 6];
            l0.AddRange(a);
            l0.Sort();

            foreach (int item in l0)
            {
                Console.WriteLine(item);
            }
        }

        private static void StringToList(string test)
        {
            List<string> l = [.. test.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries)];

            foreach (string item in l)
            {
                Console.WriteLine(item);
            }

            List<string> l0 = [.. test.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)];

            foreach (string item in l0)
            {
                Console.WriteLine(item);
            }
        }
    }
}
