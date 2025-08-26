using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Text;

namespace Rftim3AdventOfCode.Refactor
{
    public class _14_DockingData : I_14_DockingData
    {
        #region Static
        private readonly List<string>? data;

        public _14_DockingData()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_14_DockingData));
        }

        /// <summary>
        /// As your ferry approaches the sea port, the captain asks for your help again. 
        /// The computer system that runs this port isn't compatible with the docking program on the ferry, 
        /// so the docking parameters aren't being correctly initialized in the docking program's memory.
        /// 
        /// After a brief inspection, you discover that the sea port's computer system uses a strange bitmask system in its initialization program. 
        /// Although you don't have the correct decoder chip handy, you can emulate it in software!
        /// 
        /// The initialization program(your puzzle input) can either update the bitmask or write a value to memory.
        /// Values and memory addresses are both 36-bit unsigned integers.For example, ignoring bitmasks for a moment, 
        /// a line like mem[8] = 11 would write the value 11 to memory address 8.
        /// 
        /// The bitmask is always given as a string of 36 bits, written with the most significant bit(representing 2^35) on the left
        /// and the least significant bit(2^0, that is, the 1s bit) on the right.The current bitmask is applied to values immediately 
        /// before they are written to memory: a 0 or 1 overwrites the corresponding bit in the value, while an X leaves the bit in the value unchanged.
        /// 
        /// For example, consider the following program:
        /// 
        /// mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
        /// mem[8] = 11
        /// mem[7] = 101
        /// mem[8] = 0
        /// This program starts by specifying a bitmask(mask = ....). 
        /// The mask it specifies will overwrite two bits in every written value: the 2s bit is overwritten with 0, and the 64s bit is overwritten with 1.
        /// 
        /// The program then attempts to write the value 11 to memory address 8. By expanding everything out to individual bits, the mask is applied as follows:
        /// 
        /// value:  000000000000000000000000000000001011  (decimal 11)
        /// mask:   XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
        /// result: 000000000000000000000000000001001001  (decimal 73)
        /// So, because of the mask, the value 73 is written to memory address 8 instead.Then, the program tries to write 101 to address 7:
        /// 
        /// value:  000000000000000000000000000001100101  (decimal 101)
        /// mask:   XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
        /// result: 000000000000000000000000000001100101  (decimal 101)
        /// This time, the mask has no effect, as the bits it overwrote were already the values the mask tried to set.Finally, the program tries to write 0 to address 8:
        /// 
        /// value:  000000000000000000000000000000000000  (decimal 0)
        /// mask:   XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
        /// result: 000000000000000000000000000001000000  (decimal 64)
        /// 64 is written to address 8 instead, overwriting the value that was there previously.
        /// 
        /// To initialize your ferry's docking program, you need the sum of all values left in memory after the initialization program completes.
        /// (The entire 36-bit address space begins initialized to the value 0 at every address.) 
        /// In the above example, only two values in memory are not zero - 101 (at address 7) and 64 (at address 8) - producing a sum of 165.
        /// 
        /// Execute the initialization program.What is the sum of all values left in memory after it completes? (Do not truncate the sum to 36 bits.)
        /// </summary>
        [Benchmark]
        public long PartOne() => PartOne0(data!);

        private static long PartOne0(List<string> input)
        {
            Dictionary<int, long> memory = [];
            Dictionary<long, long> memoryPart2 = [];
            StringBuilder address = new();
            StringBuilder addressToAddTo = new();
            string mask = "", result = "", value = "", addressToUse = "", combo = "";
            long memAdd, finalResult, part1 = 0;
            int memoryLocation, countTo, indexOfBinary, counter = 0;
            string[] memVal;

            foreach (string s in input)
            {
                if (s.Contains("mask")) mask = s[7..];
                else
                {
                    memVal = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    memoryLocation = int.Parse(memVal[0]);
                    value = Convert.ToString(int.Parse(memVal[1]), 2).PadLeft(36, '0');
                    address.Append(Convert.ToString(int.Parse(memVal[0]), 2).PadLeft(36, '0'));
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (mask[i] == 'X')
                        {
                            result += value[i];
                            address[i] = mask[i];
                        }
                        else if (mask[i] == '1')
                        {
                            result += '1';
                            address[i] = mask[i];
                        }
                        else if (mask[i] == '0') result += '0';
                    }
                    addressToUse = address.ToString();
                    address.Clear();
                    combo = "";
                    foreach (char c in addressToUse)
                    {
                        if (c == 'X') combo += '0';
                    }
                    counter = 0;
                    countTo = (int)Math.Pow(2, combo.Length) - 1;
                    while (counter <= countTo)
                    {
                        combo = Convert.ToString(counter, 2).PadLeft(combo.Length, '0');
                        indexOfBinary = 0;
                        for (int i = 0; i < addressToUse.Length; i++)
                        {
                            if (mask[i] == 'X')
                            {
                                addressToAddTo.Append(combo[indexOfBinary]);
                                indexOfBinary++;
                            }
                            else if (mask[i] == '1') addressToAddTo.Append('1');
                            else addressToAddTo.Append(addressToUse[i]);
                        }
                        memAdd = Convert.ToInt64(addressToAddTo.ToString(), 2);
                        addressToAddTo.Clear();
                        if (!memoryPart2.ContainsKey(memAdd)) memoryPart2.Add(memAdd, long.Parse(memVal[1]));
                        else memoryPart2[memAdd] = long.Parse(memVal[1]);

                        counter++;
                    }
                    finalResult = Convert.ToInt64(result, 2);
                    result = "";
                    if (!memory.TryAdd(memoryLocation, finalResult)) memory[memoryLocation] = finalResult;
                }
            }
            part1 = memory.Sum(x => x.Value);

            return part1;
        }

        /// <summary>
        /// For some reason, the sea port's computer system still can't communicate with your ferry's docking program. It must be using version 2 of the decoder chip!
        /// 
        /// A version 2 decoder chip doesn't modify the values being written at all. Instead, it acts as a memory address decoder. 
        /// Immediately before a value is written to memory, each bit in the bitmask modifies the corresponding bit of the destination memory address in the following way:
        /// 
        /// If the bitmask bit is 0, the corresponding memory address bit is unchanged.
        ///         If the bitmask bit is 1, the corresponding memory address bit is overwritten with 1.
        /// If the bitmask bit is X, the corresponding memory address bit is floating.
        /// A floating bit is not connected to anything and instead fluctuates unpredictably.
        /// In practice, this means the floating bits will take on all possible values, potentially causing many memory addresses to be written all at once!
        /// 
        /// For example, consider the following program:
        /// 
        /// mask = 000000000000000000000000000000X1001X
        ///         mem[42] = 100
        /// mask = 00000000000000000000000000000000X0XX
        ///         mem[26] = 1
        /// When this program goes to write to memory address 42, it first applies the bitmask:
        /// 
        /// address: 000000000000000000000000000000101010  (decimal 42)
        /// mask:    000000000000000000000000000000X1001X
        ///         result:  000000000000000000000000000000X1101X
        /// After applying the mask, four bits are overwritten, three of which are different, and two of which are floating.
        /// Floating bits take on every possible combination of values; with two floating bits, four actual memory addresses are written:
        /// 
        /// 000000000000000000000000000000011010  (decimal 26)
        /// 000000000000000000000000000000011011  (decimal 27)
        /// 000000000000000000000000000000111010  (decimal 58)
        /// 000000000000000000000000000000111011  (decimal 59)
        /// Next, the program is about to write to memory address 26 with a different bitmask:
        /// 
        /// address: 000000000000000000000000000000011010  (decimal 26)
        /// mask:    00000000000000000000000000000000X0XX
        /// result:  00000000000000000000000000000001X0XX
        /// This results in an address with three floating bits, causing writes to eight memory addresses:
        /// 
        /// 000000000000000000000000000000010000  (decimal 16)
        /// 000000000000000000000000000000010001  (decimal 17)
        /// 000000000000000000000000000000010010  (decimal 18)
        /// 000000000000000000000000000000010011  (decimal 19)
        /// 000000000000000000000000000000011000  (decimal 24)
        /// 000000000000000000000000000000011001  (decimal 25)
        /// 000000000000000000000000000000011010  (decimal 26)
        /// 000000000000000000000000000000011011  (decimal 27)
        /// The entire 36-bit address space still begins initialized to the value 0 at every address,
        /// and you still need the sum of all values left in memory at the end of the program.In this example, the sum is 208.
        /// 
        /// Execute the initialization program using an emulator for a version 2 decoder chip.What is the sum of all values left in memory after it completes?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            Dictionary<int, long> memory = [];
            Dictionary<long, long> memoryPart2 = [];
            StringBuilder address = new();
            StringBuilder addressToAddTo = new();
            string mask = "", result = "", value = "", addressToUse = "", combo = "";
            long memAdd, finalResult, part2 = 0;
            int memoryLocation, countTo, indexOfBinary, counter = 0;
            string[] memVal;

            foreach (string s in input)
            {
                if (s.Contains("mask")) mask = s[7..];
                else
                {
                    memVal = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    memoryLocation = int.Parse(memVal[0]);
                    value = Convert.ToString(int.Parse(memVal[1]), 2).PadLeft(36, '0');
                    address.Append(Convert.ToString(int.Parse(memVal[0]), 2).PadLeft(36, '0'));
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (mask[i] == 'X')
                        {
                            result += value[i];
                            address[i] = mask[i];
                        }
                        else if (mask[i] == '1')
                        {
                            result += '1';
                            address[i] = mask[i];
                        }
                        else if (mask[i] == '0') result += '0';
                    }
                    addressToUse = address.ToString();
                    address.Clear();
                    combo = "";
                    foreach (char c in addressToUse)
                    {
                        if (c == 'X') combo += '0';
                    }
                    counter = 0;
                    countTo = (int)Math.Pow(2, combo.Length) - 1;
                    while (counter <= countTo)
                    {
                        combo = Convert.ToString(counter, 2).PadLeft(combo.Length, '0');
                        indexOfBinary = 0;
                        for (int i = 0; i < addressToUse.Length; i++)
                        {
                            if (mask[i] == 'X')
                            {
                                addressToAddTo.Append(combo[indexOfBinary]);
                                indexOfBinary++;
                            }
                            else if (mask[i] == '1') addressToAddTo.Append('1');
                            else addressToAddTo.Append(addressToUse[i]);
                        }
                        memAdd = Convert.ToInt64(addressToAddTo.ToString(), 2);
                        addressToAddTo.Clear();
                        if (!memoryPart2.ContainsKey(memAdd)) memoryPart2.Add(memAdd, long.Parse(memVal[1]));
                        else memoryPart2[memAdd] = long.Parse(memVal[1]);

                        counter++;
                    }
                    finalResult = Convert.ToInt64(result, 2);
                    result = "";

                    if (!memory.TryAdd(memoryLocation, finalResult)) memory[memoryLocation] = finalResult;
                }
            }

            part2 = memoryPart2.Sum(x => x.Value);

            return part2;
        }

        private static readonly string[] separator = ["mem[", "] = ",];
        #endregion

        #region UnitTest
        public static long PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _14_DockingData(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_14_DockingData));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}