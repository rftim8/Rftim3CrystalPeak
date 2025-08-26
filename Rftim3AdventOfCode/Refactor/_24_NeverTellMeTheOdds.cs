using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3AdventOfCode.Refactor;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Diagnostics;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Rftim3AdventOfCode
{
    public partial class _24_NeverTellMeTheOdds : I_24_NeverTellMeTheOdds
    {
        #region Static
        private readonly List<string>? data;

        public _24_NeverTellMeTheOdds()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_24_NeverTellMeTheOdds));
        }

        /// <summary>
        /// It seems like something is going wrong with the snow-making process. 
        /// Instead of forming snow, the water that's been absorbed into the air seems to be forming hail!
        /// 
        /// Maybe there's something you can do to break up the hailstones?
        /// 
        /// Due to strong, probably-magical winds, the hailstones are all flying through the air in perfectly linear trajectories.
        /// You make a note of each hailstone's position and velocity (your puzzle input). For example:
        /// 
        /// 19, 13, 30 @ -2,  1, -2
        /// 18, 19, 22 @ -1, -1, -2
        /// 20, 25, 34 @ -2, -2, -4
        /// 12, 31, 28 @ -1, -2, -1
        /// 20, 19, 15 @  1, -5, -3
        /// Each line of text corresponds to the position and velocity of a single hailstone.
        /// The positions indicate where the hailstones are right now (at time 0). 
        /// The velocities are constant and indicate exactly how far each hailstone will move in one nanosecond.
        /// 
        /// Each line of text uses the format px py pz @ vx vy vz.
        /// For instance, the hailstone specified by 20, 19, 15 @ 1, -5, -3 has initial X position 20, Y position 19, Z position 15,
        /// X velocity 1, Y velocity -5, and Z velocity -3. After one nanosecond, the hailstone would be at 21, 14, 12.
        /// 
        /// Perhaps you won't have to do anything.
        /// How likely are the hailstones to collide with each other and smash into tiny ice crystals?
        /// 
        /// To estimate this, consider only the X and Y axes; ignore the Z axis.
        /// Looking forward in time, how many of the hailstones' paths will intersect within a test area? 
        /// (The hailstones themselves don't have to collide, just test for intersections between the paths they will trace.)
        /// 
        /// In this example, look for intersections that happen with an X and Y position each at least 7 and at most 27; 
        /// in your actual data, you'll need to check a much larger test area. 
        /// Comparing all pairs of hailstones' future paths produces the following results:
        /// 
        /// Hailstone A: 19, 13, 30 @ -2, 1, -2
        /// Hailstone B: 18, 19, 22 @ -1, -1, -2
        /// Hailstones' paths will cross inside the test area (at x=14.333, y=15.333).
        /// 
        /// Hailstone A: 19, 13, 30 @ -2, 1, -2
        /// Hailstone B: 20, 25, 34 @ -2, -2, -4
        /// Hailstones' paths will cross inside the test area (at x=11.667, y=16.667).
        /// 
        /// Hailstone A: 19, 13, 30 @ -2, 1, -2
        /// Hailstone B: 12, 31, 28 @ -1, -2, -1
        /// Hailstones' paths will cross outside the test area (at x=6.2, y=19.4).
        /// 
        /// Hailstone A: 19, 13, 30 @ -2, 1, -2
        /// Hailstone B: 20, 19, 15 @ 1, -5, -3
        /// Hailstones' paths crossed in the past for hailstone A.
        /// 
        /// Hailstone A: 18, 19, 22 @ -1, -1, -2
        /// Hailstone B: 20, 25, 34 @ -2, -2, -4
        /// Hailstones' paths are parallel; they never intersect.
        /// 
        /// Hailstone A: 18, 19, 22 @ -1, -1, -2
        /// Hailstone B: 12, 31, 28 @ -1, -2, -1
        /// Hailstones' paths will cross outside the test area (at x=-6, y=-5).
        /// 
        /// Hailstone A: 18, 19, 22 @ -1, -1, -2
        /// Hailstone B: 20, 19, 15 @ 1, -5, -3
        /// Hailstones' paths crossed in the past for both hailstones.
        /// 
        /// Hailstone A: 20, 25, 34 @ -2, -2, -4
        /// Hailstone B: 12, 31, 28 @ -1, -2, -1
        /// Hailstones' paths will cross outside the test area (at x=-2, y=3).
        /// 
        /// Hailstone A: 20, 25, 34 @ -2, -2, -4
        /// Hailstone B: 20, 19, 15 @ 1, -5, -3
        /// Hailstones' paths crossed in the past for hailstone B.
        /// 
        /// Hailstone A: 12, 31, 28 @ -1, -2, -1
        /// Hailstone B: 20, 19, 15 @ 1, -5, -3
        /// Hailstones' paths crossed in the past for both hailstones.
        /// So, in this example, 2 hailstones' future paths cross inside the boundaries of the test area.
        /// 
        /// However, you'll need to search a much larger test area if you want to see if any hailstones might collide.
        /// Look for intersections that happen with an X and Y position each at least 200000000000000 and at most 400000000000000. 
        /// Disregard the Z axis entirely.
        /// 
        /// Considering only the X and Y axes, check all pairs of hailstones' future paths for intersections. 
        /// How many of these intersections occur within the test area?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            Particle[] particles = ParseParticles(string.Join("\n", input));
            long areaBegin = 200000000000000;
            long areaEnd = 400000000000000;
            int res = 0;
            for (int i = 0; i < particles.Length; i++)
            {
                for (int j = i + 1; j < particles.Length; j++)
                {
                    Vec2? mp = MeetPoint(particles[i], particles[j]);

                    if (mp == null) continue;
                    if (areaBegin > mp.X || mp.X > areaEnd) continue;
                    if (areaBegin > mp.Y || mp.Y > areaEnd) continue;
                    if (Past(particles[i], mp)) continue;
                    if (Past(particles[j], mp)) continue;
                    res++;
                }
            }

            return res;
        }

        /// <summary>
        /// Upon further analysis, it doesn't seem like any hailstones will naturally collide. It's up to you to fix that!
        /// 
        /// You find a rock on the ground nearby.
        /// While it seems extremely unlikely, if you throw it just right, you should be able to hit every hailstone in a single throw!
        /// 
        /// You can use the probably-magical winds to reach any integer position you like and to propel the rock at any integer velocity. 
        /// Now including the Z axis in your calculations, if you throw the rock at time 0, 
        /// where do you need to be so that the rock perfectly collides with every hailstone? 
        /// Due to probably-magical inertia, the rock won't slow down or change direction when it collides with a hailstone.
        /// 
        /// In the example above, you can achieve this by moving to position 24, 13, 10 and throwing the rock at velocity -3, 1, 2. 
        /// If you do this, you will hit every hailstone as follows:
        /// 
        /// Hailstone: 19, 13, 30 @ -2, 1, -2
        /// Collision time: 5
        /// Collision position: 9, 18, 20
        /// 
        /// Hailstone: 18, 19, 22 @ -1, -1, -2
        /// Collision time: 3
        /// Collision position: 15, 16, 16
        /// 
        /// Hailstone: 20, 25, 34 @ -2, -2, -4
        /// Collision time: 4
        /// Collision position: 12, 17, 18
        /// 
        /// Hailstone: 12, 31, 28 @ -1, -2, -1
        /// Collision time: 6
        /// Collision position: 6, 19, 22
        /// 
        /// Hailstone: 20, 19, 15 @ 1, -5, -3
        /// Collision time: 1
        /// Collision position: 21, 14, 12
        /// Above, each hailstone is identified by its initial position and its velocity. 
        /// Then, the time and position of that hailstone's collision with your rock are given.
        /// 
        /// After 1 nanosecond, the rock has exactly the same position as one of the hailstones, obliterating it into ice dust! 
        /// Another hailstone is smashed to bits two nanoseconds after that.
        /// After a total of 6 nanoseconds, all of the hailstones have been destroyed.
        /// 
        /// So, at time 0, the rock needs to be at X position 24, Y position 13, and Z position 10. 
        /// Adding these three coordinates together produces 47. (Don't add any coordinates from the rock's velocity.)
        /// 
        /// Determine the exact position and velocity the rock needs to have at time 0 so that it perfectly collides with every hailstone.
        /// What do you get if you add up the X, Y, and Z coordinates of that initial position?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            return MagicRockPosition(ParseHailstones([.. input]));
        }

        private record Particle(Vec2 Pos, Vec2 Vel);

        public record Vec2(decimal X, decimal Y) { }

        private record Mat2(decimal A, decimal B, decimal C, decimal D)
        {
            public decimal Det => A * D - B * C;
            public Mat2 Inv()
            {
                decimal det = Det;

                return new Mat2(D / det, -B / det, -C / det, A / det);
            }

            public static Mat2 operator *(Mat2 m1, Mat2 m2)
            {
                return new Mat2(
                    m1.A * m2.A + m1.B * m2.C,
                    m1.A * m2.B + m1.B * m2.D,
                    m1.B * m2.A + m1.D * m2.C,
                    m1.B * m2.B + m1.D * m2.D
                );
            }

            public static Vec2 operator *(Mat2 m1, Vec2 v)
            {
                return new Vec2(
                    m1.A * v.X + m1.B * v.Y,
                    m1.C * v.X + m1.D * v.Y
                );
            }
        }

        private record Hailstone((long X, long Y, long Z) P, (long X, long Y, long Z) V)
        {
            private Hailstone VOffsetXY(long dvy, long dvx) => new(P, (V.X + dvx, V.Y + dvy, V.Z));

            public bool IntersectsXY(Hailstone other, long min, long max)
            {
                (bool intersects, double x, double y, double _) = IntersectsXY(other);

                if (!intersects) return false;

                return x >= min && x <= max && y >= min && y <= max;
            }

            public double InterpolateZ(double t, long dvz) => Round(P.Z + t * (V.Z + dvz));

            private (bool, double x, double y, double t) IntersectsXY(Hailstone other)
            {
                if (V.X == 0) return (false, 0, 0, -1);
                decimal dydx = V.Y / (decimal)V.X;
                decimal c = P.Y - dydx * P.X;

                if (other.V.X == 0) return (false, 0, 0, -1);
                decimal hdydx = other.V.Y / (decimal)other.V.X;
                decimal hc = other.P.Y - hdydx * other.P.X;

                if (dydx == hdydx) return (false, 0, 0, -1);

                decimal x = (hc - c) / (dydx - hdydx);
                decimal t1 = (x - P.X) / V.X;
                decimal t2 = (x - other.P.X) / other.V.X;

                if (t1 < 0 || t2 < 0) return (false, 0, 0, -1);

                decimal y = dydx * (x - P.X) + P.Y;

                return (true, Round((double)x), Round((double)y), (double)t1);
            }

            public (bool intersects, double x, double y, double t) IsIntersectionXY(Hailstone other, long dvy, long dvx)
                => other.VOffsetXY(dvy, dvx).IntersectsXY(VOffsetXY(dvy, dvx));

            static private double Round(double d) => Math.Round(d, 3);
        }

        private static long MagicRockPosition(Hailstone[] hailstones)
        {
            (Hailstone hs0, Hailstone hs1, Hailstone hs2, Hailstone hs3) = (hailstones[0], hailstones[1], hailstones[^2], hailstones[^1]);

            foreach (int y in SearchSpace())
            {
                foreach (int x in SearchSpace())
                {
                    (bool intersects, double x, double y, double t) i1 = hs0.IsIntersectionXY(hs1, y, x); if (!i1.intersects) continue;
                    (bool intersects, double x, double y, double t) i2 = hs0.IsIntersectionXY(hs2, y, x); if (!i2.intersects) continue;
                    (bool intersects, double x, double y, double t) i3 = hs0.IsIntersectionXY(hs3, y, x); if (!i3.intersects) continue;

                    if ((i1.y, i1.x) != (i2.y, i2.x) || (i1.y, i1.x) != (i3.y, i3.x)) continue;

                    foreach (int z in SearchSpace())
                    {
                        double z1 = hs1.InterpolateZ(i1.t, z);
                        double z2 = hs2.InterpolateZ(i2.t, z);
                        if (z1 != z2) continue;
                        double z3 = hs3.InterpolateZ(i3.t, z);
                        if (z1 != z3) continue;

                        return (long)(i1.x + i1.y + z1);
                    }
                }
            }

            throw new UnreachableException();

            static IEnumerable<int> SearchSpace() => Enumerable.Range(-300, 600);
        }

        private static int CountIntersectionsXY(Hailstone[] hailstones, long min, long max)
            => hailstones
                .SelectMany((h1, i) => hailstones.Skip(i + 1), (h1, h2) => new { h1, h2 })
                .Count(pair => pair.h1.IntersectsXY(pair.h2, min, max));

        private static Hailstone[] ParseHailstones(string[] lines) => [.. lines.Select(ParseHailstone)];

        private static Hailstone ParseHailstone(string line)
        {
            string[] parts = line.Split(" @ ");
            List<long> position = parts[0].Split(", ").Select(long.Parse).ToList();
            List<long> velocity = parts[1].Split(", ").Select(long.Parse).ToList();

            return new Hailstone((position[0], position[1], position[2]), (velocity[0], velocity[1], velocity[2]));
        }

        private static bool Past(Particle p, Vec2 v)
        {
            if (p.Vel.X == 0) return true;

            return (v.X - p.Pos.X) / p.Vel.X < 0;
        }

        private static Vec2? MeetPoint(Particle p1, Particle p2)
        {
            Mat2 m1 = new(
                p1.Vel.Y, -p1.Vel.X,
                p2.Vel.Y, -p2.Vel.X
            );

            decimal det = m1.Det;
            if (det == 0) return null;

            Vec2 v = new(
                p1.Vel.Y * p1.Pos.X - p1.Vel.X * p1.Pos.Y,
                p2.Vel.Y * p2.Pos.X - p2.Vel.X * p2.Pos.Y
            );

            return m1.Inv() * v;
        }

        private static Particle[] ParseParticles(string input) => (
            from line in input.Split('\n')
            let v = MyRegex().Matches(line).Select(m => decimal.Parse(m.Value)).ToArray()
            select new Particle(new Vec2(v[0], v[1]), new Vec2(v[3], v[4]))
        ).ToArray();

        private static BigInteger ModInv(BigInteger a, BigInteger m) => BigInteger.ModPow(a, m - 2, m);
        [GeneratedRegex(@"-?\d+")]
        private static partial Regex MyRegex();
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _24_NeverTellMeTheOdds(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_24_NeverTellMeTheOdds));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}