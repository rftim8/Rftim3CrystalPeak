namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class PanelCount
    {
        /// <summary>
        /// Goal : count the number of persons matching some formulas.
        /// 
        /// Input :
        /// - The properties of the persons(e.g.Age, Gender).
        /// - A list of persons.Each one is identified by a name and its space-separated properties (e.g.John 25 London).
        /// - A list of formulas.Each formula is a combination of properties, and is used to filter the matching persons (e.g.Town= Paris AND Gender = Male)
        /// 
        /// Output :
        /// For each formula, filter the matching persons and print their count.
        /// 
        /// Example : Gender= Male AND Age = 25 AND Town = Berlin.The expected output is the number of 25yo men living in Berlin.
        /// 
        /// Note : each formula has a variable number of properties.
        /// </summary>
        public PanelCount()
        {
            Dictionary<string, int> kvp = [];
            kvp.Add("Gender", 0);

            Console.WriteLine(PanelCount0(
                kvp,
                [
                    "Leo Male",
                    "Samuel Male",
                    "Maya Female",
                    "Diane Female",
                    "Mael Male"
                ],
                [
                    "Gender=Female"
                ]
                ));
        }

        public static int PanelCount0(Dictionary<string, int> a0, string[] a1, string[] a2) => RftPanelCount0(a0, a1, a2);

        private static int RftPanelCount0(Dictionary<string, int> property, string[] person, string[] formula)
        {
            foreach (string item in formula)
            {
                List<string> l = [.. item.Split(" ")];
                l.RemoveAll(o => o == "AND");
                List<(string, int)> t = [];
                bool notFound = false;
                for (int i = 0; i < l.Count; i++)
                {
                    if (!property.ContainsKey(l[i].Split("=")[0]))
                    {
                        notFound = true;
                        break;
                    }
                    t.Add((l[i].Split("=")[1], property[l[i].Split("=")[0]]));
                }

                int res = 0;
                if (!notFound)
                {
                    foreach (string item1 in person)
                    {
                        List<string> l0 = [.. item1.Split(" ")];
                        int c = 0;

                        foreach ((string, int) item2 in t)
                        {
                            if (l0[item2.Item2 + 1] == item2.Item1) c++;
                        }

                        if (c == t.Count) res++;
                    }
                }
                Console.WriteLine(res);
            }

            return -1;
        }
    }
}
