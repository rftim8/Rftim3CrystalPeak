using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _18_BoilingBoulders : I_18_BoilingBoulders
    {
        #region Static
        private readonly List<string>? data;

        public _18_BoilingBoulders()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_18_BoilingBoulders));
        }

        /// <summary>
        /// You and the elephants finally reach fresh air. You've emerged near the base of a large volcano that seems to be actively erupting!
        /// Fortunately, the lava seems to be flowing away from you and toward the ocean.
        /// 
        /// Bits of lava are still being ejected toward you, so you're sheltering in the cavern exit a little longer. 
        /// Outside the cave, you can see the lava landing in a pond and hear it loudly hissing as it solidifies.
        /// 
        /// Depending on the specific compounds in the lava and speed at which it cools, it might be forming obsidian!
        /// The cooling rate should be based on the surface area of the lava droplets, so you take a quick scan of a droplet as it flies past you(your puzzle input).
        /// 
        /// Because of how quickly the lava is moving, the scan isn't very good; its resolution is quite low and, as a result, 
        /// it approximates the shape of the lava droplet with 1x1x1 cubes on a 3D grid, each given as its x,y,z position.
        /// 
        /// To approximate the surface area, count the number of sides of each cube that are not immediately connected to another cube.
        /// So, if your scan were only two adjacent cubes like 1,1,1 and 2,1,1, each cube would have a single side covered and five sides exposed, a total surface area of 10 sides.
        /// 
        /// Here's a larger example:
        /// 
        /// 2,2,2
        /// 1,2,2
        /// 3,2,2
        /// 2,1,2
        /// 2,3,2
        /// 2,2,1
        /// 2,2,3
        /// 2,2,4
        /// 2,2,6
        /// 1,2,5
        /// 3,2,5
        /// 2,1,5
        /// 2,3,5
        /// In the above example, after counting up all the sides that aren't connected to another cube, the total surface area is 64.
        /// 
        /// What is the surface area of your scanned lava droplet?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            HashSet<(int X, int Y, int Z)> cubes = input.Select(i =>
            {
                string[] split = i.Split(',');
                return (X: int.Parse(split[0]), Y: int.Parse(split[1]), Z: int.Parse(split[2]));
            }).ToHashSet();

            int sides = 6 * cubes.Count;
            foreach ((int X, int Y, int Z) in cubes)
            {
                if (cubes.Contains((X - 1, Y, Z))) --sides;
                if (cubes.Contains((X + 1, Y, Z))) --sides;
                if (cubes.Contains((X, Y - 1, Z))) --sides;
                if (cubes.Contains((X, Y + 1, Z))) --sides;
                if (cubes.Contains((X, Y, Z - 1))) --sides;
                if (cubes.Contains((X, Y, Z + 1))) --sides;
            }

            return sides;
        }

        /// <summary>
        /// Something seems off about your calculation. 
        /// The cooling rate depends on exterior surface area, but your calculation also included the surface area of air pockets trapped in the lava droplet.
        /// 
        /// Instead, consider only cube sides that could be reached by the water and steam as the lava droplet tumbles into the pond.
        /// The steam will expand to reach as much as possible, completely displacing any air on the outside of the lava droplet but never expanding diagonally.
        /// 
        /// In the larger example above, exactly one cube of air is trapped within the lava droplet(at 2,2,5), so the exterior surface area of the lava droplet is 58.
        /// 
        /// What is the exterior surface area of your scanned lava droplet?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            List<(int X, int Y, int Z)> cubes = input.Select(i =>
            {
                string[] split = i.Split(',');
                return (X: int.Parse(split[0]), Y: int.Parse(split[1]), Z: int.Parse(split[2]));
            }).ToList();

            return BFS();


            int BFS()
            {
                (int X, int Y, int Z) = cubes.OrderBy(c => c.X).First();
                (int X, int Y, int Z) firstSteam = (X: X - 1, Y, Z);
                HashSet<(int X, int Y, int Z)> steam = [(firstSteam.X, firstSteam.Y, firstSteam.Z)];
                HashSet<(int X, int Y, int Z)> newSteam = [(firstSteam.X, firstSteam.Y, firstSteam.Z)];

                while (newSteam.Count != 0)
                {
                    List<(int X, int Y, int Z)> tempNewSteam = [];
                    foreach ((int X, int Y, int Z) steamCube in newSteam)
                    {
                        tempNewSteam.AddRange(ExpandSteam(steamCube));
                    }

                    foreach ((int X, int Y, int Z) t in tempNewSteam)
                    {
                        steam.Add((t.X, t.Y, t.Z));
                    }
                    newSteam = new HashSet<(int X, int Y, int Z)>(tempNewSteam);
                }

                return CountSteamContacts();


                HashSet<(int X, int Y, int Z)> ExpandSteam((int X, int Y, int Z) steamCube)
                {
                    HashSet<(int X, int Y, int Z)> expandedSteam = [];

                    if (!steam.Contains((steamCube.X - 1, steamCube.Y, steamCube.Z)) &&
                        !cubes.Contains((steamCube.X - 1, steamCube.Y, steamCube.Z)) &&
                        cubes.Any(c => Adjacent(c, (steamCube.X - 1, steamCube.Y, steamCube.Z)))) expandedSteam.Add((steamCube.X - 1, steamCube.Y, steamCube.Z));

                    if (!steam.Contains((steamCube.X + 1, steamCube.Y, steamCube.Z)) &&
                        !cubes.Contains((steamCube.X + 1, steamCube.Y, steamCube.Z)) &&
                        cubes.Any(c => Adjacent(c, (steamCube.X + 1, steamCube.Y, steamCube.Z)))) expandedSteam.Add((steamCube.X + 1, steamCube.Y, steamCube.Z));

                    if (!steam.Contains((steamCube.X, steamCube.Y - 1, steamCube.Z)) &&
                        !cubes.Contains((steamCube.X, steamCube.Y - 1, steamCube.Z)) &&
                        cubes.Any(c => Adjacent(c, (steamCube.X, steamCube.Y - 1, steamCube.Z)))) expandedSteam.Add((steamCube.X, steamCube.Y - 1, steamCube.Z));

                    if (!steam.Contains((steamCube.X, steamCube.Y + 1, steamCube.Z)) &&
                        !cubes.Contains((steamCube.X, steamCube.Y + 1, steamCube.Z)) &&
                        cubes.Any(c => Adjacent(c, (steamCube.X, steamCube.Y + 1, steamCube.Z)))) expandedSteam.Add((steamCube.X, steamCube.Y + 1, steamCube.Z));

                    if (!steam.Contains((steamCube.X, steamCube.Y, steamCube.Z - 1)) &&
                        !cubes.Contains((steamCube.X, steamCube.Y, steamCube.Z - 1)) &&
                        cubes.Any(c => Adjacent(c, (steamCube.X, steamCube.Y, steamCube.Z - 1)))) expandedSteam.Add((steamCube.X, steamCube.Y, steamCube.Z - 1));

                    if (!steam.Contains((steamCube.X, steamCube.Y, steamCube.Z + 1)) &&
                        !cubes.Contains((steamCube.X, steamCube.Y, steamCube.Z + 1)) &&
                        cubes.Any(c => Adjacent(c, (steamCube.X, steamCube.Y, steamCube.Z + 1)))) expandedSteam.Add((steamCube.X, steamCube.Y, steamCube.Z + 1));

                    return expandedSteam;
                }

                bool Adjacent((int X, int Y, int Z) cube, (int X, int Y, int Z) steamCube)
                {
                    return cube.X >= steamCube.X - 1 &&
                        cube.X <= steamCube.X + 1 &&
                        cube.Y >= steamCube.Y - 1 &&
                        cube.Y <= steamCube.Y + 1 &&
                        cube.Z >= steamCube.Z - 1 &&
                        cube.Z <= steamCube.Z + 1 &&
                        !(cube.X == steamCube.X && cube.Y == steamCube.Y && cube.Z == steamCube.Z);
                }

                int CountSteamContacts()
                {
                    int contacts = 0;
                    foreach ((int X, int Y, int Z) cube in cubes)
                    {
                        if (steam.Contains((cube.X - 1, cube.Y, cube.Z))) ++contacts;
                        if (steam.Contains((cube.X + 1, cube.Y, cube.Z))) ++contacts;
                        if (steam.Contains((cube.X, cube.Y - 1, cube.Z))) ++contacts;
                        if (steam.Contains((cube.X, cube.Y + 1, cube.Z))) ++contacts;
                        if (steam.Contains((cube.X, cube.Y, cube.Z - 1))) ++contacts;
                        if (steam.Contains((cube.X, cube.Y, cube.Z + 1))) ++contacts;
                    }

                    return contacts;
                }
            }
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _18_BoilingBoulders(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_18_BoilingBoulders));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}