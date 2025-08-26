namespace Rftim3Console.System.Collections.Generic
{
    class RftDictionary
    {
        private static readonly Dictionary<int, string> kvp = [];

        public RftDictionary()
        {
            //RftBasic();
            RftDictionaryStruct();
        }

        private static void RftBasic()
        {
            for (int i = 0; i < 3; i++)
            {
                kvp.Add(i, "q");
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{kvp[i]}");
            }
        }

        private static void RftDictionaryStruct()
        {
            Point robot = new()
            {
                x = 1,
                y = 2
            };

            Dictionary<string, int> kvp1 = new()
            {
                [RftPointState(robot, 0)] = 1,
                [RftPointState(robot, 3)] = 2
            };
            kvp1.Add(RftPointState(robot, 1), 0);

            foreach (KeyValuePair<string, int> item in kvp1)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static string RftPointState(Point point, int direction)
        {
            return $"{point.x};{point.y};{direction}";
        }

        private struct Point
        {
            public int x;
            public int y;
        }
    }
}
