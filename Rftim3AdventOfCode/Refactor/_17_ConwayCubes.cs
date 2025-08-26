using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Collections.Immutable;

namespace Rftim3AdventOfCode.Refactor
{
    public class _17_ConwayCubes : I_17_ConwayCubes
    {
        #region Static
        private readonly List<string>? data;

        public _17_ConwayCubes()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_17_ConwayCubes));
        }

        /// <summary>
        /// As your flight slowly drifts through the sky, the Elves at the Mythical Information Bureau at the North Pole contact you. 
        /// They'd like some help debugging a malfunctioning experimental energy source aboard one of their super-secret imaging satellites.
        /// 
        /// The experimental energy source is based on cutting-edge technology: a set of Conway Cubes contained in a pocket dimension! 
        /// When you hear it's having problems, you can't help but agree to take a look.
        /// 
        /// The pocket dimension contains an infinite 3-dimensional grid. At every integer 3-dimensional coordinate (x, y, z), 
        /// there exists a single cube which is either active or inactive.
        /// 
        /// In the initial state of the pocket dimension, almost all cubes start inactive.
        /// The only exception to this is a small flat region of cubes (your puzzle input); the cubes in this region start in the specified active(#) or inactive (.) state.
        /// 
        /// The energy source then proceeds to boot up by executing six cycles.
        /// 
        /// Each cube only ever considers its neighbors: any of the 26 other cubes where any of their coordinates differ by at most 1. 
        /// For example, given the cube at x= 1, y= 2, z= 3, its neighbors include the cube at x= 2, y= 2, z= 2, the cube at x = 0, y= 2, z= 3, and so on.
        /// 
        /// During a cycle, all cubes simultaneously change their state according to the following rules:
        /// 
        /// If a cube is active and exactly 2 or 3 of its neighbors are also active, the cube remains active. Otherwise, the cube becomes inactive.
        /// If a cube is inactive but exactly 3 of its neighbors are active, the cube becomes active. Otherwise, the cube remains inactive.
        /// The engineers responsible for this experimental energy source would like you to simulate the pocket dimension and determine
        /// what the configuration of cubes should be at the end of the six-cycle boot process.
        /// 
        ///         For example, consider the following initial state:
        /// 
        /// .#.
        /// ..#
        /// ###
        /// Even though the pocket dimension is 3-dimensional, this initial state represents a small 2-dimensional slice of it.
        /// (In particular, this initial state defines a 3x3x1 region of the 3-dimensional space.)
        /// 
        /// Simulating a few cycles from this initial state produces the following configurations,
        /// where the result of each cycle is shown layer-by-layer at each given z coordinate (and the frame of view follows the active cells in each cycle):
        /// 
        /// Before any cycles:
        /// 
        /// z=0
        /// .#.
        /// ..#
        /// ###
        /// 
        /// 
        /// After 1 cycle:
        /// 
        /// z=-1
        /// #..
        /// ..#
        /// .#.
        /// 
        /// z=0
        /// #.#
        /// .##
        /// .#.
        /// 
        /// z=1
        /// #..
        /// ..#
        /// .#.
        /// 
        /// 
        /// After 2 cycles:
        /// 
        /// z=-2
        /// .....
        /// .....
        /// ..#..
        /// .....
        /// .....
        /// 
        /// z=-1
        /// ..#..
        /// .#..#
        /// ....#
        /// .#...
        /// .....
        /// 
        /// z=0
        /// ##...
        /// ##...
        /// #....
        /// ....#
        /// .###.
        /// 
        /// z=1
        /// ..#..
        /// .#..#
        /// ....#
        /// .#...
        /// .....
        /// 
        /// z=2
        /// .....
        /// .....
        /// ..#..
        /// .....
        /// .....
        /// 
        /// 
        /// After 3 cycles:
        /// 
        /// z=-2
        /// .......
        /// .......
        /// ..##...
        /// ..###..
        /// .......
        /// .......
        /// .......
        /// 
        /// z=-1
        /// ..#....
        /// ...#...
        /// #......
        /// .....##
        /// .#...#.
        /// ..#.#..
        /// ...#...
        /// 
        /// z=0
        /// ...#...
        /// .......
        /// #......
        /// .......
        /// .....##
        /// .##.#..
        /// ...#...
        /// 
        /// z=1
        /// ..#....
        /// ...#...
        /// #......
        /// .....##
        /// .#...#.
        /// ..#.#..
        /// ...#...
        /// 
        /// z=2
        /// .......
        /// .......
        /// ..##...
        /// ..###..
        /// .......
        /// .......
        /// .......
        /// After the full six-cycle boot process completes, 112 cubes are left in the active state.
        /// 
        /// Starting with your given initial configuration, simulate six cycles. How many cubes are left in the active state after the sixth cycle?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            IEnumerable<(int x, int y, int z, int w)> inputSlice = input.SelectMany((l, x) =>
                l.Select((c, y) => (c, y))
                 .Where(ay => ay.c == '#')
            .Select(ay => (x, ay.y, z: 0, w: 0))
            );

            return Solve(inputSlice, 6, false);
        }

        /// <summary>
        /// For some reason, your simulated results don't match what the experimental energy source engineers expected. 
        /// Apparently, the pocket dimension actually has four spatial dimensions, not three.
        /// 
        /// The pocket dimension contains an infinite 4-dimensional grid.At every integer 4-dimensional coordinate (x, y, z, w), 
        /// there exists a single cube (really, a hypercube) which is still either active or inactive.
        /// Each cube only ever considers its neighbors: any of the 80 other cubes where any of their coordinates differ by at most 1. 
        /// For example, given the cube at x= 1, y= 2, z= 3, w= 4, its neighbors include the cube at x= 2, y= 2, z= 3, w= 3, the cube at x = 0, y= 2, z= 3, w= 4, and so on.
        /// The initial state of the pocket dimension still consists of a small flat region of cubes. 
        /// Furthermore, the same rules for cycle updating still apply: during each cycle, consider the number of active neighbors of each cube.
        /// 
        /// For example, consider the same initial state as in the example above.
        /// Even though the pocket dimension is 4-dimensional, this initial state represents a small 2-dimensional slice of it. 
        /// (In particular, this initial state defines a 3x3x1x1 region of the 4-dimensional space.)
        /// 
        /// Simulating a few cycles from this initial state produces the following configurations, 
        /// where the result of each cycle is shown layer-by-layer at each given z and w coordinate:
        /// 
        /// Before any cycles:
        /// 
        /// z= 0, w= 0
        /// .#.
        /// ..#
        /// ###
        /// 
        /// 
        /// After 1 cycle:
        /// 
        /// z= -1, w= -1
        /// #..
        /// ..#
        /// .#.
        /// 
        /// z= 0, w= -1
        /// #..
        /// ..#
        /// .#.
        /// 
        /// z= 1, w= -1
        /// #..
        /// ..#
        /// .#.
        /// 
        /// z= -1, w= 0
        /// #..
        /// ..#
        /// .#.
        /// 
        /// z= 0, w= 0
        /// #.#
        /// .##
        /// .#.
        /// 
        /// z = 1, w= 0
        /// #..
        /// ..#
        /// .#.
        /// 
        /// z= -1, w= 1
        /// #..
        /// ..#
        /// .#.
        /// 
        /// z= 0, w= 1
        /// #..
        /// ..#
        /// .#.
        /// 
        /// z= 1, w= 1
        /// #..
        /// ..#
        /// .#.
        /// 
        /// 
        /// After 2 cycles:
        /// 
        /// z= -2, w= -2.....
        /// .....
        /// ..#..
        /// .....
        /// .....
        /// 
        /// z= -1, w= -2.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= 0, w= -2
        /// ###..
        /// ##.##
        /// #...#
        /// .#..#
        /// .###.
        /// 
        /// z = 1, w= -2.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= 2, w= -2.....
        /// .....
        /// ..#..
        /// .....
        /// .....
        /// 
        /// z= -2, w= -1.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= -1, w= -1.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= 0, w= -1.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= 1, w= -1.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= 2, w= -1.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= -2, w= 0
        /// ###..
        /// ##.##
        /// #...#
        /// .#..#
        /// .###.
        /// 
        /// z = -1, w= 0.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= 0, w= 0.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= 1, w= 0.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= 2, w= 0
        /// ###..
        /// ##.##
        /// #...#
        /// .#..#
        /// .###.
        /// 
        /// z = -2, w= 1.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= -1, w= 1.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= 0, w= 1.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= 1, w= 1.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= 2, w= 1.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= -2, w= 2.....
        /// .....
        /// ..#..
        /// .....
        /// .....
        /// 
        /// z= -1, w= 2.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= 0, w= 2
        /// ###..
        /// ##.##
        /// #...#
        /// .#..#
        /// .###.
        /// 
        /// z = 1, w= 2.....
        /// .....
        /// .....
        /// .....
        /// .....
        /// 
        /// z= 2, w= 2.....
        /// .....
        /// ..#..
        /// .....
        /// .....
        /// After the full six-cycle boot process completes, 848 cubes are left in the active state.
        /// 
        /// Starting with your given initial configuration, simulate six cycles in a 4-dimensional space. 
        /// How many cubes are left in the active state after the sixth cycle?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            IEnumerable<(int x, int y, int z, int w)> inputSlice = input.SelectMany((l, x) =>
                 l.Select((c, y) => (c, y))
                  .Where(ay => ay.c == '#')
                  .Select(ay => (x, ay.y, z: 0, w: 0))
             );

            return Solve(inputSlice, 6, true);
        }

        private static int Solve(IEnumerable<(int, int, int, int)> input, int iterations = 6, bool theFourthDimension = false)
        {
            ImmutableList<(int x, int y, int z, int w)> neighbors = Enumerable
                .Range(-1, 3)
                .SelectMany(x => Enumerable.Range(-1, 3)
                    .SelectMany(y => Enumerable.Range(-1, 3)
                        .SelectMany(z => Enumerable.Range(-1, 3)
                            .Select(w => (x, y, z, w))
                        )
                    )
            ).ToImmutableList();
            neighbors = neighbors.Remove((0, 0, 0, 0));

            ImmutableHashSet<(int, int, int, int)> activeHyperCube = input.ToImmutableHashSet();
            int passes = 0;
            while (passes < iterations)
            {
                passes++;

                IEnumerable<int> rangeX = ExpanseRange(0, activeHyperCube);
                IEnumerable<int> rangeY = ExpanseRange(1, activeHyperCube);
                IEnumerable<int> rangeZ = ExpanseRange(2, activeHyperCube);
                IEnumerable<int> rangeW = ExpanseRange(3, activeHyperCube);

                ImmutableHashSet<(int x, int y, int z, int w)> theExpanse = rangeX
                    .SelectMany(x => rangeY
                        .SelectMany(y => rangeZ
                            .SelectMany(z =>
                                theFourthDimension switch
                                {
                                    true => rangeW.Select(w => (x, y, z, w)),
                                    false => [(x, y, z, w: 0)]
                                })
                        )
                    ).ToImmutableHashSet();

                activeHyperCube = theExpanse.AsParallel().Where(expanse =>
                {
                    int nCount = neighbors.Count(nbr => activeHyperCube.Contains(CoordAdd(expanse, nbr)));

                    return activeHyperCube.Contains(expanse) switch
                    {
                        true => nCount >= 2 && nCount <= 3,
                        false => nCount == 3
                    };
                }).ToImmutableHashSet();
            }

            return activeHyperCube.Count;
        }

        private static IEnumerable<int> ExpanseRange(int coordIx, IEnumerable<(int x, int y, int z, int w)> input)
        {
            IEnumerable<int> coordValues = input.Select(i => coordIx switch
            {
                0 => i.x,
                1 => i.y,
                2 => i.z,
                3 => i.w,
                _ => 0
            }).Distinct();

            return Enumerable.Range(coordValues.Min() - 1, coordValues.Max() - coordValues.Min() + 3);
        }

        private static (int x, int y, int z, int w) CoordAdd((int x, int y, int z, int w) a, (int x, int y, int z, int w) b) => (x: a.x + b.x, y: a.y + b.y, z: a.z + b.z, w: a.w + b.w);
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _17_ConwayCubes(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_17_ConwayCubes));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}