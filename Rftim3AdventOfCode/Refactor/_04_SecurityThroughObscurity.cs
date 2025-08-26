using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _04_SecurityThroughObscurity : I_04_SecurityThroughObscurity
    {
        #region Static
        private readonly List<string>? data;

        public _04_SecurityThroughObscurity()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_04_SecurityThroughObscurity));
        }

        /// <summary>
        /// Finally, you come across an information kiosk with a list of rooms. 
        /// Of course, the list is encrypted and full of decoy data, but the instructions to decode the list are barely hidden nearby. 
        /// Better remove the decoy data first.
        /// 
        /// Each room consists of an encrypted name(lowercase letters separated by dashes) followed by a dash, a sector ID, and a checksum in square brackets.
        /// 
        /// A room is real (not a decoy) if the checksum is the five most common letters in the encrypted name, in order, with ties broken by alphabetization.For example:
        /// 
        /// aaaaa-bbb-z-y-x-123[abxyz] is a real room because the most common letters are a(5), b(3), and then a tie between x, y, and z, which are listed alphabetically.
        /// a-b-c-d-e-f-g-h-987[abcde] is a real room because although the letters are all tied (1 of each), the first five are listed alphabetically.
        /// not-a-real-room-404[oarel] is a real room.
        /// totally-real-room-200[decoy] is not.
        /// Of the real rooms from the list above, the sum of their sector IDs is 1514.
        /// 
        /// What is the sum of the sector IDs of the real rooms?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;
            foreach (string item in input)
            {
                string s0 = item.Split('[')[0].Replace("-", "");
                string s1 = item.Split('[')[1].Replace("]", "");

                Dictionary<char, int> kvp = [];

                string id = string.Empty;
                foreach (char item1 in s0)
                {
                    if (char.IsLetter(item1))
                    {
                        if (kvp.TryGetValue(item1, out int value)) kvp[item1] = ++value;
                        else kvp[item1] = 1;
                    }
                    else id += item1;
                }

                List<KeyValuePair<char, int>> x = [.. kvp.OrderByDescending(o => o.Value).ThenBy(o => o.Key)];

                string t = string.Empty;
                foreach (KeyValuePair<char, int> item2 in x[..5])
                {
                    t += item2.Key;
                }

                if (t.SequenceEqual(s1)) r += int.Parse(id);
                Console.WriteLine(t);
            }

            return r;
        }

        /// <summary>
        /// With all the decoy data out of the way, it's time to decrypt this list and get moving.
        /// 
        /// The room names are encrypted by a state-of-the-art shift cipher, which is nearly unbreakable without the right software.
        /// However, the information kiosk designers at Easter Bunny HQ were not expecting to deal with a master cryptographer like yourself.
        /// 
        /// To decrypt a room name, rotate each letter forward through the alphabet a number of times equal to the room's sector ID. 
        /// A becomes B, B becomes C, Z becomes A, and so on. 
        /// Dashes become spaces.
        /// 
        /// For example, the real name for qzmt-zixmtkozy-ivhz-343 is very encrypted name.
        /// 
        /// What is the sector ID of the room where North Pole objects are stored?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;
            int location = 0;

            foreach (string item in input)
            {
                string s = item.Split('[')[0];
                string s0 = s.Remove(s.LastIndexOf('-'), s.Length - s.LastIndexOf('-'));
                string s1 = item.Split('[')[1].Replace("]", "");
                int id = int.Parse(item.Split('[')[0].Split('-').Last());
                int offset = id % 26;

                Dictionary<char, int> kvp = [];

                foreach (char item1 in s0)
                {
                    if (char.IsLetter(item1))
                    {
                        if (kvp.TryGetValue(item1, out int value)) kvp[item1] = ++value;
                        else kvp[item1] = 1;
                    }
                }

                List<KeyValuePair<char, int>> x = [.. kvp.OrderByDescending(o => o.Value).ThenBy(o => o.Key)];

                string t = string.Empty;
                foreach (KeyValuePair<char, int> item2 in x[..5])
                {
                    t += item2.Key;
                }

                string t0 = string.Empty;
                if (t.SequenceEqual(s1))
                {
                    r += id;
                    t0 = s0.Replace($" {id}", "");
                }

                if (!string.IsNullOrEmpty(t0))
                {
                    string t1 = string.Empty;
                    foreach (char item1 in t0)
                    {
                        if (char.IsLetter(item1))
                        {
                            int i = (item1 - 97 + id) % 26;
                            t1 += (char)(i + 97);
                        }
                        else t1 += ' ';
                    }
                    if (t1.Contains("north")) location = id;
                }
            }

            return location;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _04_SecurityThroughObscurity(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_04_SecurityThroughObscurity));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}