using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _06_SignalsAndNoise : I_06_SignalsAndNoise
    {
        #region Static
        private readonly List<string>? data;

        public _06_SignalsAndNoise()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_06_SignalsAndNoise));
        }

        /// <summary>
        /// Something is jamming your communications with Santa. 
        /// Fortunately, your signal is only partially jammed, and protocol in situations like this is to switch to a simple repetition code to get the message through.
        /// 
        /// In this model, the same message is sent repeatedly. 
        /// You've recorded the repeating message signal (your puzzle input), but the data seems quite corrupted - almost too badly to recover. Almost.
        /// 
        /// All you need to do is figure out which character is most frequent for each position. 
        /// For example, suppose you had recorded the following messages:
        /// 
        /// eedadn
        /// drvtee
        /// eandsr
        /// raavrd
        /// atevrs
        /// tsrnev
        /// sdttsa
        /// rasrtv
        /// nssdts
        /// ntnada
        /// svetve
        /// tesnvt
        /// vntsnd
        /// vrdear
        /// dvrsen
        /// enarar
        /// The most common character in the first column is e; in the second, a; in the third, s, and so on. 
        /// Combining these characters returns the error-corrected message, easter.
        /// 
        /// Given the recording in your puzzle input, what is the error-corrected version of the message being sent?
        /// </summary>
        [Benchmark]
        public string PartOne() => PartOne0(data!);

        private static string PartOne0(List<string> input)
        {
            string r = string.Empty;

            for (int i = 0; i < input[0].Length; i++)
            {
                Dictionary<char, int> kvp = [];
                for (int j = 0; j < input.Count; j++)
                {
                    if (kvp.TryGetValue(input[j][i], out int value)) kvp[input[j][i]] = ++value;
                    else kvp[input[j][i]] = 1;
                }
                r += kvp.MaxBy(o => o.Value).Key;
            }

            return r;
        }

        /// <summary>
        /// Of course, that would be the message - if you hadn't agreed to use a modified repetition code instead.
        /// 
        /// In this modified code, the sender instead transmits what looks like random data, but for each character, 
        /// the character they actually want to send is slightly less likely than the others. Even after signal-jamming noise, 
        /// you can look at the letter distributions in each column and choose the least common letter to reconstruct the original message.
        /// In the above example, the least common character in the first column is a; in the second, d, and so on. 
        /// Repeating this process for the remaining characters produces the original message, advent.
        /// 
        /// Given the recording in your puzzle input and this new decoding methodology, what is the original message that Santa is trying to send?
        /// </summary>        
        [Benchmark]
        public string PartTwo() => PartTwo0(data!);

        private static string PartTwo0(List<string> input)
        {
            string r = string.Empty;

            for (int i = 0; i < input[0].Length; i++)
            {
                Dictionary<char, int> kvp = [];
                for (int j = 0; j < input.Count; j++)
                {
                    if (kvp.TryGetValue(input[j][i], out int value)) kvp[input[j][i]] = ++value;
                    else kvp[input[j][i]] = 1;
                }
                r += kvp.MinBy(o => o.Value).Key;
            }

            return r;
        }
        #endregion

        #region UnitTest
        public static string PartOne_Test(List<string> data) => PartOne0(data);

        public static string PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _06_SignalsAndNoise(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_06_SignalsAndNoise));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}