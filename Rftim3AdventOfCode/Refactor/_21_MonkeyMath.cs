using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3AdventOfCode.Refactor;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Text.RegularExpressions;

namespace Rftim3AdventOfCode
{
    public partial class _21_MonkeyMath : I_21_MonkeyMath
    {
        #region Static
        private readonly List<string>? data;

        public _21_MonkeyMath()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_21_MonkeyMath));
        }

        /// <summary>
        /// The monkeys are back! You're worried they're going to try to steal your stuff again, 
        /// but it seems like they're just holding their ground and making various monkey noises at you.
        /// 
        /// Eventually, one of the elephants realizes you don't speak monkey and comes over to interpret. 
        /// As it turns out, they overheard you talking about trying to find the grove; they can show you a shortcut if you answer their riddle.
        /// 
        /// Each monkey is given a job: either to yell a specific number or to yell the result of a math operation.
        /// All of the number-yelling monkeys know their number from the start; however, the math operation monkeys need to wait for two other monkeys to yell a number, 
        /// and those two other monkeys might also be waiting on other monkeys.
        ///         Your job is to work out the number the monkey named root will yell before the monkeys figure it out themselves.
        /// 
        /// For example:
        /// 
        /// root: pppw + sjmn
        ///         dbpl: 5
        /// cczh: sllz + lgvd
        ///         zczc: 2
        /// ptdq: humn - dvpt
        /// dvpt: 3
        /// lfqf: 4
        /// humn: 5
        /// ljgn: 2
        /// sjmn: drzm* dbpl
        /// sllz: 4
        /// pppw: cczh / lfqf
        /// lgvd: ljgn* ptdq
        /// drzm: hmdt - zczc
        /// hmdt: 32
        /// Each line contains the name of a monkey, a colon, and then the job of that monkey:
        /// 
        /// A lone number means the monkey's job is simply to yell that number.
        /// A job like aaaa + bbbb means the monkey waits for monkeys aaaa and bbbb to yell each of their numbers; the monkey then yells the sum of those two numbers.
        /// aaaa - bbbb means the monkey yells aaaa's number minus bbbb's number.
        /// Job aaaa * bbbb will yell aaaa's number multiplied by bbbb's number.
        /// Job aaaa / bbbb will yell aaaa's number divided by bbbb's number.
        /// So, in the above example, monkey drzm has to wait for monkeys hmdt and zczc to yell their numbers. 
        /// Fortunately, both hmdt and zczc have jobs that involve simply yelling a single number, so they do this immediately: 32 and 2. 
        /// Monkey drzm can then yell its number by finding 32 minus 2: 30.
        /// 
        /// Then, monkey sjmn has one of its numbers (30, from monkey drzm), and already has its other number, 5, from dbpl.
        /// This allows it to yell its own number by finding 30 multiplied by 5: 150.
        /// 
        /// This process continues until root yells a number: 152.
        /// 
        /// However, your actual situation involves considerably more monkeys.What number will the monkey named root yell?
        /// </summary>
        [Benchmark]
        public long PartOne() => PartOne0(data!);

        private static long PartOne0(List<string> input)
        {
            IMonkey.Monkeys.Clear();
            Regex lineRegex = MyRegex();
            Regex definitionRegex = MyRegex1();
            foreach (string line in input)
            {
                Match lineMatch = lineRegex.Match(line);
                string id = lineMatch.Groups["id"].Value;
                string definition = lineMatch.Groups["definition"].Value;
                if (long.TryParse(definition, out long number)) IMonkey.Monkeys.Add(id, new NumberMonkey(id, number));
                else
                {
                    Match definitionMatch = definitionRegex.Match(definition);
                    switch (definitionMatch.Groups["operator"].Value)
                    {
                        case "+":
                            IMonkey.Monkeys.Add(id, new AdditionMonkey(id, definitionMatch.Groups["othermonkey1id"].Value, definitionMatch.Groups["othermonkey2id"].Value));
                            break;
                        case "-":
                            IMonkey.Monkeys.Add(id, new SubtractionMonkey(id, definitionMatch.Groups["othermonkey1id"].Value, definitionMatch.Groups["othermonkey2id"].Value));
                            break;
                        case "*":
                            IMonkey.Monkeys.Add(id, new MultiplicationMonkey(id, definitionMatch.Groups["othermonkey1id"].Value, definitionMatch.Groups["othermonkey2id"].Value));
                            break;
                        case "/":
                            IMonkey.Monkeys.Add(id, new DivisionMonkey(id, definitionMatch.Groups["othermonkey1id"].Value, definitionMatch.Groups["othermonkey2id"].Value));
                            break;
                        default:
                            break;
                    }
                }
            }

            return IMonkey.Monkeys["root"].GetNumber();
        }

        /// <summary>
        /// Due to some kind of monkey-elephant-human mistranslation, you seem to have misunderstood a few key details about the riddle.
        /// 
        /// First, you got the wrong job for the monkey named root; specifically, you got the wrong math operation.
        /// The correct operation for monkey root should be =, which means that it still listens for two numbers (from the same two monkeys as before), 
        /// but now checks that the two numbers match.
        /// 
        /// Second, you got the wrong monkey for the job starting with humn:. It isn't a monkey - it's you.
        /// Actually, you got the job wrong, too: you need to figure out what number you need to yell so that root's equality check passes. 
        /// (The number that appears after humn: in your input is now irrelevant.)
        /// 
        /// In the above example, the number you need to yell to pass root's equality test is 301. 
        /// (This causes root to get the same number, 150, from both of its monkeys.)
        /// 
        /// What number do you yell to pass root's equality test?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            IMonkey.Monkeys.Clear();
            Regex lineRegex = MyRegex();
            Regex definitionRegex = MyRegex1();
            foreach (string line in input)
            {
                Match lineMatch = lineRegex.Match(line);
                string id = lineMatch.Groups["id"].Value;
                string definition = lineMatch.Groups["definition"].Value;
                if (long.TryParse(definition, out long number)) IMonkey.Monkeys.Add(id, new NumberMonkey(id, number));
                else
                {
                    Match definitionMatch = definitionRegex.Match(definition);
                    switch (definitionMatch.Groups["operator"].Value)
                    {
                        case "+":
                            IMonkey.Monkeys.Add(id, new AdditionMonkey(id, definitionMatch.Groups["othermonkey1id"].Value, definitionMatch.Groups["othermonkey2id"].Value));
                            break;
                        case "-":
                            IMonkey.Monkeys.Add(id, new SubtractionMonkey(id, definitionMatch.Groups["othermonkey1id"].Value, definitionMatch.Groups["othermonkey2id"].Value));
                            break;
                        case "*":
                            IMonkey.Monkeys.Add(id, new MultiplicationMonkey(id, definitionMatch.Groups["othermonkey1id"].Value, definitionMatch.Groups["othermonkey2id"].Value));
                            break;
                        case "/":
                            IMonkey.Monkeys.Add(id, new DivisionMonkey(id, definitionMatch.Groups["othermonkey1id"].Value, definitionMatch.Groups["othermonkey2id"].Value));
                            break;
                        default:
                            break;
                    }
                }
            }

            return IMonkey.Monkeys["root"].GetNumberToYell("humn");
        }

        private interface IMonkey
        {
            public static Dictionary<string, IMonkey> Monkeys { get; } = [];
            string Id { get; }
            long GetNumber();
            bool LinkedTo(string id);
            long GetNumberToYell(string id, long number);
            long GetNumberToYell(string id);
        }

        private class NumberMonkey(string id, long number) : IMonkey
        {
            public string Id { get; set; } = id;
            public long Number { get; set; } = number;

            public long GetNumber() => Number;

            public bool LinkedTo(string id) => id == Id;

            public long GetNumberToYell(string id) => throw new InvalidOperationException("Should never be called");

            public long GetNumberToYell(string id, long number) => id == Id ? number : throw new ArgumentException("Numbermonkeys can only respond to this if you adress them with their Id");
        }

        private abstract class BaseOperationMonkey(string id, string otherMonkey1Id, string otherMonkey2Id) : IMonkey
        {
            public string Id { get; set; } = id;
            public string OtherMonkey1Id { get; set; } = otherMonkey1Id;
            public string OtherMonkey2Id { get; set; } = otherMonkey2Id;
            public IMonkey OtherMonkey1 => IMonkey.Monkeys[OtherMonkey1Id];
            public IMonkey OtherMonkey2 => IMonkey.Monkeys[OtherMonkey2Id];

            public bool LinkedTo(string id) => OtherMonkey1.LinkedTo(id) || OtherMonkey2.LinkedTo(id);

            public abstract long GetNumber();
            public abstract long DetermineNumberForMonkey1(long requiredResult);
            public abstract long DetermineNumberForMonkey2(long requiredResult);

            public long GetNumberToYell(string id, long number)
            {
                if (id == Id) return number;
                if (OtherMonkey1.LinkedTo(id)) return OtherMonkey1.GetNumberToYell(id, DetermineNumberForMonkey1(number));
                else return OtherMonkey2.GetNumberToYell(id, DetermineNumberForMonkey2(number));
            }

            public long GetNumberToYell(string id)
            {
                if (OtherMonkey1.LinkedTo(id))
                {
                    long requiredNumber = OtherMonkey2.GetNumber();

                    return OtherMonkey1.GetNumberToYell(id, requiredNumber);
                }
                else
                {
                    long requiredNumber = OtherMonkey1.GetNumber();

                    return OtherMonkey2.GetNumberToYell(id, requiredNumber);
                }
            }
        }

        private class AdditionMonkey(string id, string otherMonkey1Id, string otherMonkey2Id) : BaseOperationMonkey(id, otherMonkey1Id, otherMonkey2Id)
        {
            private long? _number;
            public override long GetNumber() => _number ??= OtherMonkey1.GetNumber() + OtherMonkey2.GetNumber();

            public override long DetermineNumberForMonkey1(long requiredResult) => requiredResult - OtherMonkey2.GetNumber();

            public override long DetermineNumberForMonkey2(long requiredResult) => requiredResult - OtherMonkey1.GetNumber();
        }

        private class DivisionMonkey(string id, string otherMonkey1Id, string otherMonkey2Id) : BaseOperationMonkey(id, otherMonkey1Id, otherMonkey2Id)
        {
            private long? _number;
            public override long GetNumber() => _number ??= OtherMonkey1.GetNumber() / OtherMonkey2.GetNumber();

            public override long DetermineNumberForMonkey1(long requiredResult) => requiredResult * OtherMonkey2.GetNumber();

            public override long DetermineNumberForMonkey2(long requiredResult) => OtherMonkey1.GetNumber() / requiredResult;
        }

        private class MultiplicationMonkey(string id, string otherMonkey1Id, string otherMonkey2Id) : BaseOperationMonkey(id, otherMonkey1Id, otherMonkey2Id)
        {
            private long? _number;
            public override long GetNumber() => _number ??= OtherMonkey1.GetNumber() * OtherMonkey2.GetNumber();

            public override long DetermineNumberForMonkey1(long requiredResult) => requiredResult / OtherMonkey2.GetNumber();

            public override long DetermineNumberForMonkey2(long requiredResult) => requiredResult / OtherMonkey1.GetNumber();
        }

        private class SubtractionMonkey(string id, string otherMonkey1Id, string otherMonkey2Id) : BaseOperationMonkey(id, otherMonkey1Id, otherMonkey2Id)
        {
            private long? _number;
            public override long GetNumber() => _number ??= OtherMonkey1.GetNumber() - OtherMonkey2.GetNumber();

            public override long DetermineNumberForMonkey1(long requiredResult) => requiredResult + OtherMonkey2.GetNumber();

            public override long DetermineNumberForMonkey2(long requiredResult) => OtherMonkey1.GetNumber() - requiredResult;
        }

        [GeneratedRegex(@"(?<id>[a-z]{4}): (?<definition>(([a-z]{4} . [a-z]{4})|(\d*)))")]
        private static partial Regex MyRegex();
        [GeneratedRegex(@"(?<othermonkey1id>[a-z]{4}) (?<operator>.) (?<othermonkey2id>[a-z]{4})")]
        private static partial Regex MyRegex1();
        #endregion

        #region UnitTest
        public static long PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _21_MonkeyMath(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_21_MonkeyMath));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}