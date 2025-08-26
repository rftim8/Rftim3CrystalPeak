using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _14_ReindeerOlympics : I_14_ReindeerOlympics
    {
        #region Static
        private readonly List<string>? data;

        public _14_ReindeerOlympics()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_14_ReindeerOlympics));
        }

        /// <summary>
        /// This year is the Reindeer Olympics! Reindeer can fly at high speeds, but must rest occasionally to recover their energy. 
        /// Santa would like to know which of his reindeer is fastest, and so he has them race.
        /// Reindeer can only either be flying (always at their top speed) or resting(not moving at all), and always spend whole seconds in either state.
        /// 
        /// For example, suppose you have the following Reindeer:
        /// 
        /// Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
        /// Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.
        /// After one second, Comet has gone 14 km, while Dancer has gone 16 km.
        /// After ten seconds, Comet has gone 140 km, while Dancer has gone 160 km.
        /// On the eleventh second, Comet begins resting (staying at 140 km), and Dancer continues on for a total distance of 176 km.
        /// On the 12th second, both reindeer are resting.They continue to rest until the 138th second, when Comet flies for another ten seconds.
        /// On the 174th second, Dancer flies for another 11 seconds.
        /// 
        /// In this example, after the 1000th second, both reindeer are resting, and Comet is in the lead at 1120 km(poor Dancer has only gotten 1056 km by that point). 
        /// So, in this situation, Comet would win(if the race ended at 1000 seconds).
        /// 
        /// Given the descriptions of each reindeer(in your puzzle input), after exactly 2503 seconds, what distance has the winning reindeer traveled?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;

            List<Reindeer> reindeers = [];

            foreach (string item in input)
            {
                string name = item.Split(' ')[0];
                int speed = int.Parse(item.Split(' ')[3]);
                int sprint = int.Parse(item.Split(' ')[6]);
                int rest = int.Parse(item.Split(' ')[13]);

                reindeers.Add(new Reindeer(name, true, speed, sprint, sprint, rest, rest, 0, 0));
            }

            for (int i = 0; i < 2503; i++)
            {
                foreach (Reindeer item in reindeers)
                {
                    if (item.running)
                    {
                        if (item.sprint1 > 0)
                        {
                            item.dist += item.speed;
                            item.sprint1--;
                        }
                        else
                        {
                            item.running = false;
                            item.rest1 = item.rest;
                            item.rest1--;
                        }
                    }
                    else
                    {
                        if (item.rest1 > 0) item.rest1--;
                        else
                        {
                            item.running = true;
                            item.sprint1 = item.sprint;
                            item.dist += item.speed;
                            item.sprint1--;
                        }
                    }
                }
            }

            foreach (Reindeer item in reindeers)
            {
                Console.WriteLine($"{item.name}: {item.dist} {item.score}");
            }

            return r;
        }

        /// <summary>
        /// Seeing how reindeer move in bursts, Santa decides he's not pleased with the old scoring system.
        /// Instead, at the end of each second, he awards one point to the reindeer currently in the lead.
        /// (If there are multiple reindeer tied for the lead, they each get one point.)
        /// He keeps the traditional 2503 second time limit, of course, as doing otherwise would be entirely ridiculous.
        /// Given the example reindeer from above, after the first second, Dancer is in the lead and gets one point. 
        /// He stays in the lead until several seconds into Comet's second burst: after the 140th second, Comet pulls into the lead and gets his first point. 
        /// Of course, since Dancer had been in the lead for the 139 seconds before that, he has accumulated 139 points by the 140th second.
        /// After the 1000th second, Dancer has accumulated 689 points, while poor Comet, our old champion, only has 312. 
        /// So, with the new scoring system, Dancer would win(if the race ended at 1000 seconds).
        /// 
        /// Again given the descriptions of each reindeer(in your puzzle input), after exactly 2503 seconds, how many points does the winning reindeer have?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;

            List<Reindeer> reindeers = [];

            foreach (string item in input)
            {
                string name = item.Split(' ')[0];
                int speed = int.Parse(item.Split(' ')[3]);
                int sprint = int.Parse(item.Split(' ')[6]);
                int rest = int.Parse(item.Split(' ')[13]);

                reindeers.Add(new Reindeer(name, true, speed, sprint, sprint, rest, rest, 0, 0));
            }

            for (int i = 0; i < 2503; i++)
            {
                foreach (Reindeer item in reindeers)
                {
                    if (item.running)
                    {
                        if (item.sprint1 > 0)
                        {
                            item.dist += item.speed;
                            item.sprint1--;
                        }
                        else
                        {
                            item.running = false;
                            item.rest1 = item.rest;
                            item.rest1--;
                        }
                    }
                    else
                    {
                        if (item.rest1 > 0)
                        {
                            item.rest1--;
                        }
                        else
                        {
                            item.running = true;
                            item.sprint1 = item.sprint;
                            item.dist += item.speed;
                            item.sprint1--;
                        }
                    }
                }

                int lead = reindeers.Select(o => o.dist).Max();

                foreach (Reindeer item in reindeers)
                {
                    if (item.dist == lead) item.score++;
                }
            }

            foreach (Reindeer item in reindeers)
            {
                Console.WriteLine($"{item.name}: {item.dist} {item.score}");
            }

            return r;
        }

        private class Reindeer(string name, bool running, int speed, int sprint, int sprint1, int rest, int rest1, int dist, int score)
        {
            public string name = name;
            public bool running = running;
            public int speed = speed, sprint = sprint, sprint1 = sprint1, rest = rest, rest1 = rest1, dist = dist, score = score;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _14_ReindeerOlympics(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_14_ReindeerOlympics));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}