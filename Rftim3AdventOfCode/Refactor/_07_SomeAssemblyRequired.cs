using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _07_SomeAssemblyRequired : I_07_SomeAssemblyRequired
    {
        #region Static
        private readonly List<string>? data;

        public _07_SomeAssemblyRequired()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_07_SomeAssemblyRequired));
        }

        /// <summary>
        /// This year, Santa brought little Bobby Tables a set of wires and bitwise logic gates! Unfortunately, 
        /// little Bobby is a little under the recommended age range, and he needs help assembling the circuit.
        /// Each wire has an identifier(some lowercase letters) and can carry a 16-bit signal(a number from 0 to 65535). 
        /// A signal is provided to each wire by a gate, another wire, or some specific value.
        /// Each wire can only get a signal from one source, but can provide its signal to multiple destinations.
        /// A gate provides no signal until all of its inputs have a signal.
        /// The included instructions booklet describes how to connect the parts together: x AND y -> z means to connect wires x and y to an AND gate,
        /// and then connect its output to wire z.
        /// 
        /// For example:
        /// 
        /// 123 -> x means that the signal 123 is provided to wire x.
        /// x AND y -> z means that the bitwise AND of wire x and wire y is provided to wire z.
        /// p LSHIFT 2 -> q means that the value from wire p is left-shifted by 2 and then provided to wire q.
        /// NOT e -> f means that the bitwise complement of the value from wire e is provided to wire f.
        /// 
        /// Other possible gates include OR (bitwise OR) and RSHIFT (right-shift). If, for some reason, you'd like to emulate the circuit instead, 
        /// almost all programming languages(for example, C, JavaScript, or Python) provide operators for these gates.
        /// 
        /// For example, here is a simple circuit:
        /// 
        /// 123 -> x
        /// 456 -> y
        /// x AND y -> d
        /// x OR y -> e
        /// x LSHIFT 2 -> f
        /// y RSHIFT 2 -> g
        /// NOT x -> h
        /// NOT y -> i
        /// 
        /// After it is run, these are the signals on the wires:
        /// 
        /// d: 72
        /// e: 507
        /// f: 492
        /// g: 114
        /// h: 65412
        /// i: 65079
        /// x: 123
        /// y: 456
        /// 
        /// In little Bobby's kit's instructions booklet (provided as your puzzle input), what signal is ultimately provided to wire a?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;
            List<Wire> wires = [];

            while (input.Count != 0)
            {
                Console.WriteLine(input.Count);
                for (int i = 0; i < input.Count; i++)
                {
                    int n = input[i].Split(' ').Length;

                    switch (n)
                    {
                        case 3:
                            #region Value -> Wire
                            if (int.TryParse(input[i].Split(' ')[0], out int value))
                            {
                                string name = input[i].Split(' ')[2];

                                if (wires.Where(o => o.name == name).Any())
                                {
                                    foreach (Wire m in wires)
                                    {
                                        if (m.name == name) m.value = value;
                                    }
                                }
                                else wires.Add(new Wire(name, value));

                                ReplaceFound(input, name, value);

                                input.RemoveAt(i);
                                i--;
                            }
                            #endregion
                            break;
                        case 4:
                            #region NOT Value -> Wire
                            string name2 = input[i].Split(' ')[3];
                            if (input[i].Split(' ')[0] == "NOT" && int.TryParse(input[i].Split(' ')[1], out int value3))
                            {
                                if (wires.Where(o => o.name == name2).Any())
                                {
                                    foreach (Wire m in wires)
                                    {
                                        if (m.name == name2) m.value = ushort.MaxValue + ~value3 + 1;
                                    }
                                }
                                else wires.Add(new Wire(name2, ushort.MaxValue + ~value3 + 1));

                                ReplaceFound(input, name2, ushort.MaxValue + ~value3 + 1);

                                input.RemoveAt(i);
                                i--;
                            }
                            #endregion
                            break;
                        case 5:
                            #region Value Op Value -> Wire
                            string value1 = input[i].Split(' ')[0];
                            string op = input[i].Split(' ')[1];
                            string value2 = input[i].Split(' ')[2];
                            string name1 = input[i].Split(' ')[4];
                            if (int.TryParse(value1, out int value1i) && int.TryParse(value2, out int value2i))
                            {
                                if (wires.Where(o => o.name == name1).Any())
                                {
                                    foreach (Wire m in wires)
                                    {
                                        if (m.name == name1) m.value = Op(op, value1i, value2i);
                                    }
                                }
                                else wires.Add(new Wire(name1, Op(op, value1i, value2i)));

                                ReplaceFound(input, name1, Op(op, value1i, value2i));

                                input.RemoveAt(i);
                                i--;
                            }
                            #endregion
                            break;
                        default:
                            break;
                    }
                }
            }

            foreach (Wire item in wires)
            {
                Console.WriteLine($"{item.name}: {item.value}");
            }

            return r;
        }

        /// <summary>
        /// Now, take the signal you got on wire a, override wire b to that signal, and reset the other wires (including wire a). 
        /// 
        /// What new signal is ultimately provided to wire a?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == "14146 -> b") input[i] = "956 -> b";
            }
            List<Wire> wires = [];

            while (input.Count != 0)
            {
                Console.WriteLine(input.Count);
                for (int i = 0; i < input.Count; i++)
                {
                    int n = input[i].Split(' ').Length;

                    switch (n)
                    {
                        case 3:
                            #region Value -> Wire
                            if (int.TryParse(input[i].Split(' ')[0], out int value))
                            {
                                string name = input[i].Split(' ')[2];

                                if (wires.Where(o => o.name == name).Any())
                                {
                                    foreach (Wire m in wires)
                                    {
                                        if (m.name == name) m.value = value;
                                    }
                                }
                                else wires.Add(new Wire(name, value));

                                ReplaceFound(input, name, value);

                                input.RemoveAt(i);
                                i--;
                            }
                            #endregion
                            break;
                        case 4:
                            #region NOT Value -> Wire
                            string name2 = input[i].Split(' ')[3];
                            if (input[i].Split(" ")[0] == "NOT" && int.TryParse(input[i].Split(' ')[1], out int value3))
                            {
                                if (wires.Where(o => o.name == name2).Any())
                                {
                                    foreach (Wire m in wires)
                                    {
                                        if (m.name == name2) m.value = ushort.MaxValue + ~value3 + 1;
                                    }
                                }
                                else wires.Add(new Wire(name2, ushort.MaxValue + ~value3 + 1));

                                ReplaceFound(input, name2, ushort.MaxValue + ~value3 + 1);

                                input.RemoveAt(i);
                                i--;
                            }
                            #endregion
                            break;
                        case 5:
                            #region Value Op Value -> Wire
                            string value1 = input[i].Split(' ')[0];
                            string op = input[i].Split(' ')[1];
                            string value2 = input[i].Split(' ')[2];
                            string name1 = input[i].Split(' ')[4];
                            if (int.TryParse(value1, out int value1i) && int.TryParse(value2, out int value2i))
                            {
                                if (wires.Where(o => o.name == name1).Any())
                                {
                                    foreach (Wire m in wires)
                                    {
                                        if (m.name == name1) m.value = Op(op, value1i, value2i);
                                    }
                                }
                                else wires.Add(new Wire(name1, Op(op, value1i, value2i)));

                                ReplaceFound(input, name1, Op(op, value1i, value2i));

                                input.RemoveAt(i);
                                i--;
                            }
                            #endregion
                            break;
                        default:
                            break;
                    }
                }
            }

            foreach (Wire item in wires)
            {
                Console.WriteLine($"{item.name}: {item.value}");
            }

            return r;
        }

        private static int Op(string op, int x, int y)
        {
            return op switch
            {
                "AND" => x & y,
                "OR" => x | y,
                "LSHIFT" => x << y,
                "RSHIFT" => x >> y,
                _ => 0,
            };
        }

        private static void ReplaceFound(List<string> x, string name, int value)
        {
            for (int j = 0; j < x.Count; j++)
            {
                List<string> q = [.. x[j].Split(' ')];

                if (q.Contains(name)) x[j] = x[j].Replace(name, value.ToString());
            }
        }

        private class Wire(string name, int value)
        {
            public string name = name;
            public int value = value;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _07_SomeAssemblyRequired(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_07_SomeAssemblyRequired));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}