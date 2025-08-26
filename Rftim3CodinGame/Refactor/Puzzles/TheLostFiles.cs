namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class TheLostFiles
    {
        /// <summary>
        /// You work in CG, where you wrote a bleeding-edge map generator for the next multi-player contest.
        /// Your map generator takes 2 parameters: C the number of continents and T the total number of tiles to generate.
        /// Generated tiles have polygonal shape and 2 tiles belong to the same continent if they share at least one vertex.
        /// 
        /// Your generator generates 2 files vertices.txt and edges.txt.
        /// The first one contains coordinates of tile vertices sorted by their index, the second one describes edges between vertices.
        /// You spent days to generate random maps and carefully saved the output files of the nicest ones for the contest... 
        /// but you just accidentally erased all the vertices.txt files!
        /// 
        /// With the right values of C and T, you could easily re-generate the erased files because you always hard-code random seeds to 42, 
        /// but you cannot remember these damn parameters and the contest is in 24h.
        /// No choice, you will have to cancel the contest...unless you can write a program to recover the C and T parameters from the leftover edges.txt files.
        /// 
        /// Your task
        /// Find the generator parameters C and T from the generated list of edges.
        /// 
        /// Example
        /// Here is a possible planar representation of the edges in the first test:
        /// 
        ///            1 --- 4 -- 10 -- 5
        ///            |     |     \   /
        ///            |     |      \ /
        ///            2 --- 7       8
        ///                   \     /
        /// 3 --- 6            \   /
        ///  \   /              \ /
        ///   \ /                0
        ///    9
        /// 
        /// The edges form C = 2 continents with 1 and 3 tiles for a total of T = 4 tiles.
        /// The output should be:
        /// 2 4
        /// </summary>
        public TheLostFiles()
        {
            Console.WriteLine(TheLostFiles0(
                13,
                [
                    "4 10",
                    "7 2",
                    "2 1",
                    "4 1",
                    "8 10",
                    "3 9",
                    "6 3",
                    "8 0",
                    "7 4",
                    "5 10",
                    "9 6",
                    "7 0",
                    "8 5"
                ]
                ));
        }

        public static string TheLostFiles0(int a0, List<string> a1) => RftTheLostFiles0(a0, a1);

        private static string RftTheLostFiles0(int E, List<string> inputs)
        {
            string res = "";

            // Find continents
            Dictionary<int, HashSet<int>> kvp = [];

            for (int i = 0; i < E; i++)
            {
                int n1 = int.Parse(inputs[i].Split(' ')[0]);
                int n2 = int.Parse(inputs[i].Split(' ')[1]);

                if (kvp.TryGetValue(n1, out HashSet<int>? value)) value.Add(n2);
                else kvp[n1] = [n2];

                if (kvp.TryGetValue(n2, out HashSet<int>? value1)) value1.Add(n1);
                else kvp[n2] = [n1];
            }

            foreach (KeyValuePair<int, HashSet<int>> item in kvp)
            {
                foreach (KeyValuePair<int, HashSet<int>> item1 in kvp)
                {
                    if (item.Key != item1.Key)
                    {
                        foreach (int item2 in item1.Value)
                        {
                            if (item.Value.Contains(item2))
                            {
                                foreach (int item3 in item1.Value)
                                {
                                    item.Value.Add(item3);
                                }
                                break;
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<int, HashSet<int>> item in kvp)
            {
                Console.WriteLine(item.Key);
                foreach (int item1 in item.Value.OrderBy(o => o))
                {
                    Console.Write($"{item1} ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            return res;
        }
    }
}