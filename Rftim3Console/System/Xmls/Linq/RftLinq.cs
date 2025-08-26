using System.Text;
using System.Xml.Linq;

namespace Rftim3Console.System.Xmls.Linq
{
    class RftLinq
    {
        //private readonly string message = "Woa";
        private static readonly int nr = 1234567890;
        private static readonly string[] cities = ["New York", "Paris", "Moscow", "Beijing", "Sidney"];
        private static readonly string[] cities2 = ["North America", "Europe", "Asia", "Australia", "Moscow"];
        private static readonly List<Student> students =
        [
            new Student("Ana", [90, 97, 96]),
            new Student("Maria", [30]),
            new Student("Eva", [100]),
            new Student("Dan", [50]),
            new Student("Mark", [99])
        ];
        private const int w = 8;
        private const int h = 12;
        private const int x = w * h;
        private static readonly int[] pixel = [
                220,
            251,
            30,
            182,
            233,
            122,
            150,
            30,
            132,
            101,
            135,
            212,
            246,
            201,
            128,
            203,
            62,
            33,
            39,
            70,
            73,
            175,
            218,
            140,
            44,
            165,
            9,
            140,
            83,
            67,
            34,
            100,
            142,
            75,
            125,
            242,
            49,
            175,
            209,
            37,
            252,
            26,
            123,
            6,
            186,
            72,
            230,
            94,
            218,
            85,
            228,
            205,
            146,
            67,
            219,
            187,
            194,
            159,
            81,
            190,
            51,
            235,
            41,
            121,
            208,
            33,
            245,
            71,
            172,
            218,
            97,
            130,
            122,
            31,
            135,
            198,
            135,
            249,
            174,
            28,
            162,
            109,
            149,
            216,
            156,
            195,
            140,
            10,
            100,
            252,
            1,
            164,
            150,
            22,
            144,
            109
            ];

        public RftLinq()
        {
            #region Linq
            //Console.WriteLine($"Aggregate List:");
            //RftAggregate(nr);
            //Console.WriteLine($"\nSmaller or Equal Than 3:");
            //RftSmallerThan(3);
            //Console.WriteLine($"\n\nSelect Where:");
            //RftSelectWhere(cities, students);
            //Console.WriteLine($"\nSelect Join:");
            //RftSelectJoin(cities, cities2);
            //Console.WriteLine($"\nSelect OrderBy:");
            //RftSelectOrderBy(cities);
            //Console.WriteLine($"\n\nCache ToList:");
            //RftCacheToList(cities);
            //Console.WriteLine($"\n\nCache ToArray:");
            //RftCacheToArray(cities2);
            //Console.WriteLine($"\n\nJoin:");
            //RftJoin(x, pixel);
            //RftZip();
            #endregion

            #region Queries
            //RftQuery();
            #endregion

            #region XML
            //Console.WriteLine($"\n\nXML Select:");
            ////RftXMLSelect();
            //Console.WriteLine($"\n\nXML Create file");
            //RftXMLJoin();
            #endregion

            Console.WriteLine(nr);
        }

        #region Linq
        private static void RftAggregate(int nr)
        {
            List<int> x = [];
            for (int i = 0; i < nr.ToString().Length; i++)
            {
                x.Add(int.Parse(nr.ToString().Substring(i, 1)));
            }

            Console.WriteLine($" - {x.Aggregate((a, b) => a + b)}");
        }

        private static void RftSmallerThan(sbyte limit)
        {
            sbyte[] source = [0, 1, 2, 3, 4, 5];
            //IEnumerable<sbyte> query = from item in source where item <= limit select item;
            IEnumerable<sbyte> query = source.Where(item => item <= limit);

            Console.Write($" - ");

            foreach (sbyte item in query)
            {
                Console.Write($"{item} ");
            }
        }

        private static void RftSelectWhere(string[] cities, List<Student> students)
        {
            //IEnumerable<string> customer = from customerz in cities where customerz == "Paris" select customerz;
            IEnumerable<string> customer = cities.Where(customerz => customerz == "Paris");

            foreach (string item in customer)
            {
                Console.WriteLine($" - {item}");
            }

            var Students = from studentz in students
                           from score in studentz.score
                           where score > 80
                           select new { Last = studentz.name, score };

            Console.WriteLine($"\nMultiple From:");
            foreach (var item in Students)
            {
                Console.WriteLine($" - {item.Last}: {item.score} ");
            }
        }

        private static void RftSelectJoin(string[] cities, string[] cities2)
        {
            var locations1 = from citiez in cities
                             join citiez2 in cities2 on citiez equals citiez2
                             select new { Citiez = citiez, Citiez2 = citiez2 };
            var locations = cities.Intersect(cities2);

            Console.Write($" - ");

            foreach (string? item in locations)
            {
                Console.WriteLine($"{item}");
            }

            foreach (var item in locations1)
            {
                Console.WriteLine($"{item.Citiez} {item.Citiez2}");
            }
        }

        private static void RftSelectOrderBy(string[] cities)
        {
            IOrderedEnumerable<string> Cities = from citiez in cities
                                                orderby citiez
                                                select citiez;

            Console.Write($" - ");

            foreach (string item in Cities)
            {
                Console.Write($"{item}, ");
            }
        }

        private static void RftCacheToList(string[] cities)
        {
            List<string>? city = [.. from Cities in cities where Cities.StartsWith('N') select Cities];

            foreach (string item in city)
            {
                Console.WriteLine($"{item}");
            }
        }

        private static void RftCacheToArray(string[] cities)
        {
            string[]? city = [.. from Cities in cities where Cities.StartsWith($"A") select Cities];

            foreach (string item in city)
            {
                Console.WriteLine($"{item}");
            }
        }

        private static void RftJoin(int x, int[] pixel)
        {
            string temp = string.Empty;

            for (int i = 1; i <= x; i++)
            {
                var binStr = string.Join("", pixel[i - 1].ToString().Select(b => Convert.ToString(b, 2)));
                temp += binStr.Substring(binStr.Length - 1, 1);
            }
            Console.WriteLine($"{temp}");

            StringBuilder result = new();
            while (temp.Length > 0)
            {
                string character = temp[..8];
                temp = temp[8..];
                int value = 0;
                foreach (int item in character)
                {
                    int z = item - 48;
                    value = value << 1 | z;
                }
                result.Append(Convert.ToChar(value));
            }

            Console.WriteLine($"{result}");
        }

        private static void RftZip()
        {
            List<int> listOne = [1, 2, 3];
            List<int> listTwo = [4, 5, 6];
            List<int> sumList = [.. listOne.Zip(listTwo, (x, y) => x + y)];

            foreach (int item in sumList)
            {
                Console.WriteLine($"Zip function: {item}");
            }
        }
        #endregion

        #region Queries
        private static void RftQuery()
        {
            string[] a = ["int", "double", "float", "char", "string", "New England", "New York", "Los Angeles", "Washington"];
            IOrderedEnumerable<string> x = from state in a where state.Contains(' ') orderby state descending select state;
            foreach (string item in x)
            {
                Console.WriteLine($"State: {item}");
            }

            int[] b = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            IOrderedEnumerable<int> y = from gt in b where gt > 5 orderby gt descending select gt;
            foreach (int item in y)
            {
                Console.WriteLine($"Greater than 5: {item}");
            }
        }
        #endregion

        #region XML
        static void RftXMLSelect()
        {
            XElement contacts = XElement.Load(@"/RftConstruct/RftLINQ/XMLFile1.xml");

            //IEnumerable<XElement>? foundContacts = from name in contacts.Elements() select name;
            IEnumerable<XElement>? foundContacts = contacts.Elements();

            foreach (XElement contact in foundContacts)
            {
                Console.WriteLine($"{contact}");
            }
        }

        static void RftXMLJoin()
        {
            List<Student1> students =
            [
                new Student1("Svetlana", "Omelchenko", 111, [97, 92, 81, 60]),
                new Student1("Claire", "O’Donnell", 112, [75, 84, 91, 39]),
                new Student1("Sven", "Mortensen", 113, [88, 94, 65, 91])
            ];

            XElement studentsToXML = new("Root",
                from student in students
                let scores = string.Join(",", student.scores)
                select new XElement("student", new XElement("First", student.first), new XElement("Last", student.last), new XElement("Scores", scores)));

            Console.WriteLine(studentsToXML);
        }
        #endregion
    }

    class Student(string name, List<int> score)
    {
        public string name = name;
        public List<int> score = score;
    }

    class Student1(string first, string last, int id, List<int> scores)
    {
        public string first = first;
        public string last = last;
        public int id = id;
        public List<int> scores = scores;
    }
}
